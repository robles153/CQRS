using CQRS.Domain.Entities;
using MediatR;

namespace CQRS.Application.Members.Commands.Notifications;

public class MemberCreatedNotification : INotification
{
    public Member Mamber { get; }

    public MemberCreatedNotification(Member mamber)
    {
        Mamber = mamber;
    }
}
