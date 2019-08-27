using System;
using System.Web;

namespace SiegeApi.Extensions
{
    public static class UriExtensions
    {
        public static Uri AddParameter(this Uri uri, string name, string value)
        {
            UriBuilder uriBuilder = new UriBuilder(uri);
            var query = HttpUtility.ParseQueryString(uri.Query);
            query[name] = value;
            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }
    }
}
