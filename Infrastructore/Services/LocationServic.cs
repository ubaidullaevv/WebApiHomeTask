using Dapper;
using Domain.Models;
using Infrastructore.Datacontext;
using Infrastructore.Interface;
using WebApi.ApiResponse;
using System.Net;
namespace Infrastructore.Services;



public class LocationService(DapperContext _context ) : ILocationService
{
    public Response<bool> AddLocation(Location location)
    {     
         using var context = _context.Connection();
        string cmd = "insert into Locations(city,address)values(@City,@Address)";
        var res = context.Execute(cmd,location);
              if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client eror!");
        }
        return new Response<bool>(res>0);
        
    }

    public Response<bool> DeleteLocation(int id)
    {
         using var context = _context.Connection();
        string cmd = "delete from Locations where id=@LocationId";
        var res = context.Execute(cmd,new {LocationId=id});
             if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client eror!");
        }
        return new Response<bool>(res>0);
    }

    public Response<Location>? GetLocationById(int id)
    {
         using var context = _context.Connection();
        string cmd="select * from Locations where id=@LocationId";
        var res = context.Query<Location>(cmd,new {LocationId=id}).FirstOrDefault();
        if(res==null)
        {
            return new Response<Location>(HttpStatusCode.InternalServerError,"Server Eror!");
        }
        return  new Response<Location>(res);
    }

    public Response<List<Location>> GetLocations()
    {
     using var context = _context.Connection();
        string cmd = "select * from Locations";
        var Locations = context.Query<Location>(cmd).ToList();
        if(Locations==null)
        {
            return new Response<List<Location>>(HttpStatusCode.InternalServerError,"Server Eror");
        }
        return new Response<List<Location>>(Locations);
    }

    public Response<bool> UpdateLocation(Location location)
    {
         using var context = _context.Connection();
        string cmd = "update Locations set locationid=@LocationId, city=@City,addrss=@Address";
        var res = context.Execute(cmd,location);
              if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client eror!");
        }
        return new Response<bool>(res>0);
    }
}


