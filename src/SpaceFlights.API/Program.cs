using SpaceFlights.API.Endpoints;
using SpaceFlights.Core.Repositories;
using SpaceFlights.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
    new SqliteConnectionFactory(builder.Configuration.GetValue<string>("Database:ConnectionString")));
builder.Services.AddSingleton<DatabaseInitializer>();
builder.Services.AddSingleton<IFlightRepository, FlightRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHealthChecks("/health");

app.UseFlightEndpoints();

var db = app.Services.GetRequiredService<DatabaseInitializer>();
await db.Initialize();

app.Run();
