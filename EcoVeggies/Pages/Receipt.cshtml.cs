using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoVeggies.DataAccess;
using EcoVeggies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoVeggies.Pages
{
    public class ReceiptModel : PageModel
    {
        
        private readonly ICustomer customerDataAccess;
        private readonly ICart cartDataAccess;
        private readonly IOrder orderDataAccess;

        public bool IsPaid { get; set; }
        public Order thisOrder { get; set; }
        public string feedback; //Set Feedback
        public List<Item> ListCartItems { get; set; }

        public ReceiptModel(ICustomer customerDataAccess, ICart cartDataAccess, IOrder orderDataAccess)
        {
            this.customerDataAccess = customerDataAccess;
            this.cartDataAccess = cartDataAccess;
            this.orderDataAccess = orderDataAccess;
        }
        public void OnGet(Order order)
        {
            List<Order> orders = orderDataAccess.GetAll().ToList();

            int index = orders.Count - 1;

            if (ListCartItems == null)
            {
                ListCartItems = new List<Item>();
            }

            thisOrder = orders[index];

            IsPaid = true;

            if (IsPaid == true)
            {
                feedback = "Payment succesful";
                ListCartItems = orders[index].ListCartItems;
            }
        }
    }
}
