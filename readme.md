**Employee benefits calculator**

One of the critical functions that we provide for our clients is the ability to pay for their employees’ benefits packages. A portion of these costs are deducted from their paycheck, and we handle that deduction. Please demonstrate how you would code the following scenario:
	• The cost of benefits is $1000/year for each employee
	• Each dependent (children and possibly spouses) incurs a cost of $500/year
	• Anyone whose name starts with ‘A’ gets a 10% discount, employee or dependent
We’d like to see this calculation used in a web application where employers input employees and their dependents, and get a preview of the costs. This is of course a contrived example. We want to know how youwould implement the application structure and calculations and get a brief preview of how you work.
Please implement a web application based on these assumptions:
	• All employees are paid $2000 per paycheck before deductions
	• There are 26 paychecks in a year

**Installation/Setup**

	•Install .Net framework 4.8.
	•Install SQL Server, but not mandatory. A mock repository has also been implemented for the repository. You can run the application with the data in memory at run time.

The repository class library PaylocityChallenge.Repository has been implemented to run with SQL database as well as runtime memory implementation. If you do not want to run all the database scripts, please change the settings in container to use a mock repository.
The IEmployeeRepository concrete implementation should be marked to MockEmployeeRepository  in the code below on Startup.cs
        
	
	public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IEmployeeBenefitService, EmployeeBenefitService>();
            //services.AddTransient<IEmployeeRepository, MockEmployeeRepository>();
            services.AddTransient<IEmployeeRepository, SQLEmployeeRepository>();
            services.AddTransient<IEmployeeBenefitsRepository, SQLEmployeeBenefitsRepository>();
            services.AddTransient<ISqlDataAccess, SqlDataAccess>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton(typeof(ILogger), typeof(Logger<Startup>));
        }

**Technologies Used**

• .Net Core 3.1 using razor pages (MVVM pattern).
• Bootstrap, javascript and Jquery for front end.
• Auto Mapper for mapping objects across layers.
• Dapper micro ORM object mapper to query the database.
• Xunit framework with Moq for unite tests.
• Nlog is used for writing logs.
• Sql server.

**Sample Screens**

![image](https://user-images.githubusercontent.com/55157295/114337926-e17b5f00-9b06-11eb-8ab3-c4db43019f62.png)
![image](https://user-images.githubusercontent.com/55157295/114337935-e809d680-9b06-11eb-82c9-0d846f1df996.png)
![image](https://user-images.githubusercontent.com/55157295/114337944-eb04c700-9b06-11eb-9679-996e72be4413.png)
![image](https://user-images.githubusercontent.com/55157295/114337953-ee984e00-9b06-11eb-9484-ae84a13df3d4.png)

**Things to note**

• All the application layers are built with dependency injection.
• MockEmployeeRepository has been built to run  the application with out installing the SQL scripts.
• Application is configured to write logs to C:\PaylocdityChallengeLogs. Please change that in launchsettings.json.
• ServviceException class has been implemented to give error codes to exceptions. This would help in easy monitoring in tools like splunk or appdynamics.






