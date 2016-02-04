using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestTenta.ViewModels
{
    public class ListArtistsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public decimal Revenue { get; set; }
    }
}
