Public Class Board
    Private fSquares(7, 7) As Boolean
    Private fSize As Integer
    Private fSquareSize As Integer

    Public ReadOnly Property Size As Integer
        Get
            Return fSize
        End Get
    End Property

    Public ReadOnly Property SquareSize As Integer
        Get
            Return fSquareSize
        End Get
    End Property

    Public Sub New()
        'Preconditions: none
        'Postconditions: A board has been created with Size set to 5,
        'SquareSize set to 0 and all squares recorded as not visited.
        fSize = 5
        fSquareSize = 0
        For gridX As Integer = 0 To 7
            For gridY As Integer = 0 To 7
                fSquares(gridX, gridY) = False
            Next
        Next
    End Sub

    Public Sub New(ByVal initSize As Integer)
        'Preconditions: initSize lies between 3 and 8 inclusive.
        'Postconditions: A board has been created with Size set to initSize,
        'SquareSize set to 0 and all squares recorded as not visited.
        fSize = initSize
        fSquareSize = 0
        For gridX As Integer = 0 To 7
            For gridY As Integer = 0 To 7
                fSquares(gridX, gridY) = False
            Next
        Next
    End Sub

    Public Sub visit(ByVal boardX As Integer, ByVal boardY As Integer)
        'Preconditions: The square (boardX, boardY) lies within the board.
        'Postconditions: The square (boardX, boardY) is recorded as having been visited.
        fSquares(boardX, boardY) = True
    End Sub

    Public Function beenVisited(ByVal boardX As Integer, ByVal boardY As Integer) As Boolean
        'Preconditions: The square (boardX, boardY) lies within the board.
        'Postconditions: True is returned if (boardX, boardY) has been visited.
        'Otherwise False is returned.
        Return fSquares(boardX, boardY)
    End Function

    Public Function canMoveTo(ByVal gridX As Integer, ByVal gridY As Integer) As Boolean
        'Preconditions: none
        'Postconditions: True is returned if the square (gridX, gridY) lies within
        'the board and has not yet been visited. Otherwise False is returned.
        Dim result As Boolean
        result = False
        If (gridX >= 0) And (gridX < Size) And (gridY >= 0) And (gridY < Size) Then
            result = Not beenVisited(gridX, gridY)
        End If
        Return result
    End Function

    Public Sub drawState(ByVal g As Graphics, ByVal r As Rectangle)
        If r.Width < r.Height Then
            fSquareSize = (r.Width - 1) \ Size
        Else
            fSquareSize = (r.Height - 1) \ Size
        End If
        For boardX As Integer = 0 To Size - 1
            For boardY As Integer = 0 To Size - 1
                If beenVisited(boardX, boardY) Then
                    g.FillRectangle(Brushes.DarkGray, boardX * SquareSize, boardY * SquareSize, SquareSize, SquareSize)
                Else
                    g.FillRectangle(Brushes.LightGray, boardX * SquareSize, boardY * SquareSize, SquareSize, SquareSize)
                End If
                g.DrawRectangle(Pens.Black, boardX * SquareSize, boardY * SquareSize, SquareSize, SquareSize)
            Next
        Next
    End Sub
End Class
