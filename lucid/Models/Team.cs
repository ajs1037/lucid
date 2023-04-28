using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using lucid.Data;

namespace lucid.Models
{
    public class Team : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required( ErrorMessage = "Team Name is Required" )]
        public string TeamName { get; set; }

        public string TeamLeaderEmployeeId { get; set; }

        public string TeamDriverEmployeeId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
