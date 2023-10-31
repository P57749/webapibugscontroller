using ProyectoBugsManager.Data;
using Microsoft.EntityFrameworkCore;
using ProyectoBugsManager.Models;

[Route("api/[controller]")]
[ApiController]
public class BugController : ControllerBase
{
    private readonly BugsManagerContext _context;

    public BugController(BugsManagerContext context)
    {
        _context = context;
    }

    // GET: api/Bug
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Error>>> GetErrors()
    {
        return await _context.Errors.ToListAsync();
    }

    // GET: api/Bug/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Error>> GetError(int id)
    {
        var error = await _context.Errors.FindAsync(id);

        if (error == null)
        {
            return NotFound();
        }

        return error;
    }

    // PUT: api/Bug/5
    [HttpPut("{id}")]
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
[HttpPost]
public async Task<ActionResult<Error>> PostError(Error error)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    _context.Errors.Add(error);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetError", new { id = error.ErrorId }, error);
}


    // DELETE: api/Bug/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteError(int id)
    {
        var error = await _context.Errors.FindAsync(id);
        if (error == null)
        {
            return NotFound();
        }

        _context.Errors.Remove(error);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ErrorExists(int id)
    {
        return _context.Errors.Any(e => e.ErrorId == id);
    }

    // GET: api/Bug?pageNumber=1&pageSize=10&sortBy=Description
[HttpGet]
public async Task<ActionResult<IEnumerable<Error>>> GetErrors(int pageNumber = 1, int pageSize = 10, string sortBy = "Description")
{
    var errors = _context.Errors.AsQueryable();

    if (!string.IsNullOrEmpty(sortBy))
    {
        errors = string.Equals(sortBy, "Description", StringComparison.OrdinalIgnoreCase) ? errors.OrderBy(e => e.Description) : errors.OrderBy(e => e.ErrorId);
    }

    return await errors.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
}

}


