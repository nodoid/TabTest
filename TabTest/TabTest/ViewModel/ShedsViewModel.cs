using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace TabTest
{
    public class ShedsViewModel : ViewModelBase
    {
        INavigationService navService;

        public ShedsViewModel(INavigationService nav)
        {
            navService = nav;
        }

        public string Text
        {
            get { return "Sheds"; }
        }

        public string ImageFilename
        {
            get { return "tod_colour.png"; }
        }
    }
}
