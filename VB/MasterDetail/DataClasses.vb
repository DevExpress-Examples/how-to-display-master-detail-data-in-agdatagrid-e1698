Imports Microsoft.VisualBasic
Imports System
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports System.Collections
Imports System.Linq

Namespace MasterDetail

	Public Class Products
		Private privateProductID As Integer
		Public Property ProductID() As Integer
			Get
				Return privateProductID
			End Get
			Set(ByVal value As Integer)
				privateProductID = value
			End Set
		End Property
		Private privateProductName As String
		Public Property ProductName() As String
			Get
				Return privateProductName
			End Get
			Set(ByVal value As String)
				privateProductName = value
			End Set
		End Property
		Private privateCategoryID As Integer
		Public Property CategoryID() As Integer
			Get
				Return privateCategoryID
			End Get
			Set(ByVal value As Integer)
				privateCategoryID = value
			End Set
		End Property
		Private privateUnitPrice As Decimal
		Public Property UnitPrice() As Decimal
			Get
				Return privateUnitPrice
			End Get
			Set(ByVal value As Decimal)
				privateUnitPrice = value
			End Set
		End Property
	End Class

	<XmlRoot("NewDataSet")> _
	Public Class ProductsData
		Inherits List(Of Products)
		Public Shared ReadOnly Property DataSource() As ProductsData
			Get
				Dim s As New XmlSerializer(GetType(ProductsData))
				Dim assemblyGetManifestResourceStream As System.IO.Stream = GetType(ProductsData).Assembly.GetManifestResourceStream(GetType(ProductsData).Namespace + ".Data.Products.xml")
				Return CType(s.Deserialize(assemblyGetManifestResourceStream), ProductsData)
			End Get
		End Property

		Public Function GetProductsByCategory(ByVal categoryID As Integer) As Object
			Return _
				From product In Me _
				Where product.CategoryID = categoryID _
				Select product
		End Function
	End Class


	Public Class Categories
		Private privateCategoryID As Integer
		Public Property CategoryID() As Integer
			Get
				Return privateCategoryID
			End Get
			Set(ByVal value As Integer)
				privateCategoryID = value
			End Set
		End Property
		Private privateCategoryName As String
		Public Property CategoryName() As String
			Get
				Return privateCategoryName
			End Get
			Set(ByVal value As String)
				privateCategoryName = value
			End Set
		End Property
		Private privateDescription As String
		Public Property Description() As String
			Get
				Return privateDescription
			End Get
			Set(ByVal value As String)
				privateDescription = value
			End Set
		End Property
		Private privateProducts As Object
		Public Property Products() As Object
			Get
				Return privateProducts
			End Get
			Set(ByVal value As Object)
				privateProducts = value
			End Set
		End Property
	End Class

	<XmlRoot("NorthwindDataSet")> _
	Public Class CategoriesData
		Inherits List(Of Categories)
		Private Shared Function ReadCategories() As List(Of Categories)
			Dim s As New XmlSerializer(GetType(CategoriesData))
			Dim assemblyGetManifestResourceStream As System.IO.Stream = GetType(CategoriesData).Assembly.GetManifestResourceStream(GetType(CategoriesData).Namespace + ".Data.Categories.xml")
			Return CType(s.Deserialize(assemblyGetManifestResourceStream), List(Of Categories))
		End Function
		Public Shared ReadOnly Property DataSource() As List(Of Categories)
			Get
				Dim categories As List(Of Categories) = ReadCategories()
				Dim products As ProductsData = ProductsData.DataSource
				For Each category As Categories In categories
					category.Products = products.GetProductsByCategory(category.CategoryID)
				Next category
				Return categories
			End Get
		End Property
	End Class



End Namespace
