using DemoJwtApi.Core.Contract;
using DemoJwtApi.Core.Services;
using DemoJwtApi.Core.Services.Helper;
using DemoJwtApi.Infra.Contract;
using DemoJwtApi.Infra.Repository;

namespace DemoJwtApi.Configuration
{
    public static class DependencyConfiguration
    {
        public static void AddDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddTransient<FileUpload>();


        }
    }
}
