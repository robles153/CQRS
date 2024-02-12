using CQRS.Domain.Entities;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Members.Commands.CreateMember;

public class CreateMemberComandHandler : IRequestHandler<CreateMemberCommand, Member>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMemberComandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Member> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var member = new Member(request.FirstName, request.LastName, request.Gender, request.Email, request.IsActive);

        await _unitOfWork.MemberRepository.AddMember(member);
        await _unitOfWork.CommitAsync();
        return member;
    }
}
