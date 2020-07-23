Public Class FormAbout
    Private Sub FormAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TopMost = True
        TextBoxDescription.BringToFront()
    End Sub
    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles btOK.Click
        Close()
    End Sub
End Class