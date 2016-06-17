Module Module1

    Sub Main()

        Dim sensor As New EarthquakeSensor()
        Dim magnitude As Double = 0.0
        Dim randomGenerator As New Random()

        sensor.AddNotifier(New DashboardNotifier())
        sensor.AddNotifier(New EmailAndSMSNotifier())
        sensor.AddNotifier(New AlertNotifier())

        For i As Integer = 1 To 10

            magnitude = randomGenerator.NextDouble()
            magnitude = magnitude * 10.0

            sensor.Trigger(magnitude)
            Console.WriteLine()

            Console.ReadLine()

        Next
    End Sub

End Module
