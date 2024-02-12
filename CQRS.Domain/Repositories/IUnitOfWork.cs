namespace CQRS.Domain.Repositories;

public interface IUnitOfWork
{
    IMemberRepository MemberRepository { get; }
    Task CommitAsync();
}
