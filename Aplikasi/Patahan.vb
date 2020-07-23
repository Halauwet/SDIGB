Imports System.Data
Imports MySql.Data.MySqlClient
'Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Public Class FormPatahan
    Dim ids As String
    Dim patahan As String
    Dim deskripsi, mekanisme, sumber As String
    Dim barat, timur, utara, selatan As Double
    Dim i As Integer
    Dim tbPatahan As New DataTable
#Region "DATA PATAHAN"
    Sub DataPatahan()
        KoneksiBasisData()
        Dim dtAdapter As New MySqlDataAdapter
        Try
            koneksi.Open()
            dtSetPatahan = New DataSet
            sql = "select * from tpatahan"
            dtAdapter.SelectCommand = New MySqlCommand(sql, koneksi)
            dtAdapter.Fill(dtSetPatahan, "tPatahan")
            PosisiRecord = 0
            koneksi.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub exportPatahan()
        Dim dtAdapter As New MySqlDataAdapter
        Try
            koneksi.Open()
            sql = "select * from tpatahan"
            dtAdapter.SelectCommand = New MySqlCommand(sql, koneksi)
            dtAdapter.Fill(tbPatahan)
            PosisiRecord = 0
            koneksi.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ListPatahan()
        PosisiRecord = 0
        Try
            lblID.Text = Format(dtSetPatahan.Tables("tPatahan").Rows(PosisiRecord)("ID"), "0000")
            txtPatahan.Text = dtSetPatahan.Tables("tPatahan").Rows(PosisiRecord)("Patahan")
            txtDeskripsi.Text = dtSetPatahan.Tables("tPatahan").Rows(PosisiRecord)("Deskripsi")
            cbMekanisme.Text = dtSetPatahan.Tables("tPatahan").Rows(PosisiRecord)("Mekanisme")
            txtBarat.Text = dtSetPatahan.Tables("tPatahan").Rows(PosisiRecord)("AreaBarat")
            txtTimur.Text = dtSetPatahan.Tables("tPatahan").Rows(PosisiRecord)("AreaTimur")
            txtUtara.Text = dtSetPatahan.Tables("tPatahan").Rows(PosisiRecord)("AreaUtara")
            txtSelatan.Text = dtSetPatahan.Tables("tPatahan").Rows(PosisiRecord)("AreaSelatan")
            txtSumberdata.Text = dtSetPatahan.Tables("tPatahan").Rows(PosisiRecord)("Sumber Data")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Columnheader()
        Dim col1, col2, col3, col4, col5, col6, col7, col8, col9 As New ColumnHeader
        With col1
            .Text = "ID"
            .TextAlign = HorizontalAlignment.Right
            .Width = 45
        End With
        With col2
            .Text = "Nama Patahan"
            .Width = 120
        End With
        With col3
            .Text = "Deskripsi"
            .Width = 320
        End With
        With col4
            .Text = "Mekanisme"
            .Width = 85
        End With
        With col5
            .Text = "Barat"
            .Width = 60
        End With
        With col6
            .Text = "Timur"
            .Width = 60
        End With
        With col7
            .Text = "Utara"
            .Width = 60
        End With
        With col8
            .Text = "Selatan"
            .Width = 60
        End With
        With col9
            .Text = "Sumber Data"
            .Width = 100
        End With
        With lvwPatahan
            .Columns.Add(col1)
            .Columns.Add(col2)
            .Columns.Add(col3)
            .Columns.Add(col4)
            .Columns.Add(col5)
            .Columns.Add(col6)
            .Columns.Add(col7)
            .Columns.Add(col8)
            .Columns.Add(col9)
            .View = View.Details
        End With
    End Sub
    Sub BuatKodePatahan()
        Dim kodePatahan As String
        Try
            If dtSetPatahan.Tables("tPatahan").Rows.Count = 0 Then
                lblID.Text = Format(1, "0000")
            Else
                PosisiRecord = dtSetPatahan.Tables("tPatahan").Rows.Count - 1
                kodePatahan = dtSetPatahan.Tables("tPatahan").Rows(PosisiRecord)("ID")
                lblID.Text = Format(Val(kodePatahan) + 1, "0000")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub Showlvw(ByVal data As DataTable, ByVal lvw As ListView)
        lvw.GridLines = True
        lvw.Columns.Clear()
        lvw.Items.Clear()
        Columnheader()
        'For Each col As DataColumn In data.Columns       'lvw.Columns.Add(col.ToString, col.MaxLength)       'Next
        For Each row As DataRow In data.Rows
            Dim lst As ListViewItem
            lst = lvw.Items.Add(Format(Val(row(0)), "0000"))
            For i As Integer = 1 To data.Columns.Count - 1
                If i = 4 Then
                    If Not IsDBNull(row(4)) Then
                        lst.SubItems.Add(Format(row(4), "000.000"))
                    End If
                ElseIf i = 5 Then
                    If Not IsDBNull(row(5)) Then
                        lst.SubItems.Add(Format(row(5), "000.000"))
                    End If
                ElseIf i = 6 Then
                    If Not IsDBNull(row(6)) Then
                        lst.SubItems.Add(Format(row(6), "00.000"))
                    End If
                ElseIf i = 7 Then
                    If Not IsDBNull(row(7)) Then
                        lst.SubItems.Add(Format(row(7), "00.000"))
                    End If
                Else
                    lst.SubItems.Add(row(i).ToString)
                End If
            Next
        Next
    End Sub
    Sub GetVal()
        ids = lblID.Text
        patahan = txtPatahan.Text
        deskripsi = txtDeskripsi.Text
        If cbMekanisme.Text = "-- pilih --" Or String.IsNullOrWhiteSpace(cbMekanisme.Text) Then
            mekanisme = ""
        Else
            mekanisme = cbMekanisme.Text
        End If
        sumber = txtSumberdata.Text
        If String.IsNullOrWhiteSpace(txtBarat.Text) Then
            barat = 0
        Else
            barat = Val(txtBarat.Text)
        End If
        If String.IsNullOrWhiteSpace(txtTimur.Text) Then
            timur = 0
        Else
            timur = Val(txtTimur.Text)
        End If
        If String.IsNullOrWhiteSpace(txtUtara.Text) Then
            utara = 0
        Else
            utara = Val(txtUtara.Text)
        End If
        If String.IsNullOrWhiteSpace(txtSelatan.Text) Then
            selatan = 0
        Else
            selatan = Val(txtSelatan.Text)
        End If
    End Sub
    Sub Export(ByVal filepath As String, ByVal table As DataTable)
        Dim output As New StreamWriter(filepath, False, UnicodeEncoding.Default)
        Dim delim As String
        delim = ""
        For Each col As DataColumn In table.Columns
            output.Write(delim)
            output.Write(col.ColumnName)
            delim = ","
        Next
        output.WriteLine()
        For Each row As DataRow In table.Rows
            delim = ""
            For Each value As Object In row.ItemArray
                output.Write(delim)
                If TypeOf value Is String Then
                    output.Write(""""c) ' thats four double quotes and a c
                    output.Write(value)
                    output.Write(""""c) ' thats four double quotes and a c
                Else
                    output.Write(value)
                End If
                delim = ","
            Next
            output.WriteLine()
        Next
        output.Close()
    End Sub
#End Region
#Region "METHODS & EVENTS"
    Private Sub Patahan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        i = 1
        TextboxEnable6(False)
        Navigasi6(True)
        If dtSetPatahan.Tables("tPatahan").Rows.Count > 0 Then
            Showlvw(dtSetPatahan.Tables("tPatahan"), lvwPatahan)
        End If
        btAdd.Focus()
        btExport.BringToFront()
        'btAdd.Focus()
    End Sub
    Private Sub lvwPatahan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwPatahan.SelectedIndexChanged
        If lvwPatahan.SelectedItems.Count > 0 Then
            TextboxEnable6(False)
            Navigasi6(True)
            Dim lvi As ListViewItem = lvwPatahan.SelectedItems(0)
            lblID.Text = lvi.SubItems(0).Text
            txtPatahan.Text = lvi.SubItems(1).Text
            txtDeskripsi.Text = lvi.SubItems(2).Text
            cbMekanisme.Text = lvi.SubItems(3).Text
            txtBarat.Text = lvi.SubItems(4).Text
            txtTimur.Text = lvi.SubItems(5).Text
            txtUtara.Text = lvi.SubItems(6).Text
            txtSelatan.Text = lvi.SubItems(7).Text
            txtSumberdata.Text = lvi.SubItems(8).Text
            btEdit.BringToFront()
            btEdit.Focus()
        End If
    End Sub
    Private Sub btAdd_Click(sender As Object, e As EventArgs) Handles btAdd.Click
        If i = 1 Then
            DataPatahan()
        End If
        i += 1
        TextboxEnable6(True)
        Navigasi6(False)
        LayarBersih6()
        BuatKodePatahan()
        txtPatahan.Focus()
    End Sub
    Private Sub btEdit_Click(sender As Object, e As EventArgs) Handles btEdit.Click
        If lvwPatahan.SelectedItems.Count > 0 Then
            Dim lvi As ListViewItem = lvwPatahan.SelectedItems(0)
            lblID.Text = lvi.SubItems(0).Text
            txtPatahan.Text = lvi.SubItems(1).Text
            txtDeskripsi.Text = lvi.SubItems(2).Text
            cbMekanisme.Text = lvi.SubItems(3).Text
            txtBarat.Text = lvi.SubItems(4).Text
            txtTimur.Text = lvi.SubItems(5).Text
            txtUtara.Text = lvi.SubItems(6).Text
            txtSelatan.Text = lvi.SubItems(7).Text
            txtSumberdata.Text = lvi.SubItems(8).Text
            TextboxEnable6(True)
            Navigasi6(False)
            txtPatahan.Focus()
            txtPatahan.SelectAll()
            btSave.Text = "&Update"
            btSave.BringToFront()
        End If
    End Sub
    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        If String.IsNullOrWhiteSpace(txtPatahan.Text) Then
            MsgBox("Harap memasukan Nama Patahan", MsgBoxStyle.OkOnly, "Perhatian")
            txtPatahan.Focus()
            txtPatahan.SelectAll()
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtDeskripsi.Text) Then
            'MsgBox("Harap memasukan deskripsi patahan", MsgBoxStyle.OkOnly, "Perhatian")
            'txtDeskripsi.Focus()
            'txtDeskripsi.SelectAll()
            'Exit Sub
        ElseIf String.IsNullOrWhiteSpace(cbMekanisme.Text) Or cbMekanisme.Text = "-- pilih --" Then
            'MsgBox("Harap memasukan mekanisme patahan", MsgBoxStyle.OkOnly, "Perhatian")
            'cbMekanisme.Focus()
            'cbMekanisme.SelectAll()
            'Exit Sub
        End If
        GetVal()
        If btSave.Text = "&Save" Then
            modFungsi.simpanpatahan(vid:=ids, vpatahan:=patahan, vdeskripsi:=deskripsi, vmekanisme:=mekanisme, vbarat:=barat, vtimur:=timur, vutara:=utara, vselatan:=selatan, vsumber:=sumber)
        ElseIf btSave.Text = "&Update" Then
            modFungsi.updatepatahan(vid:=ids, vpatahan:=patahan, vdeskripsi:=deskripsi, vmekanisme:=mekanisme, vbarat:=barat, vtimur:=timur, vutara:=utara, vselatan:=selatan, vsumber:=sumber)
            btSave.Text = "&Save"
        End If
        Navigasi6(True)
        TextboxEnable6(False)
        btAdd.Focus()
        DataPatahan()
        Showlvw(dtSetPatahan.Tables("tPatahan"), lvwPatahan)
        LayarBersih6()
    End Sub
    Private Sub btDelete_Click(sender As Object, e As EventArgs) Handles btDelete.Click
        If lvwPatahan.SelectedItems.Count > 0 Then
            Select Case MsgBox("Hapus Data Patahan " & txtPatahan.Text & "?", MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    GetVal()
                    modFungsi.hapuspatahan(vid:=ids)
            End Select
            Navigasi6(True)
            TextboxEnable6(False)
            btExit.Focus()
            DataPatahan()
            Showlvw(dtSetPatahan.Tables("tPatahan"), lvwPatahan)
            LayarBersih6()
        End If
    End Sub
    Private Sub btCancel_Click(sender As Object, e As EventArgs) Handles btCancel.Click
        TextboxEnable6(False)
        Navigasi6(True)
        btExit.Focus()
        btSave.Text = "&Save"
        If dtSetPatahan.Tables("tPatahan").Rows.Count > 0 Then
            Showlvw(dtSetPatahan.Tables("tPatahan"), lvwPatahan)
        End If
        LayarBersih6()
    End Sub
    Private Sub btExit_Click(sender As Object, e As EventArgs) Handles btExit.Click
        btSave.Text = "&Save"
        i = 1
        Close()
    End Sub
    Private Sub txtSelatan_LostFocus(sender As Object, e As EventArgs) Handles txtSelatan.LostFocus
        btSave.Focus()
    End Sub
    Private Sub btExport_Click(sender As Object, e As EventArgs) Handles btExport.Click
        SavePatahan.ShowDialog()
        SavePatahan.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    End Sub
    Private Sub SavePatahan_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SavePatahan.FileOk
        Dim SaveFile As String = SavePatahan.FileName
        exportPatahan()
        Export(SaveFile, tbPatahan)
        Process.Start(SaveFile)
    End Sub
#End Region
#Region "VALIDASI"
    Dim mytooltip As New ToolTip
    Private Sub txtUtara_Enter(sender As Object, e As EventArgs) Handles txtUtara.Enter
        mytooltip.Show("For south latitude use minus sign ("" - "")", txtUtara)
    End Sub
    Private Sub txtUtara_Leave(sender As Object, e As EventArgs) Handles txtUtara.Leave
        mytooltip.Hide(txtUtara)
    End Sub
    Private Sub txtSelatan_Enter(sender As Object, e As EventArgs) Handles txtSelatan.Enter
        mytooltip.Show("For south latitude use minus sign ("" - "")", txtSelatan)
    End Sub
    Private Sub txtSelatan_Leave(sender As Object, e As EventArgs) Handles txtSelatan.Leave
        mytooltip.Hide(txtSelatan)
        btSave.Focus()
    End Sub
    Private Sub txtBarat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarat.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtTimur_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTimur.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtUtara_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUtara.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtSelatan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSelatan.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtPatahan_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPatahan.Validating
        If Not String.IsNullOrWhiteSpace(txtPatahan.Text) Then
            patahan = txtPatahan.Text
        End If
    End Sub
    Private Sub txtBarat_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtBarat.Validating
        If String.IsNullOrWhiteSpace(txtBarat.Text) Then
            barat = 0
        Else
            barat = Val(txtBarat.Text)
            txtBarat.Text = Format(barat, "000.000")
        End If
    End Sub
    Private Sub txtTimur_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtTimur.Validating
        If String.IsNullOrWhiteSpace(txtTimur.Text) Then
            timur = 0
        Else
            timur = Val(txtTimur.Text)
            txtTimur.Text = Format(timur, "000.000")
        End If
    End Sub
    Private Sub txtUtara_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtUtara.Validating
        If String.IsNullOrWhiteSpace(txtUtara.Text) Then
            utara = 0
        Else
            utara = Val(txtUtara.Text)
            txtUtara.Text = Format(utara, "00.000")
        End If
    End Sub
    Private Sub txtSelatan_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtSelatan.Validating
        If String.IsNullOrWhiteSpace(txtSelatan.Text) Then
            selatan = 0
        Else
            selatan = Val(txtSelatan.Text)
            txtSelatan.Text = Format(selatan, "00.000")
        End If
    End Sub
#End Region
End Class