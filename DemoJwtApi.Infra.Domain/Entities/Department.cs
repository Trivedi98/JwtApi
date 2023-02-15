using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJwtApi.Infra.Domain.Entities
{
    public class Department
    {
        public Department() { }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }


    }
}

