Public Class Rectangle
    Implements IShape


    Public Function ComputeArea() As Double Implements IShape.ComputeArea
        Dim length As Integer = 0
        Dim width As Integer = 0

        Console.Write("Enter Lenght :")
        length = Integer.Parse(Console.ReadLine())
        Console.Write("Enter Width :")
        width = Integer.Parse(Console.ReadLine())

        ComputeArea = length * width

    End Function

    Public Sub Draw() Implements IShape.Draw

        Console.WriteLine("Drawing a RECTANGLE named " + Name)

    End Sub

    Public Property Name As String Implements IShape.Name
End Class
