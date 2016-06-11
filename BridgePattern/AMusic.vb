Public MustInherit Class AMusic

    Protected _musicDecoder As IDecoder

    Sub New(ByVal aDecoder As IDecoder)
        _musicDecoder = aDecoder
    End Sub

    MustOverride Sub Play()



End Class
