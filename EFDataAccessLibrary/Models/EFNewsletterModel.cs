using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccessLibrary.Models
{
    public class EFNewsletterModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string HowTheyHeard { get; set; }
        public string Reason { get; set; }
    }
}
