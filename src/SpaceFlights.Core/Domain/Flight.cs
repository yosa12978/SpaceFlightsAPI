using System.ComponentModel.DataAnnotations;

namespace SpaceFlights.Core.Domain;

public class Flight {
    [Required]
    public string Id {get;set;}
    [Required]
    public string Mission {get;set;}
    [Required]
    public string Rocket {get;set;}
    [Required]
    public string Desc {get;set;}
    [Required]
    public string Date {get;set;}
}
