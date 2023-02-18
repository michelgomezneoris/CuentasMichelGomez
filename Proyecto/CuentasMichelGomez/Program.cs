using CuentasMichelGomez.DbContexts;
using CuentasMichelGomez.Scopeds;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.WebHost.UseUrls("http://localhost:5024");

// For Entity Frameworks
//string? stringConnection = Environment.GetEnvironmentVariable("ConnectionString");
string? stringConnection = builder.Configuration.GetConnectionString("DataConnection");
builder.Services.AddDbContext<CuentasDbContext>(config =>
    config.UseNpgsql(stringConnection));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Scoped 
builder.Services.AddApiScopeds();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
