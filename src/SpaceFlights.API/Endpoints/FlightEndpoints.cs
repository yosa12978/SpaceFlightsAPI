using SpaceFlights.Core.Repositories;
using SpaceFlights.Core.Domain;
using SpaceFlights.API.Dtos;

namespace SpaceFlights.API.Endpoints;

public static class FlightEndpoints {
    public static void UseFlightEndpoints(this WebApplication app) {
        app.MapGet("/flights", GetFlights);
        app.MapGet("/flights/{id}", GetFlight);
        app.MapPost("/flights", CreateFlight);
        app.MapDelete("/flights", DeleteFlight);
    }

    private static async Task<IResult> GetFlights(IFlightRepository repo) {
        return Results.Ok(await repo.GetFlights());
    }

    private static async Task<IResult> GetFlight(string id, IFlightRepository repo) {
        return Results.Ok(await repo.GetFlight(Guid.Parse(id)));
    }

    private static async Task<IResult> DeleteFlight(string id, IFlightRepository repo) {
        await repo.DeleteFlight(Guid.Parse(id));
        return Results.Ok(new {Status = 200, Message = "success"});
    }

    private static async Task<IResult> CreateFlight(FlightCreateDto flight_dto, IFlightRepository repo) {
        Flight flight = new Flight {
            Id = Guid.NewGuid().ToString(),
            Date = flight_dto.Date,
            Mission = flight_dto.Mission,
            Rocket = flight_dto.Rocket,
            Desc = flight_dto.Desc
        };
        await repo.CreateFlight(flight);
        return Results.Created("/flights/", new {Status = 201, Message = "created"});
    }
}