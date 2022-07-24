namespace SpaceFlights.API.Dtos.Interfaces;

public interface IUpdateDto<T> 
{
    T Map(T parent);
}