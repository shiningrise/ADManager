using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.WebAdmin.Business
{
    public class DeptmentEntity
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public string  CompanyName { get; set; }
        public string  DeptName { get; set; }
        public string  Description { get; set; }
    }
}
