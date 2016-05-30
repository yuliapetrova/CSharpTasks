using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Task2._1
{
    interface IFlowers
    {
        void ShowPrices();
        double GetFlowerPrice(string Name);

    }


    public class Flowers: IFlowers
    {
        public void ShowPrices()
        {
            Console.WriteLine("List oof flower prices");
        }

        public double GetFlowerPrice(string Name)
        {
            return 0;
        }
    } 
        
    public class GardenFlowers : Flowers, IFlowers
    {
        private readonly Dictionary<string, double> FlowerAndPrice = new Dictionary<string, double>()
        {
            { "Rose", 200}, { "Tulip", 100}, { "Iris", 250},  { "Lily", 300},  { "Orhid", 350},

        };
        public void ShowPrices()

        {
            foreach (KeyValuePair<string, double> kvp in FlowerAndPrice)
            {
                Console.WriteLine("Flower = {0}, Price = {1}",
                    kvp.Key, kvp.Value);
            }
        }
        public double GetFlowerPrice(string Name)
        {
            return FlowerAndPrice[Name];
        }
    }

    static class BuyBouquet
    {
        public static double GetBouquetPrice(GardenFlowers obj, List<string> list)
        {
            double result = 0;
            for (int i = 0; i < (list.Count); i++)
            {
                 result = result + obj.GetFlowerPrice(list[i]);
            }
            return result;
        }

        public static void ShowBouquet(List<string> list)
        {
            Console.WriteLine("Your bouquet consists of : ");
            foreach (string aflower in list)
            {
                Console.WriteLine(aflower);
            }

        }

        public static void Buy(GardenFlowers obj, List<string> list)
        {
          Console.WriteLine("Enter money: ");
          double money = TryParseDouble(Console.ReadLine());
            if (money >= GetBouquetPrice(obj, list))
                Console.WriteLine("Thank you! Here is your bouquet!");
            else
                Console.WriteLine("Sorry, money is not enough");
        }

        private static double TryParseDouble(String s)
        {
            try
            {
                return Convert.ToDouble(s);
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong input format. ");
                return 1;
            }
        }
        static void Main(string[] args)
        {
            //  Take list of flowers from file - bouquet.txt
            List<string> bouquet = new List<string>();
            using (var sr = new StreamReader("bouquet.txt"))
            {
                while (sr.Peek() >= 0)
                    bouquet.Add(sr.ReadLine());
            }
            GardenFlowers gardenFlowers = new GardenFlowers();
            gardenFlowers.ShowPrices();
            ShowBouquet(bouquet);
            Console.WriteLine("Price of your bouquet is: " + GetBouquetPrice(gardenFlowers, bouquet));
            Buy(gardenFlowers, bouquet);
            Console.ReadLine();
        }
    }
}
