Public Class SingletonObject

    'create a private instance of the class
    Private Shared _instance As SingletonObject
    Private _name As String = "ChosenOne"

    Public Property InstanceName() As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    'make the constructor private so that it cannot be accessd outside the class
    Private Sub Main()
    End Sub

    Public Shared Function GetInstance() As SingletonObject
        'Note this is not thread safe, locks must be used to ensure thread safety.
        'Check if there is already an instance
        If (_instance Is Nothing) Then

            'Create one if there is none
            _instance = New SingletonObject()

        End If

        'return the current instance
        GetInstance = _instance
    End Function

    Public Sub DoAction()
        Console.WriteLine()
        Console.WriteLine("My  instance name is " + _name)
        Console.WriteLine("I not complicated , I am a Singleton!")
        Console.WriteLine()
    End Sub

End Class
