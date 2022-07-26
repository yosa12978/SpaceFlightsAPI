using SpaceFlights.Core.Domain;
using SpaceFlights.Core.Repositories.Interfaces;
using SpaceFlights.Data;
using Dapper;

namespace SpaceFlights.Core.Repositories.Impl;

public class FlightRepository : IFlightRepository
{
    private readonly IDbConnectionFactory _factory;
    public FlightRepository(IDbConnectionFactory factory) 
    {
        _factory = factory;
    }
    public async Task CreateFlight(Flight f)
    {
        var db = _factory.GetConnection();
        await db.ExecuteAsync(@"INSERT INTO Flights VALUES (
            @Id, @Mission, @Rocket, @Desc, @Date
        )", f);
    }

    public async Task DeleteFlight(string id)
    {
        var db = _factory.GetConnection();
        await db.ExecuteAsync("DELETE FROM Flights WHERE Id = @Id", new {Id = id});
    }

    public async Task<Flight?> GetFlight(string id)
    {
        var db = _factory.GetConnection();
        return await db.QueryFirstOrDefaultAsync<Flight>(
            "SELECT * FROM Flights WHERE Id = @Id LIMIT 1", new {Id = id});
    }

    public async Task<IEnumerable<Flight>> GetFlights()
    {
        var db = _factory.GetConnection();
        return await db.QueryAsync<Flight>("SELECT * FROM Flights");
    }

    public async Task UpdateFlight(Flight f) 
    {
        var db = _factory.GetConnection();
        await db.ExecuteAsync(@"UPDATE Flights 
        SET Rocket=@Rocket, Mission=@Mission, Desc=@Desc, Date=@Date 
        WHERE Id=@Id", f);
    }
}