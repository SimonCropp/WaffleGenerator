using WaffleGenerator;

namespace Bogus
{
    public class Waffle : DataSet
    {
        public string Html(int paragraphs = 1, bool includeHeading = true, bool includeHeadAndBody = true)
        {
            return WaffleEngine.Html(RandomNumber, paragraphs, includeHeading, includeHeadAndBody);
        }

        public string Text(int paragraphs = 1, bool includeHeading = true)
        {
            return WaffleEngine.Text(RandomNumber, paragraphs, includeHeading);
        }

        public string Markdown(int paragraphs = 1, bool includeHeading = true)
        {
            return WaffleEngine.Markdown(RandomNumber, paragraphs, includeHeading);
        }

        public string Title()
        {
            return WaffleEngine.Title(RandomNumber);
        }

        int RandomNumber(int i)
        {
            return Random.Number(i - 1);
        }
    }
}