Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace WinSolution.Module
	<DefaultClassOptions> _
	Public Class MyRole
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private _roleName As String
		Public Property RoleName() As String
			Get
				Return _roleName
			End Get
			Set(ByVal value As String)
				SetPropertyValue("RoleName", _roleName, value)
			End Set
		End Property
		<Association("MyRoles-MyUsers")> _
		Public ReadOnly Property MyUsers() As XPCollection(Of MyUser)
			Get
				Return GetCollection(Of MyUser)("MyUsers")
			End Get
		End Property
	End Class

End Namespace
