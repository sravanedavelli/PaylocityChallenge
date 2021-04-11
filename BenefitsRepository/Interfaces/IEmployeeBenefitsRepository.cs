using PaylocityChallenge.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityChallenge.Repository
{
    public interface IEmployeeBenefitsRepository
    {
        void InsertEmployeeBenefitCost(EmployeeData employee);
        void UpdateEmployeeBenefitCost(EmployeeData employee);

    }
}
