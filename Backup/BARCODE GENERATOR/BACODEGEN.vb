Imports System
Imports System.Data
Imports System.Data.SqlClient


Public Class BACODEGEN


    Dim str As String
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim rd As SqlDataReader
    Dim str2 As String

    Private Sub BACODEGEN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

       
    End Sub

    Private Sub TXT1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT1.TextChanged

        If TXT1.Text.Length = 11 Then
            TXTP.Focus()

        End If
    End Sub

    Private Sub GENERATEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GENERATEToolStripMenuItem.Click
        generatedbarcode.Show()
    End Sub

    Private Sub BTNsave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNsave.Click



        If TXT1.Text = "" Then
            MsgBox("You Must Enter 11 digits character", MsgBoxStyle.Critical)
            TXT1.Focus()
        ElseIf TXTP.Text = "" Then
            MsgBox("You must input the price", MsgBoxStyle.Critical)
            TXTP.Focus()
        ElseIf IsNumeric(TXTP.Text) = False Then
            MsgBox("Only numbers are allowed", MsgBoxStyle.Critical)
            TXTP.Clear()
            TXTP.Focus()



        Else


            str = "server=COVEBABA\COVE;database=barcodedb;uid=sa;pwd=cove1"
            con = New SqlConnection(str)
            con.Open()
            str2 = "select barcode from barcodetb where barcode='" & TXT1.Text & "'"
            cmd = New SqlCommand(str2, con)
            rd = cmd.ExecuteReader
            If rd.Read = True Then
                MsgBox("Record already exist, duplicate not allowed")
                TXT1.Clear()
                TXT1.Focus()
            Else

                rd.Close()


                str = "server=COVEBABA\COVE;database=barcodedb;uid=sa;pwd=cove1"
                con = New SqlConnection(str)
                con.Open()


                str2 = "insert into barcodetb values ( @barcode, @price)"
                cmd = New SqlCommand(str2, con)
                cmd.Parameters.Add("@barcode", SqlDbType.VarChar).Value = TXT1.Text
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = TXTP.Text
                cmd.ExecuteNonQuery()
                MsgBox("Record Saved Successfully", MsgBoxStyle.Information)
                Dim L As String
                L = MsgBox("Do you want to Print this Barcode now?", MsgBoxStyle.Question + MsgBoxStyle.YesNo)
                If L = MsgBoxResult.Yes Then
                    Printbarcode.Show()
                End If
                con.Close()
            End If
        End If



    End Sub

    Private Sub TXTP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTP.TextChanged
        If TXTP.Text.Length = 6 Then
            BTNsave.Focus()
        End If
      
    End Sub

    Private Sub BTNCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCLEAR.Click
        TXT1.Clear()
        TXTP.Clear()
    End Sub

    Private Sub EXITToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXITToolStripMenuItem.Click
        Dim K As String
        K = MsgBox("Are you sure to exit this Application?", MsgBoxStyle.Question + MsgBoxStyle.YesNo)
        If K = MsgBoxResult.Yes Then
            Me.Close()
             End If
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class