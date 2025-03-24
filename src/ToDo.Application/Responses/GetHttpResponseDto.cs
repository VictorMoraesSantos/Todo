using System.Net;

namespace ToDo.Application.Responses
{
    public class GetHttpResponseDto<T>
    {
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
        public string[] Errors { get; set; }

        public GetHttpResponseDto(T data, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Data = data;
            StatusCode = statusCode;
            Success = ((int)statusCode >= 200 && (int)statusCode < 300);
            Errors = new string[0];
        }

        public GetHttpResponseDto(HttpStatusCode statusCode, params string[] errors)
        {
            StatusCode = statusCode;
            Success = false;
            Errors = errors;
        }

        public GetHttpResponseDto()
        {
            Errors = new string[0];
        }

        public static GetHttpResponseDto<T> Ok(T response)
        {
            return new GetHttpResponseDto<T>(response, HttpStatusCode.OK);
        }

        public static GetHttpResponseDto<T> BadRequest(params string[] errors)
        {
            return new GetHttpResponseDto<T>(HttpStatusCode.BadRequest, errors);
        }

        public static GetHttpResponseDto<T> NotFound(params string[] errors)
        {
            return new GetHttpResponseDto<T>(HttpStatusCode.NotFound, errors);
        }

        public static GetHttpResponseDto<T> Forbidden(params string[] errors)
        {
            return new GetHttpResponseDto<T>(HttpStatusCode.Forbidden, errors);
        }

        public static GetHttpResponseDto<T> Error(Exception ex)
        {
            return new GetHttpResponseDto<T>(
                HttpStatusCode.InternalServerError,
                new string[] { ex.Message, ex.InnerException?.Message ?? "" }
            );
        }

        public static GetHttpResponseDto<T> Error(HttpStatusCode statusCode, Exception ex)
        {
            return new GetHttpResponseDto<T>(
                statusCode,
                new string[] { ex.Message, ex.InnerException?.Message ?? "" }
            );
        }

        public static GetHttpResponseDto<T> Error(HttpStatusCode statusCode, string[] errors)
        {
            return new GetHttpResponseDto<T>(statusCode, errors);
        }

        public static GetHttpResponseDto<T> Error(params string[] errors)
        {
            return new GetHttpResponseDto<T>(HttpStatusCode.InternalServerError, errors);
        }
    }
}
