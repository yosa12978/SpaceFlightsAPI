namespace SpaceFlights.API.Dtos.Impl;

public class StatusMessage 
{
    public int Status {get;set;} = default!;
    public string Message {get;set;} = default!;

    public StatusMessage(int Status, string Message) 
    {
        this.Status = Status;
        this.Message = Message;
    }
}