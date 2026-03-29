using Microsoft.AspNetCore.Http;

namespace UniversitySystem.Application.Bases
{
    public static class ResponseHandler
    {
        public static Response<T> Success<T>(T data, string message = "Request successful", int statusCode = StatusCodes.Status200OK)
        {
            return new Response<T>
            {
                IsSuccess = true,
                Data = data,
                Message = message,
                StatusCode = statusCode
            };
        }

        public static Response<T> Failure<T>(string message, List<string>? errors = null, int statusCode = StatusCodes.Status400BadRequest)
        {
            return new Response<T>
            {
                IsSuccess = false,
                Message = message,
                Errors = errors ?? new List<string>(),
                StatusCode = statusCode
            };
        }

        public static Response<T> NotFound<T>(string message = "Resource not found", List<string>? errors = null)
        {
            return new Response<T>
            {
                IsSuccess = false,
                Message = message,
                Errors = errors ?? new List<string>(),
                StatusCode = StatusCodes.Status404NotFound
            };
        }

        public static Response<T> Unauthorized<T>(string message = "Unauthorized")
        {
            return new Response<T>
            {
                IsSuccess = false,
                Message = message,
                Errors = new List<string> { message },
                StatusCode = 401
            };
        }
    }
}