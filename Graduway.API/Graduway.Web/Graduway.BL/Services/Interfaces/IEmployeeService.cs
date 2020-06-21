using Graduway.DAL.Entities;
using System.Collections.Generic;

namespace Graduway.BL.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
        void AddEmployee(Employee employee);
        Employee GetEmployeeById(int employeeId);
        void UpdateEmployee(Employee updatedEmployee);
        void DeleteEmployee(int employeeId);
    }
}