using Microsoft.EntityFrameworkCore;
using Producto.Data;
using Producto.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 🔌 Conexión a la base de datos (EF Core)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🧠 Inyección de dependencias (Repository)
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

// ⚠️ Puedes dejar esto o quitarlo si no lo usas
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Productos}/{action=Index}/{id?}") // 👈 importante
    .WithStaticAssets();

app.Run();