using PaylocityChallenge.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DependentType = PaylocityChallenge.Repository.Models.DependentType;

namespace PaylocityChallenge.Repository
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private static List<EmployeeData> _employeeList;

        public MockEmployeeRepository()
        {

        }
        public IEnumerable<EmployeeData> GetAllEmployees()
        {
            if (_employeeList == null)
            {
                _employeeList = new List<EmployeeData>()
                {
                    new EmployeeData(){EmployeeId=1,FirstName="Sravan",LastName="Edavelli", Age= 34, EmailId="sedavelli@stech.com", },
                    new EmployeeData(){EmployeeId=2,FirstName="Mark",LastName="Senti", Age= 26,EmailId="msenti@stech.com" },
                    new EmployeeData(){EmployeeId=3,FirstName="John",LastName="Wu", Age= 22,EmailId="jwu@stech.com" },
                    new EmployeeData(){EmployeeId=4,FirstName="Sophie",LastName="Chowdary", Age= 45,EmailId="schowdary@stech.com" },
                };

                _employeeList.FirstOrDefault(e => e.EmployeeId == 1).Dependents.Add(new DependentData() { DependentId = 1, FirstName = "Elen", LastName = "Edavelli", DependentType = DependentType.Child, IsActive = true });
                _employeeList.FirstOrDefault(e => e.EmployeeId == 1).Dependents.Add(new DependentData() { DependentId = 2, FirstName = "Rayma", LastName = "Edavelli", DependentType = DependentType.Spouse, Age = 30, IsActive = true });


                _employeeList.FirstOrDefault(e => e.EmployeeId == 2).Dependents.Add(new DependentData() { DependentId = 3, FirstName = "Mike", LastName = "Senti", DependentType = DependentType.Child, IsActive = true });
                _employeeList.FirstOrDefault(e => e.EmployeeId == 2).Dependents.Add(new DependentData() { DependentId = 4, FirstName = "Ana", LastName = "Senti", DependentType = DependentType.Child, IsActive = true });
                _employeeList.FirstOrDefault(e => e.EmployeeId == 2).Dependents.Add(new DependentData() { DependentId = 5, FirstName = "Dave", LastName = "Senti", DependentType = DependentType.Spouse, Age = 25, IsActive = true });

                _employeeList.FirstOrDefault(e => e.EmployeeId == 3).Dependents.Add(new DependentData() { DependentId = 6, FirstName = "Alex", LastName = "Wu", DependentType = DependentType.Child, IsActive = true });
                _employeeList.FirstOrDefault(e => e.EmployeeId == 3).Dependents.Add(new DependentData() { DependentId = 7, FirstName = "Roxy", LastName = "Wu", DependentType = DependentType.Spouse, Age = 32, IsActive = true });
              
            }

            return _employeeList;
        }

        public EmployeeData GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.EmployeeId == Id);
        }

        public EmployeeData UpdateEmployee(EmployeeData updatedEmployee)
        {
            EmployeeData employee = _employeeList.FirstOrDefault(e => e.EmployeeId == updatedEmployee.EmployeeId);

            if (employee != null)
            {
                employee.FirstName = updatedEmployee.FirstName;
                employee.LastName = updatedEmployee.LastName;
                employee.EmailId = updatedEmployee.EmailId;

                employee.Dependents = updatedEmployee.Dependents;
            }

            return employee;
        }

        public IEnumerable<EmployeeData> Search(string searchTerm = null)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return GetAllEmployees();
            }

            return GetAllEmployees().Where(e => e.FirstName.ToUpper().Contains(searchTerm.ToUpper()));

        }
               
        public EmployeeData AddEmployee(EmployeeData newEmployee)
        {
            newEmployee.EmployeeId = GetAllEmployees().Max(e => e.EmployeeId) + 1;
            _employeeList.Add(newEmployee);
            return newEmployee;
        }
    }

}
