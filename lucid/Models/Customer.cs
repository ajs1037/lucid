using System;
using System.ComponentModel.DataAnnotations;

namespace lucid.Models
{
    public class Customer
    {
        // to get rid of warnings put this: <Nullable>enable</Nullable> in .csproj file

        public string Id { get; set; }

        [Display( Name = "Full Name" )] // these are called data annotations
        public string FullName { get; set; }

        [Display( Name = "Nick Name" )]
        public string NickName { get; set; }

        [Display( Name = "Phone Number" )]
        public string PhoneNumber { get; set; }

        [Display( Name = "Email Address" )]
        public string EmailAddress { get; set; }

        public string Notes { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime ModifiedDateTIme { get; set; }
    }
}
