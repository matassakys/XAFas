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

    public class WorkOrder : BaseObject
    { 
        public WorkOrder(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            this._status = StatusEnum.NotStarted;
            this._type = TypeEnum.Maintenance;
        }

        private TypeEnum _type;
        public TypeEnum Type
        {
            get { return _type; }
            set { SetPropertyValue(nameof(Type), ref _type, value); }
        }

        public enum TypeEnum
        {
            Inspection,
            Maintenance
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
            NotStarted,
            InProgress,
            Ended
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetPropertyValue(nameof(Description), ref _description, value); }
        }
        private DateTime _start;
        public DateTime StartDate
        {
            get { return _start; }
            set { SetPropertyValue(nameof(StartDate), ref _start, value); }
        }

        private DateTime _end;
        public DateTime EndDate
        {
            get { return _end; }
            set { SetPropertyValue(nameof(EndDate), ref _end, value); }
        }

        [Association("WorkOrder-Failures")]
        public XPCollection<Failure> Failures
        {
            get
            {
                return GetCollection<Failure>(nameof(Failures));
            }
        }       
    }
}