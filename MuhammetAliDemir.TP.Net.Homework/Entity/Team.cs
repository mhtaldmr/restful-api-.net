using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MuhammetAliDemir.TP.Net.Homework.Entity
{
    public class Team : BaseEntity
    {
        public string PowerUnit { get; set; }
        public string Country { get; set; }
        public string TeamChief { get; set; }
        public List<Driver> Drivers { get; set; }
        public int Championship { get; set; }
    }
}
