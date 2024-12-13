
using Domain.Models;
using WebApi.ApiResponse;

namespace Infrastructore.Interface;


public interface ICustomerService
{
    public Response<List<Customer>> GetCustomers();
    public Response<bool> AddCustomer(Customer customer);
    public Response<bool> UpdateCustomer(Customer customer);
    public Response<bool> DeleteCustomer(int id);
    public Response<Customer> GetCustomerById(int id);
}