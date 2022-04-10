using System.Collections.Generic;

namespace Employee.Repository
{
    public interface IEmployeeRepository
    {
        List<Models.Employee> GetAllEmployees();
    }
}
