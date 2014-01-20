using System;
using System.Linq;

namespace GetGluePortable
{
    public static class GetGlueHelpers
    {
        public static string GetAuthorizationCodeFromUrl(this Uri uri)
        {
            var queryList = uri.Query.ParseQueryString();

            return queryList.FirstOrDefault(q => q.Key == "code").Value;
        }
    }
}
