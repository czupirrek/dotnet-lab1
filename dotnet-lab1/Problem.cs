using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("dotnet-lab1-test"), InternalsVisibleTo("dotnet-lab1-gui")]
namespace dotnet_lab1
{
    internal class Problem
    {
        public List<Item> items;
        private List<Item> stolenItems;
        private int numItems;
        private int capacity;
        public Problem(int seed, int numItems) { //seed rng, number of items to generate
            this.numItems = numItems;
            this.items = new List<Item>();
            Random random = new Random(seed);
            for (int i = 0; i < numItems; i++)
            {
                items.Add(new Item(i, random.Next(1, 10), random.Next(1, 10)));
            }
        }
        public void Print()
        {
            Console.WriteLine("Listing all items:");
            foreach (Item item in items)
            {
                Console.WriteLine("Id: " + item.Id + " Weight: " + item.Weight + " Value: " + item.Value + " Ratio: " + item.Ratio);
            }
        }

        public string ParseToString()
        {
            string rv = "";
            foreach (Item item in items)
            {
                rv += "Id: " + item.Id + "\tWeight: " + item.Weight + "\tValue: " + item.Value + "\tRatio: " + Math.Round((decimal)item.Ratio, 2) + "\r\n";
            }
            return rv;
        }


        public Result Solve(int capacity)
        {
            this.capacity = capacity;
            this.stolenItems = new List<Item>();

            items.Sort((x, y) => y.Ratio.CompareTo(x.Ratio));

            int usedCapacity = 0;

            for (int i = 0; i < numItems; i++)
            {
                if (usedCapacity + items[i].Weight <= capacity)
                {
                    stolenItems.Add(items[i]);
                    usedCapacity += items[i].Weight;
                }
                else continue;
            }
            if (stolenItems.Count == 0)
            {
                Console.WriteLine("No items stolen");
            }
                
                Result rv = new Result(stolenItems);
                return rv;
            
        }
    }

    
}
