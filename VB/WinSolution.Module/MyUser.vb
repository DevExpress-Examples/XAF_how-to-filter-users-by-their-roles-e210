Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace WinSolution.Module
	<DefaultClassOptions> _
	Public Class MyUser
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private _userName As String
		Public Property UserName() As String
			Get
				Return _userName
			End Get
			Set(ByVal value As String)
				SetPropertyValue("UserName", _userName, value)
			End Set
		End Property
		<Association("MyRoles-MyUsers")> _
		Public ReadOnly Property MyRoles() As XPCollection(Of MyRole)
			Get
				Return GetCollection(Of MyRole)("MyRoles")
			End Get
		End Property
	End Class

End Namespace
