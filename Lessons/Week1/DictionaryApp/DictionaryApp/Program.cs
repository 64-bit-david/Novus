using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DictionaryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, int> numbersNames = new Dictionary<string, int>();
            numbersNames.Add("Joe", 22); //adding kv pair using Add()
            numbersNames.Add("Jack", 23);
            numbersNames.Add("Tom", 24);

            foreach(KeyValuePair<string, int> kvp in numbersNames)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            IDictionary<string, string> objectTypes = new Dictionary<string, string>();


            objectTypes.Add(
                "Fruits",
                "Apple, Banana, Orange, Grapes, Pineapple"
            );

            objectTypes.Add(
                "Vegetables",
                "Sprouts, Carrots, Cauliflower, Peas"
            );

            objectTypes.Add(
                "Furnitures",
                "Table, Chair, Sofa, Stool"
            );

            objectTypes.Add(
                "Hardware",
                "Hammer, Screwdriver, Nails, Screws, Crowbar"
            );

            foreach(KeyValuePair<string, string> kvp in  objectTypes)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }


            //access using an indxer

            var nums = new List<int>();

            nums.Add(1);
            nums.Add(2);
            nums.Add(3);
            nums.Add(4);
            nums.Add(5);

            Console.WriteLine($"The element at index 3 is: {nums[3]}");


            //update a value using it's key

            objectTypes["Furnitures"] += ", Bed";

            Console.WriteLine(objectTypes["Furnitures"]);

            //delete value using a key

            Console.WriteLine(objectTypes["Hardware"]);
            //objectTypes["Hardware"] = null;
            //better to use the Remove method
            objectTypes.Remove("Hardware");

            foreach (KeyValuePair<string, string> kvp in objectTypes)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
            //

            Console.ReadLine();
        }
    }
}
