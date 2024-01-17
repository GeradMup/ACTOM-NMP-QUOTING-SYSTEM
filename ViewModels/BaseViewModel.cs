using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NMP_Quoting_System.ViewModels
{
    public abstract partial class BaseViewModel : ObservableObject
    {
        public BaseViewModel()
        {

        }

        /// <summary>
        /// Function for resetting ViewModels.
        /// Function is declared as virtual because some child classes may not override this method!
        /// </summary>
        public virtual void ResetViewModel() { }
    }
}
