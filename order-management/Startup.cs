public class Startup
{
    //For more information on how to configure your application,
    //visit http://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<MyWebApiContext>(options =>
            options.UseNpgsql(
                Configuration.GetConnectionString("PSQLConnection")
            )
        );
    }

    public void Configure(IApplicationBuilder app)
    {

    }
}

