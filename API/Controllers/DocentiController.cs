using API.Context;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocentiController : Controller
{
    private readonly DataContext _context;

    public DocentiController(DataContext context)
    {
        _context = context;
    }

    [HttpPost(Name = "AddDocente")]
    public ActionResult<Docente> Post(Docente docente)
    {
        // add the person to the database
        _context.Docenti.Add(docente);
    
        // save the changes
        _context.SaveChanges();
    
        return Ok(docente);
    }
    
    [HttpGet(Name = "GetDocenti")]
    public ActionResult<IEnumerable<Docente>> Get()
    {
        return Ok(_context.Docenti.ToList());
    }
    
    [HttpGet("{id}", Name = "GetDocente")]
    public ActionResult<Docente> Get(int id)
    {
        return Ok(_context.Docenti.Find(id));
    }
}