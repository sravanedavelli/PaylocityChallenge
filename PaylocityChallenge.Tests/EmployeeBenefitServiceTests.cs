using PaylocityChallenge.Models;
using Moq;
using PaylocityChallenge.Services;
using System;
using Xunit;

namespace PaylocityChallenge.Tests
{
    public class EmployeeBenefitsServiceTests
    {
        private readonly EmployeeBenefitService _sut;
       private readonly Mock<IEmployeeBenefitService> _employeebenfitsMock = new Mock<IEmployeeBenefitService>();
       
        public EmployeeBenefitsServiceTests()
        {
            _sut = new EmployeeBenefitService();
        }

        [Fact]
        public void TestYearlyBenefitCost_OneActiveDependent()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Sravan",
                LastName = "Edavelli",
                Age = 34,
                Email = "sedavelli@stech.com"
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Elen", LastName = "Edavelli", Type = DependentType.Child, IsActive = true });

            _employeebenfitsMock.Setup(x => x.GetYearlyBenefitCost(_testEmployee));

            //Act
            var Employee = _sut.GetYearlyBenefitCost(_testEmployee);

            //Assert
            Assert.Equal(1500.00m, _testEmployee.YearlyBenefitCost, 2);
        }

        [Fact]
        public void TestYearlyBenefitCost_OneInActiveDependent()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Sravan",
                LastName = "Edavelli",
                Age = 34,
                Email = "sedavelli@stech.com"
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Elen", LastName = "Edavelli", Type = DependentType.Child, IsActive = false });

            _employeebenfitsMock.Setup(x => x.GetYearlyBenefitCost(_testEmployee));

            //Act
            var Employee = _sut.GetYearlyBenefitCost(_testEmployee);

