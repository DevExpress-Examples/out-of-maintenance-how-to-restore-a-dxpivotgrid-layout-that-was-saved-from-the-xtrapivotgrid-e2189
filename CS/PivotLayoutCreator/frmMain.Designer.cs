namespace PivotLayoutCreator {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pivotGrid = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.fieldCategory = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldProduct = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldDate = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldSales = new DevExpress.XtraPivotGrid.PivotGridField();
            this.btnRunWpfDemo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // pivotGrid
            // 
            this.pivotGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pivotGrid.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldCategory,
            this.fieldProduct,
            this.fieldDate,
            this.fieldSales});
            this.pivotGrid.Location = new System.Drawing.Point(12, 12);
            this.pivotGrid.Name = "pivotGrid";
            this.pivotGrid.OptionsDataField.Area = DevExpress.XtraPivotGrid.PivotDataArea.ColumnArea;
            this.pivotGrid.Size = new System.Drawing.Size(481, 297);
            this.pivotGrid.TabIndex = 3;
            // 
            // fieldCategory
            // 
            this.fieldCategory.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldCategory.AreaIndex = 0;
            this.fieldCategory.FieldName = "Category";
            this.fieldCategory.Name = "fieldCategory";
            // 
            // fieldProduct
            // 
            this.fieldProduct.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldProduct.AreaIndex = 1;
            this.fieldProduct.FieldName = "Product";
            this.fieldProduct.Name = "fieldProduct";
            // 
            // fieldDate
            // 
            this.fieldDate.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldDate.AreaIndex = 0;
            this.fieldDate.FieldName = "Date";
            this.fieldDate.Name = "fieldDate";
            // 
            // fieldSales
            // 
            this.fieldSales.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldSales.AreaIndex = 0;
            this.fieldSales.FieldName = "Sales";
            this.fieldSales.Name = "fieldSales";
            // 
            // btnRunWpfDemo
            // 
            this.btnRunWpfDemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunWpfDemo.Location = new System.Drawing.Point(359, 315);
            this.btnRunWpfDemo.Name = "btnRunWpfDemo";
            this.btnRunWpfDemo.Size = new System.Drawing.Size(134, 24);
            this.btnRunWpfDemo.TabIndex = 5;
            this.btnRunWpfDemo.Text = "Save && Run WPF Demo";
            this.btnRunWpfDemo.UseVisualStyleBackColor = true;
            this.btnRunWpfDemo.Click += new System.EventHandler(this.btnRunWpfDemo_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 350);
            this.Controls.Add(this.btnRunWpfDemo);
            this.Controls.Add(this.pivotGrid);
            this.Name = "MainForm";
            this.Text = "Win Demo";
            ((System.ComponentModel.ISupportInitialize)(this.pivotGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPivotGrid.PivotGridControl pivotGrid;
        private System.Windows.Forms.Button btnRunWpfDemo;
        private DevExpress.XtraPivotGrid.PivotGridField fieldCategory;
        private DevExpress.XtraPivotGrid.PivotGridField fieldProduct;
        private DevExpress.XtraPivotGrid.PivotGridField fieldDate;
        private DevExpress.XtraPivotGrid.PivotGridField fieldSales;


    }
}

