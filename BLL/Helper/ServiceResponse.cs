using Sprache;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Helper
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

        public static ServiceResponse<T> SuccessResponse(T result, string message = null)
        {
            return new ServiceResponse<T>
            {
                Success = true,
                Message = message,
                Result = result
            };
        }
        public static ServiceResponse<T> FailureResponse(string message)
        {
            return new ServiceResponse<T>
            {
                Success = false,
                Message = message
            };
        }
    }
}
