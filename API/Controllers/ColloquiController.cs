using API.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;
using Shared.Models;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ColloquiController : Controller
{
    private readonly DataContext _context;

    public ColloquiController(DataContext context)
    {
        _context = context;
    }
    
    // get all colloqui
    [HttpGet]
    public async Task<IActionResult> GetColloqui()
    {
        try
        {
            var colloqui = await _context.Colloqui
                .Include(c=>c.Docente)
                .Include(c=> c.Studente)
                .ToListAsync();
            return Ok(colloqui);
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    
    // create a new colloquio
    [HttpPost]
    public async Task<IActionResult> CreateColloquio(AddAppuntamento addApp)
    {
        try
        {
            Appuntamento app = new Appuntamento();
            app.Docente = await _context.Docenti.FirstOrDefaultAsync(d => d.Id == addApp.DocenteId);
            app.Studente = await _context.Studenti.FirstOrDefaultAsync(s => s.Id == addApp.StudenteId);
            app.DataColloquioRichiesta = addApp.Appuntamento;
            app.Confermato = false;
            
            await _context.Colloqui.AddAsync(app);
            await _context.SaveChangesAsync();
            return Ok(app);
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    // get colloqui from a specific docente
    [HttpGet]
    [Route("GetColloquiDocente/{docenteId}")]
    public async Task<IActionResult> GetColloqui(int docenteId)
    {
        try
        {
            var colloqui = await _context.Colloqui
                .Include(c=>c.Docente)
                .Include(c=> c.Studente)
                .Where(c => c.Docente.Id == docenteId).ToListAsync();
            return Ok(colloqui);
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    // get colloqui from a specific studente
    [HttpGet]
    [Route("GetColloquiStudente/{studenteId}")]
    public async Task<IActionResult> GetColloquiStudente(int studenteId)
    {
        try
        {
            var colloqui = await _context.Colloqui
                .Include(c=>c.Studente)
                .Include(c=> c.Docente)
                .Where(c => c.Studente.Id == studenteId).ToListAsync();
            return Ok(colloqui);
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    
    // confirm colloquio 
    [HttpPut]
    [Route("ConfermaColloquio/{colloquioId}")]
    public async Task<IActionResult> ConfermaColloquio(int colloquioId, bool conferma)
    {
        try
        {
            var colloquio = await _context.Colloqui.FirstOrDefaultAsync(c => c.Id == colloquioId);
            if (colloquio == null)
            {
                return NotFound("Colloquio non trovato");
            }
            colloquio.Confermato = conferma;
            await _context.SaveChangesAsync();
            return Ok(colloquio);
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}