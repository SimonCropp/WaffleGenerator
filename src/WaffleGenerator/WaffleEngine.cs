using System;
using System.Text;

namespace WaffleGenerator
{
    public static class WaffleEngine
    {
        public static string Html(int paragraphs, bool includeHeading, bool includeHeadAndBody)
        {
            return Html(new Random(), paragraphs, includeHeading, includeHeadAndBody);
        }

        public static string Html(Random random, int paragraphs, bool includeHeading, bool includeHeadAndBody)
        {
            return Html(x => random.Next(0, x), paragraphs, includeHeading, includeHeadAndBody);
        }

        public static string Html(Func<int, int> random, int paragraphs, bool includeHeading, bool includeHeadAndBody)
        {
            var builder = new StringBuilder();
            var innerEngine = new InnerEngine(random);
            var waffleContent = innerEngine.GetContent(paragraphs, includeHeading);

            if (waffleContent.Heading != null)
            {
                if (includeHeadAndBody)
                {
                    builder.AppendLine("<html>");
                    builder.AppendLine("<head>");
                    builder.AppendFormat("<title>{0}</title>", waffleContent.Heading.Title);
                    builder.AppendLine();
                    builder.AppendLine("</head>");
                    builder.AppendLine("<body>");
                }

                builder.AppendFormat("<h1>{0}</h1>", waffleContent.Heading.Title);
                builder.AppendLine();
                builder.AppendLine($"<blockquote>\"{waffleContent.Heading.Quote}\"<br>");
                builder.AppendLine($"<cite>{waffleContent.Heading.Cite}</cite></blockquote>");
                builder.AppendLine($"<h2>{waffleContent.Heading.Buzz}</h2>");
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

        public static string Title()
        {
            return Title(new Random());
        }

        public static string Title(Random random)
        {
            return Title(x => random.Next(0, x));
        }

        public static string Title(Func<int, int> random)
        {
            var innerEngine = new InnerEngine(random);
            return innerEngine.BuildTitle();
        }

        public static string Text(int paragraphs, bool includeHeading)
        {
            return Text(new Random(), paragraphs, includeHeading);
        }

        public static string Text(Random random, int paragraphs, bool includeHeading)
        {
            return Text(x => random.Next(0, x), paragraphs, includeHeading);
        }

        public static string Text(Func<int, int> random, int paragraphs, bool includeHeading)
        {
            var builder = new StringBuilder();
            var innerEngine = new InnerEngine(random);
            var waffleContent = innerEngine.GetContent(paragraphs, includeHeading);
            if (waffleContent.Heading != null)
            {
                builder.AppendLine(waffleContent.Heading.Title);
                builder.AppendLine();
                builder.AppendLine($"\"{waffleContent.Heading.Quote}\"");
                builder.AppendLine();
                builder.AppendLine($" - {waffleContent.Heading.Cite}");
                builder.AppendLine();
                builder.AppendLine(waffleContent.Heading.Buzz);
                builder.AppendLine();
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
}