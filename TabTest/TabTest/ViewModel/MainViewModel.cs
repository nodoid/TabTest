using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace TabTest
{
    public class MainViewModel : ViewModelBase
    {
        INavigationService navService;

        public MainViewModel(INavigationService nav)
        {
            navService = nav;
        }

        RelayCommand timeMove, conditionsMove, resultMove;
        public RelayCommand TimeMove
        {
            get
            {
                return timeMove ??
                    (timeMove = new RelayCommand(
                    () =>
                    {
                        navService.NavigateTo(ViewModelLocator.CropKey);
                    }));
            }
        }
        public RelayCommand ConditionsMove
        {
            get
            {
                return conditionsMove ??
                    (conditionsMove = new RelayCommand(
                    () =>
                    {
                        navService.NavigateTo(ViewModelLocator.LivestockKey);
                    }));
            }
        }
        public RelayCommand ResultsMove
        {
            get
            {
                return resultMove ??
                    (resultMove = new RelayCommand(
                    () =>
                    {
                        navService.NavigateTo(ViewModelLocator.ShedsKey);
                    }));
            }
        }
    }
}