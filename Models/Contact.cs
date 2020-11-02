using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace e4_ContactsProject.Models
{
    [XmlRoot("Datatable"), Serializable]
    public class Datatable
    {
        [XmlElement("Contacts")]
        public Employees Contacts { get; set; }
    }

    public class Employees
    {
        [XmlAttribute("Count")]
        public int Count { get; set; }
        [XmlElement("Employee")]
        public List<Contact> ContactDetails { get; set; }
    }

    public class Contact
    {
        public Guid ContactID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public String Title { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage = "First name can't be more than 20 characters")]
        public String Firstname { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        [StringLength(20,ErrorMessage = "Last name can't be more than 20 characters")]
        public String Lastname { get; set; }

        [Required(ErrorMessage = "Gender must be specified")]
        public String Gender { get; set; }

        [StringLength(30, ErrorMessage = "Email can't be more than 30 characters")]
        [EmailAddress]
        [Required(ErrorMessage = "Email must be specified")]
        public String EmailAddress { get; set; }    

        [Phone]
        [Required(ErrorMessage = "Cell number is required")]
        [Display(Name = "Cell number")]
        [MaxLength(12,ErrorMessage ="Cell number with 9 - 12 characters")]
        [MinLength(9, ErrorMessage = "Contact number with 9 - 12 characters")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Not a valid cell number eg.0822482817")]
        public String CellNumber { get; set; }

        [MaxLength(13, ErrorMessage = "Contact number with 9 - 13 characters")]
        [MinLength(9, ErrorMessage = "Contact number with 9 - 13 characters")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Not a valid contact number eg.011223344")]
        public String ContactNumber { get; set; }

        [Required(ErrorMessage = "Birth Date is required")]
        [Display(Name = "Birth Date")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:yyyy-MM-dd}")]
        public String BirthDate { get; set; }

       
    }
}



