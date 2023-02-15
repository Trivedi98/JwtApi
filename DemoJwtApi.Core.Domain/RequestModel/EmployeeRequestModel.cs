using Microsoft.AspNetCore.Http;

namespace DemoJwtApi.Core.Domain.RequestModel
{
    public record EmployeeRequestModel
    {
        public string Name { get; set; }

        //public string Email { get; set; }

       // public string Password { get; set; }


        public DateTime BirthDate { get; set; }

        public int DepartmentId { get; set; }

        public IFormFile CvFile { get; set; }
    }
}