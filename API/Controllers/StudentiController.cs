using API.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentiController : Controller
{
    private readonly DataContext _context;

    public StudentiController(DataContext context)
    {
        _context = context;
    }
    
    [HttpPost(Name = "AddStudente")]
    public IActionResult AddStudente(Studente stud)
    {
        try
        {
            _context.Studenti.Add(stud);
            _context.SaveChanges();

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet(Name = "GetStudenti")]
    public IActionResult GetStudenti()
    {
        try
        {
            return Ok(_context.Studenti.ToList());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("{id}", Name = "GetStudente")]
    public IActionResult GetStudente(int id)
    {
        try
        {
            return Ok(_context.Studenti.Find(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}