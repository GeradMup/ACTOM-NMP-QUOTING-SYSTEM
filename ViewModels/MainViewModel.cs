using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using NMP_Quoting_System.Services;
using System.Runtime.InteropServices;
using System.Printing;

namespace NMP_Quoting_System.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {

        [ObservableProperty]
        private INavigationService _navigation;

        public MainViewModel(INavigationService navService)
        {
            Navigation = navService;
            Navigation.NavigateTo<NavigationViewModel>();
        }

        [RelayCommand]
        public void homeBtn() 
        {
            Navigation.NavigateTo<NavigationViewModel>();
        }

    }
}
