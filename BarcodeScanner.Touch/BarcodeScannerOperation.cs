using Foundation;
using ZXing.Mobile;

namespace BarcodeScanner.Touch
{
    public class BarcodeScannerOperation: NSOperation
    {
        public OperationResponse<ZXing.Result> Result { get; private set; }
        private readonly MobileBarcodeScanner scanner;

        public BarcodeScannerOperation()
        {
            scanner = new MobileBarcodeScanner();
            Result = new OperationResponse<ZXing.Result>(null);
        }

        public override void Main()
        {
            base.Main();

            scanner.UseCustomOverlay = false;
            scanner.TopText = "Hold the camera up to the barcode\nAbout 6 inches away";
            scanner.BottomText = "Wait for the barcode to automatically scan!";

            var result = scanner.Scan();
            var response = result.Result;

            Result = new OperationResponse<ZXing.Result>(response);
        }
    }
}
