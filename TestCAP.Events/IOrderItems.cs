namespace TestCAP.Events
{
    public interface IOrderItems
    {
        string ID { get; set; }

        string ProductID { get; set; }

        decimal Price { get; set; }

        double Quantity { get; set; }
    }
}
