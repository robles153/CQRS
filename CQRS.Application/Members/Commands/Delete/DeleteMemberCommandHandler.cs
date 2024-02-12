using CQRS.Domain.Entities;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Members.Commands.Delete;

public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand, Member>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMemberCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Member> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await GetMember(request.Id);
        _unitOfWork.MemberRepository.DeleteMember(member.Id);
        await _unitOfWork.CommitAsync();
        return member;

    }

    private async Task<Member> GetMember(int id)
    {
        var member = await _unitOfWork.MemberRepository.GetMemberById(id);
        if (member == null)
        {
            throw new Exception("Member not found");
        }
        return member;
    }
}
