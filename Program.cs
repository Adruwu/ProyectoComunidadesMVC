using Microsoft.EntityFrameworkCore;
using ProyectoComunidades.Controllers._Factory_StrategyFactory;
using ProyectoComunidades.Controllers.Checks;
using ProyectoComunidadesRelativo.Controllers;
using ProyectoComunidadesRelativo.DB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ValidateCredentials>();
builder.Services.AddScoped<CheckPasswordPattern>();
builder.Services.AddScoped<StrategyFactory>();  // Agrega StrategyFactory al contenedor de servicios


// PROYECTO RAIZ
string proyectoRaiz = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\.."));

    AppDomain.CurrentDomain.SetData("DataDirectory", proyectoRaiz);

    // ACCESO A BBDD
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        var configuration = builder.Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlServer(configuration);
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthorization();
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();


