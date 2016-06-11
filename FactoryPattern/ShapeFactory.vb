Public Class ShapeFactory

    Public Enum SHAPES
        SQUARE
        RECTANGLE
        CIRCLE
    End Enum

    Public Shared Function GetShape(ByVal ShapeType As SHAPES) As IShape

        Select Case ShapeType
            Case SHAPES.SQUARE
                GetShape = New Square()
            Case SHAPES.RECTANGLE
                GetShape = New Rectangle()
            Case SHAPES.CIRCLE
                GetShape = New Circle()
            Case Else
                Return Nothing
        End Select



    End Function


End Class
