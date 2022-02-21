using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ALT
{
    class ValidationResult
    {
        public List<Error> Errors;

        public class Error
        {
            public Exception exception;
            public int line;

            public Error(Exception _exception, int _line)
            {
                exception = _exception;
                line = _line;
            }
        }

        public ValidationResult()
        {
            Errors = new List<Error>();
        }

        public void Add(Exception _exception, int _line)
        {
            Errors.Add(new Error(_exception, _line));
        }
    }
}
