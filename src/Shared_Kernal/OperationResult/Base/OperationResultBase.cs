namespace ecommerce_shared.OperationResult.Base
{
    public class OperationResultBase<T>
    {

        

        public T Result { get; set; }

        public string Message { get; set; }
        
        public int StatusCode { get; set; }

        public List<string> Errors { get; set; }
        


    }
}
