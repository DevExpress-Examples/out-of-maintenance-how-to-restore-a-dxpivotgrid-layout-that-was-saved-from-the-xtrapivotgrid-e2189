Imports Microsoft.VisualBasic
Imports System
Namespace PivotLayoutCreator
	Partial Public Class MainForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.pivotGrid = New DevExpress.XtraPivotGrid.PivotGridControl()
			Me.fieldCategory = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.fieldProduct = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.fieldDate = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.fieldSales = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.btnRunWpfDemo = New System.Windows.Forms.Button()
			CType(Me.pivotGrid, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' pivotGrid
			' 
			Me.pivotGrid.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.pivotGrid.Fields.AddRange(New DevExpress.XtraPivotGrid.PivotGridField() { Me.fieldCategory, Me.fieldProduct, Me.fieldDate, Me.fieldSales})
			Me.pivotGrid.Location = New System.Drawing.Point(12, 12)
			Me.pivotGrid.Name = "pivotGrid"
			Me.pivotGrid.OptionsDataField.Area = DevExpress.XtraPivotGrid.PivotDataArea.ColumnArea
			Me.pivotGrid.Size = New System.Drawing.Size(481, 297)
			Me.pivotGrid.TabIndex = 3
			' 
			' fieldCategory
			' 
			Me.fieldCategory.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
			Me.fieldCategory.AreaIndex = 0
			Me.fieldCategory.FieldName = "Category"
			Me.fieldCategory.Name = "fieldCategory"
			' 
			' fieldProduct
			' 
			Me.fieldProduct.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
			Me.fieldProduct.AreaIndex = 1
			Me.fieldProduct.FieldName = "Product"
			Me.fieldProduct.Name = "fieldProduct"
			' 
			' fieldDate
			' 
			Me.fieldDate.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
			Me.fieldDate.AreaIndex = 0
			Me.fieldDate.FieldName = "Date"
			Me.fieldDate.Name = "fieldDate"
			' 
			' fieldSales
			' 
			Me.fieldSales.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
			Me.fieldSales.AreaIndex = 0
			Me.fieldSales.FieldName = "Sales"
			Me.fieldSales.Name = "fieldSales"
			' 
			' btnRunWpfDemo
			' 
			Me.btnRunWpfDemo.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnRunWpfDemo.Location = New System.Drawing.Point(359, 315)
			Me.btnRunWpfDemo.Name = "btnRunWpfDemo"
			Me.btnRunWpfDemo.Size = New System.Drawing.Size(134, 24)
			Me.btnRunWpfDemo.TabIndex = 5
			Me.btnRunWpfDemo.Text = "Save && Run WPF Demo"
			Me.btnRunWpfDemo.UseVisualStyleBackColor = True
'			Me.btnRunWpfDemo.Click += New System.EventHandler(Me.btnRunWpfDemo_Click);
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(505, 350)
			Me.Controls.Add(Me.btnRunWpfDemo)
			Me.Controls.Add(Me.pivotGrid)
			Me.Name = "MainForm"
			Me.Text = "Win Demo"
			CType(Me.pivotGrid, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private pivotGrid As DevExpress.XtraPivotGrid.PivotGridControl
		Private WithEvents btnRunWpfDemo As System.Windows.Forms.Button
		Private fieldCategory As DevExpress.XtraPivotGrid.PivotGridField
		Private fieldProduct As DevExpress.XtraPivotGrid.PivotGridField
		Private fieldDate As DevExpress.XtraPivotGrid.PivotGridField
		Private fieldSales As DevExpress.XtraPivotGrid.PivotGridField


	End Class
End Namespace

