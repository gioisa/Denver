using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Denver._Model.UserModel
{
    public class UserModel
    {
        [Key]
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
