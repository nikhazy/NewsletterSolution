using NewsletterProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsletterProject.Services.DataAccess
{
    interface INewsletterDbService
    {
        /// <summary>
        /// This method add a person to the NewsletterDB database, if the email adress is already added
        /// it throws an EmailIsAlreadyAddedException
        /// </summary>
        /// <param name="newUser">Model contains the data of the new user</param>
        public void AddNewPersonToNewsletter(NewsletterModel newUser);
    }
}
