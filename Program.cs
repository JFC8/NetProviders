using Microsoft.EntityFrameworkCore;
using NetProviders.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PostDbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("NetProductsDB"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.25-mariadb"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
