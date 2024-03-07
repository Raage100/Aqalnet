using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Companies;
using Aqalnet.Domain.Users;

namespace Aqalnet.Application.Companies;

public sealed class RegisterAgentCommandHandler
    : ICommandHandler<RegisterAgentCommand, RegisterAgentReponse>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IUserRepository _userRepository;
    private IUnitOfWork _unitOfWork;

    public RegisterAgentCommandHandler(
        ICompanyRepository companyRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork
    )
    {
        _companyRepository = companyRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
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
            request.Profile
        );
        _userRepository.Add(user);
        var company = await _companyRepository.GetByIdAsync(request.companyId);
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
