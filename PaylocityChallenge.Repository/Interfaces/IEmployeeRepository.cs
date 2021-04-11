using PaylocityChallenge.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityChallenge.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeData> GetAllEmployees();
        EmployeeData GetEmployee(int Id);
        EmployeeData UpdateEmployee(EmployeeData updatedEmployee);
        EmployeeData AddEmployee(EmployeeData newEmployee);
        IEnumerable<EmployeeData> Search(string searchTerm);
    }
}
