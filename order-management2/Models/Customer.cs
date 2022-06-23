namespace order_management2.Models
{
    public class Customer
    {
        public int Customer_Id { get; set; }
        public string? Customer_Name { get; set; }
        public string Customer_Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal_Code { get; set; }
    }
}