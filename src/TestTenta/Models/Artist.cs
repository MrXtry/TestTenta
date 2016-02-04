using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTenta.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public decimal Revenue { get; set; }
        public string Description { get; set; }
    }
}
