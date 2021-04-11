This Application has been constructed using .NET Core 3.1 using razor pages architechture which uses MVVM Pattern.

All the class libraries are build using .NET Standard 2.0

The repository layer PaylocityChallenge.Repository has been implemented to run with SQL database as well as runtime memory implementation.
If you dont want to run all the database scripts, please change the settings in container to use a mock repository.


The IEmployeeRepository concrete implementation should be marked to MockEmployeeRepository in  the code below on Startup.cs

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

AutoMapper nuget package has been used for mapping the objects across the layers.

All the unit tests are built using XUnit framework. Used Moq as mockign framework on unittests.

Frontend of the application is built using Bootstrap.

