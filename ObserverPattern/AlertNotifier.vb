Public Class AlertNotifier
    Inherits AObserver


    Public Overrides Sub Update(aValue As Double)

        If (aValue >= 6) Then

            Console.WriteLine("Received update from earthquake sensor.")
            Console.WriteLine("Magnitude : " + aValue.ToString())
            Console.WriteLine("Sending alert messages to dashboard...")
            Console.WriteLine("Activating all earthquake warning system on areas affected...")

        End If

    End Sub
End Class
