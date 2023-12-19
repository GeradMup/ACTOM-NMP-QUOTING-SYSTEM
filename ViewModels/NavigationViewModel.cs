using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Printing.Interop;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NMP_Quoting_System.Services;


namespace NMP_Quoting_System.ViewModels
{
    public partial class NavigationViewModel : BaseViewModel
    {
        private INavigationService navigation;

        public NavigationViewModel(INavigationService navigation)
        {
            this.navigation = navigation;
        }

        public INavigationService Navigation
        {
            get => navigation;
            set => navigation = value;
        }


        [RelayCommand]
        public void GearboxBtn()
        {
            Navigation.NavigateTo<GearBoxSelectionViewModel>();
        }

        [RelayCommand]
        public void MotorBtn() 
        {
        
        }

        [RelayCommand]
        public void MotorPlusGearboxBtn() 
        {
        
        }

    }
}
