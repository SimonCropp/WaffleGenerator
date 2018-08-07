using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

class InnerEngine
{
    Func<int, int> random;
    int cardinalSequence;
    int ordinalSequence;
    string title;
    string quote;
    List<Paragraph> paragraphs = new List<Paragraph>();
    string cite;
    string buzz;

    public InnerEngine(Func<int, int> random)
    {
        this.random = random;
    }

    void EvaluateRandomPhrase(string[] phrases, StringBuilder output)
    {
        var index = random(phrases.Length);
        EvaluatePhrase(phrases[index], output);
    }

    void EvaluatePhrase(string phrase, StringBuilder result)
    {
        for (var i = 0; i < phrase.Length; i++)
        {
            if (phrase[i] == '|' && i + 1 < phrase.Length)
            {
                i++;

                var escape = result;
                var titleCase = false;

                if (phrase[i] == 'u' && i + 1 < phrase.Length)
                {
                    escape = new StringBuilder();
                    titleCase = true;
                    i++;
                }

                switch (phrase[i])
                {
                    case 'a':
                        EvaluateCardinalSequence(escape);
                        break;
                    case 'b':
                        EvaluateOrdinalSequence(escape);
                        break;
                    case 'c':
                        EvaluateRandomPhrase(Constants.buzzPhrases, escape);
                        break;
                    case 'd':
                        EvaluateRandomPhrase(Constants.verbs, escape);
                        break;
                    case 'e':
                        EvaluateRandomPhrase(Constants.adverbs, escape);
                        break;
                    case 'f':
                        EvaluateRandomPhrase(Constants.forenames, escape);
                        break;
                    case 's':
                        EvaluateRandomPhrase(Constants.surnames, escape);
                        break;
                    case 'o':
                        EvaluateRandomPhrase(Constants.artyNouns, escape);
                        break;
                    case 'y':
                        RandomDate(escape);
                        break;
                    case 'h':
                        EvaluateRandomPhrase(Constants.prefixes, escape);
                        break;
                    case 'A':
                        EvaluateRandomPhrase(Constants.preamblePhrases, escape);
                        break;
                    case 'B':
                        EvaluateRandomPhrase(Constants.subjectPhrases, escape);
                        break;
                    case 'C':
                        EvaluateRandomPhrase(Constants.verbPhrases, escape);
                        break;
                    case 'D':
                        EvaluateRandomPhrase(Constants.objectPhrases, escape);
                        break;
                    case '1':
                        EvaluateRandomPhrase(Constants.firstAdjectivePhrases, escape);
                        break;
                    case '2':
                        EvaluateRandomPhrase(Constants.secondAdjectivePhrases, escape);
                        break;
                    case '3':
                        EvaluateRandomPhrase(Constants.nounPhrases, escape);
                        break;
                    case '4':
                        EvaluateRandomPhrase(Constants.cliches, escape);
                        break;
                    case 't':
                        escape.Append(title);
                        break;
                }

                if (titleCase)
                {
                    result.Append(TitleCaseWords(escape.ToString()));
                }
            }
            else
            {
                result.Append(phrase[i]);
            }
        }
    }

    void EvaluateCardinalSequence(StringBuilder output)
    {
        if (cardinalSequence >= Constants.cardinalSequences.Length)
        {
            cardinalSequence = 0;
        }

        output.Append(Constants.cardinalSequences[cardinalSequence++]);
    }

    void EvaluateOrdinalSequence(StringBuilder output)
    {
        if (ordinalSequence >= Constants.ordinalSequences.Length)
        {
            ordinalSequence = 0;
        }

        output.Append(Constants.ordinalSequences[ordinalSequence++]);
    }

    void RandomDate(StringBuilder output)
    {
        output.AppendFormat("{0:04u}", DateTime.Now.Year - random(31));
    }

    static string TitleCaseWords(string input)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input);
    }

    public WaffleContent GetContent(int paragraphsCount, bool includeHeading)
    {
        cardinalSequence = 0;
        ordinalSequence = 0;
        if (includeHeading)
        {
            title = BuildTitle();
            var quoteBuilder = new StringBuilder();
            EvaluatePhrase("|A |B |C |t", quoteBuilder);
            quote = quoteBuilder.ToString();
            var citeBuilder = new StringBuilder();
            EvaluatePhrase("|f |s in The Journal of the |uc (|uy)", citeBuilder);
            cite = citeBuilder.ToString();
            var buzzBuilder = new StringBuilder();
            EvaluatePhrase("|c.", buzzBuilder);
            buzz = buzzBuilder.ToString();
        }

        for (var i = 0; i < paragraphsCount; i++)
        {
            var paragraph = new Paragraph();

            if (i != 0)
            {
                var headingBuilder = new StringBuilder();
                EvaluateRandomPhrase(Constants.maybeHeading, headingBuilder);
                var paragraphHeading = headingBuilder.ToString();
                if (!string.IsNullOrEmpty(paragraphHeading))
                {
                    paragraph.Heading = paragraphHeading;
                }
            }

            var bodyBuilder = new StringBuilder();
            EvaluatePhrase("|A |B |C |D.", bodyBuilder);
            paragraph.Body = bodyBuilder.ToString();
            paragraphs.Add(paragraph);
        }

        var content = new WaffleContent
        {
            Paragraphs = paragraphs
        };
        if (includeHeading)
        {
            content.Heading = new Heading()
            {
                Title = title,
                Buzz = buzz,
                Cite = cite,
                Quote = quote
            };
        }

        return content;
    }

    public string BuildTitle()
    {
        var builder = new StringBuilder();
        EvaluatePhrase("the |o of |2 |o", builder);

        return TitleCaseWords(builder.ToString());
    }
}