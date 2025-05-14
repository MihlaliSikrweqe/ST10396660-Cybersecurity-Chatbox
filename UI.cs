using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ST10396660_Cybersecurity_Chatbox
{
    public class UI
    {
        public static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
  ____ ____     ____ _           _   _                
 / ___/ ___|   / ___| |__   __ _| |_| |__   _____  __ 
| |   \___ \  | |   | '_ \ / _` | __| '_ \ / _ \ \/ / 
| |___ ___) | | |___| | | | (_| | |_| |_) | (_) >  <  
 \____|____/   \____|_| |_|\__,_|\__|_.__/ \___/_/\_\ ");
            Console.ResetColor();
        }

        public static void TypeWrite(string message, int delay = 20)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
            Console.ResetColor ();
        }
    }
}
