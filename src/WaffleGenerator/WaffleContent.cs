class WaffleContent
{
    public WaffleContent(Heading? heading, List<Paragraph> paragraphs)
    {
        Heading = heading;
        Paragraphs = paragraphs;
    }
    public Heading? Heading { get; }
    public List<Paragraph> Paragraphs { get; }
}