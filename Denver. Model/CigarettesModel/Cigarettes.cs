using System;
using System.ComponentModel.DataAnnotations;

namespace Denver._Model
{
    public class Cigarettes
    {
        [Key]
        public int IdCigarettes { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public int Fillin { get; set; }
    }
}
