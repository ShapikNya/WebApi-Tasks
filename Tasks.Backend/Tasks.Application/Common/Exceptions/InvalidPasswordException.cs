using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.Common.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string name, object key)
           : base($"Incorrect ({key}) for \"{name}\"") { }
    }
}
