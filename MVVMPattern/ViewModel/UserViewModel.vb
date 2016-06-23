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

    Private Sub Edit()
        EditMode = True
        AddMode = False
        Editable = True
      
    End Sub

    Private Sub Save()
        Editable = False

        _db.EditUser(SelectedUser.ToMyUser())
        SelectedUser = _usersList(0)

        EditMode = False
        AddMode = False

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

    Private Sub NotifyPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class
