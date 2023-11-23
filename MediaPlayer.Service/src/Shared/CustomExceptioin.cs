using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaPlayer.Controller.src.Shared
{
    public class CustomException : Exception
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public CustomException(int code, string message)
        {
            StatusCode = code;
            Message = message;
        }

        public static CustomException NotFoundException(string message = "Cannot find the item")
        {
            return new CustomException(404, message);
        }
    }
}