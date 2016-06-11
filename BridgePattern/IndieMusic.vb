Public Class IndieMusic
    Inherits AMusic

    Sub New(ByVal aDecoder As IDecoder)
        MyBase.New(aDecoder)
    End Sub

    Public Overrides Sub Play()
        Console.WriteLine("Genre : Indie")
        _musicDecoder.DecodeAndPlay()
    End Sub

End Class
