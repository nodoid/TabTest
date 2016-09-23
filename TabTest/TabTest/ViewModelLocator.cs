/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:TabTest.WinPhone"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace TabTest
{
    public class ViewModelLocator
    {
        public const string CropKey = "Crops";
        public const string LivestockKey = "Livestock";
        public const string ShedsKey = "Sheds";
        public const string MainKey = "Main";

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CropViewModel>();
            SimpleIoc.Default.Register<LivestockViewModel>();
            SimpleIoc.Default.Register<ShedsViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public CropViewModel Crops
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CropViewModel>();
            }
        }

        public LivestockViewModel Livestock
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LivestockViewModel>();
            }
        }

        public ShedsViewModel Sheds
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ShedsViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}