using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestTenta.ViewModels
{
    public class EditArtistViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "This field is Required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid Email Address")]
        public string Email { get; set; }

        
        public decimal Revenue { get; set; }
        public string Description { get; set; }
    }
}
