using Comercio.Data;
using Microsoft.OpenApi.Models;
using Comercio.Models;
using MySQL.Data.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Description = "Minimal APIs", Version = "v1" });
});


builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
});


app.MapControllers();

app.Run();
