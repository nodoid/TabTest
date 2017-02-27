
using Android.App;
using Android.OS;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Helpers;

namespace TabTest.Droid
{
    [Activity(Label = "TabTest.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ActivityBase
    {
        ObservableCollection<Fragment> fragments = new ObservableCollection<Fragment>();
        public MainViewModel ViewModel => App.Locator.Main;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            fragments.Add(new TODFragment());
            fragments.Add(new ConditionsFragment());
            fragments.Add(new ResultsFragment());

            AddTabToActionBar("Time", Resource.Drawable.crucifix_colour);
            AddTabToActionBar("Conditions", Resource.Drawable.weather_colour);
            AddTabToActionBar("Results", Resource.Drawable.tod_colour);
        }

        void AddTabToActionBar(string text, int iconResourceId)
        {
            var tab = ActionBar.NewTab()
                                         .SetText(text)
                                         .SetIcon(iconResourceId);

            tab.TabSelected += TabOnTabSelected;
            ActionBar.AddTab(tab);
        }

        void TabOnTabSelected(object sender, ActionBar.TabEventArgs tabEventArgs)
        {
            var tab = (ActionBar.Tab)sender;

            var frag = fragments[tab.Position];
            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
        }
    }
}


