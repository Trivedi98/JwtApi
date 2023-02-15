using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJwtApi.Infra.Domain.Entities
{
    public class Employee : Audit
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? JobTitle { get; set; }

        public DateTime BirthDate { get; set; }

        public int DepartmentId { get; set; }

        public string CvFile { get; set; }

        public virtual Department Department { get; set; }

        public Employee() { }

        public Employee(string name, DateTime Birthdate, int departmentId, string cvFile)
        {
            Name = name;
            //Email = email;
            //Password = password;
            BirthDate = Birthdate;
            DepartmentId = departmentId;
            CvFile = cvFile;
            CreatedOn = DateTime.UtcNow;
            IsDeleted = false;
        }
        public Employee Delete()
        {
            UpdatedOn = DateTime.UtcNow;
            IsDeleted = true;
            return this;
        }

        public Employee Update(string name, DateTime Birthdate, int departmentId)
        {
            Name = name;
            BirthDate = Birthdate;
            DepartmentId = departmentId;
            UpdatedOn = DateTime.UtcNow;

            return this;
        }
    }
}
