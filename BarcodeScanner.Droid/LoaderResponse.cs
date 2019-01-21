namespace BarcodeScanner.Droid
{
    public class LoaderResponse<T>: Java.Lang.Object
    {
        public T Response { get; private set; }

        public LoaderResponse(T response)
        {
            Response = response;
        }
    }
}
