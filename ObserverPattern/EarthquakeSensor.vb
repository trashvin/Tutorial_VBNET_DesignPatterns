Public Class EarthquakeSensor

    Private _magnitude As Double

    Private notifiers As New List(Of AObserver)

    Sub New()

        _magnitude = 0.0

    End Sub

    Public Sub Trigger(ByVal aValue As Double)
        _magnitude = aValue
        NotifyAllObservers()
    End Sub

    Public Sub AddNotifier(ByVal aNotifier As AObserver)
        notifiers.Add(aNotifier)
    End Sub

    Public Sub ClearNotifiers()
        notifiers.Clear()
    End Sub

    Public Function GetActiveNotifiersCount() As Integer
        GetActiveNotifiersCount = notifiers.Count
    End Function

    Private Sub NotifyAllObservers()
        For Each notifier As AObserver In notifiers
            notifier.Update(_magnitude)
        Next
    End Sub

End Class
