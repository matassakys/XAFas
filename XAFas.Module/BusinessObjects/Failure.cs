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

    public class Failure : BaseObject
    { 
        public Failure(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Status = StatusEnum.NotFixed;
            FailureDate = DateTime.Now;
        }

        protected override void OnSaving()
        {
            if (this.Equipment != null)
            {
                if (this.Status == StatusEnum.NotFixed && this.Equipment.Status == Equipment.StatusEnum.Operating)
                {
                    this.Equipment.Status = Equipment.StatusEnum.Broken;
                }
                else if (this.Status == StatusEnum.Fixing && this.Equipment.Status != Equipment.StatusEnum.Maintenance)
                {
                    this.Equipment.Status = Equipment.StatusEnum.Maintenance;
                }
            }
                
            base.OnSaving();
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetPropertyValue(nameof(Description), ref _description, value); }
        }

        private PriorityEnum _priority;
        public PriorityEnum Priority
        {
            get { return _priority; }
            set { SetPropertyValue(nameof(Priority), ref _priority, value); }
        }

        public enum PriorityEnum
        {
            Urgent,
            Average,
            Low
        }

        private StatusEnum _status;
        public StatusEnum Status
        {
            get { return _status; }
            set { SetPropertyValue(nameof(Status), ref _status, value); }
        }
        public enum StatusEnum
        {
            NotFixed,
            Fixing,
            Closed
        }

        private DateTime _failureDate;
        public DateTime FailureDate
        {
            get { return _failureDate; }
            set { SetPropertyValue(nameof(FailureDate), ref _failureDate, value); }
        }

        private Equipment equipment;
        [Association("Equipment-Failures")]
        public Equipment Equipment
        {
            get { return equipment; }
            set { SetPropertyValue(nameof(Equipment), ref equipment, value); }
        }

        private WorkOrder workOrder;
        [Association("WorkOrder-Failures")]
        public WorkOrder WorkOrder
        {
            get { return workOrder; }
            set { SetPropertyValue(nameof(WorkOrder), ref workOrder, value); }
        }
    }
}