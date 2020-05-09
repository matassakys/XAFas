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
using DevExpress.ExpressApp.ConditionalAppearance;

namespace XAFas.Module.BusinessObjects
{ 
    [DefaultClassOptions]
    [Appearance("FontColorRed", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
    Criteria = "UpcopingIspection <= AddDays(LocalDateTimeNow(), 3)", FontColor = "Red")]
    public class Equipment : BaseObject
    { 
        public Equipment(Session session)
            : base(session)
        {
        }
        
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Status = StatusEnum.Operating;
        }

        private EquipmentType _type;
        [RuleRequiredField(DefaultContexts.Save)]
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

        private StatusEnum _status;
        [ModelDefault("AllowEdit", "false")]
        public StatusEnum Status
        {
            get { return _status; }
            set { SetPropertyValue(nameof(Status), ref _status, value); }
        }
        public enum StatusEnum
        {
            Operating,
            Broken,
            Maintenance,
            WritenOff
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