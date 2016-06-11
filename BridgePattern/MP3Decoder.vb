Public Class MP3Decoder
    Implements IDecoder

    Public Sub DecodeAndPlay() Implements IDecoder.DecodeAndPlay
        Console.WriteLine("Decoding MP3 file........")
        Console.WriteLine("Playing MP3 file.........")
    End Sub
End Class
