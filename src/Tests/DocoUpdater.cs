using MarkdownSnippets;
using Xunit;

public class DocoUpdater
{
    [Fact]
    public void Run()
    {
        GitHubMarkdownProcessor.RunForFilePath();
    }
}