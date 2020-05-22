Imports Microsoft.VisualBasic

Public Class Class1
    Sub limpiarTexto(ByVal formulario As Form)
        Dim Text As Object
        For Each Text In formulario.Controls
            If TypeOf Text Is TextBox Then
                Dim txtTempo As TextBox = CType(Text, TextBox)
                txtTempo.Text = ""
            End If
        Next
    End Sub
End Class
