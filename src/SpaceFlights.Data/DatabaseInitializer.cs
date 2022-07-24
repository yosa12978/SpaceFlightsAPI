using Dapper;

namespace SpaceFlights.Data;

public class DatabaseInitializer 
{
    private readonly IDbConnectionFactory _dbConnectionFactory;
    public DatabaseInitializer(IDbConnectionFactory dbConnectionFactory) 
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task Initialize() 
    {
        var db = _dbConnectionFactory.GetConnection();
        await db.ExecuteAsync("CREATE TABLE IF NOT EXISTS Flights ("+
        "Id CHAR(36) PRIMARY KEY,"+
        "Mission TEXT NOT NULL,"+
        "Rocket TEXT NOT NULL,"+
        "Desc TEXT NOT NULL,"+
        "Date TEXT NOT NULL"+
        ");");
    } 
}