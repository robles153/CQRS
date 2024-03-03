using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRS.Application.Members.Commands.Notifications;

public class MemberCreatedEmailHandler : INotificationHandler<MemberCreatedNotification>
{
    private readonly ILogger<MemberCreatedEmailHandler>? _logger;

    public MemberCreatedEmailHandler(ILogger<MemberCreatedEmailHandler>? logger)
    {
        _logger = logger;
    }

    public Task Handle(MemberCreatedNotification notification, CancellationToken cancellationToken)
    {
        // Send a comfirmation email
        _logger?.LogInformation($"Confirmation email sent for : {notification.Mamber.LastName}");


        // Logica para enviar email


        return Task.CompletedTask;
    }
}
