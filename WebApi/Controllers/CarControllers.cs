using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Infrastructore.Services;
using Infrastructore.Interface;
using WebApi.ApiResponse;
using System.Net;

namespace RentaCar.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController(ICarService carService) : ControllerBase
{
    [HttpGet]
    public Response<List<Car>> GetCars()
    {
        var response=carService.GetCars();
        return response;
    }
    [HttpPost]
    public Response<bool> AddCar(Car car)
    {
        var response=carService.AddCar(car);
        return response;
    }
    [HttpPut]
    public Response<bool> UpdateCar(Car car)
    {
        var response=carService.UpdateCar(car);
        return response;
    }
    [HttpDelete]
    public Response<bool> DeleteCar(int id)
    {
        var response=carService.DeleteCar(id);
        return response;
    }
    [HttpGet ("get-by-id")]
    public Response<Car> GetCar(int id)
    {
        var response=carService.GetCarById(id);
        return response;
    }
}