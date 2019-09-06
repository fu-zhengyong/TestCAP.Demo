using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TestCAP.Events;

namespace TestCAP.OrderService.Models.Entities
{
    [Table("Orders")]
    public class Order : IOrder
    {
        [Column("OrderID")]
        public string ID { get; set; }

        [Column("OrderTime")]
        public DateTime OrderTime { get; set; }

        [Column("OrderUserID")]
        public string OrderUserID { get; set; }

        [NotMapped]
        public List<IOrderItems> OrderItems { get; set; }

        [Column("ProductID")]
        public string ProductID { get; set; }
    }
}
