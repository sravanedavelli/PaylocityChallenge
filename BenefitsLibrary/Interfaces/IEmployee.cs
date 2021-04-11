using System.Collections.Generic;

namespace PaylocityChallenge.Models
{
    public interface IEmployee
    {
        int Id { get; set; }
        int Age { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        
        decimal PayCheckSalary { get; set; }
        decimal YearlySalary { get; set; }
        decimal PayCheckBenefitCost { get; set; }
        decimal YearlyBenefitCost { get; set; }
        List<Dependent> Dependents { get; set; }
    }
}