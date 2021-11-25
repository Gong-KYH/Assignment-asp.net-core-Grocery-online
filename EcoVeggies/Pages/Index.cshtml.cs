using EcoVeggies.DataAccess;
using EcoVeggies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoVeggies.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProduct _product;

        public List<Item> Products { get; set; }
        public List<Item> FoundItem { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty]
        public string Sort { get; set; }

        //Constructor
        public IndexModel(IProduct product)
        {
            _product = product;
            Products = _product.GetAll().ToList();
        }
     
        public IActionResult OnGet(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                RedirectToPage("/Index");
            }
            else
            {
                Products = Products.Where(p => p.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }
            return Page();

        }
        public IActionResult OnPostSort()
        {
            switch (Sort)
            {
                case "low":
                    Products = Products.OrderBy(o => o.Price).ToList();
                    break;

                case "high":
                    Products = Products.OrderByDescending(o => o.Price).ToList();
                    break;
            }
            return Page();
        }

    }

}
