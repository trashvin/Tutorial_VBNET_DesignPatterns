Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports DataProviderService

<TestClass()> Public Class UserDBTest

    Private _userList As New UserDBProvider()

    <TestMethod()> Public Sub TestInitialData()

        Dim expectedCount As Integer = 3
        Dim actualCount As Integer = _userList.GetUsers().Count

        Assert.AreEqual(expectedCount, actualCount)

    End Sub

    <TestMethod()> Public Sub TestAddData()

        Dim expectedCount = 4
        Dim newUser As New MyUser With {.UserID = 4, .FullName = "Maria Summers", .Gender = "Female", .Age = 30}

        _userList.AddUser(newUser)

        Assert.AreEqual(expectedCount, _userList.GetUsers().Count)
    End Sub


    <TestMethod()> Public Sub TestDeleteData()

        Dim userIDToDelete As Integer = 3

        _userList.DeleteUser(userIDToDelete)

        Dim foundUser = _userList.FindUserByID(3)

        Assert.AreEqual(Nothing, foundUser)


    End Sub

    <TestMethod()> Public Sub TestEditData()

        Dim newData As New MyUser With {.UserID = 1, .FullName = "James Y Jones", .Gender = "Male", .Age = 45}

        Dim oldAge As Integer = _userList.FindUserByID(1).Age

        _userList.EditUser(newData)

        Dim newAge As Integer = _userList.FindUserByID(1).Age
        Dim newName As String = _userList.FindUserByID(1).FullName

        Assert.AreNotEqual(oldAge, newAge)
        Assert.AreEqual("James Y Jones", newName)

    End Sub

    <TestMethod()> Public Sub TestFindByID()

        Dim name As String = _userList.FindUserByID(1).FullName

        Assert.AreEqual("James Jones", name)

    End Sub

End Class