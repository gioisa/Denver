using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Denver._Model.StoreModel
{
    public class StoreModel
    {
        [Key]
        public int StoreId { get; set; }
        public string NameStore { get; set; }
        public string Address { get; set; }
    }
}
