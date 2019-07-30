namespace MarkAllRead
{
    partial class MarkAllAsReadRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public MarkAllAsReadRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
            Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher ribbonDialogLauncherImpl1 = this.Factory.CreateRibbonDialogLauncher();
            this.tabMail = this.Factory.CreateRibbonTab();
            this.groupMarkAll = this.Factory.CreateRibbonGroup();
            this.buttonMarkAll = this.Factory.CreateRibbonButton();
            this.tabMail.SuspendLayout();
            this.groupMarkAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMail
            // 
            this.tabMail.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabMail.ControlId.OfficeId = "TabMail";
            this.tabMail.Groups.Add(this.groupMarkAll);
            this.tabMail.Label = "TabMail";
            this.tabMail.Name = "tabMail";
            // 
            // groupMarkAll
            // 
            ribbonDialogLauncherImpl1.ScreenTip = "Set Selected Folders";
            ribbonDialogLauncherImpl1.SuperTip = "Set the folders in which all messages will be marked as read.";
            this.groupMarkAll.DialogLauncher = ribbonDialogLauncherImpl1;
            this.groupMarkAll.Items.Add(this.buttonMarkAll);
            this.groupMarkAll.Label = "Mark All";
            this.groupMarkAll.Name = "groupMarkAll";
            this.groupMarkAll.Position = this.Factory.RibbonPosition.BeforeOfficeId("GroupMailDelete");
            this.groupMarkAll.DialogLauncherClick += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.groupMarkAll_DialogLauncherClick);
            // 
            // buttonMarkAll
            // 
            this.buttonMarkAll.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.buttonMarkAll.Label = "Mark All As Read";
            this.buttonMarkAll.Name = "buttonMarkAll";
            this.buttonMarkAll.OfficeImageId = "MarkAllAsRead";
            this.buttonMarkAll.ScreenTip = "Mark All As Read";
            this.buttonMarkAll.ShowImage = true;
            this.buttonMarkAll.SuperTip = "Marks all messages in all selected folders as read.";
            this.buttonMarkAll.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonMarkAll_Click);
            // 
            // MarkAllAsReadRibbon
            // 
            this.Name = "MarkAllAsReadRibbon";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.tabMail);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.MarkAllAsRead_Load);
            this.tabMail.ResumeLayout(false);
            this.tabMail.PerformLayout();
            this.groupMarkAll.ResumeLayout(false);
            this.groupMarkAll.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabMail;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupMarkAll;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonMarkAll;
    }

    partial class ThisRibbonCollection
    {
        internal MarkAllAsReadRibbon MarkAllAsRead
        {
            get { return this.GetRibbon<MarkAllAsReadRibbon>(); }
        }
    }
}
