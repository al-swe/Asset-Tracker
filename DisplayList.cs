using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectCW2122
{
    public class DisplayList
    {
        MyDbContext Context = new MyDbContext();

        // Method to show records in DB (sorted by method parameter)
        public void Display(string sortCriteria)
        {
            Console.Clear();
            Console.WriteLine(Header.SubHeader());
            List<Asset> Result = Context.Assets.ToList();

            // Table headers
            Console.WriteLine($"{"Type".PadRight(20)}{"Brand".PadRight(20)}{"Model".PadRight(20)}{"Office".PadRight(20)}{"Purchase Date".PadRight(30)}{"Price (SEK)".PadRight(20)}{"Currency".PadRight(20)}{"Price (Local Currency)"}");
            Console.WriteLine($"{"----".PadRight(20)}{"-----".PadRight(20)}{"-----".PadRight(20)}{"------".PadRight(20)}{"-------------".PadRight(30)}{"------------".PadRight(20)}{"--------".PadRight(20)}{"------------"}");

            // Decides sorting method
            if (sortCriteria == "type")
            {
                Result = Result.OrderBy(x => x.Type).ThenBy(x => x.PurchaseDate).ToList();
            }
            else if (sortCriteria == "office")
            {
                Result = Result.OrderBy(x => x.Office).ThenBy(x => x.PurchaseDate).ToList();
            }

            // Loops over results in DB and prints them out
            foreach (var asset in Result)
            {
                int warrantyPeriod = 3;
                DateTime warrantyExpirationDate = asset.PurchaseDate.AddYears(warrantyPeriod);
                DateTime currentDate = DateTime.Now;
                DateTime threeMonths = currentDate.AddMonths(3);
                DateTime sixMonths = currentDate.AddMonths(6);

                if (warrantyExpirationDate <= threeMonths)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (warrantyExpirationDate <= sixMonths)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ResetColor();
                }

                // Prints columns with same PadRight for all rows
                string type = asset.Type.ToString().PadRight(20);
                string brand = asset.Brand.ToString().PadRight(20);
                string model = asset.Model.ToString().PadRight(20);
                string office = asset.Office.PadRight(20);
                string purchaseDate = asset.PurchaseDate.ToShortDateString().PadRight(30);
                string cost = asset.Cost.ToString("F2").PadRight(20);
                string currency = asset.Currency.ToString().PadRight(20);
                string localCost = asset.LocalCost.ToString().PadRight(20);

                Console.WriteLine($"{type}{brand}{model}{office}{purchaseDate}{cost}{currency}{localCost}");
            }

            // Promts user to go back one step
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("\n> Back");
            Console.ResetColor();
            Console.ReadLine();
            ArrowMenu.StartMenu();
        }

        // Simple display of DB records, with ID added
        public void DisplayId()
        {
            Console.Clear();
            Console.WriteLine(Header.SubHeader()); // Header from Header.cs
            List<Asset> Result = Context.Assets.ToList();

            Console.WriteLine($"{"Id".PadRight(5)}{"Type".PadRight(20)}{"Brand".PadRight(20)}{"Model".PadRight(20)}{"Office".PadRight(20)}{"Purchase Date".PadRight(30)}{"Price (SEK)".PadRight(20)}{"Currency".PadRight(20)}{"Price (Local Currency)"}");
            Console.WriteLine($"{"--".PadRight(5)}{"----".PadRight(20)}{"-----".PadRight(20)}{"-----".PadRight(20)}{"------".PadRight(20)}{"-------------".PadRight(30)}{"------------".PadRight(20)}{"--------".PadRight(20)}{"------------"}");

            foreach (var asset in Result)
            {
                // Prints columns with same PadRight for all rows
                string id = asset.Id.ToString().PadRight(5);
                string type = asset.Type.ToString().PadRight(20);
                string brand = asset.Brand.ToString().PadRight(20);
                string model = asset.Model.ToString().PadRight(20);
                string office = asset.Office.PadRight(20);
                string purchaseDate = asset.PurchaseDate.ToShortDateString().PadRight(30);
                string cost = asset.Cost.ToString("F2").PadRight(20);
                string currency = asset.Currency.ToString().PadRight(20);
                string localCost = asset.LocalCost.ToString().PadRight(20);

                Console.WriteLine($"{id}{type}{brand}{model}{office}{purchaseDate}{cost}{currency}{localCost}");
            }
        }
    }
}
