using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NewsletterProject.Models;
using NewsletterProject.Services.DataAccess.Exceptions;

namespace NewsletterProject.Services.DataAccess
{
    public class NewsletterMsSqlDbContext : DbContext, INewsletterDbService
    {
        public NewsletterMsSqlDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<NewsletterModel> Newsletter { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json")
               .Build();
                optionsBuilder.UseSqlite(configuration.GetConnectionString("Default"));
            }
        }
        public void AddNewPersonToNewsletter(NewsletterModel newUser)
        {
            try
            {
                //Check if the database already contains the given email address
                if (this.Newsletter.Where(x => x.EmailAddress == newUser.EmailAddress).Count() == 0)
                {
                    newUser.Id = 0;
                    this.Newsletter.Add(newUser);
                    this.SaveChanges();
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
