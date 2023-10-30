


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

    // POST: api/Bug
    [HttpPost]
    public async Task<ActionResult<Error>> PostError(Error error)
    {
        _context.Errors.Add(error);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetError", new { id = error.Id }, error);
    }
}
