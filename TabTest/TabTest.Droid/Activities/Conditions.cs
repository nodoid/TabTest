
using Android.App;
using Android.OS;
using Android.Views;
using GalaSoft.MvvmLight.Helpers;

namespace TabTest.Droid
{
    public partial class ConditionsFragment : Fragment
    {
        View view;

        public CropViewModel ViewModel => App.Locator.Crops;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.Crops, null);
            CreateBindings();
            return view;
        }

        void CreateBindings()
        {
            this.SetBinding(
                () => ViewModel.Text,
                () => TxtView.Text,
                BindingMode.Default);

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