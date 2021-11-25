using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EcoVeggies.DataSource
{
    public class DataCart
    {

        string path = @"C:\Users\gongm\Source\Repos\Gong-KYH\EcoVeggies\EcoVeggies.DataSource\JSONDataSource\Cart.json";
       
        public string GetData()
        {
            var jsonResponse = File.ReadAllText(path);
            return jsonResponse;
        }

        public void Save(string serializedItems)//Needs string variabel, gets it from SaveItem() in "DesCart"
        {
            //Takes in path from above and the string from SaveItem() "DesCart", saves it in JSON
            File.WriteAllText(path, serializedItems);
        }
    }
}
