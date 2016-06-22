Class MainWindow 

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DataContext = New UserViewModel()
    End Sub

    
End Class
