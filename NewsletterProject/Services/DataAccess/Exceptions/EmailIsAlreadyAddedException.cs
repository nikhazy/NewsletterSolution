using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsletterProject.Services.DataAccess.Exceptions
{
    public class EmailIsAlreadyAddedException : Exception
    {
        public EmailIsAlreadyAddedException() : base()
        {

        }
        public EmailIsAlreadyAddedException(string message) : base(message)
        {

        }
        public EmailIsAlreadyAddedException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
