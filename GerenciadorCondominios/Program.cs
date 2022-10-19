using GerenciadorCondominios.BLL.Models;
using GerenciadorCondominios.DAL.Context;
using GerenciadorCondominios.DAL.Interfaces;
using GerenciadorCondominios.DAL.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();


// Conexão com o banco de dados \/
string Connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options =>
                  options.UseSqlServer(Connection));

builder.Services.AddIdentity<Usuario, Funcao>().AddEntityFrameworkStores<DbContext>();
builder.Services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



//string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<APICatalogContext>(options =>
//                 options.UseMySql(mySqlConnection,
//                 ServerVersion.AutoDetect(mySqlConnection)));


//builder.Services.AddIdentity<Usuario, Funcao>().AddEntityFrameworkStores<DataContext>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
