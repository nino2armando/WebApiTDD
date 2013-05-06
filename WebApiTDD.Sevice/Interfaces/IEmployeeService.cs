using System.Collections.Generic;
using WebApiTDD.DataContract;

namespace WebApiTDD.Sevice.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee FindById(object id);
    }
}
