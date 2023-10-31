using ProyectoBugsManager.Data;
using Microsoft.EntityFrameworkCore;
using ProyectoBugsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



[Route("api/[controller]")]
[ApiController]

public class BugsManagerContext : DbContext
{
    public DbSet<Error> Errores { get; set; }
    public DbSet<Error> Usuarios { get; set; }
    public DbSet<Error> Proyectos { get; set; }

    // otras propiedades y métodos...
}


public class BugController : ControllerBase
{
    private readonly BugsManagerContext _context;

    public BugController(BugsManagerContext context)
    {
        _context = context;
    }

    // GET: api/Bug
    //[HttpGet]
    public async Task<ActionResult<IEnumerable<Error>>> GetErrors()
    {
        return await _context.Errores.ToListAsync();
    }

    // GET: api/Bug/5
    //[HttpGet("{id}")]
    public async Task<ActionResult<Error>> GetError(int id)
    {
        var error = await _context.Errores.FindAsync(id);

        if (error == null)
        {
            return NotFound();
        }

        return error;
    }

    // PUT: api/Bug/5
    //[HttpPut("{id}")]
    public async Task<IActionResult> PutError(int id, Error error)
    {
        if (id != error.ErrorId)
        {
            return BadRequest();
        }

        _context.Entry(error).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ErrorExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Bug
    //[HttpPost]
    // POST: api/Bug
    //[HttpPost]
    public async Task<ActionResult<Error>> PostError(Error error)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Errores.Add(error); // Cambiado de _context.Error a _context.Errores
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetError", new { id = error.ErrorId }, error);
    }



    // DELETE: api/Bug/5
    //[HttpDelete("{id}")]
    public async Task<IActionResult> DeleteError(int id)
    {
        var error = await _context.Errores.FindAsync(id);
        if (error == null)
        {
            return NotFound();
        }

        _context.Errores.Remove(error);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ErrorExists(int id)
    {
        return _context.Errores.Any(e => e.ErrorId == id);
    }

    // GET: api/Bug?pageNumber=1&pageSize=10&sortBy=Description
//[HttpGet]
public async Task<ActionResult<IEnumerable<Error>>> GetErrors(int pageNumber = 1, int pageSize = 10, string sortBy = "Description")
{
    var errors = _context.Errores.AsQueryable();

    if (!string.IsNullOrEmpty(sortBy))
    {
        errors = string.Equals(sortBy, "Description", StringComparison.OrdinalIgnoreCase) ? errors.OrderBy(e => e.Description) : errors.OrderBy(e => e.ErrorId);
    }

    return await errors.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
}

}


