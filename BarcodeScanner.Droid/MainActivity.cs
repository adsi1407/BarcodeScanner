using System;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Widget;
using CheeseBind;
using ZXing.Mobile;

namespace BarcodeScanner.Droid
{
    [Android.App.Activity(MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        [BindView(Resource.Id.button_scan)]
        private Button button_scan;

        private MobileBarcodeScanner scanner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Bind(this);

            MobileBarcodeScanner.Initialize(Application);
            scanner = new MobileBarcodeScanner();
            button_scan.Click += async delegate {

                scanner.UseCustomOverlay = false;
                scanner.TopText = "Hold the camera up to the barcode\nAbout 6 inches away";
                scanner.BottomText = "Wait for the barcode to automatically scan!";

                var result = await scanner.Scan();
                RunOnUiThread(() => Toast.MakeText(this, result.Text, ToastLength.Short).Show());
            };
        }
    }
}

