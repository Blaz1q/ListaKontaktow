using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ListaKontaktow.Components.shared
{
    public static class Dane
    {
        public static List<Kontakt> kontakty = new List<Kontakt>();
        public static List<SlownikKategorii> kategorie = new List<SlownikKategorii>(); 
        public static Kontakt LoggedInUser = new Kontakt();
        public static string Token = "";
        public static bool isTokenEmpty() { 
            return Token.Length == 0;
        }
    }
}
