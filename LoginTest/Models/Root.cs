using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginTest.Model
{
    public class Destination
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public DateTime Date { get; set; }
        public string Adress { get; set; }
        public string Contact { get; set; }
        public string ContactPhone { get; set; }
        public string TimeArrive { get; set; }
        public string TimeDepart { get; set; }
        public string TypeOf { get; set; }
        public byte[] Image { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
        public List<Order> Order { get; set; }
        public int orderId { get; set; }
        public List<OrderItem> Products { get; set; } 
    }

    public class Route
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public int LadingGewicht { get; set; }
        public int LadingVolume { get; set; }

    }

    public class Order
    {
        public int orderId { get; set; }
        public int ID { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }

    public class OrderItem
    {
        public int orderid { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }

    }
}
