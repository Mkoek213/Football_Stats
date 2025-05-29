// File: Models/Zawodnik.cs
namespace FootballApp.Models
{
    public class Zawodnik
    {
        public int Id { get; set; }
        public string Imie { get; set; } = string.Empty;
        public string Nazwisko { get; set; } = string.Empty;
        public string Pozycja { get; set; } = string.Empty;

        public int? DruzynaId { get; set; }
        public Druzyna? Druzyna { get; set; }

        public StatystykiZawodnika Statystyki { get; set; } 

        public Zawodnik() 
        {
            Statystyki = new StatystykiZawodnika();
        }
    }
}