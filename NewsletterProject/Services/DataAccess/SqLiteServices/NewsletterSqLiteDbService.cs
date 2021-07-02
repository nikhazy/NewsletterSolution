﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsletterProject.Models;
using NewsletterProject.Services.DataAccess.Exceptions;

namespace NewsletterProject.Services.DataAccess
{
    public class NewsletterSqLiteDbService : INewsletterDbService
    {

        private readonly NewsletterSqLiteDbContext _dbContext;

        public NewsletterSqLiteDbService(NewsletterSqLiteDbContext dbContext)
        {
            _dbContext = dbContext;
            //If there is no database, this method create it
            _dbContext.Database.EnsureCreated();
        }

        public void AddNewPersonToNewsletter(NewsletterModel newUser)
        {
            try
            {
                //Check if the database already contains the given email address
                if (_dbContext.Newsletter.Where(x => x.EmailAddress == newUser.EmailAddress).Count() == 0)
                {
                    newUser.Id = 0;
                    _dbContext.Newsletter.Add(newUser);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new EmailIsAlreadyAddedException("This email address is already signed up!");
                }
            }
            catch (Exception e)
            {
                //If any other error occured with the database connection I throw the exception
                throw e;
            }
        }

    }
}
