namespace app.Domain.Contract
{
    public class ApiResponse<T>
    {
        public T Data {get;set;}
        public bool IsSuccess {get;set;}
        public string Message {get;set;}

        public ApiResponse(T data,string? message = null,bool status =true)
        {
            Data = data;
            IsSuccess = status;
            Message = message;
        }
         public ApiResponse(string message,bool status)
        {
            Data = default;
            IsSuccess = status;
            Message = message;
        }
    }
}