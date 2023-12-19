using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMP_Quoting_System.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel? _selectedViewModel = new GearBoxSelectionViewModel();
       
        public MainViewModel()
        {
                
        }

        public BaseViewModel? SelectedViewModel 
        { 
            get => _selectedViewModel; 
            set => _selectedViewModel = value; 
        }
    }
}
