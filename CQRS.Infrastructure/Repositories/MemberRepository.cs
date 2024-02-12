using CQRS.Domain.Entities;
using CQRS.Domain.Repositories;
using CQRS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Infrastructure.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly AppDbContext _context;

    public MemberRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Member>> ListMembers()
    {
        var members = await _context.Members.ToListAsync();
        return members ?? Enumerable.Empty<Member>();
    }

    public async Task<Member> GetMemberById(int id)
    {
        var member = await _context.Members.FindAsync(id);
        if (member is null) throw new InvalidOperationException("Member not found");
        return member;
    }

    public async Task<Member> AddMember(Member member)
    {
        if (member is null) throw new ArgumentNullException(nameof(member));
        await _context.Members.AddAsync(member);
        return member;
    }

    public void UpdateMember(Member member)
    {
        if (member is null) throw new ArgumentNullException(nameof(member));
        _context.Members.Update(member);
    }

    public async Task<Member> DeleteMember(int id)
    {
        var member = await GetMemberById(id);

        if (member is null) throw new InvalidOperationException("Member not found");
        _context.Members.Remove(member);
        return member;
    }
}
