using System;

namespace Bugs;

public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<BugsManagerContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("BugsManagerDatabase")));
}
