using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Companies;
using Aqalnet.Domain.Users;

namespace Aqalnet.Application.Companies.RegisterCompany;

public sealed class RegisterCompanyCommandHandler : ICommandHandler<RegisterCompanyCommand, Guid>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IUserRepository _userRepository;
    private IUnitOfWork _unitOfWork;

    public RegisterCompanyCommandHandler(
        ICompanyRepository companyRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork
    )
    {
        _userRepository = userRepository;
        _companyRepository = companyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        RegisterCompanyCommand request,
        CancellationToken cancellationToken
    )
    {
        var company = Company.Create(request.CompanyName, request.Address, request.Logo, request.firstName, request.lastName,request.email,request.mobileNumber, request.ProfilePicture);
        if (company is null)
        {
            return Result.Failure<Guid>(CompanyErrors.NotFound);
        }

        _companyRepository.Add(company);

       


        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(company.Id);
    }
}
