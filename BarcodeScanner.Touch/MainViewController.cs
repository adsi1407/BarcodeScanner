using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace BarcodeScanner.Touch
{
    public class MainViewController: UIViewController
    {
        private UIButton buttonScan;
        private UILabel labelResult;
        private NSOperationQueue queue;
        private BarcodeScannerOperation operation;

        public MainViewController()
        {
            queue = new NSOperationQueue();

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;
            Title = "BarcodeScanner";
            SetupViews();
        }

        private void SetupViews()
        {
            buttonScan = UIButton.FromType(UIButtonType.System);
            buttonScan.Frame = new CGRect(10, 100, 300, 44);
            buttonScan.SetTitle("Scan", UIControlState.Normal);
            buttonScan.TouchUpInside += ButtonScan_TouchUpInside;
            View.AddSubview(buttonScan);

            labelResult = new UILabel();
            labelResult.Frame = new CGRect(10, 200, 300, 44);
            View.AddSubview(labelResult);
        }

        private void ButtonScan_TouchUpInside(object sender, EventArgs e)
        {
            operation = new BarcodeScannerOperation();
            operation.CompletionBlock += Operation_CompletionBlock;
            queue.AddOperation(operation);
        }

        private void Operation_CompletionBlock()
        {
            if (operation.Result.Response != null)
            {
                labelResult.Text = operation.Result.Response.Text;
            }
        }

    }
}
