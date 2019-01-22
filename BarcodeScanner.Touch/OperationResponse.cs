namespace BarcodeScanner.Touch
{
    public class OperationResponse<T>
    {
        public T Response { get; private set; }

        public OperationResponse(T response)
        {
            Response = response;
        }
    }
}
