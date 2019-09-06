using System;
using System.Collections.Generic;

namespace TestCAP.Events
{
    public interface IOrder
    {
        string ID { get; set; }

        DateTime OrderTime { get; set; }

        List<IOrderItems> OrderItems { get; set; }

        string OrderUserID { get; set; }

        string ProductID { get; set; } // 演示字段，实际应该在OrderItems中

    }
}
