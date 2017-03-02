using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace steamironService.DataObjects
{
    public class Customer:EntityData
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public double Points { get; set; }
        public bool Verified { get; set; }
    }
}