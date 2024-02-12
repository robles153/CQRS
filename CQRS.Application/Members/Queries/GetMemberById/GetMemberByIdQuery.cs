using CQRS.Domain.Entities;
using MediatR;

namespace CQRS.Application.Members.Queries.GetMemberById;

public class GetMemberByIdQuery : IRequest<Member>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }
}
