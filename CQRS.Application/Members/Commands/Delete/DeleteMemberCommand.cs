using CQRS.Domain.Entities;
using MediatR;

namespace CQRS.Application.Members.Commands.Delete;

public class DeleteMemberCommand : IRequest<Member>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

}
