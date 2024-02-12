using CQRS.Domain.Entities;
using MediatR;

namespace CQRS.Application.Members.Queries.GetAllMembers;

public class GetMembersQuery : IRequest<IEnumerable<Member>>
{
}
