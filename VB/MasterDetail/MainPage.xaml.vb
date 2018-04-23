Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Media.Imaging
Imports System.IO
Imports System.Globalization
Imports System.Windows.Data

Namespace MasterDetail
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			masterGrid.DataSource = CategoriesData.DataSource
		End Sub
	End Class
End Namespace
