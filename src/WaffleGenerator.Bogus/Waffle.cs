using WaffleGenerator;

namespace Bogus;

public class Waffle : DataSet
{
    public string Html(int paragraphs = 1, bool includeHeading = true, bool includeHeadAndBody = true) =>
        WaffleEngine.Html(RandomNumber, paragraphs, includeHeading, includeHeadAndBody);

    public string Text(int paragraphs = 1, bool includeHeading = true) =>
        WaffleEngine.Text(RandomNumber, paragraphs, includeHeading);

    public string Markdown(int paragraphs = 1, bool includeHeading = true) =>
        WaffleEngine.Markdown(RandomNumber, paragraphs, includeHeading);

    public string Title() =>
        WaffleEngine.Title(RandomNumber);

    int RandomNumber(int i) =>
        Random.Number(i - 1);
}