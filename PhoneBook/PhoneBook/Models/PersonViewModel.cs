using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBook.Models
{
    public class PersonViewModel
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public String MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        public DateTime AddedOn { get; set; }
        [Required]
        public String AddedBy { get; set; }
        [Required]
        [Display(Name = "Home Address")]
        public String HomeAddress { get; set; }
        [Required]
        [Display(Name = "Home City")]
        public String HomeCity { get; set; }
        [Required]
        [Display(Name = "Facebook Account ID")]
        public String FaceBookAccountId { get; set; }
        [Required]
        [Display(Name = "LinkedIn ID")]
        public String LinkedInId { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdateOn { get; set; }
        public String ImagePath { get; set; }
        [Required]
        [Display(Name = "Twitter ID")]
        public String TwitterId { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email ID")]
        public String EmailId { get; set; }

    }
}