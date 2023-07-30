namespace WaffleGenerator;

public static class WaffleEngine
{
    public static string Html(int seed, int paragraphs, bool includeHeading, bool includeHeadAndBody) =>
        Html(new Random(seed), paragraphs, includeHeading, includeHeadAndBody);

    public static string Html(int paragraphs, bool includeHeading, bool includeHeadAndBody) =>
        Html(new Random(), paragraphs, includeHeading, includeHeadAndBody);

    public static string Html(Random random, int paragraphs, bool includeHeading, bool includeHeadAndBody) =>
        Html(x => random.Next(0, x), paragraphs, includeHeading, includeHeadAndBody);

    public static string Html(Func<int, int> random, int paragraphs, bool includeHeading, bool includeHeadAndBody)
    {
        var builder = new StringBuilder();
        var innerEngine = new InnerEngine(random);
        var waffleContent = innerEngine.GetContent(paragraphs, includeHeading);

        if (waffleContent.Heading != null)
        {
            if (includeHeadAndBody)
            {
                builder.AppendLine(
                    $"""
                     <html>
                     <head>
                     <title>{waffleContent.Heading.Title}</title>
                     </head>
                     <body>
                     """);
            }

            builder.AppendLine(
                $"""
                 <h1>{waffleContent.Heading.Title}</h1>
                 <blockquote>'{waffleContent.Heading.Quote}'<br>
                 <cite>{waffleContent.Heading.Cite}</cite></blockquote>
                 <h2>{waffleContent.Heading.Buzz}</h2>
                 """);
        }

        foreach (var paragraph in waffleContent.Paragraphs)
        {
            builder.AppendLine("<p>");
            if (paragraph.Heading != null)
            {
                builder.AppendLine($"<h2>{paragraph.Heading}</h2>");
            }

            builder.AppendLine(paragraph.Body);
            builder.AppendLine("</p>");
        }

        if (includeHeadAndBody)
        {
            builder.AppendLine("</body>");
            builder.Append("</html>");
        }

        return builder.ToString();
    }

    public static string Title() =>
        Title(new Random());

    public static string Title(int seed) =>
        Title(new Random(seed));

    public static string Title(Random random) =>
        Title(x => random.Next(0, x));

    public static string Title(Func<int, int> random)
    {
        var innerEngine = new InnerEngine(random);
        return innerEngine.BuildTitle();
    }

    public static string Markdown(int seed, int paragraphs, bool includeHeading) =>
        Markdown(new Random(seed), paragraphs, includeHeading);

    public static string Markdown(int paragraphs, bool includeHeading) =>
        Markdown(new Random(), paragraphs, includeHeading);

    public static string Markdown(Random random, int paragraphs, bool includeHeading) =>
        Markdown(x => random.Next(0, x), paragraphs, includeHeading);

    public static string Markdown(Func<int, int> random, int paragraphs, bool includeHeading)
    {
        var builder = new StringBuilder();
        var innerEngine = new InnerEngine(random);
        var waffleContent = innerEngine.GetContent(paragraphs, includeHeading);

        if (waffleContent.Heading != null)
        {
            builder.AppendLine(
                $"""
                 # {waffleContent.Heading.Title}
                 
                  > {waffleContent.Heading.Quote}
                 
                  * {waffleContent.Heading.Cite}

                 ## {waffleContent.Heading.Buzz}

                 """);
        }

        foreach (var paragraph in waffleContent.Paragraphs)
        {
            if (paragraph.Heading != null)
            {
                builder.AppendLine($"## {paragraph.Heading}");
                builder.AppendLine("");
            }

            builder.AppendLine(paragraph.Body);
            builder.AppendLine("");
        }

        return builder.ToString();
    }

    public static string Text(int seed, int paragraphs, bool includeHeading) =>
        Text(new Random(seed), paragraphs, includeHeading);

    public static string Text(int paragraphs, bool includeHeading) =>
        Text(new Random(), paragraphs, includeHeading);

    public static string Text(Random random, int paragraphs, bool includeHeading) =>
        Text(x => random.Next(0, x), paragraphs, includeHeading);

    public static string Text(Func<int, int> random, int paragraphs, bool includeHeading)
    {
        var builder = new StringBuilder();
        var innerEngine = new InnerEngine(random);
        var waffleContent = innerEngine.GetContent(paragraphs, includeHeading);
        if (waffleContent.Heading != null)
        {
            builder.AppendLine(
                $"""
                 {waffleContent.Heading.Title}

                 '{waffleContent.Heading.Quote}'
                 
                  - {waffleContent.Heading.Cite}

                 {waffleContent.Heading.Buzz}

                 """);
        }

        var lastIndex = waffleContent.Paragraphs.Count - 1;
        for (var index = 0; index < waffleContent.Paragraphs.Count; index++)
        {
            var paragraph = waffleContent.Paragraphs[index];
            if (paragraph.Heading != null)
            {
                builder.AppendLine(paragraph.Heading);
                builder.AppendLine();
            }

            builder.AppendLine(paragraph.Body);
            if (index != lastIndex)
            {
                builder.AppendLine();
            }
        }

        return builder.ToString();
    }
}