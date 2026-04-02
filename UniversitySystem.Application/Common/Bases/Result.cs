namespace UniversitySystem.Application.Common.Wrappers
{
    public class Result<T>
    {
        public bool Succeeded { get; set; }
        public T? Data { get; set; }
        public string? Error { get; set; }

        public static Result<T> Failure(string error) => new Result<T> { Succeeded = false, Error = error };
        public static Result<T> Success(T data) => new Result<T> { Succeeded = true, Data = data };
    }

}
