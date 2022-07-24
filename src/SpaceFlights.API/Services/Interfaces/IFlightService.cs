using SpaceFlights.Core.Domain;
using SpaceFlights.API.Dtos.Interfaces;

namespace SpaceFlights.API.Services.Interfaces;

public interface IFlightService 
{
    Task<IEnumerable<Flight>> GetFlights();
    Task<Flight?> GetFlightByID(string id);
    Task<bool> DeleteFlight(string id);
    Task<bool> UpdateFlight(string id, IUpdateDto<Flight> flight_dto);
    Task CreateFlight(ICreateDto<Flight> flight_dto);
}