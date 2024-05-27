using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MiniProjectCW2122
{
    public class ArrowMenu
    {
        AssetManager assetManager = new AssetManager();
        DisplayList displayList = new DisplayList();

        // Properties for menu state
        public int SelectedIndex;
        public string[] Options;
        public string Prompt;

        public ArrowMenu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        // Method to displat menu options
        public void DisplayOptions()
        {
            WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;

                // Highlights selected options
                if (i == SelectedIndex)
                {
                    prefix = ">";
                    ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                }
                WriteLine($"{prefix} {currentOption}");
            }
            ResetColor();
        }

        // Method to run the menu and capture use input
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                // Arrow input handling
                if (keyPressed == ConsoleKey.DownArrow)
                {
                    if (SelectedIndex < Options.Length - 1)
                    {
                        SelectedIndex++;
                    }
                } else if (keyPressed == ConsoleKey.UpArrow)
                {
                    if (SelectedIndex > 0)
                    {
                        SelectedIndex--;
                    }
                } 
            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }

        // Start menu method
        public static void StartMenu()
        {
            AssetManager assetManager = new AssetManager();
            DisplayList displayList = new DisplayList();
            Report report = new Report();

            // Start menu prompt and options
            string prompt = Header.StartHeader();
            string[] options = { "View Assets", "Add Asset", "Edit Asset", "Remove Asset", "View Report", "Quit" };

            ArrowMenu mainMenu = new ArrowMenu(prompt, options);
            int selectedIndex = mainMenu.Run();

            // Handles selected option
            switch (selectedIndex)
            {
                case 0:
                    SortList();
                    break;
                case 1:
                    assetManager.AddAsset();
                    break;
                case 2:
                    assetManager.EditAsset();
                    break;
                case 3:
                    assetManager.RemoveAsset();
                    break;
                case 4:
                    report.ShowReport();
                    break;
                case 5:
                    Quit();
                    break;
            }
        }

        // Method to display sorting (view DB records)
        public static void SortList()
        {
            string prompt = Header.SortHeader(); ;
            string[] options = { "Type", "Office", "Back" };
            ArrowMenu mainMenu = new ArrowMenu(prompt, options);
            int selectedIndex = mainMenu.Run();
            DisplayList displayList = new DisplayList();

            switch (selectedIndex)
            {
                case 0:
                    displayList.Display("type");
                    break;
                case 1:
                    displayList.Display("office");
                    break;
                    case 2:
                    StartMenu();
                    break;
            }
        }

        // Handles quitting the application
        public static void Quit()
        {
            string prompt = Header.ExitHeader(); ;
            string[] options = { "Yes, quit!", "No" };
            ArrowMenu mainMenu = new ArrowMenu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    StartMenu();
                    break;
            }
        }
    }
}
