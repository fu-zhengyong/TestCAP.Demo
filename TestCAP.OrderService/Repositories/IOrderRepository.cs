using System.Threading.Tasks;
using TestCAP.Events;

namespace TestCAP.OrderService.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> CreateOrderByEF(IOrder order);
        Task<bool> CreateOrderByDapper(IOrder order);
    }
}
