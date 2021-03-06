using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;

namespace TabTest.Droid
{
    public partial class TODFragment : Fragment
    {
        View view;
        public LivestockViewModel ViewModel => App.Locator.Livestock;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var _ = base.OnCreateView(inflater, container, savedInstanceState);
            view = inflater.Inflate(Resource.Layout.Livestock, null);

            CreateBindings();
            return view;
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            KillViews();
        }

        void CreateBindings()
        {
            this.SetBinding(
                    () => ViewModel.Text,
                    () => TxtView.Text,
                    BindingMode.TwoWay);

            ImgView.SetImageResource(GetImageFromFilename(ViewModel.ImageFilename));
        }

        int GetImageFromFilename(string file)
        {
            var filename = file.Split('.');
            var id = Resources.GetIdentifier(filename[0], "drawable", Activity.PackageName);
            return id;
        }
    }
}