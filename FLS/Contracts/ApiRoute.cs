namespace FLS.Contracts
{
    public static class ApiRoute
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Guests
        {
            public const string Login = Base + "/guest/login";
        }

        public static class Users
        {
            public const string GetAll = Base + "/user/";
            public const string Get = Base + "/user/{id}";
            public const string Create = Base + "/user";
            public const string Update = Base + "/user/{id}";
            public const string Delete = Base + "/user/{id}";
        }

        public static class Subjects
        {
            public const string GetAll = Base + "/subject/";
            public const string Get = Base + "/subject/{id}";
            public const string Create = Base + "/subject";
            public const string Update = Base + "/subject/{id}";
            public const string Delete = Base + "/subject/{id}";
        }
    }
}