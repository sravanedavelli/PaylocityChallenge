using AutoMapper;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using PaylocityChallenge.Models;
using PaylocityChallenge.Repository;
using PaylocityChallenge.Repository.Models;
using PaylocityChallenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PaylocityChallenge.Tests
{
    public class EmployeeServiceTests
    {

        private readonly EmployeeService _sut;
        private readonly IMapper _mapper;
        private readonly Mock<IEmployeeRepository> _employeeRepoMock = new Mock<IEmployeeRepository>();
        private readonly Mock<ILogger<EmployeeService>> _loggerMock = new Mock<ILogger<EmployeeService>>();

        private static List<EmployeeData> _employeeList;

        public EmployeeServiceTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapping());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            _sut = new EmployeeService(_employeeRepoMock.Object, _mapper, _loggerMock.Object);

            CreateSomeMockRepoObjects();
        }

        private List<EmployeeData> CreateSomeMockRepoObjects()
        {
            if (_employeeList == null)
            {
                _employeeList = new List<EmployeeData>()
                {
                    new EmployeeData(){EmployeeId=1,FirstName="EmployeeOne",LastName="LastOne", Age= 34, EmailId="fLastOne@stech.com", },
                    new EmployeeData(){EmployeeId=2,FirstName="EmployeeTwo",LastName="LastTwo", Age= 26,EmailId="fLastTwo@stech.com" },
                    new EmployeeData(){EmployeeId=3,FirstName="EmployeeThree",LastName="LastThree", Age= 22,EmailId="fLastThree@stech.com" },
                    new EmployeeData(){EmployeeId=4,FirstName="EmployeeFour",LastName="LastFour", Age= 45,EmailId="fLastFour@stech.com" },
                };

                _employeeList.FirstOrDefault(e => e.EmployeeId == 1).Dependents.Add(new DependentData() { DependentId = 1, FirstName = "EmpOneDependentOne", LastName = "LastOne", DependentType = Repository.Models.DependentType.Child, IsActive = true });
                _employeeList.FirstOrDefault(e => e.EmployeeId == 1).Dependents.Add(new DependentData() { DependentId = 2, FirstName = "EmpOneDependentTwo", LastName = "LastOne", DependentType = Repository.Models.DependentType.Spouse, Age = 30, IsActive = true });


                _employeeList.FirstOrDefault(e => e.EmployeeId == 2).Dependents.Add(new DependentData() { DependentId = 3, FirstName = "EmpTwoDependentOne", LastName = "LastTwo", DependentType = Repository.Models.DependentType.Child, IsActive = true });
                _employeeList.FirstOrDefault(e => e.EmployeeId == 2).Dependents.Add(new DependentData() { DependentId = 4, FirstName = "EmpTwoDependentTwo", LastName = "LastTwo", DependentType = Repository.Models.DependentType.Child, IsActive = true });
                _employeeList.FirstOrDefault(e => e.EmployeeId == 2).Dependents.Add(new DependentData() { DependentId = 5, FirstName = "EmpTwoDependentThree", LastName = "LastTwo", DependentType = Repository.Models.DependentType.Spouse, Age = 25, IsActive = true });

                _employeeList.FirstOrDefault(e => e.EmployeeId == 3).Dependents.Add(new DependentData() { DependentId = 6, FirstName = "EmpThreeDependentOne", LastName = "LastThree", DependentType = Repository.Models.DependentType.Child, IsActive = true });
                _employeeList.FirstOrDefault(e => e.EmployeeId == 3).Dependents.Add(new DependentData() { DependentId = 7, FirstName = "EmpThreeDependentTwo", LastName = "LastThree", DependentType = Repository.Models.DependentType.Spouse, IsActive = true });

            }

            return _employeeList;

        }
        [Fact]
        public void TestAddEmployee_SearchShouldReturnEmployee()
        {
            //Arrange
            _employeeRepoMock.Setup<EmployeeData>(m => m.AddEmployee(It.IsAny<EmployeeData>())).Returns(_employeeList.FirstOrDefault(e => e.EmployeeId == 1));

            //Act
            var outputemployee = _sut.AddEmployee(new Employee { FirstName = "EmployeeOne" });

            //Assert
            Assert.IsType<Employee>(outputemployee);
            Assert.Equal<int>(1, outputemployee.Id);

        }

        [Fact]
        public void TestAddEmployee_ShouldThrowServiceExceptionWithErrorCode1011()
        {
            //Arrange
            _employeeRepoMock.Setup<EmployeeData>(m => m.AddEmployee(It.IsAny<EmployeeData>())).Returns(_employeeList.FirstOrDefault(e => e.EmployeeId == 1));

            //Act and Assert
            var ex = Assert.Throws<ServiceException>(() => _sut.AddEmployee(new Employee { }));
            Assert.Equal(1011,ex.ErrorCode);

        }

        [Fact]
        public void TestSearchEmployee_ShouldReturnRightEmployee()
        {
             //Arrange          
            _employeeRepoMock.Setup<IEnumerable<EmployeeData>>(m => m.Search(It.IsAny<String>())).Returns(_employeeList);

            //Act
            var outputemployees = _sut.SearchEmployees("EmployeeOne");
            var someInsideData = outputemployees.FirstOrDefault().GetType().GetProperty("FirstName").GetValue(outputemployees.FirstOrDefault(), null);

            //Assert
            Assert.Equal("EmployeeOne", someInsideData);

        }

        [Fact]
        public void TestGetEmployee_ShouldReturnRightEmployee()
        {
            //Arrange          
            _employeeRepoMock.Setup<EmployeeData>(m => m.GetEmployee(It.IsAny<int>())).Returns(_employeeList.FirstOrDefault(e => e.EmployeeId == 2));

            //Act
            var outputemployee = _sut.GetEmployee(2);

            //Assert
            Assert.Equal("EmployeeTwo", outputemployee.FirstName);
            Assert.Equal(2, outputemployee.Id);
            Assert.Equal(3, outputemployee.Dependents.Count);

        }
    }
}
