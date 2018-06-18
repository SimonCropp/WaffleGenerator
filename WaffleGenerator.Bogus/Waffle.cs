using WaffleGenerator.Bogus;

namespace Bogus
{
    public class Waffle : DataSet
    {
        public string Html(int paragraphs = 1, bool includeHeading = true)
        {
            return WaffleEngine.Html(RandomNumber, paragraphs, includeHeading);
        }

        public string Text(int paragraphs = 1, bool includeHeading = true)
        {
            return WaffleEngine.Text(RandomNumber, paragraphs, includeHeading);
        }

        int RandomNumber(int i)
        {
            return Random.Number(i - 1);
        }
    }
}