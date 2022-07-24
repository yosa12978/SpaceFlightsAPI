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
        app.MapPut("/flights/{id}", UpdateFlights);
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

    private static async Task<IResult> UpdateFlights(string id,IFlightRepository repo,FlightCreateDto flight_dto) {
        Flight? flight = await repo.GetFlight(Guid.Parse(id));
        flight.Rocket = flight_dto.Rocket;
        flight.Mission = flight_dto.Mission;
        flight.Desc = flight_dto.Desc;
        flight.Date = flight_dto.Date;
        await repo.UpdateFlight(flight);
        return Results.Ok(new {Status = 200, Message = "success"});
    }
}