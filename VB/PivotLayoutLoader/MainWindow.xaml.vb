Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Imports DevExpress.Xpf.PivotGrid
Imports DevExpress.Xpf.Utils.Themes
Imports DevExpress.Xpf.Themes
Imports DevExpress.Utils

Namespace PivotLayoutLoader
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Private Const LayoutLoading As String = "Layout Loading"
		Private Const MessageLayoutNotLoaded As String = "PivotGrid layout has not been loaded."
		Public Sub New()
			InitializeComponent()
			Dim filePath As String = (CType(App.Current, App)).LayoutFileName
			If System.IO.File.Exists(filePath) Then
				pivotGrid.RestoreWinLayoutFromXml(filePath)
			Else
				MessageBox.Show(MessageLayoutNotLoaded, LayoutLoading, MessageBoxButton.OK, MessageBoxImage.Error)
			End If
		End Sub
		Private Sub btnClose_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Close()
		End Sub
	End Class
End Namespace
