using System;
using System.Collections.Generic;
using System.Text;

namespace PMT_DAL.Models
{
   public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
       
    }
}
