Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Linq
Imports System.Windows

Namespace PivotLayoutLoader
	''' <summary>
	''' Interaction logic for App.xaml
	''' </summary>
	Partial Public Class App
		Inherits Application
		Private layoutFileName_Renamed As String
		Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
			MyBase.OnStartup(e)
			If e.Args.Length > 0 Then
				layoutFileName_Renamed = e.Args(0)
			End If
		End Sub
		Public ReadOnly Property LayoutFileName() As String
			Get
				Return layoutFileName_Renamed
			End Get
		End Property
	End Class
End Namespace
