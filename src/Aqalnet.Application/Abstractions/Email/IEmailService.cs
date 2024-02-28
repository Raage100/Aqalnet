namespace Aqalnet.Application.Abstractions.Email;

public interface IEmailService
{
    Task SendAsync(string email, string subject, string body);
}
