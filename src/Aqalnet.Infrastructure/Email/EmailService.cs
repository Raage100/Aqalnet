using Aqalnet.Application.Abstractions.Email;

namespace Aqalnet.Infrastructure.Email;

public sealed class EmailService : IEmailService
{
    public Task SendAsync(string email, string subject, string body)
    {
        return Task.CompletedTask;
    }
}
