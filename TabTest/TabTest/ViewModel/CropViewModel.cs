using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace TabTest
{
    public class CropViewModel : ViewModelBase
    {
        INavigationService navService;
        public CropViewModel(INavigationService nav)
        {
            navService = nav;
        }

        public string Text
        {
            get { return "Crops"; }
        }

        public string ImageFilename
        {
            get { return "weather_colour.png"; }
        }
    }
}
