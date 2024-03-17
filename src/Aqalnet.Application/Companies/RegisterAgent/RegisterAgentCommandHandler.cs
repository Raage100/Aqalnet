using Aqalnet.Application.Abstractions.Clock;
using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Companies;
using Aqalnet.Domain.Users;

namespace Aqalnet.Application.Companies;

internal sealed class RegisterAgentCommandHandler
    : ICommandHandler<RegisterAgentCommand, RegisterAgentReponse>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;

    public RegisterAgentCommandHandler(
        ICompanyRepository companyRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider
    )
    {
        _companyRepository = companyRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result<RegisterAgentReponse>> Handle(
        RegisterAgentCommand request,
        CancellationToken cancellationToken
    )
    {
        var user = User.Create(
            request.firstName,
            request.lastName,
            request.email,
            request.mobileNumber,
            request.Profile,
            DateOnly.FromDateTime(_dateTimeProvider.UtcNow)
        );
        _userRepository.Add(user);
        var company = await _companyRepository.GetByIdAsync(request.companyId);

        if (company == null)
        {
            return Result.Failure<RegisterAgentReponse>(CompanyErrors.NotFound);
        }
        var agent = Company.CreateAgent(
            request.companyId,
            request.firstName,
            request.lastName,
            request.email,
            request.mobileNumber,
            Titles.RealEstateAgent,
            user.Id
        );
        company.AddAgent(agent);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(new RegisterAgentReponse(agent.Id, agent.Email));
    }
}
