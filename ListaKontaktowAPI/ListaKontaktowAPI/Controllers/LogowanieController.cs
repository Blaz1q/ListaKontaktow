using ListaKontaktowAPI.Data;
using ListaKontaktowAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

    [ApiController]
    [Route("api/logowanie")]
    public class LogowanieController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IConfiguration _config;

        public LogowanieController(ApiContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
    // GET: api/logowanie?email=xxx&haslo=yyy
    [HttpGet]
        public async Task<ActionResult<Kontakt>> Login([FromQuery] string email, [FromQuery] string haslo)
        {
        Console.WriteLine("GET LOGOWANIE");
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(haslo))
                return BadRequest("Email i hasło są wymagane.");

            var contact = await _context.kontakty
                .FirstOrDefaultAsync(k => k.Email == email && k.Haslo == haslo);

            if (contact == null)
                return Unauthorized(); // 401

        var token = new JsonWebToken(_config).GenerateJwtToken(contact);
        
        Console.WriteLine(contact.Imie + " " + contact.Nazwisko);
        return Ok(contact); // lub return NoContent() jeśli nie chcesz zwracać danych
    }
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] User credentials)
    {
        var contact = await _context.kontakty
            .FirstOrDefaultAsync(k => k.Email == credentials.Email && k.Haslo == credentials.Haslo);

        if (contact == null)
            return Unauthorized("Nieprawidłowy email lub hasło.");

        var token = new JsonWebToken(_config).GenerateJwtToken(contact);

        return Ok(new
        {
            token,
            imie = contact.Imie,
            nazwisko = contact.Nazwisko
        });
    }

}
