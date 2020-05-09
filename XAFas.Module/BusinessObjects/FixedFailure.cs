using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
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
        [ModelDefault("AllowEdit", "false")]
        public string Equipment { get; set; }
        [ModelDefault("AllowEdit", "false")]
        public string FailureDescription { get; set; }
        public bool IsFixed { get; set; }
        [Browsable(false)]
        public string Oid { get; set; }
    }
}
