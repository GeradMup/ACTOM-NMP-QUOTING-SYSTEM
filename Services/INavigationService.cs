using CommunityToolkit.Mvvm.ComponentModel;
using NMP_Quoting_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMP_Quoting_System.Services
{
    public interface INavigationService
    {
        BaseViewModel CurrentViewModel { get; }
        void NavigateTo<T>() where T : BaseViewModel;
    }
}
