//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MiniProjectCW2122
//{
//    public class MenuSelect
//    {
//        public void Menu()
//        {
//            AssetManager assetManager = new AssetManager();
//            DisplayList displayList = new DisplayList();

//            Console.Clear();
//            Console.WriteLine("Asset Tracker");
//            Console.WriteLine("\n(\u001B[93mV\u001b[37m)iew Assets");
//            Console.WriteLine("(\u001b[93mA\u001b[37m)dd Asset");
//            Console.WriteLine("(\u001b[93mE\u001b[37m)dit Asset");
//            Console.WriteLine("(\u001b[93mR\u001b[37m)emove Asset");
//            Console.WriteLine("(\u001b[93mQ\u001b[37m)uit Application");

//            Console.Write("\nSelect option: ");
//            string userInput = Console.ReadLine();

//            switch (userInput.ToLower().Trim())
//            {
//                case "a":
//                    assetManager.AddAsset();
//                    break;
//                case "v":
//                    displayList.Display();
//                        break;
//                case "r":
//                    assetManager.RemoveAsset();
//                    break;
//                case "e":
//                    assetManager.EditAsset();
//                    break;
//                case "q":
//                    Console.Write("Are you sure you want to quit? (y/n): ");
//                    string confirmInput = Console.ReadLine();
//                    if (confirmInput == "y")
//                    {
//                        Environment.Exit(0);
//                    }
//                    else
//                    {
//                        Menu();
//                    }
//                    break;
//                default:
//                    Menu();
//                    break;
//            }
//        }
//    }
//}
