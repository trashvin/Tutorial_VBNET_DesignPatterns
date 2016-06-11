Public Class Square
    Implements IShape

    Public Function ComputeArea() As Double Implements IShape.ComputeArea
        Dim sideDimension As Integer = 0

        Console.Write("Enter the lenght of the side :")
        sideDimension = Integer.Parse(Console.ReadLine())

        ComputeArea = Math.Pow(sideDimension, 2)

    End Function

    Public Sub Draw() Implements IShape.Draw

        Console.WriteLine("Drawing a SQUARE named " + Name)

    End Sub

    Public Property Name As String Implements IShape.Name
       
End Class
