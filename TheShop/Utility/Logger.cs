using System;
using TheShop.Utility;

namespace TheShop
{
    public class Logger
    {

        public void Log(LogLevel level, string message)
        {
            switch (level)
            {
                case LogLevel.DEBUG:
                    Console.WriteLine("Debug: " + message);
                    break;
                case LogLevel.ERROR:
                    Console.WriteLine("Error: " + message);
                    break;
                case LogLevel.WARN:
                    Console.WriteLine("Warning: " + message);
                    break;
                case LogLevel.INFO:
                    Console.WriteLine("Info: " + message);
                    break;
                case LogLevel.VERBOSE:
                    Console.WriteLine("Verose: " + message);
                    break;
                default:
                    Console.WriteLine("Info: " + message);
                    break;
            }
        }
    }
}
