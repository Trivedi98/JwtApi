using AutoMapper;
using DemoJwtApi.Core.Builder;
using DemoJwtApi.Core.Contract;
using DemoJwtApi.Core.Domain.RequestModel;
using DemoJwtApi.Core.Domain.ResponseModel;
using DemoJwtApi.Core.Services.Helper;
using DemoJwtApi.Infra.Contract;
using DemoJwtApi.Infra.Domain.Entities;
using JwtApi.Shared;

namespace DemoJwtApi.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IFileUpload _fileUpload;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IFileUpload fileUpload)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _fileUpload = fileUpload;
        }

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        
        
      public async Task AddEmployeeAsync(EmployeeRequestModel Employee)
        {
            try
            {
                var fileKey = await _fileUpload.UploadCv(Employee.CvFile);

                var employee = EmployeeBuilder.Build(Employee, fileKey);

                var count = await _employeeRepository.AddEmployee(employee);

                if (count == 0)
                {
                    throw new Exception("Employee is not Created properly");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        
        //public async Task<List<EmployeeResponseModel>> GetEmployeeAsync()
        //{
        //    try
        //    {
        //        var employee = await _employeeRepository.GetEmployee();
        //        var result = _mapper.Map<List<EmployeeResponseModel>>(employee);
        //        return result;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}


        public async Task<PageList<EmployeeResponseModel>> GetEmployeesAsync(int page = 1, int pageSize = 5)
        {
            try
            {
                var employees = await _employeeRepository.GetEmployees(page, pageSize);
                var result = _mapper.Map<PageList<EmployeeResponseModel>>(employees);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<PageList<EmployeeResponseModel>> GetEmployeeListAsync(string searchTerm = null, int page = 1, int pageSize = 5)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeList(searchTerm, page, pageSize);
                var result = _mapper.Map<PageList<EmployeeResponseModel>>(employee);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            try
            {
                
                var employee = await _employeeRepository.GetEmployeeById(id);

                if (employee == null)
                {
                    throw new Exception("EmployeeID Not Found");
                }

                employee.Delete();

                var count = await _employeeRepository.UpdateEmployee(employee);

                if (count == 0)
                {
                    throw new Exception("employee Is Not Updated Succsefully");
                }
            }

            catch (Exception)
            {
                throw;
            }

        }
        public async Task UpdateEmployeeAsync(EmployeeRequestModel employee, int employeeId)
        {
            try
            {
                var employees = await _employeeRepository.GetEmployeeById(employeeId);
                if (employees == null)
                {
                    throw new Exception("EmployeeID Not Found");
                }

                //var photo = await _fileUpload.UploadCv(employee.CvFile);
                employees.Update(employee.Name, employee.BirthDate, employee.DepartmentId);
                var count = await _employeeRepository.UpdateEmployee(employees);
                if (count == 0)
                {
                    throw new Exception("Employee is not Updated Succesfully");

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Task<bool> CheckEmployee(int id)
        {

            return _employeeRepository.CheckEmployee(id);
        }


    }

}
