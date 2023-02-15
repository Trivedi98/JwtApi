using AutoMapper;
using DemoJwtApi.Core.Domain.ResponseModel;
using DemoJwtApi.Infra.Domain.Entities;
using JwtApi.Shared;

namespace DemoJwtApi.Configuration
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeResponseModel>();
            // .ForMember(x => x.EmployeeId, opt => opt.MapFrom(c => c.Id))
            //.ForMember(x => x.EmployeeName, opt => opt.MapFrom(c => c.Name))
            //.ForMember(x => x.DepartmentName, opt => opt.MapFrom(c => c.Department.Name))

            CreateMap<PageList<Employee>, PageList<EmployeeResponseModel>>();
        }
    }
}
