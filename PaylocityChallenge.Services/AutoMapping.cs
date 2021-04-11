using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using PaylocityChallenge.Models;
using PaylocityChallenge.Repository.Models;

namespace PaylocityChallenge.Services
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<Employee, EmployeeData>()
                .ForMember(empdata => empdata.FirstName, emp => emp.MapFrom(empp => empp.FirstName))
                .ForMember(empdata => empdata.LastName, emp => emp.MapFrom(empp => empp.LastName))
                .ForMember(empdata => empdata.EmailId, emp => emp.MapFrom(empp => empp.Email))
                .ForMember(empdata => empdata.EmployeeId, emp => emp.MapFrom(empp => empp.Id))                
                .ReverseMap();


            CreateMap<Dependent, DependentData>()
                .ForMember(depData => depData.FirstName, dep => dep.MapFrom(depp => depp.FirstName))
                .ForMember(depData => depData.LastName, dep => dep.MapFrom(depp => depp.LastName))
                .ForMember(depData => depData.DependentType, dep => dep.MapFrom(depp => depp.Type))
                .ForMember(depData => depData.DependentId, dep => dep.MapFrom(depp => depp.Id))
                .ForMember(depData => depData.IsActive, dep => dep.MapFrom(depp => depp.IsActive))
                .ReverseMap();

        }
    }
}
