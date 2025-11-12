using Microsoft.OpenApi.Models;
using NetCoreAPIPostgresQSL.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "NetCoreAPIPostgresSQL",
        Version = "v1"
    });
});

// Configuración de PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
var postgresSQLConnectionConfiguration = new PostgresSQLConfiguration(connectionString);
builder.Services.AddSingleton(postgresSQLConnectionConfiguration);

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
