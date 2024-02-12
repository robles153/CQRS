using CQRS.Domain.Entities;

namespace CQRS.Domain.Repositories;

public interface IMemberRepository
{
    Task<IEnumerable<Member>> ListMembers();
    Task<Member> GetMemberById(int id);
    Task<Member> AddMember(Member member);
    void UpdateMember(Member member);
    Task<Member> DeleteMember(int id);
}
