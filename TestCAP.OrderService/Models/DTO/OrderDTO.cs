using System;
using System.Collections.Generic;
using TestCAP.Events;

namespace TestCAP.OrderService.Models.DTO
{
    public class OrderDTO : IOrder
    {
        public string ID { get; set; }

        public DateTime OrderTime { get; set; }

        public List<IOrderItems> OrderItems { get; set; }

        public string OrderUserID { get; set; }

        //public string StatusKey { get; set; }

        public string ProductID { get; set; }
    }
}
