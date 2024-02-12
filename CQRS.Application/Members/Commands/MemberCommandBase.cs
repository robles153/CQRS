using CQRS.Domain.Entities;
using MediatR;

namespace CQRS.Application.Members.Commands;

#pragma warning disable CS8618
public abstract class MemberCommandBase : IRequest<Member>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public bool? IsActive { get; set; }
}
