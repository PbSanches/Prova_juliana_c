using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class SorteioController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SorteioController(ApplicationDbContext context)
    {
        _context = context;
    }

  
    [HttpPost]
    public IActionResult PostSorteio([FromBody] Sorteio sorteio)
    {
        if (sorteio == null || !ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _context.Sorteios.Add(sorteio);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetSorteio), new { id = sorteio.Id }, sorteio);
    }    
    [HttpGet]
    public IActionResult GetSorteios()
    {
        var sorteios = _context.Sorteios;
        return Ok(sorteios);
    }

    [HttpGet("{id}")]
    public IActionResult GetSorteio(int id)
    {
        var sorteio = _context.Sorteios.Find(id);
        if (sorteio == null)
        {
            return NotFound();
        }

        return Ok(sorteio);
    }
}
