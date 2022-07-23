using System.ComponentModel.DataAnnotations;

namespace SpaceFlights.API.Dtos;

class FlightCreateDto {
    [Required]
    public string Rocket {get;set;}
    [Required]
    public string Mission {get;set;}
    [Required]
    public string Desc {get;set;}
    [Required]
    public string Date {get;set;}
}