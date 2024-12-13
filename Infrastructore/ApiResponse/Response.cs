using System.Net;

namespace WebApi.ApiResponse;



public class Response<T>
{
    public int StatusCode { get; set; }
    public T? Data {get; set;}
    public string? Message { get; set; }


    public Response(T data)
    {
        Data=data;
        StatusCode=200;
        Message="Succsess";
    }
    public Response(HttpStatusCode statusCode,string message)
    {
        Data=default;
        StatusCode=(int)statusCode;
        Message=message;
    }
}