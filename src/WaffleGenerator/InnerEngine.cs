using System.Globalization;

class InnerEngine
{
    Func<int, int> random;
    int cardinalSequence;
    int ordinalSequence;
    string? title;
    string? quote;
    string? cite;
    string? buzz;
    List<Paragraph> paragraphs = new();

    public InnerEngine(Func<int, int> random) =>
        this.random = random;

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

                if (phrase[i] == 'u' && i + 1 < phrase.Length)
                {
                    StringBuilder escape = new();
                    i++;
                    EvaluateChar(phrase[i], escape);
                    result.Append(TitleCaseWords(escape.ToString()));
                }
                else
                {
                    EvaluateChar(phrase[i], result);
                }
            }
            else
            {
                if (i == 0 && HasSentenceEnded(result))
                {
                    result.Append(char.ToUpper(phrase[i]));
                }
                else
                {
                    result.Append(phrase[i]);
                }
            }
        }
    }

    private void EvaluateChar(char c, StringBuilder builder)
    {
        switch (c)
        {
            case 'a':
                EvaluateCardinalSequence(builder);
                break;
            case 'b':
                EvaluateOrdinalSequence(builder);
                break;
            case 'c':
                EvaluateRandomPhrase(Constants.buzzPhrases, builder);
                break;
            case 'd':
                EvaluateRandomPhrase(Constants.verbs, builder);
                break;
            case 'e':
                EvaluateRandomPhrase(Constants.adverbs, builder);
                break;
            case 'f':
                EvaluateRandomPhrase(Constants.forenames, builder);
                break;
            case 's':
                EvaluateRandomPhrase(Constants.surnames, builder);
                break;
            case 'o':
                EvaluateRandomPhrase(Constants.artyNouns, builder);
                break;
            case 'y':
                RandomDate(builder);
                break;
            case 'h':
                EvaluateRandomPhrase(Constants.prefixes, builder);
                break;
            case 'A':
                EvaluateRandomPhrase(Constants.preamblePhrases, builder);
                break;
            case 'B':
                EvaluateRandomPhrase(Constants.subjectPhrases, builder);
                break;
            case 'C':
                EvaluateRandomPhrase(Constants.verbPhrases, builder);
                break;
            case 'D':
                EvaluateRandomPhrase(Constants.objectPhrases, builder);
                break;
            case '1':
                EvaluateRandomPhrase(Constants.firstAdjectivePhrases, builder);
                break;
            case '2':
                EvaluateRandomPhrase(Constants.secondAdjectivePhrases, builder);
                break;
            case '3':
                EvaluateRandomPhrase(Constants.nounPhrases, builder);
                break;
            case '4':
                EvaluateRandomPhrase(Constants.cliches, builder);
                break;
            case 't':
                builder.Append(title);
                break;
        }
    }

    static bool HasSentenceEnded(StringBuilder result) =>
        result.EndsWith('.', '>');

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

    void RandomDate(StringBuilder output) =>
        output.AppendFormat("{0:04u}", DateTime.Now.Year - random(31));

    static string TitleCaseWords(string input) =>
        CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input);

    public WaffleContent GetContent(int paragraphsCount, bool includeHeading)
    {
        cardinalSequence = 0;
        ordinalSequence = 0;
        Heading? heading = null;
        if (includeHeading)
        {
            title = BuildTitle();
            StringBuilder quoteBuilder = new();
            EvaluatePhrase("|A |B |C |t", quoteBuilder);
            quote = quoteBuilder.ToString();
            StringBuilder citeBuilder = new();
            EvaluatePhrase("|f |s in The Journal of the |uc (|uy)", citeBuilder);
            cite = citeBuilder.ToString();
            StringBuilder buzzBuilder = new();
            EvaluatePhrase("|c.", buzzBuilder);
            buzz = buzzBuilder.ToString();
            heading = new(quote, cite, buzz, title);
        }

        for (var i = 0; i < paragraphsCount; i++)
        {
            string? paragraphHeading = null;
            if (i != 0)
            {
                StringBuilder headingBuilder = new();
                EvaluateRandomPhrase(Constants.maybeHeading, headingBuilder);
                paragraphHeading = headingBuilder.ToString();
                if (string.IsNullOrWhiteSpace(paragraphHeading))
                {
                    paragraphHeading = null;
                }
            }

            StringBuilder bodyBuilder = new();
            EvaluatePhrase("|A |B |C |D.", bodyBuilder);
            Paragraph paragraph = new(paragraphHeading, bodyBuilder.ToString());
            paragraphs.Add(paragraph);
        }

        return new(heading, paragraphs);
    }

    public string BuildTitle()
    {
        StringBuilder builder = new();
        EvaluatePhrase("the |o of |2 |o", builder);

        return TitleCaseWords(builder.ToString());
    }
}