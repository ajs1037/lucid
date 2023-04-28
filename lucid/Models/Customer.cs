using System;
using System.ComponentModel.DataAnnotations;
using lucid.Data;

namespace lucid.Models
{
    public class Customer : IEntity
    {
        // to get rid of warnings put this: <Nullable>enable</Nullable> in .csproj file

        [Key]
        public int Id { get; set; }

        [Display( Name = "First Name" )] // these are called data annotations
        [Required(ErrorMessage ="First Name is Required")]
        public string FirstName { get; set; }

        [Display( Name = "Last Name" )] // these are called data annotations
        [Required( ErrorMessage = "Last Name is Required" )]
        public string LastName { get; set; }

        [Display( Name = "Nick Name" )]
        public string NickName { get; set; }

        [Display( Name = "Phone Number" )]
        [Required( ErrorMessage = "Phone Number is Required" )]
        public string PhoneNumber { get; set; }

        [Display( Name = "Email Address" )]
        [Required( ErrorMessage = "Email Address is Required" )]
        public string EmailAddress { get; set; }

        public string Notes { get; set; }

        [Required( ErrorMessage = "Street is Required" )]
        public string Street { get; set; }

        [Required( ErrorMessage = "City is Required" )]
        public string City { get; set; }

        [Required( ErrorMessage = "State is Required" )]
        public string State { get; set; }

        [Required( ErrorMessage = "Zip Code is Required" )]
        public string Zip { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime ModifiedDateTime { get; set; }
    }
}
