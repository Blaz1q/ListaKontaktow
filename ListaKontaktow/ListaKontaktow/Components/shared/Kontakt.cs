namespace ListaKontaktow.Components.shared
{
    public class Kontakt
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Haslo { get; set; }

        public int KategoriaId { get; set; }  // klucz obcy
        public SlownikKategorii? Kategoria { get; set; }

        public string Podkategoria { get; set; }
        public string Telefon { get; set; }
        public DateTime DataUrodzenia { get; set; }

        public Kontakt() { }

        public Kontakt(string imie, string nazwisko, string email, string haslo,
                       int kategoriaId, string podkategoria, string telefon, DateTime dataUrodzenia)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Email = email;
            Haslo = haslo;
            KategoriaId = kategoriaId;
            Podkategoria = podkategoria;
            Telefon = telefon;
            DataUrodzenia = dataUrodzenia;
        }
    }
}
