using System;
using System.Collections.Generic;

namespace TestCAP.Events
{
    public class OrderMessage : IOrder
    {
        public string ID { get; set; }

        public DateTime OrderTime { get; set; }

        public List<IOrderItems> OrderItems { get; set; }

        public string OrderUserID { get; set; }

        public string ProductID { get; set; } // 演示字段，实际应该在OrderItems中

        public DateTime MessageTime { get; set; }
    }
}
