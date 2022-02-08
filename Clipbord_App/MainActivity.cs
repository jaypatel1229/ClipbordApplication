using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace Clipbord_App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText edtCopy;
        ClipboardManager clipBoardManager;
        private ClipData ClipData;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // For The Text View 
             edtCopy = FindViewById<EditText>(Resource.Id.edtCopy);
            var edtPaste = FindViewById<EditText>(Resource.Id.edtPaste);

            // For the Button
            var btnCopy = FindViewById<Button>(Resource.Id.btnCopy);
            var btnPaste = FindViewById<Button>(Resource.Id.btnPaste);

            clipBoardManager = (ClipboardManager)GetSystemService(ClipboardService);


            btnCopy.Click += delegate 
            {
                string text = edtCopy.Text;
                ClipData = ClipData.NewPlainText("text",text);
                clipBoardManager.PrimaryClip = ClipData;

                Toast.MakeText(this,"Text Copied",ToastLength.Short).Show();
            };

            btnPaste.Click += delegate
            {
                ClipData data = clipBoardManager.PrimaryClip;
                ClipData.Item item = data.GetItemAt(0);

                string text = item.Text;
                edtPaste.Text = text;

                Toast.MakeText(this, "Text Paste", ToastLength.Short).Show();
            };
        }

        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}