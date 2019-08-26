using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SiegeApi.Enums;
using SiegeApi.Extensions;
using SiegeApi.Models;
using Newtonsoft.Json.Linq;

namespace SiegeApi
{
    public class Api
    {
        #region Fields

        private static Api _instance;

        #endregion

        #region Properties

        public string Token { get; internal set; }

        public string AppId { get; internal set; }

        public string Ticket { get; internal set; }

        public string RememberMeTicket { get; internal set; }

        #endregion

        #region Constructor

        private Api() { }

        #endregion

        internal static Api Instance
        {
            get
            {
                if (_instance == null)
                    throw new Exception("API instance is null. Must be initialized before use this");

                return _instance;
            }
        }

        public static Api GetInstance(string token, string ticket = null)
        {
            if (_instance == null)
            {
                _instance = new Api
                {
                    Token = token,
                    AppId = "39baebad-39e5-4552-8c25-2c9b919064e2",
                    Ticket = ticket
                };
            }

            return _instance;
        }

        public static Api GetInstance(string email, string password, string ticket = null)
        {
            string token = Convert.ToBase64String(Encoding.UTF8.GetBytes(email + ":" + password));

            return GetInstance(token: token, ticket: ticket);
        }

        private async Task FetchTicket()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://connect.ubi.com/ubiservices/v2/profiles/sessions");
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.Headers.Add("Authorization", "Basic " + Token);
            request.Headers.Add("Ubi-AppId", AppId);

            using (Stream stream = await request.GetRequestStreamAsync())
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    await writer.WriteAsync("{ \"rememberMe\": true }");
                }
            }

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string json = await reader.ReadToEndAsync();

                        JObject result = JObject.Parse(json);

                        Ticket = result.GetValue("ticket").ToString();
                        RememberMeTicket = result.GetValue("rememberMeTicket").ToString();
                    }
                }
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    using (HttpWebResponse response = (HttpWebResponse)wex.Response)
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            string json = await reader.ReadToEndAsync();

                            JObject result = JObject.Parse(json);

                            JToken message;
                            if (result.TryGetValue("message", out message))
                                throw new Exception($"Couldn't get the ticket from the Ubisoft API server. (message: {message})");
                        }
                    }
                }

                throw new Exception("Couldn't get the ticket from the Ubisoft API server.");
            }
        }

        internal async Task<JObject> FetchData(string url)
        {
            if (Ticket == null)
                await FetchTicket();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            request.Headers.Add("Authorization", "Ubi_v1 t=" + Ticket);
            request.Headers.Add("Ubi-AppId", AppId);

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string json = await reader.ReadToEndAsync();

                        JObject result = JObject.Parse(json);

                        return result;
                    }
                }
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    using (HttpWebResponse response = (HttpWebResponse)wex.Response)
                    {
                        if (response.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            await FetchTicket();
                            return await FetchData(url);
                        }
                    }
                }

                throw wex;
            }
        }

        public async Task<Player> GetPlayerById(string id, Platform platform)
        {
            var data = await FetchData($"https://public-ubiservices.ubi.com/v2/profiles?platformType={platform.ToInternalString()}&idsOnPlatform={id}");
            return data["profiles"].ToObject<IEnumerable<Player>>().FirstOrDefault();
        }

        public async Task<Player> GetPlayerByName(string name, Platform platform)
        {
            var data = await FetchData($"https://public-ubiservices.ubi.com/v2/profiles?platformType={platform.ToInternalString()}&nameOnPlatform={name}");
            return data["profiles"].ToObject<IEnumerable<Player>>().FirstOrDefault();
        }
    }
}
