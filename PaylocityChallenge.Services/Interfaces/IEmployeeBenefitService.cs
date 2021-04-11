using PaylocityChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityChallenge.Services
{
    public interface IEmployeeBenefitService
    {
        Employee GetPayCheckBenefitCost(Employee employee);
        Employee GetPayCheckSalaryAfterDeduction(Employee employee);
        Employee GetYearlyBenefitCost(Employee employee);
        Employee GetYearlySalaryAfterDeduction(Employee employee);
        void AddEmployeeBenefitsCost(Employee employee);
        void UpdateEmployeeBenefitsCost(Employee employee);
    }
}
