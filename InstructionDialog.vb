Imports System.Windows.Forms

Public Class InstructionDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub InstructionDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' The file to be loaded is plain text, so we have to specify the type.
        instructTextBox.LoadFile("Instructions.txt", RichTextBoxStreamType.PlainText)
    End Sub
End Class
