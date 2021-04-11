using Dapper;
using Microsoft.Extensions.Configuration;
using PaylocityChallenge.Repository.Internal.DataAccess;
using PaylocityChallenge.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PaylocityChallenge.Repository
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {

        private readonly IConfiguration _config;
        private readonly ISqlDataAccess _sql;

        public SQLEmployeeRepository(IConfiguration config, ISqlDataAccess sql)
        {
            _config = config;
            _sql = sql;
        }

        public SQLEmployeeRepository()
        {
            
        }
        public EmployeeData AddEmployee(EmployeeData newEmployee)
        {

            try
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dynamicParameters.Add("FirstName", newEmployee.FirstName);
                dynamicParameters.Add("LastName", newEmployee.LastName);
                dynamicParameters.Add("Email", newEmployee.EmailId);

                _sql.SaveData("dbo.spEmployee_Insert", dynamicParameters, "EmployeeBenefits");

                int id = dynamicParameters.Get<int>("Id");

                foreach (DependentData dep in newEmployee.Dependents)
                {
                    if (dep.DependentId == 0)
                    {
                        AddDependent(dep, Convert.ToInt32(id));
                    }

                    else
                    {
                        UpdateDependent(dep);
                    }
                }

                newEmployee.EmployeeId = id;
                return newEmployee;
            }

            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<EmployeeData> GetAllEmployees()
        {
            try
            { 
                var output = _sql.LoadData<EmployeeData, dynamic>("dbo.spEmployee_GetAll", new { }, "EmployeeBenefits");
                foreach (EmployeeData emp in output)
                {
                    emp.Dependents = GetDependentsByEmployeeId(emp.EmployeeId).ToList();
                }

                return output;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmployeeData GetEmployee(int Id)
        {
            try
            {
                var output = _sql.LoadData<EmployeeData, dynamic>("dbo.spEmployee_GetById", new { Id = Id }, "EmployeeBenefits").FirstOrDefault();
                output.Dependents = GetDependentsByEmployeeId(output.EmployeeId).ToList();

                return output;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<EmployeeData> Search(string searchTerm)
        {
            try 
            { 
                var output = _sql.LoadData<EmployeeData, dynamic>("dbo.spEmployee_GetAll", new { SearchTerm = searchTerm }, "EmployeeBenefits");

                return output;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmployeeData UpdateEmployee(EmployeeData updatedEmployee)
        {
            try
            {
                _sql.LoadData<EmployeeData, dynamic>("dbo.spEmployee_Update", new { updatedEmployee.FirstName, updatedEmployee.LastName, updatedEmployee.EmailId, updatedEmployee.EmployeeId }, "EmployeeBenefits").FirstOrDefault();

                foreach (DependentData dep in updatedEmployee.Dependents)
                {
                    if (dep.DependentId > 0)
                    {
                        UpdateDependent(dep);
                    }

                    else
                    {
                        AddDependent(dep, updatedEmployee.EmployeeId);
                    }
                }

                return GetEmployee(updatedEmployee.EmployeeId);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IEnumerable<DependentData> GetDependentsByEmployeeId(int employeeId)
        {
            try
            {
                var output = _sql.LoadData<DependentData, dynamic>("dbo.spDependent_GetByEmployeeId", new { EmployeeId = employeeId }, "EmployeeBenefits");

                return output;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddDependent(DependentData newDependent, int employeeId)
        {
            try
            {
                _sql.LoadData<EmployeeData, dynamic>("dbo.spDependent_Insert", new { newDependent.FirstName, newDependent.LastName, DependentType = newDependent.DependentType, EmployeeId = employeeId, IsActive = newDependent.IsActive }, "EmployeeBenefits");
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateDependent(DependentData updatedDependent)
        {
            try
            {
                _sql.LoadData<EmployeeData, dynamic>("dbo.spDependent_Update", new { updatedDependent.FirstName, updatedDependent.LastName, DependentType = updatedDependent.DependentType, DependentId = updatedDependent.DependentId, IsActive = updatedDependent.IsActive }, "EmployeeBenefits");
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
