using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityChallenge.Repository.Models
{
    public class DependentData : IDependentData
    {
        public int? DependentId { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DependentType DependentType { get; set; }
        public int EmployeeID { get; set; }
        public bool IsActive { get; set; }
    }
}
