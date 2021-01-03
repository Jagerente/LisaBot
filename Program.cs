using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Linq;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using LisaBot.Models.Guides;
using LisaBot.Database;

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
            Console.WriteLine("Start");
            var str = File.ReadAllText("guides.json", Encoding.UTF8);

            Category[] allCategories = JsonConvert.DeserializeObject<Category[]>(str);

            using (var context = new LisaBotContext())
            {
                foreach (Category category in allCategories)
                {
                    foreach (Guide guide in category.Guides)
                    {
                        guide.Category = category;
                        context.Guides.Add(guide);
                    }
                    context.Categories.Add(category);

                }

                context.SaveChanges();
            }

            Console.WriteLine("Changes");
        }
    }
}