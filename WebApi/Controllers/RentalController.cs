using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Infrastructore.Services;
using Infrastructore.Interface;
using WebApi.ApiResponse;

namespace RentaCar.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RentalController(IRentalService RentalService) : ControllerBase
{
    [HttpGet]
    public Response<List<Rental>> GetRentals()
    {
        var response=RentalService.GetRentals();
        return response;
    }
    [HttpPost]
    public Response<bool>  AddRental(Rental Rental)
    {
        var response=RentalService.AddRental(Rental);
        return response;
    }
 
    [HttpGet ("get-by-id")]
    public Response<Rental>  GetRental(int id)
    {
        var response=RentalService.GetRentalById(id);
        return response;
    }
}