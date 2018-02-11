using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manager.Web.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
  
}