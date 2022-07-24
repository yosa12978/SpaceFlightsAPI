using SpaceFlights.Core.Domain;

namespace SpaceFlights.Core.Repositories.Interfaces;

public interface IFlightRepository 
{
    Task<IEnumerable<Flight>> GetFlights();
    Task<Flight?> GetFlight(string Id);
    Task CreateFlight(Flight f);
    Task DeleteFlight(string id);
    Task UpdateFlight(Flight f);
} 
