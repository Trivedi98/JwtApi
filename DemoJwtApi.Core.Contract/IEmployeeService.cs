using DemoJwtApi.Core.Domain.RequestModel;
using DemoJwtApi.Core.Domain.ResponseModel;
using JwtApi.Shared;

namespace DemoJwtApi.Core.Contract
{
    public interface IEmployeeService
    {
        public Task AddEmployeeAsync(EmployeeRequestModel Employee);

        //public Task<List<EmployeeResponseModel>> GetEmployeeAsync();

        Task<PageList<EmployeeResponseModel?>> GetEmployeesAsync(int page = 1, int pageSize = 5);

        Task<PageList<EmployeeResponseModel>> GetEmployeeListAsync(string searchTerm = null, int page = 1, int pageSize = 5);
        public Task UpdateEmployeeAsync(EmployeeRequestModel Employee, int employeeId);
        public Task DeleteEmployeeAsync(int id);

        public Task<bool> CheckEmployee(int id);
    }
}