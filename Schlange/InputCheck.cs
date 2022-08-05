using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    public static class InputCheck
    {
        public static bool IsInt(string userInput)
        {   
             return int.TryParse(userInput, out int result);
        }
        public static bool CheckHeight(Schlange schlange)
        {
            if (schlange.WindowHeight <= 3 || schlange.WindowHeight >= 300)
            {
                return false;
            }
            return true;
        }
        public static bool CheckWidth(Schlange schlange)
        {   if (schlange.WindowWidth <= 3 || schlange.WindowWidth >= 300)
            {
                return false;
            }
            return true;
        }
        public static bool CheckBlock(Schlange schlange, int blocks)
        {
            if (blocks < 0 || blocks >= schlange.WindowWidth * schlange.WindowHeight/2)
            {
                return false;
            }
            return true;
        }
    }

