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
    public class EditModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeBenefitService _employeeBenefitService;
        private readonly ILogger _logger;

        public EditModel(IEmployeeService employeeService, IEmployeeBenefitService employeeBenefitService, ILogger logger)
        {
            this._employeeService = employeeService;
            this._employeeBenefitService = employeeBenefitService;
            this._logger = logger;
        }

        [BindProperty]
        public Employee Employee { get; set; }

         public IActionResult OnGet(int? id)
        {

            try
            {
                if (id.HasValue)
                {
                    Employee = _employeeService.GetEmployee(id.Value);
                }

                else
                {
                    Employee = new Employee();
                }

                if (Employee == null)
                {
                    return RedirectToPage("/NotFound");
                }

                return Page();
            }

            catch (ServiceException ex)
            {
                _logger.LogError("Error OnGet() Edit Employees Page", ex.ToString());
                throw ex;
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                var temp = Employee;
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                if (ModelState.IsValid)
                {

                    if (Employee.Id > 0)
                    {
                        Employee = _employeeService.UpdateEmployee(Employee);
                        CalculateCosts(Employee);
                        _employeeBenefitService.UpdateEmployeeBenefitsCost(Employee);
                    }

                    else
                    {
                        Employee = _employeeService.AddEmployee(Employee);
                        CalculateCosts(Employee);
                        _employeeBenefitService.AddEmployeeBenefitsCost(Employee);
                    }

                    return RedirectToPage("Index");
                }

                return Page();
            }

            catch (ServiceException ex)
            {
                _logger.LogError("Error OnPost() Edit Employees Page. ErroCode: {0}, Message {1}", ex.ErrorCode,  ex.ToString());
                throw ex;
            }
        }

        private Employee CalculateCosts(Employee employee)
        {
            _employeeBenefitService.GetYearlyBenefitCost(employee);
            _employeeBenefitService.GetPayCheckBenefitCost(employee);
            _employeeBenefitService.GetPayCheckSalaryAfterDeduction(employee);
            _employeeBenefitService.GetYearlySalaryAfterDeduction(employee);

            return employee;
        }
    }
}
