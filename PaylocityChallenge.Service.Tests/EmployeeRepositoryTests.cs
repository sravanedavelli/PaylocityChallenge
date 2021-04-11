using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenefitsLibrary;
using Moq;
using PaylocityChallenge.Services;
using Xunit;

namespace PaylocityChallenge.Service.Tests
{
//    public class EmployeeRepositoryTests
//    {
//        private readonly MockEmployeeRepository _employeeRespositorySut;
//        private readonly Mock<IEmployeeRepository> _employeeRepoMock = new Mock<IEmployeeRepository>();

//        public EmployeeRepositoryTests()
//        {
//            _employeeRespositorySut = new MockEmployeeRepository(_employeeRepoMock.Object);
//        }

//        [Fact]
//        public void AddEmployee_EmployeeShouldBeAdded()
//        {
//            //Arrange


//            //Act Phase

//            //Assert Phase
//        }

//        [Fact]
//        public void GetEmployee_ShouldReturnEmployee_WhenEmployeeExists()
//        {
//            //Arrange
//            var employeeId = 1;
//            var empFirstName = "Sravan";

//            var arrangeEmployee = new Employee
//            {
//                Id = employeeId,
//                FirstName = empFirstName,
//            };

//            _employeeRepoMock.Setup(x => x.GetEmployee(employeeId)).Returns(arrangeEmployee);


//            //Act
//            var employee = _employeeRespositorySut.GetEmployee(employeeId);

//            //Assert
//            Assert.Equal(expected: employeeId, actual: employee.Id);
//        }

//    }
}
