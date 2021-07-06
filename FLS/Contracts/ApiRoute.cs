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

        public static class Roles
        {
            public const string GetAll = Base + "/role/";
            public const string Get = Base + "/role/{id}";
            public const string Create = Base + "/role";
            public const string Update = Base + "/role/{id}";
            public const string Delete = Base + "/role/{id}";
        }

        public static class Subjects
        {
            public const string GetAll = Base + "/subject/";
            public const string Get = Base + "/subject/{id}";
            public const string Create = Base + "/subject";
            public const string Update = Base + "/subject/{id}";
            public const string Delete = Base + "/subject/{id}";
        }

        public static class Departments
        {
            public const string GetAll = Base + "/department/";
            public const string Get = Base + "/department/{id}";
            public const string GetByUser = Base + "/user/{id}/department";
            public const string Create = Base + "/department";
            public const string Update = Base + "/department/{id}";
            public const string Delete = Base + "/department/{id}";
        }

        public static class Lecturers
        {
            public const string GetAll = Base + "/lecturer/";
            public const string Get = Base + "/lecturer/{id}";
            public const string GetByUser = Base + "/user/{id}/lecturer";
            public const string Create = Base + "/lecturer";
            public const string Update = Base + "/lecturer/{id}";
            public const string Delete = Base + "/lecturer/{id}";
        }

        public static class LecturerTypes
        {
            public const string GetAll = Base + "/lecturer/type/";
            public const string Get = Base + "/lecturer/type/{id}";
            public const string Create = Base + "/lecturer/type";
            public const string Update = Base + "/lecturer/type/{id}";
            public const string Delete = Base + "/lecturer/type/{id}";
        }

        public static class Blogs
        {
            public const string GetAll = Base + "/blog/";
            public const string Get = Base + "/blog/{id}";
            public const string Create = Base + "/blog";
            public const string Update = Base + "/blog/{id}";
            public const string Delete = Base + "/blog/{id}";
        }

        public static class BlogCategories
        {
            public const string GetAll = Base + "/blog/category/";
            public const string Get = Base + "/blog/category/{id}";
            public const string Create = Base + "/blog/category";
            public const string Update = Base + "/blog/category/{id}";
            public const string Delete = Base + "/blog/category/{id}";
        }

        public static class Semesters
        {
            public const string GetAll = Base + "/semester/";
            public const string Get = Base + "/semester/{id}";
            public const string Create = Base + "/semester";
            public const string Update = Base + "/semester/{id}";
            public const string Delete = Base + "/semester/{id}";
        }

        public static class TimeSlots
        {
            public const string GetAll = Base + "/time-slot/";
            public const string Get = Base + "/time-slot/{id}";
            public const string Create = Base + "/time-slot";
            public const string Update = Base + "/time-slot/{id}";
            public const string Delete = Base + "/time-slot/{id}";
        }

        public static class Courses
        {
            public const string GetAll = Base + "/course/";
            public const string Get = Base + "/course/{id}";
            public const string Create = Base + "/course";
            public const string Update = Base + "/course/{id}";
            public const string Delete = Base + "/course/{id}";
        }

        public static class DepartmentBlogs
        {
            public const string GetAll = Base + "/department/blog/";
            public const string Get = Base + "/department/{dept-id}/blog/{blog-id}";
            public const string Create = Base + "/department/blog";
            public const string Update = Base + "/department/blog";
            public const string Delete = Base + "/department/{dept-id}/blog/{blog-id}";
        }

        public static class LecturerRatings
        {
            public const string GetAll = Base + "/leturer-rating/";
            public const string Get = Base + "/leturer-rating/{semplan-id}/{lec-id}";
            public const string Create = Base + "/leturer-rating";
            public const string Update = Base + "/leturer-rating";
            public const string Delete = Base + "/leturer-rating/{semplan-id}/{lec-id}";
        }

        public static class SemesterRegisters
        {
            public const string GetAll = Base + "/semester-register/";
            public const string Get = Base + "/semester-register/{sem-id}/{lec-id}";
            public const string Create = Base + "/semester-register";
            public const string Update = Base + "/semester-register";
            public const string Delete = Base + "/semester-register/{sem-id}/{lec-id}";
        }

        public static class SubjectRegisters
        {
            public const string GetAll = Base + "/subject-register/";
            public const string Get = Base + "/subject-register/{id}";
            public const string Create = Base + "/subject-register";
            public const string Update = Base + "/subject-register/{id}";
            public const string Delete = Base + "/subject-register/{id}";
        }

        public static class TeachableSubjects
        {
            public const string GetAll = Base + "/teachable-subject/";
            public const string Get = Base + "/teachable-subject/{lec-id}/{sub-id}";
            public const string Create = Base + "/teachable-subject";
            public const string Update = Base + "/teachable-subject/";
            public const string Delete = Base + "/teachable-subject/{lec-id}/{sub-id}";
        }

        public static class TimeSlotRegisters
        {
            public const string GetAll = Base + "/time-slot-register/";
            public const string Get = Base + "/time-slot-register/{id}";
            public const string Create = Base + "/time-slot-register";
            public const string Update = Base + "/time-slot-register/{id}";
            public const string Delete = Base + "/time-slot-register/{id}";
        }

        public static class MasterPlans
        {
            public const string GetAll = Base + "/master-plan/";
            public const string Get = Base + "/master-plan/{id}";
            public const string Create = Base + "/master-plan";
            public const string Update = Base + "/master-plan/{id}";
            public const string Delete = Base + "/master-plan/{id}";
        }

        public static class SemesterPlans
        {
            public const string GetAll = Base + "/semester-plan/";
            public const string Get = Base + "/semester-plan/{id}";
            public const string Create = Base + "/semester-plan";
            public const string Update = Base + "/semester-plan/{id}";
            public const string Delete = Base + "/semester-plan/{id}";
        }
    }
}