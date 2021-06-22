using BLL.BusinessLogics;
using BLL.Interfaces;
using FLS.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FLS.Installers
{
    public class DependencyInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenManager, TokenManager>();
            services.AddScoped<ITimeConvert, TimeConvert>();
            services.AddScoped<IGuestBL, GuessBL>();
            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<IRoleBL, RoleBL>();
            services.AddScoped<ISubjectBL, SubjectBL>();
            services.AddScoped<IDepartmentBL, DepartmentBL>();
            services.AddScoped<ILecturerBL, LecturerBL>();
            services.AddScoped<ILecturerTypeBL, LecturerTypeBL>();
            services.AddScoped<IBlogBL, BlogBL>();
            services.AddScoped<IBlogCategoryBL, BlogCategoryBL>();
            services.AddScoped<ISemesterBL, SemesterBL>();
            services.AddScoped<ITimeSlotBL, TimeSlotBL>();
            services.AddScoped<ICourseBL, CourseBL>();
            services.AddScoped<IDepartmentBlogBL, DepartmentBlogBL>();
            services.AddScoped<ILecturerRatingBL, LecturerRatingBL>();
            services.AddScoped<ISemesterRegisterBL, SemesterRegisterBL>();
            services.AddScoped<ISubjectRegisterBL, SubjectRegisterBL>();
            services.AddScoped<ITeachableSubjectBL, TeachableSubjectBL>();
            services.AddScoped<ITimeSlotRegisterBL, TimeSlotRegisterBL>();
            services.AddScoped<IMasterPlanBL, MasterPlanBL>();
        }
    }
}