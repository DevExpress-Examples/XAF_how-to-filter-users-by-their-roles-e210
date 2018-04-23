Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports System.ComponentModel
Imports DevExpress.Data.Filtering

Namespace WinSolution.Module
	<DefaultClassOptions> _
	Public Class DomainObject1
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private _name As String
		Public Property Name() As String
			Get
				Return _name
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", _name, value)
			End Set
		End Property
		Private _myRole As MyRole
		<ImmediatePostData> _
		Public Property MyRole() As MyRole
			Get
				Return _myRole
			End Get
			Set(ByVal value As MyRole)
				SetPropertyValue("MyRole", _myRole, value)
			End Set
		End Property
		Private _myUser As MyUser
		'[DataSourceCriteria("MyRoles[RoleName = 'r2']")]
		<DataSourceProperty("MyUserDataSource")> _
		Public Property MyUser() As MyUser
			Get
				Return _myUser
			End Get
			Set(ByVal value As MyUser)
				SetPropertyValue("MyUser", _myUser, value)
			End Set
		End Property
		Private myUserDataSourceInternal As XPCollection(Of MyUser) = Nothing
		<Browsable(False), MemberDesignTimeVisibility(False)> _
		Public ReadOnly Property MyUserDataSource() As XPCollection(Of MyUser)
			Get
				If myUserDataSourceInternal Is Nothing Then
					myUserDataSourceInternal = New XPCollection(Of MyUser)(Session)
				End If
				UpdateAddressDataSource()
				Return myUserDataSourceInternal
			End Get
		End Property
		Private Sub UpdateAddressDataSource()
			If Not MyRole Is Nothing Then
				myUserDataSourceInternal.Criteria = CriteriaOperator.Parse("MyRoles[RoleName = ?]", MyRole.RoleName)
			Else
				myUserDataSourceInternal.Criteria = Nothing
			End If
		End Sub
	End Class
End Namespace
