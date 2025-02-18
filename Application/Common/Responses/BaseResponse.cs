using System.Net;

namespace Application.Common.Responses;

public class BaseResponse
{
    public BaseResponse(object? data = null, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        StatusCode = statusCode.GetHashCode();
        Data = data;
    }
    
    public int StatusCode { get; set; }
    public object? Data { get; set; }
}
