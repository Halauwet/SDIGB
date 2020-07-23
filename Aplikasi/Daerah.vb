Imports System.Data
Imports MySql.Data.MySqlClient
'Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Public Class FormDaerah
    Dim ids As String
    Dim daerah As String
    Dim lintang, bujur As Double
    Dim barat, timur, utara, selatan As Double
    Dim i As Integer
    Dim tbDaerah As New DataTable
#Region "DATA DAERAH"
    Sub DataDaerah()
        KoneksiBasisData()
        Dim dtAdapter As New MySqlDataAdapter
        Try
            koneksi.Open()
            dtSetDaerah = New DataSet
            sql = "select * from tdaerah"
            dtAdapter.SelectCommand = New MySqlCommand(sql, koneksi)
            dtAdapter.Fill(dtSetDaerah, "tDaerah")
            PosisiRecord = 0
            koneksi.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub exportDaerah()
        Dim dtAdapter As New MySqlDataAdapter
        Try
            koneksi.Open()
            sql = "select * from tdaerah"
            dtAdapter.SelectCommand = New MySqlCommand(sql, koneksi)
            dtAdapter.Fill(tbDaerah)
            PosisiRecord = 0
            koneksi.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ListDaerah()
        Try
            lblID.Text = Format(dtSetDaerah.Tables("tDaerah").Rows(PosisiRecord)("ID"), "0000")
            txtDaerah.Text = dtSetDaerah.Tables("tDaerah").Rows(PosisiRecord)("Daerah")
            txtLintang.Text = dtSetDaerah.Tables("tDaerah").Rows(PosisiRecord)("Lintang")
            txtBujur.Text = dtSetDaerah.Tables("tDaerah").Rows(PosisiRecord)("Bujur")
            txtBarat.Text = dtSetDaerah.Tables("tDaerah").Rows(PosisiRecord)("AreaBarat")
            txtTimur.Text = dtSetDaerah.Tables("tDaerah").Rows(PosisiRecord)("AreaTimur")
            txtUtara.Text = dtSetDaerah.Tables("tDaerah").Rows(PosisiRecord)("AreaUtara")
            txtSelatan.Text = dtSetDaerah.Tables("tDaerah").Rows(PosisiRecord)("AreaSelatan")
            'lblRecno.Text = "Record No. " + (PosisiRecord + 1).ToString() + " of " + dtSetDaerah.Tables("tDaerah").Rows.Count.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Columnheader()
        Dim col1, col2, col3, col4, col5, col6, col7, col8 As New ColumnHeader
        With col1
            .Text = "ID"
            .TextAlign = HorizontalAlignment.Right
            .Width = 65
        End With
        With col2
            .Text = "Daerah Kota/Kabupaten"
            .Width = 170
        End With
        With col3
            .Text = "Lintang"
            .Width = 80
        End With
        With col4
            .Text = "Bujur"
            .Width = 80
        End With
        With col5
            .Text = "Batas Barat"
            .Width = 80
        End With
        With col6
            .Text = "Batas Timur"
            .Width = 80
        End With
        With col7
            .Text = "Batas Utara"
            .Width = 80
        End With
        With col8
            .Text = "Batas Selatan"
            .Width = 90
        End With
        With lvwDaerah
            .Columns.Add(col1)
            .Columns.Add(col2)
            .Columns.Add(col3)
            .Columns.Add(col4)
            .Columns.Add(col5)
            .Columns.Add(col6)
            .Columns.Add(col7)
            .Columns.Add(col8)
            .View = View.Details
        End With
    End Sub
    Sub BuatKodeDaerah()
        Dim kodeDaerah As String
        Try
            If dtSetDaerah.Tables("tDaerah").Rows.Count = 0 Then
                lblID.Text = Format(1, "0000")
            Else
                PosisiRecord = dtSetDaerah.Tables("tDaerah").Rows.Count - 1
                kodeDaerah = dtSetDaerah.Tables("tDaerah").Rows(PosisiRecord)("ID")
                lblID.Text = Format(Val(kodeDaerah) + 1, "0000")
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
            lst = lvw.Items.Add(Format(row(0), "0000"))
            For i As Integer = 1 To data.Columns.Count - 1
                If i = 2 Then
                    lst.SubItems.Add(Format(row(2), "00.000"))
                ElseIf i = 3 Then
                    lst.SubItems.Add(Format(row(3), "000.000"))
                ElseIf i = 4 Then
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
        daerah = txtDaerah.Text
        lintang = Val(txtLintang.Text)
        bujur = Val(txtBujur.Text)
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
#Region "STORE PROCEDURE"
    Sub TambahDaerah(ByVal tambah As String)
        'Me.GetVal()
        Try
            koneksi.Open()
            cmd = New mySqlCommand()
            With cmd
                .Connection = koneksi
                .CommandType = CommandType.StoredProcedure
                .CommandText = tambah
                .Parameters.AddWithValue("@id", ids)
                .Parameters.AddWithValue("@daerah", daerah)
                .Parameters.AddWithValue("@lintang", lintang)
                .Parameters.AddWithValue("@bujur", bujur)
                .ExecuteNonQuery()
            End With
            MsgBox("Daerah " & daerah & " berhasil ditambahkan")
            koneksi.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Perhatian")
        End Try
    End Sub
    Sub UpdateDaerah(ByVal update As String)
        'Me.GetVal()
        Try
            koneksi.Open()
            cmd = New MySqlCommand()
            With cmd
                .Connection = koneksi
                .CommandType = CommandType.StoredProcedure
                .CommandText = update
                .Parameters.AddWithValue("@id", ids)
                .Parameters.AddWithValue("@daerah", daerah)
                .Parameters.AddWithValue("@lintang", lintang)
                .Parameters.AddWithValue("@bujur", bujur)
                .ExecuteNonQuery()
            End With
            MsgBox("Daerah " & daerah & " berhasil diupdate")
            koneksi.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Perhatian")
        End Try
    End Sub
    Sub HapusDaerah(ByVal hapus As String)
        'Me.GetVal()
        Try
            koneksi.Open()
            cmd = New MySqlCommand()
            With cmd
                .Connection = koneksi
                .CommandType = CommandType.StoredProcedure
                .CommandText = hapus
                .Parameters.AddWithValue("@id", ids)
                .ExecuteNonQuery()
            End With
            MsgBox("Daerah " & daerah & " berhasil dihapus")
            koneksi.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Perhatian")
        End Try
    End Sub
