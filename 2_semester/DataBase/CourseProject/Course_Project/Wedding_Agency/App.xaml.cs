using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Wedding_Agency.Models;
using Wedding_Agency.Services;
using Wedding_Agency.Views;

namespace Wedding_Agency
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;
        public App()
        {
            ServiceCollection services = new();
            services.AddDbContext<WeddingAgencyContext>();
            services.AddTransient<MainWindow>();
            services.AddTransient<AuthorizationView>();
            services.AddTransient<ContractView>();
            services.AddTransient<CreateContractView>();
            services.AddTransient<EmployeeView>();
            services.AddTransient<CreateEmployeeView>();
            services.AddTransient<EditEmployeeView>();

            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddScoped<ICreateContractService, CreateContractService>();
            services.AddScoped<IUpdateContractService, UpdateContractService>();
            services.AddScoped<ICreateEmployeeService, CreateEmployeeService>();
            services.AddScoped<IUpdateEmployeeService, UpdateEmployeeService>();
            services.AddScoped<IDeleteEmployeeService, DeleteEmployeeService>();

            _serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = _serviceProvider.GetRequiredService<AuthorizationView>();
            window.Show();
        }
    }
}
