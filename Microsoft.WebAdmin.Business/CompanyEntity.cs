using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.WebAdmin.Business
{
    public class CompanyEntity
    {
        public int ID { get; set; }
        public string  companyName { get; set; }
        public string  address { get; set; }
        public string  zipCode { get; set; }
    }
}
