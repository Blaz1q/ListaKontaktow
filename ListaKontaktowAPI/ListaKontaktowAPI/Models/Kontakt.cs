namespace ListaKontaktowAPI.Models
{
    public class Kontakt
    {
        public string Imie { get; set; } = string.Empty;
        public string Nazwisko { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Haslo { get; set; } = string.Empty; // w produkcji: haszować!
        public SlownikKategorii? Kategoria { get; set; }
        public int? KategoriaId { get; set; }
        public string? Podkategoria { get; set; }
        public string Telefon { get; set; } = string.Empty;
        public DateTime DataUrodzenia { get; set; }
    }
}
