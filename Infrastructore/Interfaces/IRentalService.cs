
using Domain.Models;
using WebApi.ApiResponse;

namespace Infrastructore.Interface;


public interface IRentalService
{
    public Response<List<Rental>> GetRentals();
    public Response<bool> AddRental(Rental rental);
    public Response<Rental> GetRentalById(int id);
}