            //Assert
            Assert.Equal(1000.00m, _testEmployee.YearlyBenefitCost, 2);
        }

        [Fact]
        public void TestYearlyBenefitCost_OneActiveDependentFirstNameA()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Sravan",
                LastName = "Edavelli",
                Age = 34,
                Email = "sedavelli@stech.com"
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Alen", LastName = "Edavelli", Type = DependentType.Child, IsActive = true });

            _employeebenfitsMock.Setup(x => x.GetYearlyBenefitCost(_testEmployee));

            //Act
            var Employee = _sut.GetYearlyBenefitCost(_testEmployee);

            //Assert
            Assert.Equal(1450.00m, _testEmployee.YearlyBenefitCost, 2);
        }

        [Fact]
        public void TestYearlyBenefitCost_OneInActiveDependentFirstNameA()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Sravan",
                LastName = "Edavelli",
                Age = 34,
                Email = "sedavelli@stech.com"
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Alen", LastName = "Edavelli", Type = DependentType.Child, IsActive = false });

            _employeebenfitsMock.Setup(x => x.GetYearlyBenefitCost(_testEmployee));

            //Act
            var Employee = _sut.GetYearlyBenefitCost(_testEmployee);

            //Assert
            Assert.Equal(1000.00m, _testEmployee.YearlyBenefitCost, 2);
        }

        [Fact]
        public void TestYearlyBenefitCost_EmployeeFirstNameA_ActiveDependentFirstNameA()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Alex",
                LastName = "Alsentzer",
                Age = 34,
                Email = "sedavelli@stech.com"
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Alen", LastName = "Edavelli", Type = DependentType.Child, IsActive = true });

            _employeebenfitsMock.Setup(x => x.GetYearlyBenefitCost(_testEmployee));

            //Act
            var Employee = _sut.GetYearlyBenefitCost(_testEmployee);

            //Assert
            Assert.Equal(1350.00m, _testEmployee.YearlyBenefitCost, 2);
        }

        [Fact]
        public void TestYearlyBenefitCost_EmployeeFirstNameA_InActiveDependentFirstNameA()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Alex",
                LastName = "Alsentzer",
                Age = 34,
                Email = "sedavelli@stech.com"
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Alen", LastName = "Edavelli", Type = DependentType.Child, IsActive = false });

            _employeebenfitsMock.Setup(x => x.GetYearlyBenefitCost(_testEmployee));

            //Act
            var Employee = _sut.GetYearlyBenefitCost(_testEmployee);

            //Assert
            Assert.Equal(900.00m, _testEmployee.YearlyBenefitCost, 2);
        }

        [Fact]
        public void TestYearlyBenefitCost_Employee_TwoActiveDependents()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Sravan",
                LastName = "Edavelli",
                Age = 34,
                Email = "sedavelli@stech.com"
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Elen", LastName = "Edavelli", Type = DependentType.Child, IsActive = true });
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Rayma", LastName = "Edavelli", Type = DependentType.Spouse, IsActive = true });

            _employeebenfitsMock.Setup(x => x.GetYearlyBenefitCost(_testEmployee));

            //Act
            var Employee = _sut.GetYearlyBenefitCost(_testEmployee);

            //Assert
            Assert.Equal(2000.00m, _testEmployee.YearlyBenefitCost, 2);
        }

        [Fact]
        public void TestYearlyBenefitCost_Employee_ActiveAndInActiveDependents()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Sravan",
                LastName = "Edavelli",
                Age = 34,
                Email = "sedavelli@stech.com"
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Elen", LastName = "Edavelli", Type = DependentType.Child, IsActive = true });
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Rayma", LastName = "Edavelli", Type = DependentType.Spouse, IsActive = false });

            _employeebenfitsMock.Setup(x => x.GetYearlyBenefitCost(_testEmployee));

            //Act
            var Employee = _sut.GetYearlyBenefitCost(_testEmployee);

            //Assert
            Assert.Equal(1500.00m, _testEmployee.YearlyBenefitCost, 2);
        }

        [Fact]
        public void TestPaycheckBenefitCost_OneActiveDependent()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Sravan",
                LastName = "Edavelli",
                Age = 34,
                Email = "sedavelli@stech.com"
                
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Elen", LastName = "Edavelli", Type = DependentType.Child, IsActive = true });

            _employeebenfitsMock.Setup(x => x.GetPayCheckBenefitCost(_testEmployee));

            //Act
            var Employee = _sut.GetPayCheckBenefitCost(_testEmployee);

            //Assert
            Assert.Equal(57.69m, _testEmployee.PayCheckBenefitCost, 2);
        }

        [Fact]
        public void TestPayCheckBenefitCost_OneInActiveDependent()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Sravan",
                LastName = "Edavelli",
                Age = 34,
                Email = "sedavelli@stech.com"
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Elen", LastName = "Edavelli", Type = DependentType.Child, IsActive = false });


            _employeebenfitsMock.Setup(x => x.GetPayCheckBenefitCost(_testEmployee));

            //Act
            var Employee = _sut.GetPayCheckBenefitCost(_testEmployee);

            //Assert
            Assert.Equal(38.46m, _testEmployee.PayCheckBenefitCost, 2);
        }

        [Fact]
        public void TestPayCheckBenefitCost_OneActiveDependentFirstNameA()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Sravan",
                LastName = "Edavelli",
                Age = 34,
                Email = "sedavelli@stech.com"
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Alen", LastName = "Edavelli", Type = DependentType.Child, IsActive = true });

            _employeebenfitsMock.Setup(x => x.GetPayCheckBenefitCost(_testEmployee));

            //Act
            var Employee = _sut.GetPayCheckBenefitCost(_testEmployee);

            //Assert
            Assert.Equal(55.77m, _testEmployee.PayCheckBenefitCost, 2);
        }

        [Fact]
        public void TestPaycheckBenefitCost_EmployeeFirstNameA_ActiveDependentFirstNameA()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Alex",
                LastName = "Alsentzer",
                Age = 34,
                Email = "sedavelli@stech.com"
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Alen", LastName = "Edavelli", Type = DependentType.Child, IsActive = true });

            _employeebenfitsMock.Setup(x => x.GetPayCheckBenefitCost(_testEmployee));

            //Act
            var Employee = _sut.GetPayCheckBenefitCost(_testEmployee);

            //Assert
            Assert.Equal(51.92m, _testEmployee.PayCheckBenefitCost, 2);
        }

        [Fact]
        public void TestPaycheckBenefitCost_EmployeeFirstNameA_InActiveDependentFirstNameA()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Alex",
                LastName = "Alsentzer",
                Age = 34,
                Email = "sedavelli@stech.com"
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Alen", LastName = "Edavelli", Type = DependentType.Child, IsActive = false });

            _employeebenfitsMock.Setup(x => x.GetPayCheckBenefitCost(_testEmployee));

            //Act
            var Employee = _sut.GetPayCheckBenefitCost(_testEmployee);

            //Assert
            Assert.Equal(34.62m, _testEmployee.PayCheckBenefitCost, 2);
        }

        [Fact]
        public void TestPaycheckBenefitCost_Employee_TwoActiveDependents()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Sravan",
                LastName = "Edavelli",
                Age = 34,
                Email = "sedavelli@stech.com"
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Elen", LastName = "Edavelli", Type = DependentType.Child, IsActive = true });
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Rayma", LastName = "Edavelli", Type = DependentType.Spouse, IsActive = true });

            _employeebenfitsMock.Setup(x => x.GetPayCheckBenefitCost(_testEmployee));

            //Act
            var Employee = _sut.GetPayCheckBenefitCost(_testEmployee);

            //Assert
            Assert.Equal(76.92m, _testEmployee.PayCheckBenefitCost, 2);
        }

        [Fact]
        public void TestPaycheckSalary_OneActiveDependent()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Sravan",
                LastName = "Edavelli",
                Age = 34,
                Email = "sedavelli@stech.com"

            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Elen", LastName = "Edavelli", Type = DependentType.Child, IsActive = true });

            _employeebenfitsMock.Setup(x => x.GetPayCheckSalaryAfterDeduction(_testEmployee));

            //Act
            var Employee = _sut.GetPayCheckSalaryAfterDeduction(_testEmployee);

            //Assert
            Assert.Equal(1942.31m, _testEmployee.PayCheckSalary, 2);
        }

        [Fact]
        public void TestPayCheckSalary_OneInActiveDependent()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Sravan",
                LastName = "Edavelli",
                Age = 34,
                Email = "sedavelli@stech.com"
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Elen", LastName = "Edavelli", Type = DependentType.Child, IsActive = false });


            _employeebenfitsMock.Setup(x => x.GetPayCheckSalaryAfterDeduction(_testEmployee));

            //Act
            var Employee = _sut.GetPayCheckSalaryAfterDeduction(_testEmployee);

            //Assert
            Assert.Equal(1961.54m, _testEmployee.PayCheckSalary, 2);
        }

        [Fact]
        public void TestPayCheckSalary_OneActiveDependentFirstNameA()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Sravan",
                LastName = "Edavelli",
                Age = 34,
                Email = "sedavelli@stech.com"
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Alen", LastName = "Edavelli", Type = DependentType.Child, IsActive = true });

            _employeebenfitsMock.Setup(x => x.GetPayCheckSalaryAfterDeduction(_testEmployee));

            //Act
            var Employee = _sut.GetPayCheckSalaryAfterDeduction(_testEmployee);

            //Assert
            Assert.Equal(1944.23m, _testEmployee.PayCheckSalary, 2);
        }

        [Fact]
        public void TestPayCheckSalary_EmployeeFirstNameA_ActiveDependentFirstNameA()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Alex",
                LastName = "Alsentzer",
                Age = 34,
                Email = "sedavelli@stech.com"
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Alen", LastName = "Edavelli", Type = DependentType.Child, IsActive = true });

            _employeebenfitsMock.Setup(x => x.GetPayCheckSalaryAfterDeduction(_testEmployee));

            //Act
            var Employee = _sut.GetPayCheckSalaryAfterDeduction(_testEmployee);

            //Assert
            Assert.Equal(1944.23m, _testEmployee.PayCheckSalary, 2);
        }

        [Fact]
        public void TestPayCheckSalary_EmployeeFirstNameA_InActiveDependentFirstNameA()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Alex",
                LastName = "Alsentzer",
                Age = 34,
                Email = "sedavelli@stech.com"
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Alen", LastName = "Edavelli", Type = DependentType.Child, IsActive = false });

            _employeebenfitsMock.Setup(x => x.GetPayCheckSalaryAfterDeduction(_testEmployee));

            //Act
            var Employee = _sut.GetPayCheckSalaryAfterDeduction(_testEmployee);

            //Assert
            Assert.Equal(1961.54m, _testEmployee.PayCheckSalary, 2);
        }

        [Fact]
        public void TestPayCheckSalary_Employee_TwoActiveDependents()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Sravan",
                LastName = "Edavelli",
                Age = 34,
                Email = "sedavelli@stech.com"
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Elen", LastName = "Edavelli", Type = DependentType.Child, IsActive = true });
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Rayma", LastName = "Edavelli", Type = DependentType.Spouse, IsActive = true });

            _employeebenfitsMock.Setup(x => x.GetPayCheckSalaryAfterDeduction(_testEmployee));

            //Act
            var Employee = _sut.GetPayCheckSalaryAfterDeduction(_testEmployee);

            //Assert
            Assert.Equal(1923.08m, _testEmployee.PayCheckSalary, 2);
        }

        [Fact]
        public void TestYearlySalary_OneActiveDependent()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Sravan",
                LastName = "Edavelli",
                Age = 34,
                Email = "sedavelli@stech.com"

            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Elen", LastName = "Edavelli", Type = DependentType.Child, IsActive = true });

            _employeebenfitsMock.Setup(x => x.GetYearlySalaryAfterDeduction(_testEmployee));

            //Act
            var Employee = _sut.GetYearlySalaryAfterDeduction(_testEmployee);

            //Assert
            Assert.Equal(50500m, _testEmployee.YearlySalary, 2);
        }

        [Fact]
        public void TestYearlySalary_OneInActiveDependent()
        {
            //Arrange
            var _testEmployee = new Employee()
            {
                Id = 1,
                FirstName = "Sravan",
                LastName = "Edavelli",
                Age = 34,
                Email = "sedavelli@stech.com"
            };
            _testEmployee.Dependents.Add(new Dependent() { Id = 1, FirstName = "Elen", LastName = "Edavelli", Type = DependentType.Child, IsActive = false });


            _employeebenfitsMock.Setup(x => x.GetYearlySalaryAfterDeduction(_testEmployee));

            //Act
            var Employee = _sut.GetYearlySalaryAfterDeduction(_testEmployee);

            //Assert
            Assert.Equal(51000m, _testEmployee.YearlySalary, 2);
        }
    }
}
