Module Module1

    Sub Main()

        Dim kikosShape As IShape
        Dim juansShape As IShape
        Dim mariasShape As IShape


        kikosShape = ShapeFactory.GetShape(ShapeFactory.SHAPES.CIRCLE)
        juansShape = ShapeFactory.GetShape(ShapeFactory.SHAPES.RECTANGLE)
        mariasShape = ShapeFactory.GetShape(ShapeFactory.SHAPES.SQUARE)


        'Kiko first
        kikosShape.Name = "Kiko"
        kikosShape.Draw()
        Console.WriteLine("Area = " + kikosShape.ComputeArea().ToString())
        Console.WriteLine()
        'Maria
        mariasShape.Name = "Maria"
        mariasShape.Draw()
        Console.WriteLine("Area = " + mariasShape.ComputeArea().ToString())
        Console.WriteLine()
        'Juan
        juansShape.Name = "John"
        juansShape.Draw()
        Console.WriteLine("Area = " + juansShape.ComputeArea().ToString())
        Console.WriteLine()
        Console.ReadLine()




    End Sub

End Module
