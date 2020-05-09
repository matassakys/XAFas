using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using XAFas.Module.BusinessObjects;

namespace XAFas.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class FinishWorkController : ViewController
    {
        public FinishWorkController()
        {
            InitializeComponent();
            FinishWorkAction.TargetObjectsCriteria = "Status = 1";
        }
        protected override void OnActivated()
        {
            base.OnActivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }

        private void finishWorkAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            WorkOrder wo = View.CurrentObject as WorkOrder;            
           
            var nonPersistentOS = Application.CreateObjectSpace(typeof(FixedFailureList));
            FixedFailureList failureList = nonPersistentOS.CreateObject<FixedFailureList>();
            foreach (Failure failure in wo.Failures)
            {
                FixedFailure fixedFailure = new FixedFailure();
                fixedFailure.Equipment = failure.Equipment.Type.Name;
                fixedFailure.FailureDescription = failure.Description;
                fixedFailure.Oid = failure.Oid.ToString();
                failureList.FixedFailures.Add(fixedFailure);
            }
            nonPersistentOS.CommitChanges();
            DetailView detailView = Application.CreateDetailView(nonPersistentOS, failureList);
            detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            e.View = detailView;
            e.DialogController.SaveOnAccept = false;
            e.DialogController.CancelAction.Active["NothingToCancel"] = true;
        }

        private void FinishWorkAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            WorkOrder wo = e.CurrentObject as WorkOrder;
            FixedFailureList failureList = e.PopupWindowViewCurrentObject as FixedFailureList;
            if (wo != null && failureList != null)
            {
                wo.Status = WorkOrder.StatusEnum.Ended;

                foreach (Failure failure in wo.Failures)
                {
                    string failureOid = failure.Oid.ToString();
                    foreach (FixedFailure fixedFailure in failureList.FixedFailures)
                    {
                        if (fixedFailure.Oid.Equals(failureOid))
                        {
                            failure.Status = Failure.StatusEnum.Closed;
                            failure.IsFixed = fixedFailure.IsFixed;
                        }
                    }
                }
                wo.Save();
            }
        }
    }
}