#End Region
#Region "METHODS & EVENTS"
    Private Sub Daerah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        i = 1
        TextboxEnable3(False)
        Navigasi3(True)
        If dtSetDaerah.Tables("tDaerah").Rows.Count > 0 Then
            Showlvw(dtSetDaerah.Tables("tDaerah"), lvwDaerah) 'ListDaerah()
        End If
        btAdd.Focus()
        btExport.BringToFront()
        'btAdd.Focus()
    End Sub
    Private Sub lvwDaerah_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwDaerah.SelectedIndexChanged
        If lvwDaerah.SelectedItems.Count > 0 Then
            TextboxEnable3(False)
            Navigasi3(True)
            Dim lvi As ListViewItem = lvwDaerah.SelectedItems(0)
            lblID.Text = lvi.SubItems(0).Text
            txtDaerah.Text = lvi.SubItems(1).Text
            txtLintang.Text = lvi.SubItems(2).Text
            txtBujur.Text = lvi.SubItems(3).Text
            txtBarat.Text = lvi.SubItems(4).Text
            txtTimur.Text = lvi.SubItems(5).Text
            txtUtara.Text = lvi.SubItems(6).Text
            txtSelatan.Text = lvi.SubItems(7).Text
            btEdit.BringToFront()
            btEdit.Focus()
        End If
    End Sub
    Private Sub btAdd_Click(sender As Object, e As EventArgs) Handles btAdd.Click
        If i = 1 Then
            DataDaerah()
        End If
        i += 1
        TextboxEnable3(True)
        Navigasi3(False)
        LayarBersih3()
        BuatKodeDaerah()
        txtDaerah.Focus()
    End Sub
    Private Sub btEdit_Click(sender As Object, e As EventArgs) Handles btEdit.Click
        If lvwDaerah.SelectedItems.Count > 0 Then
            Dim lvi As ListViewItem = lvwDaerah.SelectedItems(0)
            lblID.Text = lvi.SubItems(0).Text
            txtDaerah.Text = lvi.SubItems(1).Text
            txtLintang.Text = lvi.SubItems(2).Text
            txtBujur.Text = lvi.SubItems(3).Text
            txtBarat.Text = lvi.SubItems(4).Text
            txtTimur.Text = lvi.SubItems(5).Text
            txtUtara.Text = lvi.SubItems(6).Text
            txtSelatan.Text = lvi.SubItems(7).Text
            TextboxEnable3(True)
            Navigasi3(False)
            txtDaerah.Focus()
            txtDaerah.SelectAll()
            btSave.Text = "&Update"
            btSave.BringToFront()
        End If
    End Sub
    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        If String.IsNullOrWhiteSpace(txtDaerah.Text) Then
            MsgBox("Harap memasukan Nama Daerah", MsgBoxStyle.OkOnly, "Perhatian")
            txtDaerah.Focus()
            txtDaerah.SelectAll()
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtLintang.Text) Then
            MsgBox("Data Koordinat belum lengkap", MsgBoxStyle.OkOnly, "Perhatian")
            txtLintang.Focus()
            txtLintang.SelectAll()
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtBujur.Text) Then
            MsgBox("Data Koordinat belum lengkap", MsgBoxStyle.OkOnly, "Perhatian")
            txtBujur.Focus()
            txtBujur.SelectAll()
            Exit Sub
        ElseIf Val(txtLintang.Text) > 11 Or Val(txtLintang.Text) < -11 Then
            MsgBox("Lintang diluar wilayah Indonesia!", MsgBoxStyle.OkOnly, "Perhatian")
            txtLintang.Focus()
            txtLintang.SelectAll()
            Exit Sub
        ElseIf Val(txtBujur.Text) > 146 Or Val(txtBujur.Text) < 90 Then
            MsgBox("Bujur diluar wilayah Indonesia!", MsgBoxStyle.OkOnly, "Perhatian")
            txtBujur.Focus()
            txtLintang.SelectAll()
            Exit Sub
        End If
        GetVal()
        If btSave.Text = "&Save" Then
            modFungsi.simpandaerah(vid:=ids, vdaerah:=daerah, vlintang:=lintang, vbujur:=bujur, vbarat:=barat, vtimur:=timur, vutara:=utara, vselatan:=selatan)
            'Me.TambahDaerah("daerahSAVE")
        ElseIf btSave.Text = "&Update" Then
            modFungsi.updatedaerah(vid:=ids, vdaerah:=daerah, vlintang:=lintang, vbujur:=bujur, vbarat:=barat, vtimur:=timur, vutara:=utara, vselatan:=selatan)
            'Me.UpdateDaerah("daerahUPDATE")
            btSave.Text = "&Save"
        End If
        Navigasi3(True)
        TextboxEnable3(False)
        btAdd.Focus()
        DataDaerah()
        Showlvw(dtSetDaerah.Tables("tDaerah"), lvwDaerah)
        LayarBersih3()
    End Sub
    Private Sub btDelete_Click(sender As Object, e As EventArgs) Handles btDelete.Click
        If lvwDaerah.SelectedItems.Count > 0 Then
            Select Case MsgBox("Hapus Data Daerah " & txtDaerah.Text & "?", MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    GetVal()
                    modFungsi.hapusdaerah(vid:=ids)
                    'HapusDaerah("daerahDELETE")
            End Select
            Navigasi3(True)
            TextboxEnable3(False)
            btExit.Focus()
            DataDaerah()
            Showlvw(dtSetDaerah.Tables("tDaerah"), lvwDaerah)
            LayarBersih3()
        End If
    End Sub
    Private Sub btCancel_Click(sender As Object, e As EventArgs) Handles btCancel.Click
        TextboxEnable3(False)
        Navigasi3(True)
        btExit.Focus()
        btSave.Text = "&Save"
        If dtSetDaerah.Tables("tDaerah").Rows.Count > 0 Then
            Showlvw(dtSetDaerah.Tables("tDaerah"), lvwDaerah) 'ListDaerah()
        End If
        LayarBersih3()
    End Sub
    Private Sub btExit_Click(sender As Object, e As EventArgs) Handles btExit.Click
        btSave.Text = "&Save"
        i = 1
        Close()
    End Sub
    Private Sub txtBujur_LostFocus(sender As Object, e As EventArgs) Handles txtBujur.Leave
        'btSave.Focus()
    End Sub
    Private Sub btExport_Click(sender As Object, e As EventArgs) Handles btExport.Click
        SaveDaerah.ShowDialog()
        SaveDaerah.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    End Sub
    Private Sub SaveDaerah_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveDaerah.FileOk
        Dim SaveFile As String = SaveDaerah.FileName
        exportDaerah()
        Export(SaveFile, tbDaerah)
        Process.Start(SaveFile)
    End Sub
#End Region
#Region "VALIDASI"
    Dim mytooltip As New ToolTip
    Private Sub txtLintang_Enter(sender As Object, e As EventArgs) Handles txtLintang.Enter
        mytooltip.Show("For south latitude use minus sign ("" - "")", txtLintang)
    End Sub
    Private Sub txtLintang_Leave(sender As Object, e As EventArgs) Handles txtLintang.Leave
        mytooltip.Hide(txtLintang)
    End Sub
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
    Private Sub txtLintang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLintang.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtBujur_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBujur.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
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
    Private Sub txtDaerah_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDaerah.Validating
        If Not String.IsNullOrWhiteSpace(txtDaerah.Text) Then
            daerah = txtDaerah.Text
            'Me.txtDaerah.Text = StrConv(daerah, VbStrConv.LinguisticCasing)
        End If
    End Sub
    Private Sub txtLintang_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtLintang.Validating
        If Not String.IsNullOrWhiteSpace(txtLintang.Text) Then
            lintang = Val(txtLintang.Text)
            txtLintang.Text = Format(lintang, "00.000")
        End If
    End Sub
    Private Sub txtBujur_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtBujur.Validating
        If Not String.IsNullOrWhiteSpace(txtBujur.Text) Then
            bujur = Val(txtBujur.Text)
            txtBujur.Text = Format(bujur, "000.000")
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