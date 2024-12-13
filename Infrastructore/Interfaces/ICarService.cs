
using Domain.Models;
using WebApi.ApiResponse;

namespace Infrastructore.Interface;


public interface ICarService
{
    public Response<List<Car>> GetCars();
    public Response<bool> AddCar(Car car);
    public Response<bool> UpdateCar(Car car);
    public Response<bool> DeleteCar(int id);
    public Response<Car> GetCarById(int id);
}