
using Domain.Models;
using WebApi.ApiResponse;

namespace Infrastructore.Interface;


public interface ILocationService
{
    public Response<List<Location>> GetLocations();
    public Response<bool> AddLocation(Location location);
    public Response<bool> UpdateLocation(Location location);
    public Response<bool> DeleteLocation(int id);
    public Response<Location> GetLocationById(int id);
}