using System;
using SiegeApi;
using SiegeApi.Enums;

namespace SiegeApiSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Api api = Api.GetInstance(email: "Your ubisoft email", password: "Your ubisoft password");

            var player = api.GetPlayerByName("etco", Platform.PLAYSTATION).Result;
            Console.WriteLine($"player.ProfileId: {player.ProfileId}");
            Console.WriteLine($"player.UserId: {player.UserId}");
            Console.WriteLine($"player.PlatformType: {player.PlatformType}");
            Console.WriteLine($"player.IdOnPlatform: {player.IdOnPlatform}");
            Console.WriteLine($"player.NameOnPlatform: {player.NameOnPlatform}");
        }
    }
}
