using CodeKatas.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddDbContext<KataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GobmanCodeKatas")));

app.MapGet("/", () => "Hello World!");

app.Run();
