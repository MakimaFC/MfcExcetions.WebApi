using System.Net;

namespace MakimaFC.Extensions.WebApi.ProblemHandling.Exception;

public class MfcException : System.Exception
{
    public HttpStatusCode StatusCode { get; init; }

    public MfcException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}