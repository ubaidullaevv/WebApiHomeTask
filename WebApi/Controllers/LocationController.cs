using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Infrastructore.Services;
using Infrastructore.Interface;
using WebApi.ApiResponse;

namespace RentaCar.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController(ILocationService LocationService) : ControllerBase
{
    [HttpGet]
    public Response<List<Location>> GetLocations()
    {
        var response=LocationService.GetLocations();
        return response;
    }
    [HttpPost]
    public Response<bool>  AddLocation(Location Location)
    {
        var response=LocationService.AddLocation(Location);
        return response;
    }
    [HttpPut]
    public Response<bool>  UpdateLocation(Location Location)
    {
        var response=LocationService.UpdateLocation(Location);
        return response;
    }
    [HttpDelete]
    public Response<bool>  DeleteLocation(int id)
    {
        var response=LocationService.DeleteLocation(id);
        return response;
    }
    [HttpGet ("get-by-id")]
    public Response<Location>  GetLocation(int id)
    {
        var response=LocationService.GetLocationById(id);
        return response;
    }
}