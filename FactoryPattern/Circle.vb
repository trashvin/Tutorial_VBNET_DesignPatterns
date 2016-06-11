Public Class Circle
    Implements IShape

    Public Function ComputeArea() As Double Implements IShape.ComputeArea

        Dim radius As Integer = 0

        Console.Write("Enter Radius :")
        radius = Integer.Parse(Console.ReadLine())

        ComputeArea = Math.PI * Math.Pow(radius, 2)

    End Function

    Public Sub Draw() Implements IShape.Draw

        Console.WriteLine("Drawing a CIRCLE named " + Name)

    End Sub

    Public Property Name As String Implements IShape.Name
End Class
