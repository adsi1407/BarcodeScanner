package md5c241ced8c161f003b6391207b174e572;


public class MobileBarcodeScannerTaskLoader
	extends android.support.v4.content.AsyncTaskLoader
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_loadInBackground:()Ljava/lang/Object;:GetLoadInBackgroundHandler\n" +
			"";
		mono.android.Runtime.register ("BarcodeScanner.Droid.MobileBarcodeScannerTaskLoader, BarcodeScanner.Droid", MobileBarcodeScannerTaskLoader.class, __md_methods);
	}


	public MobileBarcodeScannerTaskLoader (android.content.Context p0)
	{
		super (p0);
		if (getClass () == MobileBarcodeScannerTaskLoader.class)
			mono.android.TypeManager.Activate ("BarcodeScanner.Droid.MobileBarcodeScannerTaskLoader, BarcodeScanner.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public java.lang.Object loadInBackground ()
	{
		return n_loadInBackground ();
	}

	private native java.lang.Object n_loadInBackground ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
