using Microsoft.EntityFrameworkCore;
using SimpleBasket.Application.Common.Interfaces;
using System.Threading.Tasks;

namespace SimpleBasket.Application.Services
{
    public class CustomerService : ICustomerService
    {
        public ISimpleBasketDbContext _simpleBasketDbContext;

        public CustomerService(ISimpleBasketDbContext simpleBasketDbContext)
        {
            _simpleBasketDbContext = simpleBasketDbContext;
        }

        public async Task<bool> IsCustomerExist(int customerId) =>
            await _simpleBasketDbContext.Customers.AnyAsync(x => x.CustomerId == customerId);
    }
}
