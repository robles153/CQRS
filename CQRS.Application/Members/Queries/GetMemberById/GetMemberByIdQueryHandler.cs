using CQRS.Domain.Entities;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Members.Queries.GetMemberById;

public class GetMemberByIdQueryHandler : IRequestHandler<GetMemberByIdQuery, Member>
{
    private readonly IMemberDapperRepository _memberDapperRepository;

    public GetMemberByIdQueryHandler(IMemberDapperRepository memberDapperRepository)
    {
        _memberDapperRepository = memberDapperRepository;
    }

    public async Task<Member> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
    {
        var member = await _memberDapperRepository.GetMemberById(request.Id);
        if (member == null)
        {
            throw new Exception("Member not found");
        }
        return member;
    }

    public Task<Member?> GetMemberById(int id)
    {
        var member = _memberDapperRepository.GetMemberById(id);
        if (member == null)
        {
            throw new Exception("Member not found");
        }
        return member;

    }
}
