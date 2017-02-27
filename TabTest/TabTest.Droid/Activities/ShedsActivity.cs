
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Views;
using GalaSoft.MvvmLight.Helpers;

namespace TabTest.Droid
{
    public partial class ResultsFragment : Fragment
    {
        static View view;

        public ShedsViewModel ViewModel => App.Locator.Sheds;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.Sheds, null);
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