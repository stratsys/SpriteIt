using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Web.Samples
{
    public class HoverGenerator
    {
        private readonly Regex _nameExpr = new Regex(@"\\([^\\]*)\.[^\\]*$");

        public Dictionary<string, string> Generate(List<string> imageLocations)
        {
            
            var names = new Dictionary<string, string>();
            foreach (var imageLocation in imageLocations)
            {
                var nameMatch = _nameExpr.Match(imageLocation);
                if (nameMatch.Success)
                {
                    names[nameMatch.Groups[1].Value] = imageLocation;
                }
            }

            var pairs = new Dictionary<string, string>();
            var normalImgs = names.Where(n => !n.Key.EndsWith("-hover"));
            var hoverImgs = names.Where(n => n.Key.EndsWith("-hover")).ToDictionary(n => n.Key.Replace("-hover", ""), n => n.Value);

            foreach (var name in normalImgs)
            {
                string hover;
                pairs[name.Value] = hoverImgs.TryGetValue(name.Key, out hover) ? hover : null;
            }

            return pairs;
        }
    }
}
