using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Linq;

namespace LisaBot
{
    class Program
    {
        static void Main(string[] args)
        {


#if DEBUG
            DoDebug();
#else

            var bot = new Bot();
                bot.RunAsync().GetAwaiter().GetResult();
#endif

        }


        static void DoDebug()
        {

        }
    }
}