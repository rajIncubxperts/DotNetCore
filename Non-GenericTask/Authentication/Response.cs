using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Non_GenericTask.Authentication
{
    // for returning the response value after user registration and user login.
    // It will also return error messages, if the request fails.
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
