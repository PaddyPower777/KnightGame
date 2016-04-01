Imports System.Media

Public Class MainForm
    Private fGameAdmin As GameAdmin

    Public Sub New()
        fGameAdmin = New GameAdmin(5)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        boardNumUpDn.Value = 5
        updateView()
    End Sub

    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click, exitMenuItem.Click
        'The application is closed.
        Close()
    End Sub

    Private Sub InstructionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles instructionsMenuItem.Click
        ' This event handler displays a dialog box with the instructions
        ' for playing the game.
        Dim anInstructDialog As InstructionDialog
        anInstructDialog = New InstructionDialog
        anInstructDialog.ShowDialog()
        anInstructDialog.Dispose()
    End Sub

    Public Sub updateView()
        squaresTextBox.Text = fGameAdmin.SquaresLeft.ToString()
        timeTextBox.Text = fGameAdmin.TimeLeft.ToString()
        If fGameAdmin.Running Then
            gameTimer.Enabled = True
            boardPanel.Enabled = True
            startButton.Enabled = False
            boardNumUpDn.Enabled = False
            newGameButton.Enabled = True
        Else
            gameTimer.Enabled = False
            boardPanel.Enabled = False
            timeTextBox.Text = "Game Over"
            If (fGameAdmin.TimeLeft > 0 And fGameAdmin.SquaresLeft > 0) Then
                startButton.Enabled = True
                newGameButton.Enabled = False
            Else
                startButton.Enabled = False
                newGameButton.Enabled = True
            End If
            boardNumUpDn.Enabled = True
        End If
        boardPanel.Refresh()
    End Sub

    Private Sub boardPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles boardPanel.Paint
        Dim g As Graphics
        g = boardPanel.CreateGraphics()
        fGameAdmin.drawState(g, boardPanel.ClientRectangle)
        g.Dispose()
    End Sub

    Private Sub startButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startButton.Click
        fGameAdmin.start()
        updateView()
    End Sub

    Private Sub gameTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gameTimer.Tick
        fGameAdmin.decreaseTime()
        updateView()
    End Sub

    Private Sub newGameButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newGameButton.Click
        fGameAdmin = New GameAdmin(Decimal.ToInt32(boardNumUpDn.Value))
        updateView()
    End Sub

    Private Sub boardPanel_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles boardPanel.MouseClick
        Dim goodMove As Boolean
        goodMove = fGameAdmin.move(e.X, e.Y)
        If Not goodMove Then
            SystemSounds.Beep.Play()
        End If
        updateView()
    End Sub

    Private Sub boardNumUpDn_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boardNumUpDn.ValueChanged
        fGameAdmin = New GameAdmin(Decimal.ToInt32(boardNumUpDn.Value))
        updateView()
    End Sub

    Private Sub MainForm_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        boardPanel.Refresh()
    End Sub
End Class
