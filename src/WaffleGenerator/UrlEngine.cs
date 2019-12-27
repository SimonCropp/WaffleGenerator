using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

class UrlEngine
{
    private Random _random = new Random();
    private List<string> _chosen = new List<string>();

    public string Build(bool? countryTopLevel, int pathLength)
    {
        var builder = new StringBuilder();
        builder.AppendFormat("{0}://", Choice(Constants.schemes));
        if (countryTopLevel != null && !countryTopLevel.Value) {
            builder.AppendFormat("{0}.", Choice(Constants.domainsCountry));
        }
        else {
            builder.AppendFormat("{0}.", Choice(Constants.domainsSub));
        }
        builder.AppendFormat("{0}.", Choice(Constants.domains));
        builder.AppendFormat("{0}", Choice(Constants.domainsTop));
        if (countryTopLevel != null && countryTopLevel.Value) {
            builder.AppendFormat(".{0}", Choice(Constants.domainsCountry));
        }
        if (pathLength == 0) {
            builder.Append("/");
        }
        else {
            for (var i = 0; i < pathLength; i++) {
                builder.AppendFormat("/{0}", Choice(Constants.paths, false));
            }
        }
        if (pathLength > 0) {
            builder.AppendFormat(".{0}", Choice(Constants.extensions));
        }
        return builder.ToString();
    }

    private string Choice(IEnumerable<string> source, bool unique = true)
    {
        var item = source.ElementAt(_random.Next(0, source.Count() - 1));
        var exists = _chosen.Contains(item);
        if (exists) {
            if (unique) {
                Choice(source);
            }
            return item;
        }
        _chosen.Add(item);
        return item;
    }
}