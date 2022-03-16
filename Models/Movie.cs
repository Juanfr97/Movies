using System.ComponentModel.DataAnnotations;

namespace JuanDeDiosFrausto.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string ISAN { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        [Range(1900,2500)]
        public int Year { get; set; }
        [Range(1,12)]
        public int Month { get; set; }
        public string Image { get; set; }
        public string Duration { get; set; }
        public string Summary { get; set; }
    }
}
