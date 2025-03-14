namespace app.Domain.Contract
{
    public class ApiResponse<T>
    {
        public T Data {get;set;}
        public bool IsSuccess {get;set;}
        public string Message {get;set;}

        public ApiResponse(T data,string? message = null)
        {
            Data = data;
            IsSuccess = true;
            Message = message;
        }
         public ApiResponse(string message)
        {
            Data = default;
            IsSuccess = false;
            Message = message;
        }
    }
}