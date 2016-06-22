Imports DataProviderService

Public Class UserModel
    Public Property UserID As Integer
    Public Property FullName As String
    Public Property Gender As String
    Public Property Age As Integer

    Public Sub New()

    End Sub

    Public Sub New(ByVal aRawUser As MyUser)
        Me.UserID = aRawUser.UserID
        Me.FullName = aRawUser.FullName
        Me.Gender = aRawUser.Gender
        Me.Age = aRawUser.Age
    End Sub

    Public Function ToMyUser() As MyUser
        ToMyUser = New MyUser() With {.UserID = Me.UserID, .FullName = Me.FullName, .Age = Me.Age, .Gender = Me.Gender}
    End Function

End Class
