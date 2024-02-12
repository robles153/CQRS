using CQRS.Domain.Entities;

namespace CQRS.Domain.Repositories;

public interface IMemberDapperRepository
{
    Task<IEnumerable<Member>> GetAllMembers();
    Task<Member?> GetMemberById(int id);
}
