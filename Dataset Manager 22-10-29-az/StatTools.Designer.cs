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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatTools));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.DataManager = this.Factory.CreateRibbonButton();
            this.menu_DataTools = this.Factory.CreateRibbonMenu();
            this.btn_Difference = this.Factory.CreateRibbonButton();
            this.btn_Delay = this.Factory.CreateRibbonButton();
            this.btn_calc = this.Factory.CreateRibbonButton();
            this.btn_Interact = this.Factory.CreateRibbonButton();
            this.btn_single_variable = this.Factory.CreateRibbonButton();
            this.button1 = this.Factory.CreateRibbonButton();
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
            this.group1.Items.Add(this.menu_DataTools);
            this.group1.Items.Add(this.btn_single_variable);
            this.group1.Items.Add(this.button1);
            this.group1.Label = "数据";
            this.group1.Name = "group1";
            // 
            // DataManager
            // 
            this.DataManager.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.DataManager.Image = ((System.Drawing.Image)(resources.GetObject("DataManager.Image")));
            this.DataManager.Label = "数据集管理器";
            this.DataManager.Name = "DataManager";
            this.DataManager.ShowImage = true;
            this.DataManager.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.DataManager_Click);
            // 
            // menu_DataTools
            // 
            this.menu_DataTools.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.menu_DataTools.Image = ((System.Drawing.Image)(resources.GetObject("menu_DataTools.Image")));
            this.menu_DataTools.Items.Add(this.btn_Difference);
            this.menu_DataTools.Items.Add(this.btn_Delay);
            this.menu_DataTools.Items.Add(this.btn_calc);
            this.menu_DataTools.Items.Add(this.btn_Interact);
            this.menu_DataTools.Label = "数据实用工具";
            this.menu_DataTools.Name = "menu_DataTools";
            this.menu_DataTools.ShowImage = true;
            // 
            // btn_Difference
            // 
            this.btn_Difference.Label = "差分";
            this.btn_Difference.Name = "btn_Difference";
            this.btn_Difference.ShowImage = true;
            this.btn_Difference.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_Difference_Click);
            // 
            // btn_Delay
            // 
            this.btn_Delay.Label = "滞后";
            this.btn_Delay.Name = "btn_Delay";
            this.btn_Delay.ShowImage = true;
            this.btn_Delay.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button2_Click);
            // 
            // btn_calc
            // 
            this.btn_calc.Label = "运算";
            this.btn_calc.Name = "btn_calc";
            this.btn_calc.ShowImage = true;
            this.btn_calc.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_calc_Click);
            // 
            // btn_Interact
            // 
            this.btn_Interact.Label = "交互作用";
            this.btn_Interact.Name = "btn_Interact";
            this.btn_Interact.ShowImage = true;
            this.btn_Interact.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_Interact_Click);
            // 
            // btn_single_variable
            // 
            this.btn_single_variable.Label = "单变量分析";
            this.btn_single_variable.Name = "btn_single_variable";
            this.btn_single_variable.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Label = "假设检验";
            this.button1.Name = "button1";
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click_1);
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
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menu_DataTools;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_Difference;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_Delay;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_calc;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_Interact;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_single_variable;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
    }

    partial class ThisRibbonCollection
    {
        internal StatTools StatTools
        {
            get { return this.GetRibbon<StatTools>(); }
        }
    }
}
