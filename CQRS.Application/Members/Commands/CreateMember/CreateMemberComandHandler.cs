using CQRS.Application.Members.Commands.Notifications;
using CQRS.Domain.Entities;
using CQRS.Domain.Repositories;
using MediatR;

namespace CQRS.Application.Members.Commands.CreateMember;

public class CreateMemberComandHandler : IRequestHandler<CreateMemberCommand, Member>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;

    public CreateMemberComandHandler(IUnitOfWork unitOfWork, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }

    public async Task<Member> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var member = new Member(request.FirstName, request.LastName, request.Gender, request.Email, request.IsActive);

        await _unitOfWork.MemberRepository.AddMember(member);
        await _unitOfWork.CommitAsync();
        await _mediator.Publish(new MemberCreatedNotification(member), cancellationToken);

        return member;
    }
}
