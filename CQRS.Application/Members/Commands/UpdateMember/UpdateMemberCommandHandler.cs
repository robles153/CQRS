using CQRS.Domain.Entities;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Members.Commands.UpdateMember;

public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, Member>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMemberCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Member> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
    {

        var member = await GetMember(request.Id);
        member.Update(request.FirstName, request.LastName, request.Gender, request.Email, request.IsActive);

        _unitOfWork.MemberRepository.UpdateMember(member);
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
