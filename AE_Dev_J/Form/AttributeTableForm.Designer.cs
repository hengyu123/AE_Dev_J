namespace AE_Dev_J.Form
{
    partial class AttributeTableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttributeTableForm));
            this.attForm_DockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.filter_dockPanel = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.tool_dockPanel = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.spreadsheetFormulaBarControl1 = new DevExpress.XtraSpreadsheet.SpreadsheetFormulaBarControl();
            this.spreadsheetControl = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.spreadsheetNameBoxControl1 = new DevExpress.XtraSpreadsheet.SpreadsheetNameBoxControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.attForm_DockManager)).BeginInit();
            this.filter_dockPanel.SuspendLayout();
            this.tool_dockPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spreadsheetNameBoxControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // attForm_DockManager
            // 
            this.attForm_DockManager.Form = this;
            this.attForm_DockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.filter_dockPanel,
            this.tool_dockPanel});
            this.attForm_DockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // filter_dockPanel
            // 
            this.filter_dockPanel.Controls.Add(this.dockPanel1_Container);
            this.filter_dockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.filter_dockPanel.ID = new System.Guid("02a5e8d6-2ea2-4e46-bfd4-52e3f01ca7d6");
            this.filter_dockPanel.Location = new System.Drawing.Point(0, 0);
            this.filter_dockPanel.Name = "filter_dockPanel";
            this.filter_dockPanel.OriginalSize = new System.Drawing.Size(251, 200);
            this.filter_dockPanel.Size = new System.Drawing.Size(251, 523);
            this.filter_dockPanel.Text = "过滤选择";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(243, 496);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // tool_dockPanel
            // 
            this.tool_dockPanel.Controls.Add(this.controlContainer1);
            this.tool_dockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.tool_dockPanel.FloatVertical = true;
            this.tool_dockPanel.ID = new System.Guid("6e03d80d-cda8-471f-be21-c577dc7737c2");
            this.tool_dockPanel.Location = new System.Drawing.Point(251, 0);
            this.tool_dockPanel.Name = "tool_dockPanel";
            this.tool_dockPanel.OriginalSize = new System.Drawing.Size(200, 74);
            this.tool_dockPanel.Size = new System.Drawing.Size(526, 74);
            this.tool_dockPanel.Text = "Tools";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Location = new System.Drawing.Point(4, 23);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(518, 47);
            this.controlContainer1.TabIndex = 0;
            // 
            // spreadsheetFormulaBarControl1
            // 
            this.spreadsheetFormulaBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spreadsheetFormulaBarControl1.Location = new System.Drawing.Point(0, 0);
            this.spreadsheetFormulaBarControl1.MinimumSize = new System.Drawing.Size(0, 20);
            this.spreadsheetFormulaBarControl1.Name = "spreadsheetFormulaBarControl1";
            this.spreadsheetFormulaBarControl1.Size = new System.Drawing.Size(376, 20);
            this.spreadsheetFormulaBarControl1.SpreadsheetControl = this.spreadsheetControl;
            this.spreadsheetFormulaBarControl1.TabIndex = 0;
            // 
            // spreadsheetControl
            // 
            this.spreadsheetControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spreadsheetControl.Location = new System.Drawing.Point(251, 99);
            this.spreadsheetControl.Name = "spreadsheetControl";
            this.spreadsheetControl.Options.Export.Csv.Encoding = ((System.Text.Encoding)(resources.GetObject("spreadsheetControl.Options.Export.Csv.Encoding")));
            this.spreadsheetControl.Options.Export.Txt.Encoding = ((System.Text.Encoding)(resources.GetObject("spreadsheetControl.Options.Export.Txt.Encoding")));
            this.spreadsheetControl.Size = new System.Drawing.Size(526, 424);
            this.spreadsheetControl.TabIndex = 0;
            this.spreadsheetControl.Text = "attribute table";
            // 
            // spreadsheetNameBoxControl1
            // 
            this.spreadsheetNameBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spreadsheetNameBoxControl1.EditValue = "A1";
            this.spreadsheetNameBoxControl1.Location = new System.Drawing.Point(0, 0);
            this.spreadsheetNameBoxControl1.Name = "spreadsheetNameBoxControl1";
            this.spreadsheetNameBoxControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spreadsheetNameBoxControl1.Size = new System.Drawing.Size(145, 20);
            this.spreadsheetNameBoxControl1.TabIndex = 0;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainerControl1.Location = new System.Drawing.Point(251, 74);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.spreadsheetNameBoxControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.spreadsheetFormulaBarControl1);
            this.splitContainerControl1.Size = new System.Drawing.Size(526, 20);
            this.splitContainerControl1.SplitterPosition = 145;
            this.splitContainerControl1.TabIndex = 2;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(251, 94);
            this.splitterControl1.MinSize = 20;
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(526, 5);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // AttributeTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 523);
            this.Controls.Add(this.spreadsheetControl);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.tool_dockPanel);
            this.Controls.Add(this.filter_dockPanel);
            this.Name = "AttributeTableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AttributeTableForm";
            this.Load += new System.EventHandler(this.AttributeTableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.attForm_DockManager)).EndInit();
            this.filter_dockPanel.ResumeLayout(false);
            this.tool_dockPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spreadsheetNameBoxControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager attForm_DockManager;
        private DevExpress.XtraBars.Docking.DockPanel filter_dockPanel;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraSpreadsheet.SpreadsheetNameBoxControl spreadsheetNameBoxControl1;
        private DevExpress.XtraSpreadsheet.SpreadsheetFormulaBarControl spreadsheetFormulaBarControl1;
        private DevExpress.XtraBars.Docking.DockPanel tool_dockPanel;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraSpreadsheet.SpreadsheetControl spreadsheetControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;

    }
}