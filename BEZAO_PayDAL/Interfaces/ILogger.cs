using System;
using System.Collections.Generic;
using System.Text;

namespace BEZAO_PayDAL.Interfaces
{
    interface ILogger
    {
        void Log(string message);
        void LogLine(string message);
    }
}
