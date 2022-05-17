using System.ComponentModel.DataAnnotations;

namespace MuhammetAliDemir.TP.Week1.Homework.Entity
{
    public class Driver
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Team { get; set; }
        public string Nationality { get; set; }
        public int RaceEntered { get; set; }
        public int Podiums { get; set; }
        public int Championship { get; set; }
    }
}