using CQRS.Domain.Entities;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Members.Queries.GetAllMembers;

public class GetMembersQueryHandler : IRequestHandler<GetMembersQuery, IEnumerable<Member>>
{

    private readonly IMemberDapperRepository _memberDapperRepository;
    public GetMembersQueryHandler(IMemberDapperRepository memberDapperRepository)
    {
        _memberDapperRepository = memberDapperRepository;
    }

    public async Task<IEnumerable<Member>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
    {

        var members = await _memberDapperRepository.GetAllMembers();
        return members;
    }
}
