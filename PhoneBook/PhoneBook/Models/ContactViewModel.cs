using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PhoneBook.Models
{
    public class ContactViewModel
    {
        public int ContactId { get; set; }
        public string ContactNumber { get; set; }
        public string Type { get; set; }
        public int PersonId { get; set; }
    }
}