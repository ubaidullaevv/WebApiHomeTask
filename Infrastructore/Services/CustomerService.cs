using Dapper;
using Domain.Models;
using Infrastructore.Datacontext;
using Infrastructore.Interface;
using WebApi.ApiResponse;
using System.Net;
namespace Infrastructore.Services;



public class CustomerService(DapperContext _context ) : ICustomerService
{
    public Response<bool> AddCustomer(Customer customer)
    {     
         using var context = _context.Connection();
        string cmd = "insert into Customers(fullname,phone,email)values(@FullName,@Phone,@Email)";
        var res = context.Execute(cmd,customer);
        if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"");
        }
        return new Response<bool>(res>0);
    }


    public Response<bool> DeleteCustomer(int id)
    {
         using var context = _context.Connection();
        string cmd = "delete from Customers where id=@CustomerId";
        var res = context.Execute(cmd,new {CustomerId=id});
        if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Cannot found id");
        }
        return new Response<bool>(res>0);  
    }

    public Response<Customer>? GetCustomerById(int id)
    {
         using var context = _context.Connection();
        string cmd="select * from Customers where id=@CustomerId";
        var res = context.Query<Customer>(cmd,new {CustomerId=id}).FirstOrDefault();
        if(res==null)
        {
            return new Response<Customer>(HttpStatusCode.InternalServerError,"Server eror");
        }
        return new Response<Customer>(res);
    }

    public Response<List<Customer>> GetCustomers()
    {
     using var context = _context.Connection();
        string cmd = "select * from Customers";
        var Customers = context.Query<Customer>(cmd).ToList();
        if(Customers==null)
        {
            return new Response<List<Customer>>(HttpStatusCode.InternalServerError,"Server Eror");
        }
        return new Response<List<Customer>>(Customers);
    }

    public Response<bool> UpdateCustomer(Customer customer)
    {
         using var context = _context.Connection();
        string cmd = "update Customers set customerid=@CustomerId, fullname=@FullName,phone=@Phone,email=@Email";
        var res = context.Execute(cmd,customer);
        if(res==0)
        {
            return new Response<bool>(HttpStatusCode.NotFound,"Client eror!");
        }
        return new Response<bool>(res>0);
    }
}


