using System.ComponentModel.DataAnnotations;

namespace SpaceFlights.Core.Domain;

public class Flight 
{
    [Required]
    public string Id {get;set;} = default!;
    [Required]
    public string Mission {get;set;} = default!;
    [Required]
    public string Rocket {get;set;} = default!;
    [Required]
    public string Desc {get;set;} = default!;
    [Required]
    public string Date {get;set;} = default!;
}
