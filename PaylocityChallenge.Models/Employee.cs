using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaylocityChallenge.Models
{
    public class Employee : IEmployee
    {
        public Employee()
        {
            this.Dependents = new List<Dependent>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage ="Employee First Name is Required")]
        [MinLength(3,ErrorMessage = "FirstName Should Contain atleast 3 characters")]
        [RegularExpression(@"(?i)^[a-z]+", ErrorMessage ="FirstName should only contain alphabets.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Employee Last Name is Required")]
        [RegularExpression(@"(?i)^[a-z]+", ErrorMessage = "LastName should only contain alphabets.")]
        public string LastName { get; set; }

        public int Age { get; set; }

        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Email address is invalid.")]
        public string Email { get; set; }

        public decimal PayCheckSalary { get; set; }

        public decimal PayCheckBenefitCost { get; set; }

        public decimal YearlySalary { get; set; }

        public decimal YearlyBenefitCost { get; set; }

        public List<Dependent> Dependents {get; set;}

        public void AddDependent(Dependent dependent)
        {
            this.Dependents.Add(dependent);
        }

    }
}
