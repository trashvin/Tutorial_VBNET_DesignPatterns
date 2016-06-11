Module Module1

    Sub Main()

        Dim mp3decoder As New MP3Decoder()
        Dim oggDecoder As New OGGDecoder()

        Dim playlist As New List(Of AMusic)

        playlist.Add(New IndieMusic(mp3decoder))
        playlist.Add(New IndieMusic(oggDecoder))
        playlist.Add(New ClassicalMusic(oggDecoder))
        playlist.Add(New IndieMusic(oggDecoder))
        playlist.Add(New ClassicalMusic(mp3decoder))

        Console.WriteLine("Loading your playlist...")
        Console.WriteLine()

        For Each song As AMusic In playlist
            song.Play()
            Console.WriteLine()
        Next

        Console.ReadLine()

    End Sub

End Module
