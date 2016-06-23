Public Class EmailAndSMSNotifier
    Inherits AObserver

    Public Overrides Sub Update(aValue As Double)

        If (aValue >= 3) Then

            Console.WriteLine("Received update from earthquake sensor.")
            Console.WriteLine("Magnitude : " + aValue.ToString())
            Console.WriteLine("Sending data to email notification to designated users..")
            Console.WriteLine("Sending data to sms notification to designated users..")

        End If

    End Sub
End Class
