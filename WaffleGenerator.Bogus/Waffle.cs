using System.Text;
using WaffleGenerator.Bogus;

namespace Bogus
{
    public class Waffle : DataSet
    {
        public string Html(int paragraphs = 1, bool includeHeading = true)
        {
            var engine = BuildEngine();
            var builder = new StringBuilder();
            engine.HtmlWaffle(paragraphs, includeHeading, builder);
            return builder.ToString();
        }

        public string Text(int paragraphs = 1, bool includeHeading = true)
        {
            var engine = BuildEngine();
            var builder = new StringBuilder();
            engine.TextWaffle(paragraphs, includeHeading, builder);
            return builder.ToString();
        }

        WaffleEngine BuildEngine()
        {
            return new WaffleEngine(i => Random.Number(i - 1));
        }
    }
}