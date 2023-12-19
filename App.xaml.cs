using Microsoft.Extensions.DependencyInjection;
using NMP_Quoting_System.Services;
using NMP_Quoting_System.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace NMP_Quoting_System
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<MainWindow>(provider => new MainWindow 
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<NavigationViewModel>();
            services.AddSingleton<GearBoxSelectionViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();
            //
            //This part is what will be used whenever we are trying to switch between different views
            services.AddSingleton<Func<Type, BaseViewModel>>( serviceProvider => viewModelType => (BaseViewModel)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow? mainWindow = _serviceProvider.GetService<MainWindow>();

            if (mainWindow is not null)
            {
                mainWindow.Show();
                base.OnStartup(e);
            }
        }
    }

}
