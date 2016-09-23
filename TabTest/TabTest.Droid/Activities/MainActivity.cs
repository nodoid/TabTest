
using Android.App;
using Android.OS;
using GalaSoft.MvvmLight.Views;

namespace TabTest.Droid
{
    [Activity(Label = "TabTest.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ActivityBase
    {
        Fragment[] fragments;
        public MainViewModel ViewModel => App.Locator.Main;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            //SetContentView(Resource.Layout.Main);

            fragments = new Fragment[]
                         {
                             new TODFragment(),
                             new ConditionsFragment(),
                             new ResultsFragment()
                         };

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

            Fragment frag = fragments[tab.Position];
            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
        }
    }
}


