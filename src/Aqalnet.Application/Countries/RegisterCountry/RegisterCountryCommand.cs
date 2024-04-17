using System.Windows.Input;
using Aqalnet.Application.Abstractions.Messaging;

namespace Aqalnet.Application.Countries.RegisterCountry;

public record RegisterCountryCommand(string Name) : ICommand<Guid>;
