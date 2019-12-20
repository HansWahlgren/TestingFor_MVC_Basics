using System.ComponentModel.DataAnnotations;

namespace MVC_Basics.Models

{
    public class CarViewModel
    {
        [Required]
        public string Brand { get; set; }

        [Required]
        public string ModelName { get; set; }
    }
}