using DemoJwtApi.Core.Domain.RequestModel;
using DemoJwtApi.Infra.Domain.Entities;

namespace DemoJwtApi.Core.Builder
{
    public class EmployeeBuilder
    {

        public static Employee Build(EmployeeRequestModel model, string cvkey)
        {
            return new Employee(model.Name, model.BirthDate, model.DepartmentId, cvkey);

        }

    }
}