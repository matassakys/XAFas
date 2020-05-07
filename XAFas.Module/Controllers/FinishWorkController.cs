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
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void FinishWorkAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {

        }

        private void finishWorkAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            WorkOrder wo = View.CurrentObject as WorkOrder;            
           
            var nonPersistentOS = Application.CreateObjectSpace(typeof(FixedFailureList));
            FixedFailureList failureList = nonPersistentOS.CreateObject<FixedFailureList>();
            foreach (Failure failure in wo.Failures)
            {
                FixedFailure fixedFailure = new FixedFailure();
                fixedFailure.Description = failure.Description;
                fixedFailure.Oid = failure.Oid.ToString();
                failureList.FixedFailures.Add(fixedFailure);
            }
            nonPersistentOS.CommitChanges();
            DetailView detailView = Application.CreateDetailView(nonPersistentOS, failureList);
            detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            e.View = detailView;
            e.DialogController.SaveOnAccept = false;
            e.DialogController.CancelAction.Active["NothingToCancel"] = false;
        }
    }
}

