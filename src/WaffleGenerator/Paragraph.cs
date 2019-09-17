class Paragraph
{
    public Paragraph(string? heading, string body)
    {
        Heading = heading;
        Body = body;
    }
    public string? Heading { get; }
    public string Body { get; }
}