namespace SimpleBasket.Application.Common.Models
{
    public class ServiceResult<T> where T : class
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static ServiceResult<T> Result(T data, bool success, string message = null) => new ServiceResult<T>
        {
            Success = success,
            Message = message,
            Data = data,
        };

        public static ServiceResult<T> Catch(string exception) => new ServiceResult<T>
        {
            Success = false,
            Message = exception,
        };
    }
}
