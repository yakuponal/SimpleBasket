using System.Threading.Tasks;

namespace SimpleBasket.Application.Common.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> IsCustomerExist(int customerId);
    }
}
