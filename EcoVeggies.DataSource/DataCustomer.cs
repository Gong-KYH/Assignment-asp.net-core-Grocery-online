using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EcoVeggies.DataSource
{
    public class DataCustomer
    {
        public string GetData()
        {
            var path = @"C:\Users\gongm\Source\Repos\Gong-KYH\EcoVeggies\EcoVeggies.DataSource\JSONDataSource\Customer.json";
            var jsonResponse = File.ReadAllText(path);
            return jsonResponse;
        }
    }
}
