using System.Threading.Tasks;

namespace TestCAP.Events
{
    public interface IOrderSubscriberService
    {
        void ConsumeOrderMessage(OrderMessage message);
    }
}
