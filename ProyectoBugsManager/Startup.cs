using ProyectoBugsManager.Data;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<BugsManagerContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("BugsManagerContext")));
}
}