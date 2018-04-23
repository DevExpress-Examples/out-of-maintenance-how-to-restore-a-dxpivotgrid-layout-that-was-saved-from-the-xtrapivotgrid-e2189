using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;

namespace PivotLayoutCreator {
    public partial class MainForm : Form {
        const string LayoutFileName = "layout.xml";
        public MainForm() {
            InitializeComponent();
            this.pivotGrid.DataSource = GetPivotData();
        }
        void SaveLayout(string fileName) {
            pivotGrid.SaveLayoutToXml(fileName);
        }
        object GetPivotData() {
            const int MaxNumber = 100;
            DataTable table = new DataTable();
            table.Columns.Add("Category", typeof(string));//pivotGrid.Fileds[0].FieldName//???
            table.Columns.Add("Product", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Sales", typeof(decimal));
            Random r = new Random(10);
            for(int i = 0; i < MaxNumber; i++) {
                int categoryId = r.Next(MaxNumber/2),
                    productId = r.Next(5*MaxNumber),
                    year = r.Next(2005, 2009),
                    month = r.Next(1, 12);
                table.Rows.Add("Category " + categoryId.ToString(),
                    "Product " + productId.ToString(), new DateTime(year, month, 1), r.Next(MaxNumber) / 10);
            }
            return table.DefaultView;
        }
        void btnRunWpfDemo_Click(object sender, EventArgs e) {
            string filePath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, LayoutFileName);
            SaveLayout(filePath);
            System.Diagnostics.Process.Start("PivotLayoutLoader.exe", filePath);
        }
    }
}