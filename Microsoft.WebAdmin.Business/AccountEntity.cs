using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.WebAdmin.Business
{
    public class AccountEntity
    {
        public int ID { get; set; } 
        public string  AccType { get; set; }
        public string  AccShorten { get; set; }
        public string  Description { get; set; }
    }
}
