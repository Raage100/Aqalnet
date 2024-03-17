using Aqalnet.Application.Abstractions.Clock;
using Aqalnet.Application.Abstractions.Email;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Companies;
using Aqalnet.Domain.Users;
using MediatR;

namespace Aqalnet.Application.Companies.RegisterCompany;

public sealed class CompanyCreatedDomainEventHandler
    : INotificationHandler<CompanyCreatedDomainEvent>
{
    private IUserRepository _userRepository;
    private ICompanyRepository _companyRepository;

    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CompanyCreatedDomainEventHandler(
        IUserRepository userRepository,
        ICompanyRepository companyRepository,
        IUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider
    )
    {
        _userRepository = userRepository;
        _companyRepository = companyRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task Handle(
        CompanyCreatedDomainEvent notification,
        CancellationToken cancellationToken
    )
    {
        var company = await _companyRepository.GetByIdAsync(notification.companyId);
        var user = User.CreateAdminUser(
            notification.firstName,
            notification.lastName,
            notification.email,
            notification.mobilePhone,
            DateOnly.FromDateTime(_dateTimeProvider.UtcNow),
            notification.profilePicture,
            notification.companyId
        );
        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
