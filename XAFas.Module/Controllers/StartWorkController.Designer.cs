namespace XAFas.Module.Controllers
{
    partial class StartWorkController
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
            this.StartWorkAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // StartWorkAction
            // 
            this.StartWorkAction.Caption = "Start Work Action";
            this.StartWorkAction.ConfirmationMessage = null;
            this.StartWorkAction.Id = "StartWorkAction";
            this.StartWorkAction.TargetObjectType = typeof(XAFas.Module.BusinessObjects.WorkOrder);
            this.StartWorkAction.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.StartWorkAction.ToolTip = null;
            this.StartWorkAction.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.StartWorkAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.StartWorkAction_Execute);
            // 
            // StartWorkController
            // 
            this.Actions.Add(this.StartWorkAction);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction StartWorkAction;
    }
}
