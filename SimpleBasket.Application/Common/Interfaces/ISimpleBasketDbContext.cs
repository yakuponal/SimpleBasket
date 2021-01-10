using Microsoft.EntityFrameworkCore;
using SimpleBasket.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleBasket.Application.Common.Interfaces
{
    public interface ISimpleBasketDbContext
    {
        DbSet<Basket> Baskets { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Option> Options { get; set; }
        DbSet<OptionGroup> OptionGroups { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductDetail> ProductDetails { get; set; }
        DbSet<ProductOption> ProductOptions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
