using System.ComponentModel.DataAnnotations;

namespace MuhammetAliDemir.TP.Net.Homework.Entity
{
    public class Driver : BaseEntity
    {
        public string Team { get; set; }
        public string Nationality { get; set; }
        public int RaceEntered { get; set; }
        public int Podiums { get; set; }
        public int Championship { get; set; }
        public int PointsAtThisYear { get; set; }
    }
}
