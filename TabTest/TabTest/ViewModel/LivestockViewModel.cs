using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace TabTest
{
    public class LivestockViewModel : ViewModelBase
    {
        INavigationService navService;

        public LivestockViewModel(INavigationService nav)
        {
            navService = nav;
        }

        public string Text
        {
            get { return "Livestock"; }
        }

        public string ImageFilename
        {
            get { return "crucifix_colour.png"; }
        }
    }
}
