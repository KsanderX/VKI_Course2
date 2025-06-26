using System.Windows;
using exam.Services;
using exam.ViewModel;
using exam.Views;
using Microsoft.Extensions.DependencyInjection;

namespace exam
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;
        public App()
        {
            ServiceCollection services = new ();

            services.AddTransient<UserView>();
            services.AddTransient<UserViewModel>();

            services.AddTransient<AdminView>();
            services.AddTransient<AdminViewModel>();

            services.AddTransient<AuthorizateView>();
            services.AddTransient<RegisterView>();

            services.AddTransient<CarAdminView>();
            services.AddTransient<CarAdminViewModel>();

            services.AddTransient<EditCarView>();
            services.AddTransient<EditCarViewModel>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICarService, CarService>();

            _serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var win = _serviceProvider.GetRequiredService<AuthorizateView>();
            win.Show();
        }
    }

}
