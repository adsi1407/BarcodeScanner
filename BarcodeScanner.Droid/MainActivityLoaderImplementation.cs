using System;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Widget;
using CheeseBind;
using ZXing.Mobile;

namespace BarcodeScanner.Droid
{
    [Android.App.Activity(MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivityLoaderImplementation : AppCompatActivity, Android.Support.V4.App.LoaderManager.ILoaderCallbacks
    {
        private MobileBarcodeScannerTaskLoader loader;
        private const int mobileBarcodeScannerTaskLoaderId = 0;

        #region Inject views

        [BindView(Resource.Id.textView_result)]
        private TextView textViewResult;

        #endregion

        #region Lifecycle

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Bind(this);
            MobileBarcodeScanner.Initialize(Application);
            InitLoaders();
        }

        #endregion

        #region Class methods

        private void InitLoaders()
        {
            loader = new MobileBarcodeScannerTaskLoader(this);
            Android.Support.V4.App.LoaderManager.GetInstance(this).InitLoader(mobileBarcodeScannerTaskLoaderId, null, this);
        }

        #endregion

        #region Events

        [OnClick(Resource.Id.button_scan)]
        private void ButtonScan_Click(object sender, EventArgs e)
        {
            loader.ForceLoad();
        }

        #endregion

        #region ILoaderCallbacks implementation

        public Loader OnCreateLoader(int id, Bundle args)
        {
            return loader;
        }

        public void OnLoaderReset(Loader loader)
        {
            //Not implemented
        }

        public void OnLoadFinished(Loader loader, Java.Lang.Object data)
        {
            if (data.GetType() == typeof(LoaderResponse<ZXing.Result>))
            {
                LoaderResponse<ZXing.Result> loaderResponse = (LoaderResponse<ZXing.Result>)data;
                textViewResult.Text = loaderResponse.Response.Text;
            }
        }

        #endregion
    }
}


