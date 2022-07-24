using System.ComponentModel.DataAnnotations;
using SpaceFlights.Core.Domain;
using SpaceFlights.API.Dtos.Interfaces;
namespace SpaceFlights.API.Dtos.Impl;

public class FlightUpdateDto : IUpdateDto<Flight> 
{
    public string? Rocket {get;set;}
    public string? Mission {get;set;}
    public string? Desc {get;set;}
    public string? Date {get;set;}

    public Flight Map(Flight flight) 
    {
        return new Flight 
        {
            Id = flight.Id,
            Rocket = this.Rocket ?? flight.Rocket,
            Mission = this.Mission ?? flight.Mission,
            Desc = this.Desc ?? flight.Desc,
            Date = this.Date ?? flight.Date,
        };
    }
}