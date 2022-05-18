using System;
using System.ComponentModel.DataAnnotations;

namespace MuhammetAliDemir.TP.Week1.Homework.Entity
{
    public class Race
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
        public double Length { get; set; }
        public int NumberOfLaps { get; set; }
        public double LapRecord { get; set; }
        public DateTime FirstRaceAt { get; set; }
    }
}
