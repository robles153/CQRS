using CQRS.Domain.Entities;
using CQRS.Domain.Repositories;
using Dapper;
using System.Data;

namespace CQRS.Infrastructure.Repositories;

public class MemberDapperRepository : IMemberDapperRepository
{
    private readonly IDbConnection _dbConnection;

    public MemberDapperRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<Member>> GetAllMembers()
    {
        var query = "SELECT * FROM Members";
        return await _dbConnection.QueryAsync<Member>(query);

    }

    public Task<Member?> GetMemberById(int id)
    {
        string query = "SELECT * FROM Members WHERE Id = @Id";
        return _dbConnection.QueryFirstOrDefaultAsync<Member>(query, new { Id = id });
    }
}
