using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsletterProject.Models
{
    public class NewsletterModel
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The email address of the user who signing up to a newsletter
        /// </summary>
        [Required(ErrorMessage = "The email address field is required!")]
        [EmailAddress(ErrorMessage = "This is not a valid email address!")]
        [Column("Email")]
        public string EmailAddress { get; set; }

        //This value stores how the user heard about us
        private string howTheyHeardAboutUs;
        /// <summary>
        /// This variable shows how the user heard about us
        /// </summary>

        [Required(ErrorMessage = "How you heard about us field is required!")]
        [Column("HowTheyHeard")]
        public string HowTheyHeardAboutUs {
            get { return howTheyHeardAboutUs; }
            set { howTheyHeardAboutUs = SetHowTheyHeardAboutUs(value); }
        }

        /// <summary>
        /// This property shows the reason why the user would like to sign up
        /// </summary>

        [Column("Reason")]
        public string ReasonForSigningUp { get; set; }

        /// <summary>
        /// This list contains the possibilities of how the user heard about us
        /// </summary>
        public static List<string> HowTheyHeardAboutUsPossibilities = new List<string> { "Advert", "Word Of Mouth", "Other" };

        /// <summary>
        /// This method set the HowTheyHeardAboutUs property. If the reason is not in the possibility list the result will be other
        /// </summary>
        /// <param name="howTheyHeard">How the user heared from us</param>
        /// <returns></returns>
        private string SetHowTheyHeardAboutUs(string howTheyHeard)
        {
            if(howTheyHeard != null)
            {
                if (HowTheyHeardAboutUsPossibilities.Contains(howTheyHeard))
                {
                    return howTheyHeard;
                }
                else
                {
                    return "Other";
                }
            }
            else
            {
                return null;
            }
        }
    }

}
