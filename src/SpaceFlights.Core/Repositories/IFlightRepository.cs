using SpaceFlights.Core.Domain;

namespace SpaceFlights.Core.Repositories;

public interface IFlightRepository {
    Task<IEnumerable<Flight>> GetFlights();
    Task<Flight?> GetFlight(Guid Id);
    Task CreateFlight(Flight f);
    Task DeleteFlight(Guid id);
    Task UpdateFlight(Flight f);
} 
