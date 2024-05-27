using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectCW2122
{
    internal class Header
    {
        // Header for starting menu
        public static string StartHeader()
        {
            return @"
                        Welcome to
   _                _     _____                _             
  /_\  ___ ___  ___| |_  /__   \_ __ __ _  ___| | _____ _ __ 
 //_\\/ __/ __|/ _ \ __|   / /\/ '__/ _` |/ __| |/ / _ \ '__|
/  _  \__ \__ \  __/ |_   / /  | | | (_| | (__|   <  __/ |   
\_/ \_/___/___/\___|\__|  \/   |_|  \__,_|\___|_|\_\___|_|   
                                                             
            Navigate menu with UP, DOWN & ENTER.
";
        }

        // Header for sub menus
        public static string SubHeader()
        {
           return @"
   _                _     _____                _             
  /_\  ___ ___  ___| |_  /__   \_ __ __ _  ___| | _____ _ __ 
 //_\\/ __/ __|/ _ \ __|   / /\/ '__/ _` |/ __| |/ / _ \ '__|
/  _  \__ \__ \  __/ |_   / /  | | | (_| | (__|   <  __/ |   
\_/ \_/___/___/\___|\__|  \/   |_|  \__,_|\___|_|\_\___|_|   
";
        }

        // Header for view list sorting
        public static string SortHeader()
        {
            return @"
   _                _     _____                _             
  /_\  ___ ___  ___| |_  /__   \_ __ __ _  ___| | _____ _ __ 
 //_\\/ __/ __|/ _ \ __|   / /\/ '__/ _` |/ __| |/ / _ \ '__|
/  _  \__ \__ \  __/ |_   / /  | | | (_| | (__|   <  __/ |   
\_/ \_/___/___/\___|\__|  \/   |_|  \__,_|\___|_|\_\___|_|   

Sort list by: ";
        }

        // Header for exiting application
        public static string ExitHeader()
        {
            return @"
   _                _     _____                _             
  /_\  ___ ___  ___| |_  /__   \_ __ __ _  ___| | _____ _ __ 
 //_\\/ __/ __|/ _ \ __|   / /\/ '__/ _` |/ __| |/ / _ \ '__|
/  _  \__ \__ \  __/ |_   / /  | | | (_| | (__|   <  __/ |   
\_/ \_/___/___/\___|\__|  \/   |_|  \__,_|\___|_|\_\___|_|   
                                                             
Are you sure you want to quit?
";
        }
    }
}
