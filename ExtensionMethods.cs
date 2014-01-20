using System;
using System.Collections.Generic;
using System.Linq;

namespace GetGluePortable
{
    internal static class ExtensionMethods
    {
        internal static Uri ToQueryString(this Uri uri, List<KeyValuePair<string, string>> parameters)
        {
            return new Uri(uri + "?" + string.Join("&", parameters.Select(parameter => string.Format("{0}={1}", parameter.Key, parameter.Value)).ToArray()));
        }

        internal static List<KeyValuePair<string, string>> ParseQueryString(this string query)
        {
            var keyValuePairList = new List<KeyValuePair<string, string>>();

            foreach (var parts in query.TrimStart(new[] { '?' }).Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries).Select(token => token.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries)))
            {
                if (parts.Length == 2)
                    keyValuePairList.Add(new KeyValuePair<string, string>(parts[0].Trim(),
                        Uri.UnescapeDataString(parts[1]).Trim()));
                else
                {
                    keyValuePairList.Add(new KeyValuePair<string, string>(parts[0].Trim(), string.Empty));
                }
            }
            return keyValuePairList;
        }
    }
}
