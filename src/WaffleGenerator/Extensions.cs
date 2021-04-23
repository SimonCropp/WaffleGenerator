using System.Text;

static class Extensions
{
    public static bool EndsWith(this StringBuilder builder, params char[] chars)
    {
        for (var i = builder.Length-1; i != -1; i--)
        {
            var builderChar = builder[i];
            if (char.IsWhiteSpace(builderChar))
            {
                continue;
            }
            foreach (var c in chars)
            {
                if (c == builderChar)
                {
                    return true;
                }
            }

            return false;
        }

        return false;
    }
}