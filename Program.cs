using Newtonsoft.Json;
using System;
using System.IO;

namespace LisaBot
{
    class Program
    {
        private const bool Debug = true;
        static void Main(string[] args)
        {
            if (!Debug)
            {
                var bot = new Bot();
                bot.RunAsync().GetAwaiter().GetResult();
            }
            else
            {
                DoDebug();
            }
        }

        static void DoDebug()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            Modules.Guides.Category[] cats =
                JsonConvert.DeserializeObject<Modules.Guides.Category[]>("guides.json");
            Console.WriteLine(cats[0].Title);


            //var cat = new Modules.Guides.Category();
            //cat.Title = "title";
            //cat.List = new Modules.Guides.Guide[]
            //{
            //    new Modules.Guides.Guide
            //    {
            //        Title = "title",
            //        Info = new Modules.Guides.Info
            //        {
            //            Link = "localhost",
            //            Description = "descy",
            //            Premium  = false,
            //            EarlyAccess = true
            //        }
            //    }
            //};
            //var arr = new Modules.Guides.Category[]
            //{
            //    cat
            //};

            //new JsonStorage().StoreObject(arr, $@"{Directory.GetCurrentDirectory()}\guides.json");
        }
    }
}