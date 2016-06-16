Public Class UserDBProvider

    Private _usersList As List(Of MyUser)

    Sub New()

        'lets popupate some data
        _usersList = New List(Of MyUser) From {
            New MyUser With {.UserID = 1, .FullName = "James Jones", .Gender = "Male", .Age = 23},
            New MyUser With {.UserID = 2, .FullName = "Tanya Michaels", .Gender = "Female", .Age = 29},
            New MyUser With {.UserID = 3, .FullName = "Robert Sanders", .Gender = "Male", .Age = 30}
        }

    End Sub

    Public Function GetUsers() As List(Of MyUser)

        GetUsers = _usersList

    End Function

    Public Function AddUser(ByVal aUser As MyUser) As Boolean

        If (_usersList.Find(Function(user As MyUser) user.UserID = aUser.UserID) Is Nothing) Then
            _usersList.Add(aUser)
            AddUser = True
        Else
            AddUser = False
        End If

    End Function

    Public Function DeleteUser(ByVal aUserID As Integer) As Boolean

        Dim index As Integer

        index = _usersList.FindIndex(Function(user As MyUser) user.UserID = aUserID)

        If (index >= 0) Then
            _usersList.RemoveAt(index)
            DeleteUser = True
        Else
            DeleteUser = False
        End If
    End Function

    Public Function EditUser(ByVal aUser As MyUser) As Boolean

        Dim index As Integer

        index = _usersList.FindIndex(Function(user As MyUser) user.UserID = aUser.UserID)

        If (index >= 0) Then

            _usersList(index).FullName = aUser.FullName
            _usersList(index).Gender = aUser.Gender
            _usersList(index).Age = aUser.Age

            EditUser = True
        Else
            EditUser = False
        End If
    End Function

    Public Function FindUserByID(ByVal aUserID As Integer) As MyUser

        FindUserByID = _usersList.Find(Function(user As MyUser) user.UserID = aUserID)

    End Function

End Class

Public Class MyUser

    Public Property UserID As Integer
    Public Property FullName As String
    Public Property Gender As String
    Public Property Age As Integer

End Class
