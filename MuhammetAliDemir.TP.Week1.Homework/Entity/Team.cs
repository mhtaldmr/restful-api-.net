using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MuhammetAliDemir.TP.Week1.Homework.Entity
{
    public class Team
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string PowerUnit { get; set; }
        public string Country { get; set; }
        public string TeamChief { get; set; }
        public List<Driver> Drivers { get; set; }
        public int Championship { get; set; }
    }
}
