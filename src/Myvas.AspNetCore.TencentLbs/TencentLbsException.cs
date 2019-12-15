using System;
using System.Collections.Generic;
using System.Text;

namespace Myvas.AspNetCore.TencentLbs
{
    public class TencentLbsException : Exception
    {
        public int status { get; set; }
        public string message { get; set; }
        public string request_id { get; set; }

        public TencentLbsException()
        {
        }

        public TencentLbsException(string message) : base(message)
        {
        }

        public TencentLbsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public TencentLbsException(int status, string message) : base($"[{status}]{message}")
        {
        }

        public TencentLbsException(int status, string message, string request_id) : base($"[{request_id}][{status}]{message}")
        {
        }
    }
}
