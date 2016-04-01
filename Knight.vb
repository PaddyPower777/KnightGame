Public Class Knight
    Private fGridX As Integer
    Private fGridY As Integer

    Public ReadOnly Property GridX As Integer
        Get
            Return fGridX
        End Get
    End Property

    Public ReadOnly Property GridY As Integer
        Get
            Return fGridY
        End Get
    End Property

    Public Sub New()
        fGridX = 0
        fGridY = 0
    End Sub

    Public Sub New(ByVal initX As Integer, ByVal initY As Integer)
        fGridX = initX
        fGridY = initY
    End Sub

    Public Function move(ByVal newX As Integer, ByVal newY As Integer) As Boolean
        'Preconditions: none
        'Postconditions: If moving to (newX,newY) constitutes a valid knight's move
        'then the knight's position is updated and True is returned. Othewise the
        'position remains unchanged and False is returned.
        'Declare local variables xMove, yMove and result.
        Dim xMove As Integer
        Dim yMove As Integer
        Dim result As Boolean
        'Initialise xMove and yMove to give the amounts of horizontal and vertical movement.
        xMove = Math.Abs(GridX - newX)
        yMove = Math.Abs(GridY - newY)
        'Assign to result a boolean that reflects whether the proposed move is valid or not.
        result = (xMove > 0) And (yMove > 0) And (xMove + yMove = 3)
        'If result is True, update the knight's position.
        If result Then
            fGridX = newX
            fGridY = newY
        End If
        'Return result.
        Return result
    End Function

    Public Sub draw(ByVal g As Graphics, ByVal s As Integer)
        g.FillEllipse(Brushes.Red, GridX * s, GridY * s, s, s)
    End Sub
End Class
