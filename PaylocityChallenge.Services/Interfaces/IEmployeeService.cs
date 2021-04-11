using PaylocityChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityChallenge.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int Id);
        Employee UpdateEmployee(Employee updatedEmployee);
        Employee AddEmployee(Employee newEmployee);
        IEnumerable<Employee> SearchEmployees(string searchTerm);
    }
}
