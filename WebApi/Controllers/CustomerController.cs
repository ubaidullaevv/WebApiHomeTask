using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Infrastructore.Services;
using Infrastructore.Interface;
using WebApi.ApiResponse;
using System.Net;

namespace RentaCar.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService CustomerService) : ControllerBase
{
    [HttpGet]
    public Response<List<Customer>> GetCustomers()
    {
        var response=CustomerService.GetCustomers();
        return response;
    }
    [HttpPost]
    public Response<bool> AddCustomer(Customer Customer)
    {
        var response=CustomerService.AddCustomer(Customer);
        return response;
    }
    [HttpPut]
    public Response<bool> UpdateCustomer(Customer Customer)
    {
        var response=CustomerService.UpdateCustomer(Customer);
        return response;
    }
    [HttpDelete]
    public Response<bool>  DeleteCustomer(int id)
    {
        var response=CustomerService.DeleteCustomer(id);
        return response;
    }
    [HttpGet ("get-by-id")]
    public Response<Customer>  GetCustomer(int id)
    {
        var response=CustomerService.GetCustomerById(id);
        return response;
    }
}