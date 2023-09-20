namespace backend.Infrastructure.Databases.WebContents;
public static class ModelConsts
{
    public static class Portfolio
    {
        public const int NameMaxLength = 128;
        public const bool NameIsRequired = true;

        public const int TitleMaxLength = 2048;
        public const bool TitleIsRequired = true;

        public const int SubtitleMaxLength = 2048;
        public const bool SubtitleIsRequired = false;

        public const int DescriptionMaxLength = 2048;
        public const bool DescriptionIsRequired = false;
    }

    public static class Menu
    {
        public const int TitleMaxLength = 128;
        public const bool TitleIsRequired = true;

        public const int UrlMaxLength = 256;
        public const bool UrlIsRequired = false;
    }
    public static class Social
    {
        public const int TitleMaxLength = 128;
        public const bool TitleIsRequired = true;

        public const int UrlMaxLength = 256;
        public const bool UrlIsRequired = false;

        public const int IconMaxLength = 256;
        public const bool IconIsRequired = false;
    }

    public static class Experience
    {
        public const int TitleMaxLength = 128;
        public const bool TitleIsRequired = true;

        public const int CompanyMaxLength = 128;
        public const bool CompanyIsRequired = true;

        public const int DescriptionMaxLength = 2048;
        public const bool DescriptionIsRequired = false;

        public const int CompanyUrlMaxLength = 256;
        public const bool CompanyUrlIsRequired = false;

        public const bool DateStartedIsRequired = true;

        public const bool DateEndedIsRequired = false;
    }

    public static class Link
    {
        public const int TitleMaxLength = 128;
        public const bool TitleIsRequired = true;

        public const int UrlMaxLength = 256;
        public const bool UrlIsRequired = false;
    }

    public static class Skill
    {
        public const int TitleMaxLength = 128;
        public const bool TitleIsRequired = true;

        public const int DescriptionMaxLength = 2048;
        public const bool DescriptionIsRequired = false;
    }
}
