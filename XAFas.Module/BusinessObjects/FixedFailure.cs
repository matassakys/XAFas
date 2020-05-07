using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAFas.Module.BusinessObjects
{
    [DomainComponent]
    public class FixedFailure
    {
        [Browsable(false), DevExpress.ExpressApp.Data.Key]
        public int Id;
        public string Description { get; set; }
        public bool IsFixed { get; set; }
        public string Oid { get; set; }
    }
}
