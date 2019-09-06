using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCAP.OrderService.Models.DTO;
using TestCAP.OrderService.Repositories;

namespace TestCAP.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public IOrderRepository OrderRepository { get; }

        public OrderController(IOrderRepository OrderRepository)
        {
            this.OrderRepository = OrderRepository;
        }

        [HttpGet]
        public string Get()
        {
            OrderDTO orderDTO = new OrderDTO()
            {
                OrderTime = DateTime.Now,
                OrderUserID = "user001",
                ProductID = "P00001"
            };
            var result = OrderRepository.CreateOrderByDapper(orderDTO).GetAwaiter().GetResult();

            return result ? "Post Order Success" : "Post Order Failed";
        }
    }
}
