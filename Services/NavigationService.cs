using CommunityToolkit.Mvvm.ComponentModel;
using NMP_Quoting_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMP_Quoting_System.Services
{

    public partial class NavigationService : ObservableObject, INavigationService
    {
        private readonly Func<Type, BaseViewModel> viewModelFactory;
        
        [ObservableProperty]
        private BaseViewModel? _currentViewModel;

        public NavigationService(Func<Type, BaseViewModel> viewModelFactory)
        {
            this.viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<TBaseViewModel>() where TBaseViewModel : BaseViewModel 
        {
            BaseViewModel viewModel = viewModelFactory.Invoke(typeof(TBaseViewModel));
            viewModel.ResetViewModel();
            CurrentViewModel = viewModel;
        }
    }
}
