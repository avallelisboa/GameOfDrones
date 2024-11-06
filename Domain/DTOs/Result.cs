using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class Result
    {
        public Result() { }
        public Result(bool theIsValid, string theMessage)
        {
            IsValid = theIsValid;
            Message = theMessage;
        }
        public bool IsValid;
        public string Message;
    }
}
