using System.Net;

namespace Application.Common.Responses;

public static class Responses
{
    public static BaseResponse NotFound(string entity) => new($"{entity} Not Found", HttpStatusCode.NotFound);

    public static BaseResponse Success() => new();

    public static BaseResponse Success(object data) => new(data);

    public static BaseResponse AlreadyExist(string entity) => new($"{entity} Already Exists", HttpStatusCode.Conflict);

    public static BaseResponse Unauthorized() => new("Unauthorized", statusCode: HttpStatusCode.Unauthorized);
    
    public static BaseResponse InvalidCredentials() => new("Invalid Credentials", statusCode: HttpStatusCode.Unauthorized);
    public static BaseResponse Error(object data, HttpStatusCode statusCode) => new(data: data, statusCode: statusCode);
}