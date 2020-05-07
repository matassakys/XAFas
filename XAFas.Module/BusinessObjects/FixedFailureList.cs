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
    public class FixedFailureList
    {
        private BindingList<FixedFailure> fixedFailures;
        public FixedFailureList()
        {
            fixedFailures = new BindingList<FixedFailure>();
        }
        public BindingList<FixedFailure> FixedFailures { get { return fixedFailures; } }
    }
}
