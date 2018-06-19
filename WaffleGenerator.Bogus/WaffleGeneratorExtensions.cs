using Bogus.Premium;

namespace Bogus
{
    public static class WaffleExtensions
    {
        public static Waffle Waffle(this Faker faker)
        {
            return ContextHelper.GetOrSet(faker, () => new Waffle());
        }

        public static string WaffleHtml(this Faker faker, int paragraphs = 1, bool includeHeading = true)
        {
            return faker.Waffle().Html(paragraphs, includeHeading);
        }

        public static string WaffleTitle(this Faker faker)
        {
            return faker.Waffle().Title();
        }

        public static string WaffleText(this Faker faker, int paragraphs = 1, bool includeHeading = true)
        {
            return faker.Waffle().Text(paragraphs, includeHeading);
        }
    }
}