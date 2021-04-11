using AutoMapper;
using PaylocityChallenge.Models;
using Microsoft.Extensions.Logging;
using PaylocityChallenge.Repository;
using PaylocityChallenge.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityChallenge.Services
{
    public class EmployeeService : IEmployeeService
    {

        IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
         
        public EmployeeService( IEmployeeRepository employeeRepository, IMapper mapper, ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
             _mapper = mapper;
        }
        public Employee AddEmployee(Employee newEmployee)
        {
            try
            {
                if(newEmployee.FirstName == null)
                {
                    throw new NullReferenceException();
                }
                var _employeedata = _mapper.Map<EmployeeData>(newEmployee);
                _employeedata = _employeeRepository.AddEmployee(_employeedata);
                return _mapper.Map<Employee>(_employeedata);
            }

            catch(NullReferenceException ex)
            {
                _logger.LogError("Employee FirstnameName is Null. ErrorCode: {0}, ExceptionMessage: {1}", 1011, ex.ToString());
                throw new ServiceException("Employee FirstnameName is Null", ex, 1011);
            }
                        
            catch(Exception ex)
            {
                _logger.LogError("Unable to Add Employee. ErrorCode: {0}, ExceptionMessage: {1}", 1010, ex.ToString());
                throw new ServiceException( "Unable to Add Employee.", ex, 1010);
            }            

        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                var _employeeList = _employeeRepository.GetAllEmployees();
                return _mapper.Map<List<Employee>>(_employeeList);
            }

            catch (Exception ex)
            {
                _logger.LogError("Unable to Get All Employees. ErrorCode: {0}, ExceptionMessage: {1}", 1020, ex.ToString());
                throw new ServiceException("Unable to Get All Employees.", ex, 1020);
            }

        }

        public Employee GetEmployee(int Id)
        {
            try
            {
                return _mapper.Map<Employee>(_employeeRepository.GetEmployee(Id));
            }

            catch (Exception ex)
            {
                _logger.LogError("Unable to Get Employee data: ErrorCode: {0}, ExceptionMessage: {1}", 1030, ex.ToString());
                throw new ServiceException("Unable to Get Employee data.", ex, 1030);
            }
        }

        public IEnumerable<Employee> SearchEmployees(string searchTerm)
        {
           
            try
            {
                var _employeeList = string.IsNullOrEmpty(searchTerm) ? _employeeRepository.GetAllEmployees() : _employeeRepository.Search(searchTerm);
                return _mapper.Map<List<Employee>>(_employeeList);
            }
            
            catch (Exception ex)
            {
                _logger.LogError("Unable to Search Employees: ErrorCode: {0}, ExceptionMessage: {1}", 1040, ex.ToString());
                throw new ServiceException("Unable to Search Employees.", ex, 1040);
            }

        }

        public Employee UpdateEmployee(Employee updatedEmployee)
        {
            try
            {
                var _employeedata = _mapper.Map<EmployeeData>(updatedEmployee);
                return _mapper.Map<Employee>(_employeeRepository.UpdateEmployee(_employeedata));
            }
           
            catch (Exception ex)
            {
                _logger.LogError("Unable to Update Employees: ErrorCode: {0}, ExceptionMessage: {1}", 1050, ex.ToString());
                throw new ServiceException("Unable to Update Employee.", ex, 1050);
            }
        }
    }
}
