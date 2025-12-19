using System.Runtime.CompilerServices;
using VerifyTests.AngleSharp;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        // remove some noise from the html snapshot
        #region scrubbing
        VerifierSettings.ScrubEmptyLines();
        VerifierSettings.ScrubLinesWithReplace(s => s.Replace("<!--!-->", ""));
        HtmlPrettyPrint.All();
        VerifierSettings.ScrubLinesContaining("<script src=\"_framework/dotnet.");
        #endregion
        VerifyPlaywright.Initialize(true);
        VerifyImageMagick.Initialize();
        VerifyImageMagick.RegisterComparers(.01);
    }
}