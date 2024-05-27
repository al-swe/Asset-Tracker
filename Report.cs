using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectCW2122
{
    internal class Report
    {
        MyDbContext Context = new MyDbContext();

        public void ShowReport()
        {
            Console.Clear();
            Console.WriteLine(Header.SubHeader());
            List<Asset> Result = Context.Assets.ToList();

            Console.WriteLine("ASSET INVENTORY REPORT");
            Console.WriteLine($"{"\nType".PadRight(21)}{"Quantity".PadRight(19)}{"Cost (SEK)".PadRight(20)}");
            Console.WriteLine($"{"----".PadRight(20)}{"--------".PadRight(19)}{"----------".PadRight(20)}");

            var assetComputer = Context.Assets.Where(x => x.Type == "computer").Count();
            var totalComputerCost = Context.Assets.Where(x => x.Type == "computer").Sum(x => x.Cost);
            var assetMobile = Context.Assets.Where(x => x.Type == "mobile").Count();
            var totalMobileCost = Context.Assets.Where(x => x.Type == "mobile").Sum(x => x.Cost);

            var totalQuantity = assetComputer + assetMobile;
            var totalCost = totalComputerCost + totalMobileCost;

            Console.WriteLine($"{"Computers".PadRight(19)} {assetComputer.ToString().PadRight(18)} {totalComputerCost}");
            Console.WriteLine($"{"Mobiles".PadRight(19)} {assetMobile.ToString().PadRight(18)} {totalMobileCost}");
            Console.WriteLine($"{"-----".PadRight(19)} {"--------".PadRight(18)} {"----------".PadRight(20)}");
            Console.WriteLine($"{"Total".PadRight(19)} {totalQuantity.ToString().PadRight(18)} {totalCost}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n> Back");
            Console.ResetColor();
            Console.ReadLine();
            ArrowMenu.StartMenu();
        }
    }
}
