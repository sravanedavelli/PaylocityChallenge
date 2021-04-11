using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaylocityChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaylocityChallenge.Repository;
using PaylocityChallenge.Services;
using Microsoft.Extensions.Logging;

namespace PaylocityChallenge.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeBenefitService _employeeBenefitService;
        private readonly ILogger _logger;

        public DetailsModel(IEmployeeService employeeService, IEmployeeBenefitService employeeBenefitService, ILogger logger)
        {
            this._employeeService = employeeService;
            this._employeeBenefitService = employeeBenefitService;
            this._logger = logger;
        }

        public Employee Employee { get; private set; }


        public IActionResult OnGet(int id =1 )
        {
            try
            {
                Employee = _employeeService.GetEmployee(id);
                _employeeBenefitService.GetYearlyBenefitCost(Employee);
                _employeeBenefitService.GetPayCheckBenefitCost(Employee);
                _employeeBenefitService.GetPayCheckSalaryAfterDeduction(Employee);
                _employeeBenefitService.GetYearlySalaryAfterDeduction(Employee);

                if (Employee == null)
                {
                    return RedirectToPage("/NotFound");
                }

                
            }

            catch(ServiceException ex)
            {
                _logger.LogError("Error On Employees Page ErroCode: {0}, Message {1}", ex.ErrorCode, ex.ToString());
                throw ex;
            }

            return Page();
        }
    }
}
