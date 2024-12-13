
using Domain.Models;
using WebApi.ApiResponse;

namespace Infrastructore.Interface;


public interface ICarLocationService
{
    public Response<List<CarLocation>> GetCarLocations();
    public Response<bool> AddCarLocation(CarLocation carLocation);
    public Response<CarLocation> GetCarLocationById(int id);
}