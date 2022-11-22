using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _11_TablePerHierarchy_TPH_.Entities
{
    public class Customer : Person
    {
        public string? CompanyName { get; set; }
    }
}