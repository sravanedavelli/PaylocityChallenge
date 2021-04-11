using Dapper;
using Microsoft.Extensions.Configuration;
using PaylocityChallenge.Repository.Internal.DataAccess;
using PaylocityChallenge.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityChallenge.Repository
{
    public class SQLEmployeeBenefitsRepository : IEmployeeBenefitsRepository
    {
        private readonly IConfiguration _config;
        private readonly ISqlDataAccess _sql;

        public SQLEmployeeBenefitsRepository(IConfiguration config, ISqlDataAccess sql)
        {
            _config = config;
            _sql = sql;
        }
        public void InsertEmployeeBenefitCost(EmployeeData employee)
        {
            try
            {
                _sql.SaveData("dbo.spEmployeeBenefitCost_Insert", new { EmployeeID = employee.EmployeeId, PayCheckBenefitCost = employee.PayCheckBenefitCost, PayCheckSalary = employee.PayCheckSalary, YearlyBenefitCost = employee.YearlyBenefitCost, YearlySalary =  employee.YearlySalary }, "EmployeeBenefits");
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateEmployeeBenefitCost(EmployeeData employee)
        {
            try
            {
                _sql.SaveData("dbo.spEmployeeBenefitCost_Update", new { EmployeeID = employee.EmployeeId, PayCheckBenefitCost = employee.PayCheckBenefitCost, PayCheckSalary = employee.PayCheckSalary, YearlyBenefitCost = employee.YearlyBenefitCost, YearlySalary = employee.YearlySalary }, "EmployeeBenefits");
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
