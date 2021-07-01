
using NewsletterProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsletterProject.Services.DataAccess;
using Microsoft.Extensions.Logging;

namespace NewsletterProject.Services
{
    public class NewsletterDbService : IDisposable
    {
        private readonly NewsletterDbContext _dbContext;

        public NewsletterDbService(NewsletterDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddNewPersonToNewsletter(NewsletterModel newUser)
        {
            try
            {
                if(_dbContext.Newsletter.Where(x=>x.EmailAddress == newUser.EmailAddress).Count() == 0)
                {
                    newUser.Id = 0;
                    _dbContext.Newsletter.Add(newUser);
                    _dbContext.SaveChanges();
                    //return true;
                }
                else
                {
                    throw new EmailIsAlreadyAddedException("This email address is already added!");
                    //return false;
                }
            }
            catch (Exception e)
            {
                throw e;
                //return false;
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        ~NewsletterDbService()
        {
            Console.WriteLine("I am dead!");
        }
    }
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
