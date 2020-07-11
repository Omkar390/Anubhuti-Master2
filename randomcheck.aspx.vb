
Partial Class randomcheck
	Inherits System.Web.UI.Page


    Dim alreadyPicked As List(Of Integer) = New List(Of Integer)


    Protected Sub btncheck_Click(sender As Object, e As EventArgs)
        Dim curNumber As Integer
        If (alreadyPicked.Count < 20) Then
            Dim rand As Random = New Random
            Do
                curNumber = rand.Next(1, 20)
            Loop While (alreadyPicked.Contains(curNumber))
        End If


        If (curNumber > 0 AndAlso Not alreadyPicked.Contains(curNumber)) Then
            alreadyPicked.Add(curNumber)
            lblerror.Text = "The new random number is: " & curNumber.ToString()
        Else
            lblerror.Text = "Error"
        End If

    End Sub

    Protected Sub reset_Click(sender As System.Object, e As System.EventArgs) Handles reset.Click

        alreadyPicked = New List(Of Integer)

    End Sub

End Class
