using Inicio.DB.Data;
using Inicio.Server.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(
    x=> x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//---------------------------------------------------------------------------
//agregar el database context

builder.Services.AddDbContext<Context>(op => op.UseSqlServer("name=conn"));

//---------------------------------------------------------------------------

//agregar el automapper

builder.Services.AddAutoMapper(typeof(Program));

//-------------------------------------------------------------------------
//Inyectamos la clase titulo repositorio

builder.Services.AddScoped<ITituloRepositorio, TituloRepositorio>();

//-------------------------------------------------------------------------
//Inyectamos la clase tipo de documento repositorio
builder.Services.AddScoped<ITDocumentoRepositorio, TDocumentoRepositorio>();

//-------------------------------------------------------------------------

//constructor de la aplicacion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWebAssemblyDebugging();
app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
