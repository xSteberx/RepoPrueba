using ProyectoPrograAvanzada1.Models;
using ProyectoPrograAvanzada1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUsuarioModel, UsuarioModel>();
builder.Services.AddSingleton<IUtilitariosModel, UtilitariosModel>();
builder.Services.AddSingleton<IProductoModel, ProductoModel>();
builder.Services.AddSingleton<ICarritoModel, CarritoModel>();
builder.Services.AddSingleton<ICategoriaModel, CategoriaModel>();
builder.Services.AddSingleton<IRolModel, RolModel>();
builder.Services.AddSingleton<IReporteModel, ReporteModel>();
builder.Services.AddSingleton<IComprasModel, ComprasModel>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=IniciarSesion}/{id?}");

app.Run();
