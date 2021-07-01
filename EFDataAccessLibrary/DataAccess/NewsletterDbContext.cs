using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccessLibrary.DataAccess
{
    public class NewsletterDbContext : DbContext
    {
        public NewsletterDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<EFNewsletterModel> Newsletter { get; set; }


    }
}
