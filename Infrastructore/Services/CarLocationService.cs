using Dapper;
using Domain.Models;
using Infrastructore.Datacontext;
using Infrastructore.Interface;
using WebApi.ApiResponse;
using System.Net;
namespace Infrastructore.Services;



public class CarLocationService(DapperContext _context ) : ICarLocationService
{
    public Response<bool> AddCarLocation(CarLocation carLocation)
    {     
         using var context = _context.Connection();
        string cmd = "insert into CarLocations(carid,customerid)values(@CarId,@CustomerId)";
        var res = context.Execute(cmd,carLocation);
        if(carLocation==null)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Cannot found carlocation!");
        }
        return new Response<bool>(res>0);
    }


    public Response<CarLocation> GetCarLocationById(int id)
    {
         using var context = _context.Connection();
        string cmd="select * from CarLocations where id=@CarLocationId";
        var res = context.Query<CarLocation>(cmd,new {CarLocationId=id}).FirstOrDefault();
        if(res==null)
        {
            return new Response<CarLocation>(HttpStatusCode.InternalServerError,"Server Eror");
        }
        return new Response<CarLocation>(res);
    }

    public Response<List<CarLocation>> GetCarLocations()
    {
     using var context = _context.Connection();
        string cmd = "select * from CarLocations";
        var CarLocations = context.Query<CarLocation>(cmd).ToList();
        if(CarLocations==null)
        {
            return new Response<List<CarLocation>>(HttpStatusCode.InternalServerError,"");
        }
        return new Response<List<CarLocation>> (CarLocations);
    }


}


