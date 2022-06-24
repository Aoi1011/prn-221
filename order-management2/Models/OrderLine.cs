namespace order_management2.Models
{
    public class OrderLine
    {
        public long Id { get; set; }
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int OrderedQuantity { get; set; }

    }
}


