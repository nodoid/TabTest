using Android.Widget;

namespace TabTest.Droid
{
    public partial class ResultsFragment
    {
        TextView textView;
        ImageView imageView;

        public TextView TxtView => textView ?? (textView = view.FindViewById<TextView>(Resource.Id.textView1));
        public ImageView ImgView => imageView ?? (imageView = view.FindViewById<ImageView>(Resource.Id.imageView1));
    }
}
