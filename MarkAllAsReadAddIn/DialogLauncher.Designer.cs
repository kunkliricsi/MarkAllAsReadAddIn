namespace MarkAllRead
{
    partial class DialogLauncher
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.selectAllButton = new System.Windows.Forms.Button();
			this.checkedTreeView1 = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(358, 510);
			this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(108, 28);
			this.cancelButton.TabIndex = 0;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(242, 510);
			this.okButton.Margin = new System.Windows.Forms.Padding(4);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(108, 28);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// selectAllButton
			// 
			this.selectAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.selectAllButton.Location = new System.Drawing.Point(15, 510);
			this.selectAllButton.Margin = new System.Windows.Forms.Padding(4);
			this.selectAllButton.Name = "selectAllButton";
			this.selectAllButton.Size = new System.Drawing.Size(108, 28);
			this.selectAllButton.TabIndex = 3;
			this.selectAllButton.Text = "Select All";
			this.selectAllButton.UseVisualStyleBackColor = true;
			this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
			// 
			// checkedTreeView1
			// 
			this.checkedTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkedTreeView1.CheckBoxes = true;
			this.checkedTreeView1.Location = new System.Drawing.Point(16, 15);
			this.checkedTreeView1.Name = "checkedTreeView1";
			this.checkedTreeView1.Size = new System.Drawing.Size(448, 463);
			this.checkedTreeView1.TabIndex = 4;
			this.checkedTreeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.checkedTreeView1_AfterCheck);
			this.checkedTreeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.checkedTreeView1_BeforeSelect);
			// 
			// DialogLauncher
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(482, 553);
			this.Controls.Add(this.checkedTreeView1);
			this.Controls.Add(this.selectAllButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.cancelButton);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "DialogLauncher";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Set Selected Folders";
			this.Shown += new System.EventHandler(this.DialogLauncher_Shown);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button selectAllButton;
		private System.Windows.Forms.TreeView checkedTreeView1;
	}
}