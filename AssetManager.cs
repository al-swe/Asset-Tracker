using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectCW2122
{
    public class AssetManager
    {
        MyDbContext Context = new MyDbContext();
        DisplayList displayList = new DisplayList();
        decimal exchangeRate;

        // Input error message
        static void inputError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Input can not be empty!");
            Console.ResetColor();
        }

        // Add asset to DB method
        public void AddAsset()
        {
            Asset assetAdd = new Asset();

            Console.Clear();
            Console.WriteLine(Header.SubHeader()); // Header from Header.cs
            Console.WriteLine("ADD NEW ASSET");
            Console.WriteLine("-------------");

            // Loops until user enters a valid type
            bool isActive = true;
            while (isActive)
            {
                Console.Write("Mobile or Computer (M/C): ");
                assetAdd.Type = Console.ReadLine();

                switch (assetAdd.Type.ToLower().Trim())
                {
                    case "m":
                        assetAdd.Type = "Mobile";
                        isActive = false;
                        break;

                    case "c":
                        assetAdd.Type = "Computer";
                        isActive = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"'{assetAdd.Type}' is not a valid command. Please use 'M' for Mobile or 'C' for Computer.");
                        Console.ResetColor();
                        break;
                }
            }

            // Stops user from entering empty/null value
            isActive = true;
            while (isActive)
            {
                Console.Write("Brand: ");
                assetAdd.Brand = Console.ReadLine();

                if (!assetAdd.Brand.Trim().IsNullOrEmpty())
                {
                    isActive = false;
                }
                else
                {
                    inputError();
                }
            }

            // Stops user from entering empty/null value
            isActive = true;
            while (isActive)
            {
                Console.Write("Model: ");
                assetAdd.Model = Console.ReadLine();

                if (!assetAdd.Model.Trim().IsNullOrEmpty())
                {
                    isActive = false;
                }
                else
                {
                    inputError();
                }
            }

            // While loop that makes sure user selects a valid office
            bool isValidOffice = true;
            while (isValidOffice)
            {
                Console.Write("Office (SWE/UK/US): ");
                string officeInput = Console.ReadLine();
                if (officeInput.ToLower().Trim() == "swe")
                {
                    assetAdd.Office = "SWE";
                    assetAdd.Currency = "SEK";
                    exchangeRate = 1; // "m" for decimal/double error
                }
                else if (officeInput.ToLower().Trim() == "us")
                {
                    assetAdd.Office = "US";
                    assetAdd.Currency = "USD";
                    exchangeRate = 10.71m;
                }
                else if (officeInput.ToLower().Trim() == "uk")
                {
                    assetAdd.Office = "UK";
                    assetAdd.Currency = "GBP";
                    exchangeRate = 13.61m;
                }

                switch (officeInput.ToLower().Trim())
                {
                    case "swe":
                        assetAdd.Office = "SWE";
                        assetAdd.Currency = "SEK";
                        exchangeRate = 1;
                        isValidOffice = false;
                        break;
                    case "us":
                        assetAdd.Office = "US";
                        assetAdd.Currency = "USD";
                        exchangeRate = 10.71m;
                        isValidOffice = false;
                        break;
                    case "uk":
                        assetAdd.Office = "UK";
                        assetAdd.Currency = "GBP";
                        exchangeRate = 13.61m;
                        isValidOffice = false;
                        break;
                    default:
                        Console.WriteLine($"Office in '\u001B[31m{officeInput.ToUpper().Trim()}\u001B[37m' could not be found.");
                        break;
                }
            }

            // Date input error handling
            bool isValidDate = false;

            DateTime dueDate = DateTime.MinValue;

            // Error handling for date input
            while (!isValidDate)
            {
                Console.Write("Purchase Date (yyyy-MM-dd / today): ");
                string dateInput = Console.ReadLine();

                if (DateTime.TryParse(dateInput, out dueDate))
                {
                    assetAdd.PurchaseDate = dueDate;
                    isValidDate = true;
                }
                else if (dateInput.ToLower().Trim() == "today")
                {
                    assetAdd.PurchaseDate = DateTime.Now;
                    isValidDate = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{dateInput} is not a valid date format (yyyy-MM-dd)");
                    Console.ResetColor();
                }
            }

            // Error handling of cost input and calculates local currency cost
            isActive = true;
            while (isActive)
            {
                Console.Write("Cost (in SEK): ");
                string userInput = Console.ReadLine();

                if (decimal.TryParse(userInput, out decimal cost))
                {
                    assetAdd.Cost = cost;

                    // Calculates the local cost
                    assetAdd.LocalCost = cost / exchangeRate;

                    isActive = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"'{userInput}' is not a valid number. Please enter a valid number.");
                    Console.ResetColor();
                }
            }

            // Adds asset and saves to DB
            Context.Assets.Add(assetAdd);
            Context.SaveChanges();

            // Success notification to user
            Console.WriteLine($"\nAsset '\u001b[32m{assetAdd.Brand} {assetAdd.Model}\u001b[37m' has been added!");

            // Prompts user to go back to start menu
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n> Start Menu");
            Console.ResetColor();
            Console.ReadLine();
            ArrowMenu.StartMenu();
        }

        //Method to edit Asset
        public void EditAsset()
        {

            bool active = true;
            while (active)
            {
                displayList.DisplayId();
                Console.WriteLine("\nEnter the ID of item to edit");
                Console.Write("Edit: ");
                string userInput = Console.ReadLine();

                // Checks if the user input a valid ID.
                if (!int.TryParse(userInput, out int id))
                {
                    continue;
                }

                var assetEdit = Context.Assets.FirstOrDefault(x => x.Id == id);

                // Checks if the asset with the given ID exists
                if (assetEdit == null)
                {
                    continue;
                }

                // Handles editing of record
                bool editing = true;
                while (editing)
                {
                    displayList.DisplayId();
                    Console.WriteLine("\nWhat property would you like to edit?");
                    Console.Write("Edit: ");
                    string editInput = Console.ReadLine();
                    bool isActive = true;

                    switch (editInput.ToLower().Trim())
                    {
                        case "type":
                            displayList.DisplayId();
                            while (isActive)
                            {
                                Console.Write("\nNew type: ");
                                string newType = Console.ReadLine();
                                if (newType.IsNullOrEmpty())
                                {
                                    inputError();
                                }
                                else
                                {
                                    assetEdit.Type = newType;
                                    isActive = false;
                                }
                            }
                            break;
                        case "brand":
                            displayList.DisplayId();
                            while (isActive)
                            {
                                Console.Write("\nNew brand: ");
                                string newBrand = Console.ReadLine();
                                if (newBrand.IsNullOrEmpty())
                                {
                                    inputError();
                                }
                                else
                                {
                                    assetEdit.Brand = newBrand;
                                    isActive = false;
                                }
                            }
                            break;
                        case "model":
                            displayList.DisplayId();
                            while (isActive)
                            {
                                Console.Write("\nNew model: ");
                                string newModel = Console.ReadLine();
                                if (newModel.IsNullOrEmpty())
                                {
                                    inputError();
                                }
                                else
                                {
                                    assetEdit.Model = newModel;
                                    isActive = false;
                                }
                            }
                            break;
                        case "office":
                            displayList.DisplayId();
                            while (isActive)
                            {
                                Console.Write("\nNew office: ");
                                string newOffice = Console.ReadLine();
                                if (newOffice.IsNullOrEmpty())
                                {
                                    inputError();
                                }
                                else
                                {
                                    assetEdit.Office = newOffice;
                                    isActive = false;
                                }
                            }
                            break;
                        case "purchasedate":
                            displayList.DisplayId();
                            while (isActive)
                            {
                                Console.Write("\nNew purchase date (YYYY-MM-DD): ");
                                if (DateTime.TryParse(Console.ReadLine(), out DateTime newPurchaseDate))
                                {
                                    assetEdit.PurchaseDate = newPurchaseDate;
                                    isActive = false;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid date format.");
                                    continue;
                                }
                            }
                            break;
                        case "cost":
                            displayList.DisplayId();
                            while (isActive)
                            {
                                Console.Write("\nNew cost: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal newCost))
                                {
                                    assetEdit.Cost = newCost;
                                    isActive = false;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid cost format.");
                                    continue;
                                }
                            }
                            break;
                        case "currency":
                            displayList.DisplayId();
                            while (isActive)
                            {
                                Console.Write("\nNew currency: ");
                                string newCurrency = Console.ReadLine();
                                if (newCurrency.IsNullOrEmpty())
                                {
                                    inputError();
                                }
                                else
                                {
                                    assetEdit.Currency = newCurrency;
                                    isActive = false;
                                }
                            }
                            break;
                        case "localcost":
                            displayList.DisplayId();
                            while (isActive)
                            {
                                Console.Write("\nNew local cost: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal newLocalCost))
                                {
                                    assetEdit.LocalCost = newLocalCost;
                                    isActive = false;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid local cost format.");
                                    continue;
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid property name.");
                            continue;
                    }

                    // Saves and updates the database
                    Context.Assets.Update(assetEdit);
                    Context.SaveChanges();

                    // Success notification
                    Console.WriteLine($"\nChanges to '\u001b[32m{assetEdit.Brand} {assetEdit.Model}\u001b[37m' have been saved!");
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    // Prompts user to return to start menu
                    Console.WriteLine("\n> Start Menu");
                    Console.ResetColor();
                    Console.ReadLine();
                    ArrowMenu.StartMenu();
                }

            }
        }

        // Remove asset from DB method
        public void RemoveAsset()
        {
            // Prompting user for ID to remove
            displayList.DisplayId();
            Asset assetRemove = null;

            // While loop until user enters a valid and existing ID 
            bool idExist = true;
            while (idExist)
            {
                Console.Write("\nEnter the ID to remove or 'Q' to exit: ");
                int idNumber;
                string userInput = Console.ReadLine();

                // Returns to start menu if Q is entered
                if (userInput.ToLower().Trim() == "q")
                {
                    ArrowMenu.StartMenu();
                }

                // Tries to convert user input to integer, outputs the input in to idNumber
                bool isInt = Int32.TryParse(userInput, out idNumber);

                // Checks if the Id exists in Database, selects Id if exists
                if (!Context.Assets.Any(x => x.Id == idNumber))
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine($"ID {idNumber} does not exist.");
                    Console.ResetColor();
                }
                else
                {
                    assetRemove = Context.Assets.FirstOrDefault(x => x.Id == idNumber);
                    idExist = false;
                }
            }

            // Prompts and removes Id record from DB
            bool isActive = true;
            while (isActive)
            {
                Console.Write($"Are you sure you want to remove '\u001B[31m{assetRemove.Brand} {assetRemove.Model}\u001b[37m' (Y/N/Q):");
                string confirmInput = Console.ReadLine();
                if (confirmInput.ToLower().Trim() == "y")
                {
                    Context.Assets.Remove(assetRemove);
                    Context.SaveChanges();
                    Console.WriteLine($"\nAsset '\u001b[31m{assetRemove.Brand} {assetRemove.Model}\u001b[37m' has been removed!");
                    isActive = false;
                }
                else if (confirmInput.ToLower().Trim() == "n")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n> Start Menu");
                    Console.ResetColor();
                    Console.ReadLine();
                    ArrowMenu.StartMenu();
                }
                else if (confirmInput.ToLower().Trim() == "q")
                {
                    ArrowMenu.StartMenu();
                }
                else
                {
                    Console.WriteLine($"{confirmInput} is not a valid command.");
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n> Start Menu");
            Console.ResetColor();
            Console.ReadLine();
            ArrowMenu.StartMenu();
        }
    }
}
