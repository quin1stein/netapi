using Microsoft.EntityFrameworkCore;
using NetApi.Data;
var builder = WebApplication.CreateBuilder(args);

// Add DbContext with SQL Server
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Controllers
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add this line to map controller endpoints
app.MapControllers();
app.Run();
