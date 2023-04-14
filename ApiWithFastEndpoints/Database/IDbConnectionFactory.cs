using System.Data;

namespace ApiWithFastEndpoints.Database;

public interface IDbConnectionFactory
{
    public Task<IDbConnection> CreateConnectionAsync();
}
