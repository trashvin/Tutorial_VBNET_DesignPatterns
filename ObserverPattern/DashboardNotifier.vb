Public Class DashboardNotifier
    Inherits AObserver

    Public Overrides Sub Update(aValue As Double)

        If (aValue >= 0) Then
            Console.WriteLine("Received update from earthquake sensor.")
            Console.WriteLine("Magnitude : " + aValue.ToString())
            Console.WriteLine("Sending data to dashboard..")
        End If

    End Sub
End Class
