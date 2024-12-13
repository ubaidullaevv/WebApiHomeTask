using Dapper;
using Domain.Models;
using Infrastructore.Datacontext;
using Infrastructore.Interface;
using WebApi.ApiResponse;
using System.Net;
namespace Infrastructore.Services;



public class CarService(DapperContext _context ) : ICarService
{
    public Response<bool> AddCar(Car car)
    {     
         using var context = _context.Connection();
        string cmd = "insert into cars(model,manufacturer,year,priceperday)values(@Model,@Manufacturer,@Year,@PricePerDay)";
        var res = context.Execute(cmd,car);
        if(car==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror");
        }
        return new Response<bool>(res>0); 
    }

    public Response<bool> DeleteCar(int id)
    {
         using var context = _context.Connection();
        string cmd = "delete from cars where id=@CarId";
        var res = context.Execute(cmd,new {CarId=id});
        if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror");
        }
        return new Response<bool>(res>0) ;  
    }

    public Response<Car>? GetCarById(int id)
    {
         using var context = _context.Connection();
        string cmd="select * from cars where id=@CarId";
        var res = context.Query<Car>(cmd,new {CarId=id}).FirstOrDefault();
        if(res==null)
        {
            return new Response<Car>(HttpStatusCode.InternalServerError,"");
        }
        return new Response<Car>(res);
    }

    public Response<List<Car>> GetCars()
    {
     using var context = _context.Connection();
        string cmd = "select * from Cars";
        var cars = context.Query<Car>(cmd).ToList();
        if(cars==null)
        {
            return new Response<List<Car>>(HttpStatusCode.InternalServerError,"Server eror!");
        }
        return new Response<List<Car>>(cars);
    }

    public Response<bool> UpdateCar(Car car)
    {
         using var context = _context.Connection();
        string cmd = "update cars set carid=@CarId, model=@Model,manufacturer=@Manufacturer,year=@Year,priceperday=@PricePerDay";
        var res = context.Execute(cmd,car);
        if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client Eror");
        }
        return new Response<bool>(res>0);
    }
}


