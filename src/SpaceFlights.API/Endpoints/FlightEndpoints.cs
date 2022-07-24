using System.Runtime.Versioning;
using SpaceFlights.API.Services.Interfaces;
using SpaceFlights.Core.Domain;
using SpaceFlights.API.Dtos.Impl;

namespace SpaceFlights.API.Endpoints;

public static class FlightEndpoints 
{
    public static void UseFlightEndpoints(this WebApplication app) 
    {
        app.MapGet("/flights", GetFlights);
        app.MapGet("/flights/{id}", GetFlight);
        app.MapPost("/flights", CreateFlight);
        app.MapPut("/flights/{id}", UpdateFlights);
        app.MapDelete("/flights/{id}", DeleteFlight);
    }

    private static async Task<IResult> GetFlights(IFlightService flightService) 
    {
        return Results.Ok(await flightService.GetFlights());
    }

    private static async Task<IResult> GetFlight(string id, IFlightService flightService) 
    {
        Flight? flight = await flightService.GetFlightByID(id);
        if (flight == null)
            return Results.NotFound(new StatusMessage(404, "Not Found"));
        return Results.Ok(flight);
    }

    private static async Task<IResult> CreateFlight(FlightCreateDto flight_dto, IFlightService flightService) 
    {

        await flightService.CreateFlight(flight_dto);
        return Results.Created("/flights/", new StatusMessage(201, "Created"));
    }

    private static async Task<IResult> UpdateFlights(string id,IFlightService flightService,FlightUpdateDto flight_dto) 
    {
        bool ok = await flightService.UpdateFlight(id, flight_dto);
        return Results.Ok(new StatusMessage(200, "Success"));
    }

    private static async Task<IResult> DeleteFlight(string id, IFlightService flightService) 
    {
        bool ok = await flightService.DeleteFlight(id);
        if (!ok)
            return Results.NotFound(new StatusMessage(404, "Not Found"));
        return Results.Ok(new StatusMessage(200, "Success"));
    }
}