using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityChallenge.Repository.Models
{
    public interface IEmployeeData
    {
        int EmployeeId { get; set; }
        int Age { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string EmailId { get; set; }
        decimal PayCheckSalary { get; set; }
        decimal YearlySalary { get; set; }
        decimal PayCheckBenefitCost { get; set; }
        decimal YearlyBenefitCost { get; set; }
        List<DependentData> Dependents { get; set; }
    }
}
