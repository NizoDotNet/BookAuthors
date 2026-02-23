namespace BookAuthors.Application.Common;

public struct Result<T>
{
    public Result(int statusCode, T response, bool isSuccess)
    {
        StatusCode = statusCode;
        Response = response;
        Succeeded = isSuccess;
    }

    public int StatusCode { get; private set; }
    public IDictionary<string, string[]> Messages { get; set; } 
    public T Response { get; private set; }
    public bool Succeeded { get; }

    public static Result<T> Succeed(int statusCode, T response)
    {
        return new(statusCode, response, true);
    }

    public static Result<T> Failed(int statusCode, T response)
    {
        return new(statusCode, response, false);
    }

}