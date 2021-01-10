namespace SimpleBasket.Application.Common.Models
{
    public class OperationResult<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }

        public static OperationResult<T> Result(T data, string message = null) => new OperationResult<T>
        {
            Message = message,
            Data = data,
        };
    }
}
