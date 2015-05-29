namespace fflow
{
    partial class DlgMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.flowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenFlow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cboStations = new System.Windows.Forms.ComboBox();
            this.lstInbox = new System.Windows.Forms.ListBox();
            this.lstWIP = new System.Windows.Forms.ListBox();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flowToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(542, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // flowToolStripMenuItem
            // 
            this.flowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenFlow,
            this.toolStripMenuItem1,
            this.mnuExit});
            this.flowToolStripMenuItem.Name = "flowToolStripMenuItem";
            this.flowToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.flowToolStripMenuItem.Text = "&Flow";
            // 
            // mnuOpenFlow
            // 
            this.mnuOpenFlow.Name = "mnuOpenFlow";
            this.mnuOpenFlow.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpenFlow.Size = new System.Drawing.Size(163, 22);
            this.mnuOpenFlow.Text = "Öffnen...";
            this.mnuOpenFlow.Click += new System.EventHandler(this.mnuOpenFlow_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.mnuExit.Size = new System.Drawing.Size(163, 22);
            this.mnuExit.Text = "B&eenden";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // cboStations
            // 
            this.cboStations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStations.FormattingEnabled = true;
            this.cboStations.Location = new System.Drawing.Point(12, 27);
            this.cboStations.Name = "cboStations";
            this.cboStations.Size = new System.Drawing.Size(178, 21);
            this.cboStations.TabIndex = 1;
            this.cboStations.SelectedIndexChanged += new System.EventHandler(this.cboStations_SelectedIndexChanged);
            // 
            // lstInbox
            // 
            this.lstInbox.FormattingEnabled = true;
            this.lstInbox.Location = new System.Drawing.Point(13, 54);
            this.lstInbox.Name = "lstInbox";
            this.lstInbox.Size = new System.Drawing.Size(177, 264);
            this.lstInbox.TabIndex = 2;
            this.lstInbox.DoubleClick += new System.EventHandler(this.lstInbox_DoubleClick);
            // 
            // lstWIP
            // 
            this.lstWIP.ContextMenuStrip = this.contextMenuStrip1;
            this.lstWIP.FormattingEnabled = true;
            this.lstWIP.Location = new System.Drawing.Point(196, 54);
            this.lstWIP.Name = "lstWIP";
            this.lstWIP.Size = new System.Drawing.Size(177, 69);
            this.lstWIP.TabIndex = 3;
            this.lstWIP.DoubleClick += new System.EventHandler(this.lstWIP_DoubleClick);
            // 
            // lstLog
            // 
            this.lstLog.FormattingEnabled = true;
            this.lstLog.Location = new System.Drawing.Point(196, 157);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(177, 160);
            this.lstLog.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.actionToolStripMenuItem.Text = "action";
            // 
            // DlgMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 325);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.lstWIP);
            this.Controls.Add(this.lstInbox);
            this.Controls.Add(this.cboStations);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DlgMain";
            this.Text = "Folder Flow";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem flowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenFlow;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox cboStations;
        private System.Windows.Forms.ListBox lstInbox;
        private System.Windows.Forms.ListBox lstWIP;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
    }
}

