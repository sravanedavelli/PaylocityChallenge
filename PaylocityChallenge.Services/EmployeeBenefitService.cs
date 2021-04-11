using PaylocityChallenge.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using PaylocityChallenge.Repository.Models;
using PaylocityChallenge.Repository;

namespace PaylocityChallenge.Services
{
    public class EmployeeBenefitService : IEmployeeBenefitService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        IEmployeeBenefitsRepository _employeeBenefitsRepository;
        public EmployeeBenefitService(ILogger<EmployeeBenefitService> logger, IEmployeeBenefitsRepository employeeBenefitsRepository, IMapper mapper)
        { 
            _logger = logger;
            _mapper = mapper;
            _employeeBenefitsRepository = employeeBenefitsRepository;
        }

        public EmployeeBenefitService()
        {

        }
       
        public Employee GetPayCheckSalaryAfterDeduction(Employee employee)
        {
            try
            {
                CalculateYearlyBenefitCosts(employee);
                employee.PayCheckSalary = Constants.EMPLOYEE_PAYCHECK_SALARY - Constants.EMPLOYEE_YEARLY_BENEFITCOST / Constants.NUMBER_OF_PAYCHECKS - (employee.Dependents.Where(e => e.IsActive).Select(d => d.BenefitCost).Sum()) / Constants.NUMBER_OF_PAYCHECKS; //use constant
                return employee;
            }

            catch (Exception ex)
            {
                _logger.LogError("Error in GetPayCheckSalaryAfterDeduction(). ErrorCode: {0}, ExceptionMessage: {1}", 2010, ex.ToString());
                throw new ServiceException("Error in GetPayCheckSalaryAfterDeduction().", ex, 2010);
            }

        }

        public Employee GetYearlySalaryAfterDeduction(Employee employee)
        {
            try
            {
                CalculateYearlyBenefitCosts(employee);
                employee.YearlySalary = Constants.EMPLOYEE_PAYCHECK_SALARY* Constants.NUMBER_OF_PAYCHECKS - Constants.EMPLOYEE_YEARLY_BENEFITCOST  - (employee.Dependents.Where(e => e.IsActive).Select(d => d.BenefitCost).Sum());   
                return employee;
            }

            catch (Exception ex)
            {
                _logger.LogError("Error in GetYearlySalaryAfterDeduction. ErrorCode: {0}, ExceptionMessage: {1}", 2020, ex.ToString());
                throw new ServiceException("Error in GetYearlySalaryAfterDeduction()", ex, 2020);
            }
        }

        public Employee GetPayCheckBenefitCost(Employee employee)
        {
            try
            {
                CalculateYearlyBenefitCosts(employee);
                employee.PayCheckBenefitCost = employee.YearlyBenefitCost / Constants.NUMBER_OF_PAYCHECKS;  /*check for exception; use constants*/
                return employee;
            }

            catch (Exception ex)
            {
                 _logger.LogError("Error in GetPayCheckBenefitCost(). ErrorCode: {0}, ExceptionMessage: {1}", 2030, ex.ToString());
                 throw new ServiceException("Error in GetPayCheckBenefitCost()", ex, 2030);
            }
        }

        public Employee GetYearlyBenefitCost(Employee employee)
        {
            try
            {
                return CalculateYearlyBenefitCosts(employee);
            }

            catch (NullReferenceException ex)
            {
                 _logger.LogError("Error in GetYearlyBenefitCost(). ErrorCode: {0}, ExceptionMessage: {1}", 2041, ex.ToString());
                 throw new ServiceException("Error in GetYearlyBenefitCost()", ex, 2041);
            }

            catch (Exception ex)
            {
                _logger.LogError("Error in GetYearlyBenefitCost(). ErrorCode: {0}, ExceptionMessage: {1}", 2040, ex.ToString());
                throw new ServiceException("Error in GetYearlyBenefitCost.", ex, 2040);
            }
        }

        private Employee CalculateYearlyBenefitCosts(Employee employee)
        {
            employee.YearlyBenefitCost = employee.FirstName.Substring(0, 1).ToUpper().Equals("A") ? (Constants.EMPLOYEE_YEARLY_BENEFITCOST * (100 - Constants.A_DISCOUNT_PERCENT) / 100) : Constants.EMPLOYEE_YEARLY_BENEFITCOST;

            foreach (Dependent dependent in employee.Dependents)
            {
                //check if name is non-empty & not null
                if (!String.IsNullOrEmpty(dependent.FirstName))
                {
                    dependent.BenefitCost = dependent.FirstName.Substring(0, 1).ToUpper().Equals("A") ? (Constants.DEPENDENT_YEARLY_BENEFITCOST * (100 - Constants.A_DISCOUNT_PERCENT) / 100) : Constants.DEPENDENT_YEARLY_BENEFITCOST;
                }
            }

            employee.YearlyBenefitCost = employee.YearlyBenefitCost + employee.Dependents.Where(e => e.IsActive).Select(d => d.BenefitCost).Sum();

            return employee;

        }

        public void AddEmployeeBenefitsCost(Employee employee)
        {
            try
            {
                var _employeedata = _mapper.Map<EmployeeData>(employee);
                _employeeBenefitsRepository.InsertEmployeeBenefitCost(_employeedata);
            }

            catch (Exception ex)
            {
                _logger.LogError("Unable to Add Employee Benefits Costs. ErrorCode: {0}, ExceptionMessage: {1}", 2050, ex.ToString());
                throw new ServiceException("Unable to Add Employee Benefits Costs.", ex, 2050);
            }
        }

        public void UpdateEmployeeBenefitsCost(Employee employee)
        {
            try
            {
                var _employeedata = _mapper.Map<EmployeeData>(employee);
                _employeeBenefitsRepository.UpdateEmployeeBenefitCost(_employeedata);
            }

            catch (Exception ex)
            {
                _logger.LogError("Unable to Update Employee Benefits Costs. ErrorCode: {0}, ExceptionMessage: {1}", 2050, ex.ToString());
                throw new ServiceException("Unable to Update Employee Benefits Costs.", ex, 2060);
            }
        }
    }
}
