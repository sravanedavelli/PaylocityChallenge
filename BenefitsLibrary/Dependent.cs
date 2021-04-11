using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PaylocityChallenge.Models
{
    public class Dependent : IDependent
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Dependent First Name is Required")]
        [MinLength(3, ErrorMessage = "FirstName Should Contain atleast 3 Characters")]
        [RegularExpression(@"(?i)^[a-z]+", ErrorMessage = "FirstName should only contain alphabets.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Dependent Last Name is Required")]
        [RegularExpression(@"(?i)^[a-z]+", ErrorMessage = "LastName should only contain alphabets.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Dependent Type is Required")]
        public DependentType Type { get; set; }

        public decimal BenefitCost { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
