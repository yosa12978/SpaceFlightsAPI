using SpaceFlights.Core.Domain;
using SpaceFlights.API.Dtos.Interfaces;
using SpaceFlights.API.Services.Interfaces;
using SpaceFlights.Core.Repositories.Interfaces;

namespace SpaceFlights.API.Services.Impl;

public class FlightService : IFlightService
{
    private readonly IFlightRepository repo;
    public FlightService(IFlightRepository repo) 
    {
        this.repo = repo;
    }

    public async Task CreateFlight(ICreateDto<Flight> flight_dto)
    {
        await repo.CreateFlight(flight_dto.Map());
    }

    public async Task<bool> DeleteFlight(string id)
    {
        Flight? flight = await repo.GetFlight(id);
        if (flight == null)
            return false;
        await repo.DeleteFlight(id);
        return true;
    }

    public async Task<Flight?> GetFlightByID(string id)
    {
        return await repo.GetFlight(id);
    }

    public async Task<IEnumerable<Flight>> GetFlights()
    {
        return await repo.GetFlights();
    }

    public async Task<bool> UpdateFlight(string id, IUpdateDto<Flight> flight_dto)
    {
        Flight? flight = await repo.GetFlight(id);
        if (flight == null)
            return false;
        flight = flight_dto.Map(flight);
        await repo.UpdateFlight(flight);
        return true;
    }
}