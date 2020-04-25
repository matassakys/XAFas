using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace XAFas.Module.BusinessObjects
{
    [DefaultClassOptions]

    public class Equipment : BaseObject
    { 
        public Equipment(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Status = "Active";
        }

        private EquipmentType _type;
        public EquipmentType Type
        {
            get { return _type; }
            set { SetPropertyValue(nameof(Type), ref _type, value); }
        }

        /*private string _Pavadinimas;
        public string Pavadinimas
        {
            get { return _Pavadinimas; }
            set { SetPropertyValue(nameof(Pavadinimas), ref _Pavadinimas, value); }
        }*/
        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetPropertyValue(nameof(Description), ref _description, value); }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { SetPropertyValue(nameof(Status), ref _status, value); }
        }

        private DateTime _inspection;
        public DateTime UpcopingIspection
        {
            get { return _inspection; }
            set { SetPropertyValue(nameof(UpcopingIspection), ref _inspection, value); }
        }

        [Association("Equipment-Failures")]
        public XPCollection<Failure> Failures
        {
            get
            {
                return GetCollection<Failure>(nameof(Failures));
            }
        }
    }
}