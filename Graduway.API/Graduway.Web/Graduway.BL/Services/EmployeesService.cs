using Graduway.BL.Services.Interfaces;
using Graduway.BL.UnitOfWork.Interfaces;
using Graduway.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Graduway.BL.Services
{

    public class EmployeesService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _unitOfWork.EmployeesRepository.Get()
                .OrderBy(x=> x.FirstName);
        }

        public void AddEmployee(Employee employee)
        {
            employee.Id = null;
            _unitOfWork.EmployeesRepository.Insert(employee);
            _unitOfWork.Save();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _unitOfWork.EmployeesRepository.GetByID(employeeId);
        }

        public void UpdateEmployee(Employee updatedEmployee)
        {
            Employee employee = _unitOfWork.EmployeesRepository.GetByID(updatedEmployee.Id);
            employee.FirstName = updatedEmployee.FirstName;
            employee.LastName = updatedEmployee.LastName;
            employee.Title = updatedEmployee.Title;
            employee.Address = updatedEmployee.Address;
            employee.Department = updatedEmployee.Department;
            _unitOfWork.EmployeesRepository.Update(employee);
            _unitOfWork.Save();
        }

        public void DeleteEmployee(int employeeId)
        {
            _unitOfWork.EmployeesRepository.Delete(employeeId);
            _unitOfWork.Save();
        }
    }
}
