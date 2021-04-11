using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityChallenge.Repository.Models
{
    public class EmployeeData : IEmployeeData
    {
        public EmployeeData()
        {
            this.Dependents = new List<DependentData>();
        }
        public int EmployeeId { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public decimal PayCheckSalary { get; set; }
        public decimal YearlySalary { get; set; }
        public decimal PayCheckBenefitCost { get; set; }
        public decimal YearlyBenefitCost { get; set; }
        public List<DependentData> Dependents { get; set; }
    }
}
