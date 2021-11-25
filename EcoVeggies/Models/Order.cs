using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoVeggies.Models
{
    public class Order
    {
        [JsonProperty("orderid")]
        public Guid OrderId { get; set; }

        [JsonProperty("customerid")]
        public int CustomerId { get; set; }

        [JsonProperty("ispaid")]
        public bool IsPaid { get; set; } = false;

        public List<Item> ListCartItems { get; set; }
       
        //public Customer Customer { get; set; }

        public double GetTotalCost()
        {
            return ListCartItems.Sum(x => x.Price);
        }
        

        //public Order(int orderId, int customerId, List<Item> listCartItems)
        //{
        //    OrderId = orderId;
        //    CustomerId = customerId;
        //    ListCartItems = listCartItems;
        //}
    }

}
