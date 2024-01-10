using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NMP_Quoting_System.Models;
using NMP_Quoting_System.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMP_Quoting_System.ViewModels
{ 
    public partial class GearBoxSelectionViewModel : BaseViewModel
    {

        [ObservableProperty]
        public ObservableCollection<ARWGearbox>? _ARWGearboxes;

        [ObservableProperty]
        public ObservableCollection<String> _GearboxTypes;

        [ObservableProperty]
        public string? _SelectedGearboxType;

        [ObservableProperty]
        public ObservableCollection<double>? _GearboxRatings;

        [ObservableProperty]
        public double? _SelectedRating;

        [ObservableProperty]
        public ObservableCollection<int>? _Poles;

        [ObservableProperty]
        public int? _SelectedPoles;

        [ObservableProperty]
        public ObservableCollection<double>? _FinalRpms;

        [ObservableProperty]
        public double? _SelectedFinalRpm;

        [ObservableProperty]
        public ObservableCollection<double>? _GearRatios;

        [ObservableProperty]
        public double? _SelectedGearRatio;



        GearboxSelectionService gearboxSelectionService;

        public GearBoxSelectionViewModel()
        {
            gearboxSelectionService = new GearboxSelectionService();
            GearboxTypes = new ObservableCollection<string>( gearboxSelectionService.GetGearboxTypes() );
        }

        [RelayCommand]
        public void GearboxTypeChange()
        {
            if((SelectedGearboxType == null) || (SelectedGearboxType == "")) { return; }
            SelectedRating = null;
            SelectedPoles = null;
            SelectedFinalRpm = null;
            SelectedGearRatio = null;
            ARWGearboxes = null;
            if (GearboxRatings != null) GearboxRatings.Clear();
            GearboxRatings = new ObservableCollection<double>( gearboxSelectionService.GetGearboxRatings(SelectedGearboxType) );
        }

        [RelayCommand]
        public void PowerRatingChange() 
        {
            if(SelectedRating == null) { return; }
            SelectedPoles = null;
            SelectedFinalRpm = null;
            SelectedGearRatio = null;
            ARWGearboxes = null;
            Poles = new ObservableCollection<int>(gearboxSelectionService.GetPoles(SelectedRating));
        }

        [RelayCommand]
        public void PolesChange() 
        {
            if(SelectedPoles == null) { return; }
            SelectedFinalRpm = null;
            SelectedGearRatio = null;
            ARWGearboxes = null;
            FinalRpms = new ObservableCollection<double>(gearboxSelectionService.GetFinalRpms(SelectedPoles));
            GearRatios = new ObservableCollection<double>(gearboxSelectionService.GetGearRatios(SelectedPoles));
        }


        [RelayCommand]
        public void FinalRpmChange() 
        {
            if (SelectedFinalRpm == null || SelectedPoles == null) { return; }
            SelectedGearRatio = gearboxSelectionService.GetGearRatio(SelectedFinalRpm, SelectedPoles);
            ARWGearboxes = new ObservableCollection<ARWGearbox>(gearboxSelectionService.GetGearboxes(SelectedGearRatio));
        }

        [RelayCommand]
        public void GearRatioChange() 
        {
            if (SelectedGearRatio == null || SelectedPoles == null) { return; }
            SelectedFinalRpm = gearboxSelectionService.GetFinalRpm(SelectedGearRatio, SelectedPoles);
            ARWGearboxes = new ObservableCollection<ARWGearbox>(gearboxSelectionService.GetGearboxes(SelectedGearRatio));
        }

    }
}
