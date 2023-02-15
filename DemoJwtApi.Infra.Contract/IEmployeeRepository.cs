    using DemoJwtApi.Infra.Domain.Entities;
using JwtApi.Shared;

namespace DemoJwtApi.Infra.Contract
{
    public interface IEmployeeRepository
    {

        //Task<List<Employee>> GetEmployee();
        public Task<int> AddEmployee(Employee employee);

        public Task<Employee?> GetEmployeeById(int employeeId);

        public Task<PageList<Employee?>> GetEmployees(int page = 1, int pageSize = 5);

        public Task<PageList<Employee>> GetEmployeeList(string searchTerm = null, int page = 1, int pageSize = 5);

        public Task<int> UpdateEmployee(Employee employee);

        public Task<int> DeleteEmployee(int id);
        public Task<bool> CheckEmployee(int id);
           
    }
}