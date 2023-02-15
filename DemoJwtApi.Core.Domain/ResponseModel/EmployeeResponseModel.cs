using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJwtApi.Core.Domain.ResponseModel
{
    public record EmployeeResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string DepartmentName { get; set; }
    }
}
