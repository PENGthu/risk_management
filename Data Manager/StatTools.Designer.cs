namespace Dataset_Manager
{
    partial class StatTools : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public StatTools()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.DataManager = this.Factory.CreateRibbonButton();
            this.DataView = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.DataManager);
            this.group1.Items.Add(this.DataView);
            this.group1.Label = "数据";
            this.group1.Name = "group1";
            // 
            // DataManager
            // 
            this.DataManager.Label = "数据集管理器";
            this.DataManager.Name = "DataManager";
            this.DataManager.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.DataManager_Click);
            // 
            // DataView
            // 
            this.DataView.Label = "数据查看器";
            this.DataView.Name = "DataView";
            this.DataView.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.DataView_Click);
            // 
            // StatTools
            // 
            this.Name = "StatTools";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.StatTools_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton DataManager;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton DataView;
    }

    partial class ThisRibbonCollection
    {
        internal StatTools StatTools
        {
            get { return this.GetRibbon<StatTools>(); }
        }
    }
}
