using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaylocityChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaylocityChallenge.Services;
using Microsoft.Extensions.Logging;

namespace PaylocityChallenge.Pages.Employees
{
    public class IndexModel : PageModel
    {
       
        
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeBenefitService _employeeBenefitService;
        private readonly ILogger _logger;

        public IEnumerable<Employee> Employees { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public IndexModel(IEmployeeService employeeService, IEmployeeBenefitService employeeBenefitService, ILogger logger)
        {
            this._employeeService = employeeService;
            this._employeeBenefitService = employeeBenefitService;
            this._logger = logger;
        }
        
        public IActionResult OnGet()
        {
            try
            {
                Employees = _employeeService.SearchEmployees(SearchTerm);
                foreach (Employee emp in Employees)
                {
                    // _employeeService.CalculateCosts(emp);
                    _employeeBenefitService.GetYearlyBenefitCost(emp);
                    _employeeBenefitService.GetPayCheckBenefitCost(emp);
                    _employeeBenefitService.GetPayCheckSalaryAfterDeduction(emp);
                    _employeeBenefitService.GetYearlySalaryAfterDeduction(emp);
                };

                return Page();
            }

            catch(ServiceException ex)
            {
                _logger.LogError("Error On Employees Page: ErroCode: {0}, Message {1}", ex.ErrorCode, ex.ToString());
                throw ex;
            }

        }
    }
}
