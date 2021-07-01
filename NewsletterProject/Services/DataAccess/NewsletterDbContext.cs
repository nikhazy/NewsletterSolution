using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsletterProject.Models;

namespace NewsletterProject.Services.DataAccess
{
    public class NewsletterDbContext : DbContext
    {
        public NewsletterDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<NewsletterModel> Newsletter { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsletterModel>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();
            });

        }

    }
}
