using ListaKontaktowAPI.Data;
using ListaKontaktowAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class SlownikKategoriiController : ControllerBase
{
    private readonly ApiContext _context;

    public SlownikKategoriiController(ApiContext context)
    {
        _context = context;
    }

    // GET: api/slownikkategorii
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SlownikKategorii>>> GetKategorii()
    {
        return await _context.SlownikKategorii.ToListAsync();
    }
}
