Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraPivotGrid

Namespace PivotLayoutCreator
	Partial Public Class MainForm
		Inherits Form
		Private Const LayoutFileName As String = "layout.xml"
		Public Sub New()
			InitializeComponent()
			Me.pivotGrid.DataSource = GetPivotData()
		End Sub
		Private Sub SaveLayout(ByVal fileName As String)
			pivotGrid.SaveLayoutToXml(fileName)
		End Sub
		Private Function GetPivotData() As Object
			Const MaxNumber As Integer = 100
			Dim table As New DataTable()
			table.Columns.Add("Category", GetType(String)) 'pivotGrid.Fileds[0].FieldName//???
			table.Columns.Add("Product", GetType(String))
			table.Columns.Add("Date", GetType(DateTime))
			table.Columns.Add("Sales", GetType(Decimal))
			Dim r As New Random(10)
			For i As Integer = 0 To MaxNumber - 1
				Dim categoryId As Integer = r.Next(MaxNumber\2), productId As Integer = r.Next(5*MaxNumber), year As Integer = r.Next(2005, 2009), month As Integer = r.Next(1, 12)
				table.Rows.Add("Category " & categoryId.ToString(), "Product " & productId.ToString(), New DateTime(year, month, 1), r.Next(MaxNumber) / 10)
			Next i
			Return table.DefaultView
		End Function
		Private Sub btnRunWpfDemo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRunWpfDemo.Click
			Dim filePath As String = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, LayoutFileName)
			SaveLayout(filePath)
			System.Diagnostics.Process.Start("PivotLayoutLoader.exe", filePath)
		End Sub
	End Class
End Namespace