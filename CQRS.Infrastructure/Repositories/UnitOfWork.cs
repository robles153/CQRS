using CQRS.Domain.Repositories;
using CQRS.Infrastructure.Context;

namespace CQRS.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _context;
    private IMemberRepository? _memberRepository;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IMemberRepository MemberRepository => _memberRepository ??= new MemberRepository(_context);

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

