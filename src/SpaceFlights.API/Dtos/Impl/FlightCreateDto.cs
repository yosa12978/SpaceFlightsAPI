using System.ComponentModel.DataAnnotations;
using SpaceFlights.Core.Domain;
using SpaceFlights.API.Dtos.Interfaces;

namespace SpaceFlights.API.Dtos.Impl;

public class FlightCreateDto : ICreateDto<Flight> 
{
    [Required]
    public string Rocket {get;set;} = default!;
    [Required]
    public string Mission {get;set;} = default!;
    [Required]
    public string Desc {get;set;} = default!;
    [Required]
    public string Date {get;set;} = default!;

    public Flight Map() 
    {
        return new Flight 
        {
            Id = Guid.NewGuid().ToString(),
            Rocket = this.Rocket,
            Mission = this.Mission,
            Desc = this.Desc,
            Date = this.Date
        };
    }
}