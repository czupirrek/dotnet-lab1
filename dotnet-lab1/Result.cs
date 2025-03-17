using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lab1
{
    class Result
    {
        public List<Item> Items { get; set; }
        private int capacityUsed = 0;
        private List<int> itemIds;

        public Result(List<Item> stolenItems) {
            this.Items = stolenItems;
            itemIds = new List<int>();

            foreach (Item item in Items)
            {
                capacityUsed += item.Weight;
                itemIds.Add(item.Id);
            }
        }
        
        public int getValueSum()
        {
            return Items.Sum(item => item.Value);
        }

        public int getCapacityUsed()
        {
            return capacityUsed;
        }




        public void Print()
        {
            Console.WriteLine("Stolen items:");
            foreach (Item item in Items)
            {
                Console.WriteLine("Id: " + item.Id + " Weight: " + item.Weight + " Value: " + item.Value + " Ratio: " + item.Ratio);
            }
            Console.WriteLine("Capacity used: " + capacityUsed);
            Console.WriteLine("Total value: " + getValueSum());
        }


        public new string ToString()
        {
            //string rv = "";
            //foreach (int id in itemIds)
            //{
            //    rv += id + " ";
            //    Console.WriteLine(id);
            //}
            //return rv;
            if (itemIds.Count == 0)
            {
                //return "No items stolen";
                return string.Join(" ", itemIds);

            }
            else
                return string.Join(" ", itemIds);
                //return "some items stolen";

        }

    }
}
