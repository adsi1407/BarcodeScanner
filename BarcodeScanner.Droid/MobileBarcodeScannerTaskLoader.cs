using Android.Support.V4.Content;
using ZXing.Mobile;

namespace BarcodeScanner.Droid
{
    public class MobileBarcodeScannerTaskLoader : AsyncTaskLoader
    {
        private readonly MobileBarcodeScanner scanner;

        public MobileBarcodeScannerTaskLoader(Android.Content.Context context): base(context)
        {
            scanner = new MobileBarcodeScanner();
        }

        public override Java.Lang.Object LoadInBackground()
        {
            scanner.UseCustomOverlay = false;
            scanner.TopText = "Hold the camera up to the barcode\nAbout 6 inches away";
            scanner.BottomText = "Wait for the barcode to automatically scan!";

            var result = scanner.Scan();
            var response = result.Result;

            return new LoaderResponse<ZXing.Result>(response);
        }
    }
}
