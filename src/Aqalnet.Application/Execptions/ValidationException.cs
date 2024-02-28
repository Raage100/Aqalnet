namespace Aqalnet.Application.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(IEnumerable<ValidationError> errros)
    {
        Errors = errros;
    }

    public IEnumerable<ValidationError> Errors { get; }
}
