namespace ClinicManager.Application.Abstractions
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public bool IsFound { get; }
        public string Message { get; }
        public T Data { get; }

        public Result(bool isSuccess, string message, bool isFound = true, T data = default)
        {
            IsSuccess = isSuccess;
            IsFound = isFound;
            Message = message;
            Data = data;
        }

        public static Result<T> Success(T data, string message = "Sucess.")
        {
            return new Result<T>(true, message, data: data);
        }

        public static Result<T> Failure(string message = "Failure.")
        {
            return new Result<T>(false, message);
        }

        public static Result<T> NotFound(string message = "Not Found.")
        {
            return new Result<T>(false, message, false);
        }

    }
}
