using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    /**
    * Author arborshield
    * Created by on 2023/4/2.
    * Create an inteface for Log
    */
    public interface ILogger
    {
        void Log(string message);
    }
}
