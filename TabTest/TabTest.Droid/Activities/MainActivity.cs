
using Android.App;
using Android.OS;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Helpers;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Android.Widget;
using System;
using Android.Support.V7.Widget;

namespace TabTest.Droid
{
    [Activity(Label = "TabTest.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ActivityBase
    {
        ObservableCollection<Fragment> fragments = new ObservableCollection<Fragment>();
        public MainViewModel ViewModel => App.Locator.Main;
        ActionBar.Tab tab;

        ICommand TabClicked
        {
            get
            {
                return new RelayCommand(() =>
                {
                    tab.TabSelected += (object sender, ActionBar.TabEventArgs e) => TabOnTabSelected(sender, e);
                });
            }
        }

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

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
            var saved = savedInstanceState.GetInt("tab", 0);
            if (saved != ActionBar.SelectedNavigationIndex)
                ActionBar.SetSelectedNavigationItem(saved);
        }

        void AddTabToActionBar(string text, int iconResourceId)
        {
            tab = ActionBar.NewTab().SetTag(text).SetText(text).SetIcon(iconResourceId);

            /* uncomment and comment out one of the two below to see the difference in operation */

            tab.TabSelected += TabOnTabSelected;
            //tab.SetCommand<ActionBar.TabEventArgs>("TabSelected", TabClicked);

            ActionBar.AddTab(tab);
        }

        void TabOnTabSelected(object sender, ActionBar.TabEventArgs tabEventArgs)
        {
            var tabNo = sender as ActionBar.Tab;
            var frag = fragments[tabNo.Position];
            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
        }
    }
}


