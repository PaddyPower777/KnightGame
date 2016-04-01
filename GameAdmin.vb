Public Class GameAdmin
    Private fKnight As Knight
    Private fBoard As Board
    Private fSquaresLeft As Integer
    Private fTimeLeft As Integer
    Private fIsFirstMove As Boolean
    Private fRunning As Boolean

    Public ReadOnly Property SquaresLeft As Integer
        Get
            Return fSquaresLeft
        End Get
    End Property

    Public ReadOnly Property TimeLeft As Integer
        Get
            Return fTimeLeft
        End Get
    End Property

    Public ReadOnly Property IsFirstMove As Boolean
        Get
            Return fIsFirstMove
        End Get
    End Property

    Public ReadOnly Property Running As Boolean
        Get
            Return fRunning
        End Get
    End Property

    Public Sub New()
        'Preconditions: none
        'Postconditions: An instance of GameAdmin is created, the board is
        'created of size 5, SquaresLeft is 5 * 5 = 25, TimeLeft is 2 * 25 = 50,
        'IsFirstMove is True, and Running is False.
        fBoard = New Board(5)
        fSquaresLeft = 25
        fTimeLeft = 50
        fIsFirstMove = True
        fRunning = False
    End Sub

    Public Sub New(ByVal boardSize As Integer)
        'Preconditions: boardSize lies within 3 and 8 inclusive.
        'Postconditions: An instance of GameAdmin is created, the board is
        'created of size boardSize, SquaresLeft is boardSize * boardSize, TimeLeft
        'is 2 * boardSize * boardSize, IsFirstMove is True, and Running is False.
        fBoard = New Board(boardSize)
        fSquaresLeft = boardSize * boardSize
        fTimeLeft = 2 * boardSize * boardSize
        fIsFirstMove = True
        fRunning = False
    End Sub

    Public Sub start()
        'Preconditions: none
        'Postconditions: If SquaresLeft > 0 and TimeLeft > 0, then Running is set
        'to True.
        If (SquaresLeft > 0) And (TimeLeft > 0) Then
            fRunning = True
        End If
    End Sub

    Public Sub pause()
        'Preconditions: none
        'Postconditions: Running is set to False.
        fRunning = False
    End Sub

    Public Sub decreaseTime()
        'Preconditions: none
        'Postconditions: If Running, TimeLeft is decreased by 1.
        'If TimeLeft < 1, Running is set to False and the player has lost.
        If Running Then
            fTimeLeft = TimeLeft - 1
            If TimeLeft < 1 Then
                fRunning = False
            End If
        End If
    End Sub

    Public Sub drawState(ByRef g As Graphics, ByRef r As Rectangle)
        fBoard.drawState(g, r)
        If Not IsFirstMove Then
            fKnight.draw(g, fBoard.SquareSize)
        End If
    End Sub

    Public Function gridCoordinate(ByRef pixelPos As Integer) As Integer
        Dim position As Integer
        position = -1
        If fBoard.SquareSize > 0 Then
            position = pixelPos \ fBoard.SquareSize
        End If
        Return position
    End Function

    Public Function move(ByRef pixelX As Integer, ByRef pixelY As Integer) As Boolean
        Dim gridX As Integer
        Dim gridY As Integer
        Dim result As Boolean
        result = False
        If Running Then
            gridX = gridCoordinate(pixelX)
            gridY = gridCoordinate(pixelY)
            result = fBoard.canMoveTo(gridX, gridY)
            If result Then
                If IsFirstMove Then
                    fKnight = New Knight(gridX, gridY)
                    fIsFirstMove = False
                Else
                    result = fKnight.move(gridX, gridY)
                End If
                If result Then
                    fBoard.visit(gridX, gridY)
                    fSquaresLeft = fSquaresLeft - 1
                    If fSquaresLeft = 0 Then
                        fRunning = False
                    End If
                End If
            End If
        End If
        Return result
    End Function
End Class
