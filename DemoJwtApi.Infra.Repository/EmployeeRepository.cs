
using DemoJwtApi.Infra.Contract;
using DemoJwtApi.Infra.Domain;
using DemoJwtApi.Infra.Domain.Entities;
using JwtApi.Shared;
using Microsoft.EntityFrameworkCore;

namespace DemoJwtApi.Infra.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
       
        public async Task<int> AddEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            return await _context.SaveChangesAsync();
        }
        
        
        //public async Task<List<Employee>> GetEmployee()
        //{
        //    try
        //    {
        //        var employee = _context.Employees.Include(e => e.Department).ToList();
        //        return employee;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        public async Task<Employee?> GetEmployeeById(int employeeId)
        {
            var employee = await _context.Employees.Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == employeeId);
            return employee;
        }

        public Task<List<Employee>> GetEmployeeList(string searchTerm)
        {
            throw new NotImplementedException();
        }
        public async Task<PageList<Employee>> GetEmployeeList(string searchTerm, int page = 1, int pageSize = 10)
        {
            try
            {
                var employees = _context.Employees.Include(x => x.Department).Where(x => !x.IsDeleted).OrderByDescending(x => x.CreatedOn).AsQueryable();
                //var employees1 = _context.Employees.Include(x => x.Department).Where(x => !x.IsDeleted).OrderByDescending(x => x.CreatedOn).ToList();
                if (!string.IsNullOrEmpty(searchTerm))
                {

                    employees = employees.Where(x => EF.Functions.Like(x.Name, $"%{searchTerm}%") || EF.Functions.Like(x.Department.Name, $"%{searchTerm}%"));

                }
                var count = await employees.LongCountAsync();
                var pageList = employees.ToPageList(page, pageSize, count);

                return pageList;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<PageList<Employee>> GetEmployees(int page = 1, int pageSize = 5)
        {
            try
            {
                var employees = _context.Employees.Include(e => e.Department).AsQueryable();
                var count = await employees.LongCountAsync();
                var pageList = employees.ToPageList(page, pageSize, count);
                return pageList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckEmployee(int id)
        {
            return _context.Employees.Any(x => x.Id == id);
        }

        public async Task<int>DeleteEmployee(int id)
        {
            var del=await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if(del==null)
            {
                throw new Exception("employee Not Exist");
            }
            _context.Employees.Remove(del);
            return await _context.SaveChangesAsync();   
        }

    }
}