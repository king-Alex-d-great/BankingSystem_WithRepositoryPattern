using System;
using System.Collections.Generic;
using System.Text;
using BEZAO_PayDAL.Interfaces;

namespace BEZAO_PayDAL.Helpers
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void LogLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
