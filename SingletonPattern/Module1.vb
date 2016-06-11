
Module Module1

    Sub Main()

        'Instantiate new objects of the Singleton Object
        Dim objectOne = SingletonObject.GetInstance()
        Dim objectTwo = SingletonObject.GetInstance()

        objectOne.DoAction()
        objectTwo.DoAction()

        Console.WriteLine("Hit enter to change objectOne name to SPARTACUS")
        Console.ReadLine()
        objectOne.InstanceName = "Spartacus"

        objectOne.DoAction()
        objectTwo.DoAction()

        Console.ReadLine()
    End Sub

End Module
