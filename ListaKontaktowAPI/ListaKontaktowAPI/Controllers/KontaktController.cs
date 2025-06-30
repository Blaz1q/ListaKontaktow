using ListaKontaktowAPI.Data;
using ListaKontaktowAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly ApiContext _context;

    public ContactsController(ApiContext context)
    {
        _context = context;
    }

    // GET: api/contacts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Kontakt>>> GetContacts()
    {
        return await _context.kontakty
            .Include(k => k.Kategoria)
            .ToListAsync();
    }
    // GET: api/contacts/{email}
    [HttpGet("{email}")]
    public async Task<ActionResult<Kontakt>> GetContact(string email)
    {
        var contact = await _context.kontakty
            .Include(k => k.Kategoria)
            .FirstOrDefaultAsync(k => k.Email == email);

        return contact == null ? NotFound() : contact;
    }

    // POST: api/contacts
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Kontakt>> PostContact(Kontakt contact)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(contact.Imie) || string.IsNullOrWhiteSpace(contact.Nazwisko))
                return BadRequest("Imię i nazwisko nie mogą być puste.");

            if (!Validate.IsStrongPassword(contact.Haslo) || !Validate.IsValidEmail(contact.Email))
                return BadRequest("Niepoprawne hasło lub email.");

            var existing = await _context.kontakty.AnyAsync(k => k.Email == contact.Email);
            if (existing)
                return Conflict("Kontakt z tym adresem email już istnieje.");

            var categoryExists = await _context.SlownikKategorii.AnyAsync(c => c.Id == contact.KategoriaId);
            if (!categoryExists)
                return BadRequest("Niepoprawna kategoria.");

            _context.kontakty.Add(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContact), new { email = contact.Email }, contact);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Błąd serwera: {ex.Message}");
        }
    }

    // PUT: api/contacts/{email}
    [HttpPut("{email}")]
    [Authorize]
    public async Task<IActionResult> PutContact(string email, Kontakt contact)
    {
        Console.WriteLine(email);
        Console.WriteLine(contact.Email);
        
        if (!Validate.IsStrongPassword(contact.Haslo) || !Validate.IsValidEmail(contact.Email))
            return BadRequest("Niepoprawne hasło lub email.");

        var existingContact = await _context.kontakty.FirstOrDefaultAsync(k => k.Email == email);
        if (existingContact == null)
            return NotFound();

        var categoryExists = await _context.SlownikKategorii.AnyAsync(c => c.Id == contact.KategoriaId);
        if (!categoryExists)
            return BadRequest("Niepoprawna kategoria.");

        // Aktualizuj pola (nie nadpisuj całego obiektu, żeby EF poprawnie śledził zmiany)
        existingContact.Imie = contact.Imie;
        existingContact.Nazwisko = contact.Nazwisko;
        existingContact.Haslo = contact.Haslo;
        existingContact.Telefon = contact.Telefon;
        existingContact.Podkategoria = contact.Podkategoria;
        existingContact.DataUrodzenia = contact.DataUrodzenia;
        existingContact.KategoriaId = contact.KategoriaId;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/contacts/{email}
    [HttpDelete("{email}")]
    [Authorize]
    public async Task<IActionResult> DeleteContact(string email)
    {
        var contact = await _context.kontakty.FindAsync(email);
        if (contact == null)
            return NotFound();

        _context.kontakty.Remove(contact);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
