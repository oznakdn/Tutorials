using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_CodeFirst.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBird { get; set; }
        public string Branch { get; set; }
    }
}