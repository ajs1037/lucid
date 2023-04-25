using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lucid.Data;

namespace lucid.Models
{
    public class Employee : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Display( Name = "First Name" )] // these are called data annotations
        [Required( ErrorMessage = "First Name is Required" )]
        public string FirstName { get; set; }

        [Display( Name = "Last Name" )] // these are called data annotations
        [Required( ErrorMessage = "Last Name is Required" )]
        public string LastName { get; set; }

        [Display( Name = "Phone Number" )]
        [Required( ErrorMessage = "Phone Number is Required" )]
        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime ModifiedDateTIme { get; set; }


        // relationship
        public int TeamId { get; set; }

        [ForeignKey( "TeamId" )]
        public Team Team { get; set; }
    }
}
