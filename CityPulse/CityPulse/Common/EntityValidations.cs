namespace CityPulse.Common
{
    public static class EntityValidations
    {
        public const string DateTimeColumnType = "datetime2";

        public static class City
        {
            public const int CityNameMinLength = 2;
            public const int CityNameMaxLength = 100;
        }

        public static class District
        {
            public const int DistrictNameMinLength = 2;
            public const int DistrictNameMaxLength = 100;
        }

        public static class Category
        {
            public const int CategoryNameMinLength = 2;
            public const int CategoryNameMaxLength = 100;
        }

        public static class User
        {
            public const int UserFullNameMinLength = 2;
            public const int UserFullNameMaxLength = 200;

            public const int UserEmailMinLength = 5;
            public const int UserEmailMaxLength = 254;
        }

        public static class Report
        {
            public const int ReportTitleMinLength = 2;
            public const int ReportTitleMaxLength = 200;
        }
    }
}
