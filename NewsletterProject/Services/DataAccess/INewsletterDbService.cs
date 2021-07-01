using NewsletterProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsletterProject.Services.DataAccess
{
    interface INewsletterDbService
    {
        public void AddNewPersonToNewsletter(NewsletterModel newUser);
    }
}
