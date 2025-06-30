using Microsoft.AspNetCore.Mvc;

namespace ListaKontaktowAPI.Models
{
    public class User
    {
        public string Email { get; set; } = string.Empty;
        public string Haslo { get; set; } = string.Empty;
    }
}
