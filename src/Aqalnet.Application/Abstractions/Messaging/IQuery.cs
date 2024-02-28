using Aqalnet.Domain.Abstractions;
using MediatR;

namespace Aqalnet.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
