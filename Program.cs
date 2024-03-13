using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// For AddDbContext Services
// Right-click Project, Manage NuGet Packages
// Search for Microsoft.EntityFrameworkCore.SqlServer version 8 and install
// UseSQLServer squiggly line, Ctrl + . to add "using Microsoft.EntityFrameworkCore;
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middlewares
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
