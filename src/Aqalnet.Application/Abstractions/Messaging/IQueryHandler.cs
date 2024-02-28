using Aqalnet.Domain.Abstractions;
using MediatR;

namespace Aqalnet.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse> { }
