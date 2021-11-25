using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoVeggies.DataAccess;
using EcoVeggies.DataSource;
using EcoVeggies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoVeggies.Pages
{
    public class PaymentModel : PageModel
    {
       
        private readonly ICustomer _customerDataAccess;
        private readonly ICart _cartDataAccess;
        private readonly IOrder orderDataAccess;


        //public Customer Customer;//Instance for properties

        List<Order> ListOrder { get; set; }
        public Order order { get; set; }
        public bool IsPaid { get; set; }
        public string feedback; //Sätt feedback
        public Customer ThisCustomer { get; set; }


        public PaymentModel(ICustomer customerDataAccess, ICart cartDataAccess, IOrder orderDataAccess)
        {
            ListOrder = new List<Order>();
            _customerDataAccess = customerDataAccess;
            _cartDataAccess = cartDataAccess;
            this.orderDataAccess = orderDataAccess;
        }
        public void OnGet(int id)//CustomerId from cart page
        {
            ThisCustomer = _customerDataAccess.GetById(id);//Gets Customer by id
            var items = _cartDataAccess.GetAll().ToList();//Gets all items in cart

            if (ThisCustomer != null)//If there is a customer
            {
                //Create an order with CustomerId, items and sets an unique id
                order = new Order() {  CustomerId = id, ListCartItems = items, OrderId = Guid.NewGuid() };
               
                orderDataAccess.SaveOrder(order);//Saves order in order.JSON
            }
        }

        public IActionResult OnPostPayment()
        {
            return RedirectToPage("/Receipt", order);     //Send order to /Receipt, OnGet()
        }
    }
}
