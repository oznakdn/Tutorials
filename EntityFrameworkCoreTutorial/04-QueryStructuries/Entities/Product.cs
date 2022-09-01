using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _04_QueryStructurs.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

    }
}