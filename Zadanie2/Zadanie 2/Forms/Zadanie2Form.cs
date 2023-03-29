using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Zadanie_2.Forms
{
    public class Zadanie2Form
    {
        [Display(Name = "Twój szczęśliwy numerek")]
        [Required(ErrorMessage ="Pole jest obowiązkowe"), Range(1, 1000, ErrorMessage = "Oczekiwana wartość z zakresu {1} i {2}.")]
        public int Number { get; set; }

    }
     
    
}
