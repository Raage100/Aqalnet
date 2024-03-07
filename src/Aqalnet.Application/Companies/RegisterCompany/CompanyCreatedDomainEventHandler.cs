using Aqalnet.Application.Abstractions.Email;
using Aqalnet.Domain.Companies;
using Aqalnet.Domain.Users;
using MediatR;

namespace Aqalnet.Application.Companies.RegisterCompany;

public sealed class CompanyCreatedDomainEventHandler
    : INotificationHandler<CompanyCreatedDomainEvent>
{
    private IUserRepository _userRepository;
    private ICompanyRepository _companyRepository;
    private IEmailService _emailService;

    public CompanyCreatedDomainEventHandler(
        IUserRepository userRepository,
        IEmailService emailService,
        ICompanyRepository companyRepository
    )
    {
        _userRepository = userRepository;
        _companyRepository = companyRepository;
        _emailService = emailService;
    }

    public async Task Handle(
        CompanyCreatedDomainEvent notification,
        CancellationToken cancellationToken
    )
    {
        var company = await _companyRepository.GetByIdAsync(
            notification.companyId,
            cancellationToken
        );

        if (company == null)
        {
            throw new ArgumentException("Company not found");
        }

        var user = await _userRepository.GetByIdAsync(notification.userId, cancellationToken);
        user.AssociateWithCompany(company.Id);

        //send email here to the company admin





        await Task.CompletedTask;

        return;
    }
}
