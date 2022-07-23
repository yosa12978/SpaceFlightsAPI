using System.Data;
using Microsoft.Data.Sqlite;

namespace SpaceFlights.Data;

public interface IDbConnectionFactory {
    IDbConnection GetConnection();
}

public class SqliteConnectionFactory : IDbConnectionFactory {
    private readonly string connectionString;
    public SqliteConnectionFactory(string connectionString) {
        this.connectionString = connectionString;
    }
    public IDbConnection GetConnection() {
        IDbConnection conn = new SqliteConnection(connectionString);
        conn.Open();
        return conn;
    }
}