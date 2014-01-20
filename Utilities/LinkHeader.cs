using System.Linq;
using System.Text.RegularExpressions;

namespace GetGluePortable.Utilities
{
    public class LinkHeader
    {
        internal static string Parse(string linkHeader)
        {
            var linkParts = linkHeader.Split(',').ToList();

            if (linkParts.Count > 0)
            {
                foreach (var linkPart in linkParts)
                {
                    var linkMatch = Regex.Match(linkPart, @"=(.+)");
                    
                    if (linkMatch.Success)
                    {
                        var foo = linkMatch.Groups[0].Value;
                    }
                }
            }

            return string.Empty;
        }
    }
}
