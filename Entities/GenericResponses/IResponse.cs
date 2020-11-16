using System.Net;

namespace Entities.GenericResponses
{
    public interface IResponse
    {
        HttpStatusCode HttpCode { get; set; }

        bool IsError { get; set; }

        string Message { get; set; }
    }
}
