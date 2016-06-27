Imports System.ComponentModel
Imports DataProviderService
Imports System.Collections.ObjectModel
Imports System.Windows.Input
'If System.ComponentModel is not available, check if you have added reference to 
'System.ComponentModel...


Public Class UserViewModel
    Implements INotifyPropertyChanged

    Private _db As New UserDBProvider()
    Private _selectedUser As New UserModel()
    Private _usersList As New ObservableCollection(Of UserModel)

    Private _editCommand As ICommand
    Private _deleteCommand As ICommand
    Private _addCommand As ICommand
    Private _saveCommand As ICommand

    Sub New()

        For Each rawUser As MyUser In _db.GetUsers()
            _usersList.Add(New UserModel(rawUser))
        Next
        SelectedUser = _usersList(0)
        EditMode = False
        AddMode = False
        Editable = False
    

    End Sub

    Public Property UsersList As ObservableCollection(Of UserModel)
        Get
            Return _usersList
        End Get
        Set(value As ObservableCollection(Of UserModel))
            _usersList = value
            NotifyPropertyChanged("UsersList")
        End Set
    End Property


    Public Property SelectedUser As UserModel
        Get
            Return _selectedUser
        End Get
        Set(value As UserModel)
            _selectedUser = value
            NotifyPropertyChanged("SelectedUser")
        End Set
    End Property

    Private _editMode As Boolean
    Public Property EditMode As Boolean
        Get
            Return _editMode
        End Get
        Set(value As Boolean)
            _editMode = value
            NotifyPropertyChanged("EditMode")
        End Set
    End Property

    Private _addMode As Boolean
    Public Property AddMode As Boolean
        Get
            Return _addMode
        End Get
        Set(value As Boolean)
            _addMode = value
            NotifyPropertyChanged("AddMode")
        End Set
    End Property

    Private _editable As Boolean
    Public Property Editable As Boolean
        Get
            Return _editable
        End Get
        Set(value As Boolean)
            _editable = value
            NotifyPropertyChanged("Editable")
        End Set
    End Property

    Public Property SaveCommand As ICommand
        Get
            If (_saveCommand Is Nothing) Then
                _saveCommand = New RelayCommand(Sub(param) Me.Save(), Nothing)
            End If

            Return _saveCommand
        End Get
        Set(value As ICommand)
            _saveCommand = value
        End Set
    End Property

    Public Property EditCommand As ICommand
        Get
            If (_editCommand Is Nothing) Then
                _editCommand = New RelayCommand(Sub(param) Me.Edit(), Nothing)
            End If

            Return _editCommand
        End Get
        Set(value As ICommand)
            _editCommand = value
        End Set
    End Property

    Public Property DeleteCommand As ICommand
        Get
            If (_deleteCommand Is Nothing) Then
                _deleteCommand = New RelayCommand(Sub(param) Me.Delete(), Nothing)
            End If

            Return _deleteCommand
        End Get
        Set(value As ICommand)
            _deleteCommand = value
        End Set
    End Property

    Public Property AddCommand As ICommand
        Get
            If (_addCommand Is Nothing) Then
                _addCommand = New RelayCommand(Sub(param) Me.Add(), Nothing)
            End If

            Return _addCommand
        End Get
        Set(value As ICommand)
            _addCommand = value
        End Set
    End Property

    Private Sub Edit()
        EditMode = True
        AddMode = False
        Editable = True

    End Sub

    Private Sub Save()
        Editable = False

        If AddMode Then
            _db.AddUser(SelectedUser.ToMyUser())
        Else
            _db.EditUser(SelectedUser.ToMyUser())
        End If


        SelectedUser = _usersList(0)

        EditMode = False
        AddMode = False

    End Sub

    Private Sub Add()
        Editable = True
        EditMode = True
        AddMode = True

        'we can compute for the next userID and create a new instance of UserModel for the new user
        Dim newUser As New UserModel() With {.UserID = GetNextUserID()}

        'add the new temp user to the list
        UsersList.Add(newUser)

        'set the new user as the selected user
        SelectedUser = UsersList(UsersList.Count - 1)

        'Note : The solution does not support the cancellationof Add. Thus, the new user is always have to be saved.
        'If the cancellation is to be supported, this temp user have to be remved from the list

    End Sub

    Private Sub Delete()
        _db.DeleteUser(SelectedUser.UserID)
        _usersList.Clear()
        For Each rawUser As MyUser In _db.GetUsers()
            _usersList.Add(New UserModel(rawUser))
        Next

        If (_usersList.Count > 0) Then
            SelectedUser = _usersList(0)
        End If
    End Sub

    Private Function GetNextUserID() As Integer
        'This is just to easily generate a valid UserID, it not a recommended solution
        'for big projects. Try persisiting the last generated ID on a file/db to keep track.

        Dim maxID As Integer = 0

        For Each rawUser As UserModel In _usersList
            If (rawUser.UserID > maxID) Then
                maxID = rawUser.UserID
            End If
        Next

        GetNextUserID = maxID + 1
    End Function

    Private Sub NotifyPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class
