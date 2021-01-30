using System;

namespace BackendApplication
{
    public class RequestException : Exception
    {
        public int Code { get; }
        public RequestException(string message, int code) : base(message)
        {
            Code = code;
        }
    }
}
