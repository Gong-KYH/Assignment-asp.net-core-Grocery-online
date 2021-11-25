using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EcoVeggies.DataSource
{
    public class DataOrder
    {
        string path = @"C:\Users\gongm\Source\Repos\Gong-KYH\EcoVeggies\EcoVeggies.DataSource\JSONDataSource\Order.json";

        public string GetData()
        {
            var jsonResponse = File.ReadAllText(path);
            return jsonResponse;
        }

        public void Save(string serializedItems)//Needs string variabel, gets it from SaveItem() in "DesOrder"
        {
            File.WriteAllText(path, serializedItems);//Takes in path from above and the string from SaveItem() "DesOrder", saves it in JSON
        }
    }
}
