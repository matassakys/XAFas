namespace XAFas.Module.Controllers
{
    partial class FinishWorkController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FinishWorkAction = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // FinishWorkAction
            // 
            this.FinishWorkAction.AcceptButtonCaption = null;
            this.FinishWorkAction.CancelButtonCaption = null;
            this.FinishWorkAction.Caption = "Finish Work Action";
            this.FinishWorkAction.ConfirmationMessage = null;
            this.FinishWorkAction.Id = "FinishWorkAction";
            this.FinishWorkAction.TargetObjectType = typeof(XAFas.Module.BusinessObjects.WorkOrder);
            this.FinishWorkAction.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.FinishWorkAction.ToolTip = null;
            this.FinishWorkAction.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.FinishWorkAction.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.finishWorkAction_CustomizePopupWindowParams);
            this.FinishWorkAction.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.FinishWorkAction_Execute);
            // 
            // FinishWorkController
            // 
            this.Actions.Add(this.FinishWorkAction);
            this.TargetObjectType = typeof(XAFas.Module.BusinessObjects.WorkOrder);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction FinishWorkAction;
    }
}
