using Dapper;
using Domain.Models;
using Infrastructore.Datacontext;
using Infrastructore.Interface;
using WebApi.ApiResponse;
using System.Net;
namespace Infrastructore.Services;



public class RentalService(DapperContext _context ) : IRentalService
{
    public Response<bool> AddRental(Rental rental)
    {     
         using var context = _context.Connection();
        string cmd = "insert into Rentals(carid,customerid,startdate,update,totalcost)values(@CarId,@CustomerId,@StartDate,@EndDate,@TotalCost)";
        var res = context.Execute(cmd,rental);
              if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client eror!");
        }
        return new Response<bool>(res>0);
    }


    public Response<Rental>? GetRentalById(int id)
    {
         using var context = _context.Connection();
        string cmd="select * from Rentals where id=@RentalId";
        var res = context.Query<Rental>(cmd,new {RentalId=id}).FirstOrDefault();
        if(res==null)
        {
            return new Response<Rental>(HttpStatusCode.InternalServerError,"Seerver eror!");
        }
        return new Response<Rental>(res);
    }

    public Response<List<Rental>> GetRentals()
    {
     using var context = _context.Connection();
        string cmd = "select * from Rentals";
        var Rentals = context.Query<Rental>(cmd).ToList();
        if(Rentals==null)
        {
            return new Response<List<Rental>>(HttpStatusCode.InternalServerError,"Server Eror!");
        }
        return new Response<List<Rental>>(Rentals);
    }
}


