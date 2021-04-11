using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityChallenge.Repository.Models
{
    public interface IDependentData
    {
        int? DependentId { get; set; }
        int Age { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DependentType DependentType { get; set; }
        int EmployeeID { get; set; }
        bool IsActive { get; set; }
    }
}
