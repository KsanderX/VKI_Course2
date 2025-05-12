using System;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Tkachev_KR.Services;
using Tkachev_KR.ViewModel;
using Tkachev_KR.Windows;

namespace Tkachev_KR
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider serviceProvider;
        public App()
        {
            var services = new ServiceCollection();
            services.AddScoped<IAuthorization, AuthorizationService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddTransient<MainWindow>();
            services.AddTransient<OrderWindow>();
            services.AddTransient<OrderViewModel>();           
            serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
        }
    }

}
