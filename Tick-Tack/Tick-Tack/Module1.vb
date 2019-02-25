' Simple changes from Konect
'Check it out https://github.com/n43ee7/konect/
'
'Probably wont work on it much since I'll be learning Python 
'
'
' Happy hunting and modding 
'
'
' Also Change the music file locations since They cant be uploaded to GitHub due to file size
'

Module Module1

    Dim PlayerTurn As Boolean
    Dim Grid(2, 2) As String
    Dim GameState As Boolean = True
    Dim Player1 As String = "[O]" '"✔"
    Dim Player2 As String = "[X]" '"✖"
    Dim Signal(2, 2) As Boolean
    Dim KeyCheck As String

    Sub Main()
        StartScreen()
        Toss()
        Formategrid()
        Do Until GameState = False
            GameOut()
            SpriteInputCollect() '>>Forward to existing mod
            Gamecheck()
        Loop

    End Sub

    Sub StartScreen()
        'My.Computer.Audio.Play("untitled.wav", AudioPlayMode.BackgroundLoop) 'Change The location 
        Console.BackgroundColor = ConsoleColor.Black
        Console.ForegroundColor = ConsoleColor.Red
        Console.SetCursorPosition(50, 0)
        Console.WriteLine("
                              
                  ▄▄▄█████▓ ██▓ ▄████▄   ██ ▄█▀      ▄▄▄█████▓ ▄▄▄       ▄████▄   ██ ▄█▀
                  ▓  ██▒ ▓▒▓██▒▒██▀ ▀█   ██▄█▒       ▓  ██▒ ▓▒▒████▄    ▒██▀ ▀█   ██▄█▒ 
                  ▒ ▓██░ ▒░▒██▒▒▓█    ▄ ▓███▄░       ▒ ▓██░ ▒░▒██  ▀█▄  ▒▓█    ▄ ▓███▄░ 
                  ░ ▓██▓ ░ ░██░▒▓▓▄ ▄██▒▓██ █▄       ░ ▓██▓ ░ ░██▄▄▄▄██ ▒▓▓▄ ▄██▒▓██ █▄ 
                    ▒██▒ ░ ░██░▒ ▓███▀ ░▒██▒ █▄        ▒██▒ ░  ▓█   ▓██▒▒ ▓███▀ ░▒██▒ █▄
                    ▒ ░░   ░▓  ░ ░▒ ▒  ░▒ ▒▒ ▓▒        ▒ ░░    ▒▒   ▓▒█░░ ░▒ ▒  ░▒ ▒▒ ▓▒
                      ░     ▒ ░  ░  ▒   ░ ░▒ ▒░          ░      ▒   ▒▒ ░  ░  ▒   ░ ░▒ ▒░
                    ░       ▒ ░░        ░ ░░ ░         ░        ░   ▒   ░        ░ ░░ ░ 
                            ░  ░ ░      ░  ░                        ░  ░░ ░      ░  ░   
                               ░                                        ░               
")
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.Write(vbTab)
        Console.WriteLine("Bootin up the strap")
        Console.Write(vbTab)
        Console.Write("[")
        For i = 0 To 100
            System.Threading.Thread.Sleep(10)
            Console.Write("░")
        Next
        Console.WriteLine("]")

        Console.ForegroundColor = ConsoleColor.Red
        Console.SetCursorPosition(50, 20) 'Below Centre 
        Console.WriteLine("Press any key to Start")
        Console.ReadKey()
        Console.Clear()
    End Sub 'Deployed
    Sub Toss() 'Turn scheduling (P1 = False, P2 = True)
        Dim Start As Integer
        Randomize()
        Start = Int(Rnd() * 2 + 1)
        If Start = 1 Then
            PlayerTurn = False
        ElseIf Start = 2 Then
            PlayerTurn = True
        Else Toss()
        End If
        If PlayerTurn = False Then
            Console.ForegroundColor = ConsoleColor.DarkCyan
            Console.WriteLine("Player 1 Gets to start")
        ElseIf PlayerTurn = True Then
            Console.ForegroundColor = ConsoleColor.DarkGreen
            Console.WriteLine("Player 2 Gets to start")
        End If
        System.Threading.Thread.Sleep(600)
    End Sub 'Deployed
    Sub Formategrid()
        Dim rwH, clH As Integer
        For rwH = 0 To 2
            For clH = 0 To 2
                Grid(rwH, clH) = "[ ]"
            Next
        Next
    End Sub 'Deployed
    Sub GameOut()
        Dim rwH, clH As Integer
        For rwH = 0 To 2
            For clH = 0 To 2
                Console.Write(Grid(rwH, clH))
            Next
            Console.WriteLine()
        Next
        System.Threading.Thread.Sleep(2000)
    End Sub 'Deployed
    Sub SpriteInputCollect()
        Dim x, y As Integer
        Console.Clear()
1:      Console.WriteLine("=======================================================================================")
        Console.WriteLine("[!] Please Enter Coordinates of the Sprite Entry (press -1 at the first entry for HELP)")
        Console.WriteLine("=======================================================================================")
        Console.Write("(x)")
        x = Console.ReadLine()
        If x = -1 Or x > 2 Then
2:          Console.Clear()
            Console.WriteLine("===============================================================================================")
            Console.WriteLine("[!] Input the coordinates of the Sprite as Follows
> In the First input Enter the X value (Horizontal Value)  
> In the Second input Enter the Y value (Vertical Value)
> keep in mind the inputs start from 0 therefore dont mess up your turn lol

> Syntax  i.e (x,y) = (1,3) PLaces the Sprite at the Xth value of 1 going to the Yth value of 3

Honestly I myself dont know how to explain this rn so just assume you get it :)

> -1 Overload causes this message
> -2 Overload causes the games current state to be saved
> -3 Overload Prints the grid again
> -4 Overload deletes your Old save
> -5 Overload restores your  saved game
> -420 THE DAMN COMPUTA PLAYS ALL BY ITSELF!!!! LMAOOOOOOO
")
            Console.WriteLine("===============================================================================================")
            System.Threading.Thread.Sleep(700)
            GoTo 1
        ElseIf x = -2 Then
            SaveGame()
            Console.Clear()
            GoTo 1
        ElseIf x = -3 Then
            Console.Clear()
            GameOut()
            GoTo 1
        ElseIf x = -4 Then
            System.IO.File.WriteAllText("gamelog.txt", "")
            Console.Clear()
            GoTo 1
        ElseIf x = -5 Then
            RestoreGame()
            Console.Clear()
            GameOut()
        ElseIf x = -420 Then
            Console.Clear()
            fourtwentyblaze()
        End If

        Console.Write("(y)")
        y = Console.ReadLine()
        If y > 2 Then
            GoTo 2
        End If

        SpritePlacing(x, y)
    End Sub 'Deployed
    Sub checkSpriteData()
        'Blocking all existing states 
        Dim x As Integer = 0
        Dim y As Integer = 0

        For x = 0 To 2
            For y = 0 To 2

                If Grid(x, y) = "[ ]" Then
                    Signal(x, y) = False
                ElseIf Grid(x, y) = "[X]" Or Grid(x, y) = "[O]" Then
                    Signal(x, y) = True
                End If
            Next
        Next
    End Sub 'Deployed
    Sub SpritePlacing(ByRef x As Integer, ByRef y As Integer)
        checkSpriteData()
        If PlayerTurn = True And Signal(x, y) = False Then
            'Player 2 starts
            Grid(x, y) = Player2
            GameOut()
            System.Threading.Thread.Sleep(500)
            playerswitch()
            Console.ReadKey()
        ElseIf PlayerTurn = False And Signal(x, y) = False Then
            'player 1 starts
            Grid(x, y) = Player1
            GameOut()
            System.Threading.Thread.Sleep(500)
            playerswitch()
            Console.ReadKey()
        ElseIf Signal(x, y) = True Then 'kyu bhai???
            Console.WriteLine("[!] Sprite Position already taken please try again")
            System.Threading.Thread.Sleep(900)
            SpriteInputCollect()
        End If
    End Sub 'Deployed
    Sub playerswitch()
        If PlayerTurn = False Then
            PlayerTurn = True
        ElseIf PlayerTurn = True Then
            PlayerTurn = False
        End If
        SpriteInputCollect()
    End Sub 'Deployed
    Sub Gamecheck()
        'Game state = false to terminate
        Dim rwH, cwH As Integer
        For rwH = 0 To 2
            If (Grid(0, rwH) = "[X]" Or Grid(0, rwH) = "[O]") And (Grid(1, rwH) = "[X]" Or Grid(1, rwH) = "[O]") And (Grid(2, rwH) = "[X]" Or Grid(2, rwH) = "[O]") Then
                GameState = False
            End If
        Next
        For cwH = 0 To 2
            If (Grid(cwH, 0) = "[X]" Or Grid(cwH, 0) = "[O]") And (Grid(cwH, 1) = "[X]" Or Grid(cwH, 1) = "[O]") And (Grid(cwH, 2) = "[X]" Or Grid(cwH, 2) = "[O]") Then
                GameState = False
            End If
        Next

        If (Grid(0, 0) = "[X]" Or Grid(0, 0) = "[O]") And (Grid(1, 1) = "[X]" Or Grid(1, 1) = "[O]") And (Grid(2, 2) = "[X]" Or Grid(2, 2) = "[O]") Then
            GameState = False
        End If
        'Verify
        If (Grid(0, 2) = "[X]" Or Grid(0, 2) = "[O]") And (Grid(1, 1) = "[X]" Or Grid(1, 1) = "[O]") And (Grid(2, 0) = "[X]" Or Grid(2, 0) = "[O]") Then
            GameState = False
        End If
    End Sub
    Sub SaveGame()
        FileOpen(1, "gamelog.txt", OpenMode.Output)
        Dim rwH, clH As Integer
        For rwH = 0 To 2
            For clH = 0 To 2
                Write(1, Grid(rwH, clH))
            Next
            WriteLine(1)
        Next
    End Sub 'Deployed
    Sub RestoreGame()
        Dim Insert As String
        Dim rwH As Integer = 0
        Dim clh As Integer = 0
        Dim check As Boolean = False

        FileOpen(1, "gamelog.txt", OpenMode.Input)
        Insert = LineInput(1)

        Do While check = False Or rwH = 7
            Do While check = False Or clh = 7

                If Grid(rwH, clh) = "[X]" Or Grid(rwH, clh) = "[O]" Then
                    check = True
                End If

                clh = clh + 1
            Loop
            rwH = rwH + 1
        Loop
        If check = True Then
            Console.WriteLine("=======================================================")
            Console.WriteLine("[!] You can't restore the save at this time of the game.
Make sure you have a clear grid. ")
            Console.WriteLine("=======================================================")
            System.Threading.Thread.Sleep(800)
            SpriteInputCollect()
        ElseIf Insert = Nothing Then
            Console.WriteLine("====================================")
            Console.WriteLine("[!] No grid data found, in the save.")
            Console.WriteLine("====================================")
            System.Threading.Thread.Sleep(800)
            SpriteInputCollect()
        End If

        'INGEST ENGINE NOT BUILT YET

    End Sub
    Sub fourtwentyblaze()
        Console.Clear()
        'My.Computer.Audio.Play("420.wav", AudioPlayMode.BackgroundLoop) 'Change Location
        Console.BackgroundColor = ConsoleColor.Black
        Console.ForegroundColor = ConsoleColor.Green
        Console.SetCursorPosition(10, 0)
        Console.WriteLine("
                        .
                       .:.
                       :|:
                      .:|:.
                      ::|::
       :.             ::|::             .:
       :|:.          .::|::.          .:|:
       ::|:.         :::|:::         .:|:;
       `::|:.        :::|:::        .:|::'
        ::|::.       :::|:::       .::|:;
        `::|::.      :::|:::      .::|::'
         :::|::.     :::|:::     .::|::;
         `:::|::.    :::|:::    .::|::;'
`::.      `:::|::.   :::|:::   .::|::;'      .:;'
 `:::..     ¹::|::.  :::|:::  .::|::¹    ..::;'
   `:::::.    ':|::. :::|::: .::|:'   ,::::;'
     `:::::.    ':|:::::|:::::|:'   :::::;'
       `:::::.:::::|::::|::::|::::.,:::;'
          ':::::::::|:::|:::|:::::::;:'
             ':::::::|::|::|:::::::''
                  `::::::::::;'
                 .:;'' ::: ``::.
                      :':':
                        ;
")
        Console.ForegroundColor = ConsoleColor.DarkMagenta
        Console.Write(vbTab)
        Console.WriteLine("Just like old times Charlie boy")
        Console.Write(vbTab)
        Console.Write("[")
        For i = 0 To 100
            System.Threading.Thread.Sleep(50)
            Console.Write("░")
        Next
        Console.WriteLine("]")
        Console.ForegroundColor = ConsoleColor.DarkGreen

        Dim Start As Integer
        Randomize()
        Start = Int(Rnd() * 2 + 1)
        If Start = 1 Then
            PlayerTurn = False
        ElseIf Start = 2 Then
            PlayerTurn = True
        Else Toss()
        End If
        If PlayerTurn = False Then
            Console.ForegroundColor = ConsoleColor.DarkGreen
            Console.WriteLine("Computer 1 Gets to start")
        ElseIf PlayerTurn = True Then
            Console.ForegroundColor = ConsoleColor.DarkGreen
            Console.WriteLine("Computer 2 Gets to start")
        End If
        System.Threading.Thread.Sleep(600)


        'Start of automation

        Dim rwHa, clHa As Integer
        Dim rwH, clH As Integer
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim xOfGrid As Integer
        Dim yOfGrid As Integer
        Dim rwHb, clHb As Integer

        For rwHa = 0 To 2
            For clHa = 0 To 2
                Grid(rwHa, clHa) = "[ ]"
            Next
        Next 'Makes the grid
        For rwH = 0 To 2
            For clH = 0 To 2
                Console.Write(Grid(rwH, clH))
            Next
            Console.WriteLine()
        Next 'displays the grid

        System.Threading.Thread.Sleep(1000)

        Do Until GameState = False
            Randomize()
            xOfGrid = Int(Rnd() * 2 + 0)
            Randomize()
            yOfGrid = Int(Rnd() * 2 + 0)

            For x = 0 To 2
                For y = 0 To 2

                    If Grid(x, y) = "[ ]" Then
                        Signal(x, y) = False
                    ElseIf Grid(x, y) = "[X]" Or Grid(x, y) = "[O]" Then
                        Signal(x, y) = True
                    End If
                Next
            Next 'Bools up the grid
1:
            If PlayerTurn = True And Signal(xOfGrid, yOfGrid) = False Then
                'C 2 starts
                Grid(xOfGrid, yOfGrid) = Player2
                Console.WriteLine()
                Dim rwHd, clHd As Integer
                For rwHd = 0 To 2
                    For clHd = 0 To 2
                        Console.Write(Grid(rwHd, clHd))
                    Next
                    Console.WriteLine()
                Next
                System.Threading.Thread.Sleep(500)
                If PlayerTurn = False Then
                    PlayerTurn = True
                ElseIf PlayerTurn = True Then
                    PlayerTurn = False
                End If

            ElseIf PlayerTurn = False And Signal(xOfGrid, yOfGrid) = False Then
                'C 1 starts
                Grid(xOfGrid, yOfGrid) = Player1
                Console.WriteLine()
                Dim rwHc, clHc As Integer
                For rwHc = 0 To 2
                    For clHc = 0 To 2
                        Console.Write(Grid(rwHc, clHc))
                    Next
                    Console.WriteLine()
                Next
                System.Threading.Thread.Sleep(500)
                If PlayerTurn = False Then
                    PlayerTurn = True
                ElseIf PlayerTurn = True Then
                    PlayerTurn = False
                End If

            ElseIf Signal(xOfGrid, yOfGrid) = True Then
                Console.WriteLine("[!] LOL The computer did an Opsie (Wrong move)")
                System.Threading.Thread.Sleep(900)
                Randomize()
                xOfGrid = Int(Rnd() * 2 + 0)
                Randomize()
                yOfGrid = Int(Rnd() * 2 + 0)
                GoTo 1
            End If
            Console.WriteLine()
            For rwHb = 0 To 2
                For clHb = 0 To 2
                    Console.Write(Grid(rwHb, clHb))
                Next
                Console.WriteLine()
            Next 'Displays the grid

            System.Threading.Thread.Sleep(2000)
            Console.WriteLine()
            Gamecheck()
        Loop
        Console.ReadKey()
    End Sub 'STAND ALONE MOD (NO LINK) 
End Module
