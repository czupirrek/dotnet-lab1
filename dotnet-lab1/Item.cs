using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lab1
{
    class Item
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }
        public float Ratio { get; set; }

        public Item(int id, int weight, int value)
        {
            Id = id;
            Weight = weight;
            Value = value;
            Ratio = (float)value / weight;
        }
    }
}
