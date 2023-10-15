using System.Net;

namespace HttpExceptions
{
    public class HttpException : Exception
    {
        public List<string>? ErrorMessages { get; }
        public HttpStatusCode StatusCode { get; }

        public HttpException(HttpStatusCode statusCode, string? message = default, List<string>? errors = default)
            : base(message)
        {
            ErrorMessages = errors;
            StatusCode = statusCode;
        }
    }

    public class BadRequestException : HttpException
    {
        public BadRequestException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.BadRequest, message, errors) { }
    }

    public class UnauthorizedException : HttpException
    {
        public UnauthorizedException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.Unauthorized, message, errors) { }
    }

    public class PaymentRequiredException : HttpException
    {
        public PaymentRequiredException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.PaymentRequired, message, errors) { }
    }

    public class ForbiddenException : HttpException
    {
        public ForbiddenException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.Forbidden, message, errors) { }
    }

    public class NotFoundException : HttpException
    {
        public NotFoundException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.NotFound, message, errors) { }
    }

    public class MethodNotAllowedException : HttpException
    {
        public MethodNotAllowedException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.MethodNotAllowed, message, errors) { }
    }

    public class NotAcceptableException : HttpException
    {
        public NotAcceptableException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.NotAcceptable, message, errors) { }
    }

    public class ProxyAuthenticationRequiredException : HttpException
    {
        public ProxyAuthenticationRequiredException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.ProxyAuthenticationRequired, message, errors) { }
    }

    public class RequestTimeoutException : HttpException
    {
        public RequestTimeoutException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.RequestTimeout, message, errors) { }
    }

    public class ConflictException : HttpException
    {
        public ConflictException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.Conflict, message, errors) { }
    }

    public class GoneException : HttpException
    {
        public GoneException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.Gone, message, errors) { }
    }

    public class InternalServerErrorException : HttpException
    {
        public InternalServerErrorException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.InternalServerError, message, errors) { }
    }

    public class BadGatewayException : HttpException
    {
        public BadGatewayException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.BadGateway, message, errors) { }
    }

    public class ServiceUnavailableException : HttpException
    {
        public ServiceUnavailableException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.ServiceUnavailable, message, errors) { }
    }

    public class GatewayTimeoutException : HttpException
    {
        public GatewayTimeoutException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.GatewayTimeout, message, errors) { }
    }

    public class HttpVersionNotSupportedException : HttpException
    {
        public HttpVersionNotSupportedException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.HttpVersionNotSupported, message, errors) { }
    }

    public class VariantAlsoNegotiatesException : HttpException
    {
        public VariantAlsoNegotiatesException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.VariantAlsoNegotiates, message, errors) { }
    }

    public class InsufficientStorageException : HttpException
    {
        public InsufficientStorageException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.InsufficientStorage, message, errors) { }
    }

    public class LoopDetectedException : HttpException
    {
        public LoopDetectedException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.LoopDetected, message, errors) { }
    }

    public class NotExtendedException : HttpException
    {
        public NotExtendedException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.NotExtended, message, errors) { }
    }

    public class NetworkAuthenticationRequiredException : HttpException
    {
        public NetworkAuthenticationRequiredException(string? message = default, List<string>? errors = default)
            : base(HttpStatusCode.NetworkAuthenticationRequired, message, errors) { }
    }
}
