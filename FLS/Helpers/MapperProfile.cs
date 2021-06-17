using AutoMapper;
using BLL.Models.Blog.Requests;
using BLL.Models.Blog.Responses;
using BLL.Models.BlogCategory.Requests;
using BLL.Models.BlogCategory.Responses;
using BLL.Models.Department.Requests;
using BLL.Models.Department.Responses;
using BLL.Models.Lecturer.Requests;
using BLL.Models.Lecturer.Responses;
using BLL.Models.LecturerType.Requests;
using BLL.Models.LecturerType.Responses;
using BLL.Models.Role.Requests;
using BLL.Models.Role.Responses;
using BLL.Models.Semester.Requests;
using BLL.Models.Semester.Responses;
using BLL.Models.Subject.Requests;
using BLL.Models.Subject.Responses;
using BLL.Models.TimeSlot.Requests;
using BLL.Models.TimeSlot.Responses;
using BLL.Models.User.Requests;
using BLL.Models.User.Responses;
using DAL.Entities;

namespace FLS.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, CreateUserRequest>().ReverseMap();
            CreateMap<User, UpdateUserRequest>().ReverseMap();
            CreateMap<User, UserInformationResponse>().ReverseMap();
            CreateMap<User, UserProfileResponse>().ReverseMap();
            CreateMap<User, CreateUserResponse>().ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();

            CreateMap<Role, RoleRequest>().ReverseMap();
            CreateMap<Role, RoleResponse>().ReverseMap();

            CreateMap<Subject, SubjectRequest>().ReverseMap();
            CreateMap<Subject, SubjectResponse>().ReverseMap();

            CreateMap<Department, DepartmentRequest>().ReverseMap();
            CreateMap<Department, DepartmentResponse>().ReverseMap();

            CreateMap<Lecturer, LecturerRequest>().ReverseMap();
            CreateMap<Lecturer, LecturerResponse>().ReverseMap();

            CreateMap<LecturerType, LecturerTypeRequest>().ReverseMap();
            CreateMap<LecturerType, LecturerTypeResponse>().ReverseMap();

            CreateMap<Blog, CreateBlogRequest>().ReverseMap();
            CreateMap<Blog, UpdateBlogRequest>().ReverseMap();
            CreateMap<Blog, BlogResponse>().ReverseMap();

            CreateMap<BlogCategory, BlogCategoryRequest>().ReverseMap();
            CreateMap<BlogCategory, BlogCategoryResponse>().ReverseMap();

            CreateMap<Semester, SemesterRequest>().ReverseMap();
            CreateMap<Semester, SemesterResponse>().ReverseMap();

            CreateMap<TimeSlot, TimeSlotRequest>().ReverseMap();
            CreateMap<TimeSlot, TimeSlotResponse>().ReverseMap();

        }
    }
}