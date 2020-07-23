Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Math
Imports MySql.Data.MySqlClient
'Imports System.Data.SqlClient
Public Class FormSearch
    Dim dir As String = Application.StartupPath
    Dim suggestion As New AutoCompleteStringCollection
    Dim tbCari As New DataTable
    Dim ulat, blat, rlon, llon, magn, magx As Double
    Dim fromdate, todate, fdate, tdate As String
    Dim fromdepth, todepth As String
    Dim tipe, sufx, kota, wtrmark, kop As String
    Dim stasiun As String
    Dim jumlahgempa As Integer
    Dim kordinat As String
    Dim strbujur1, strbujur2, strlintang1, strlintang2, jmlh As String
#Region "METHODS & EVENTS"
    Private Sub Search_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'FormDaerah.DataDaerah()
        FormUtama.mnCari.BackColor = Color.Gainsboro
        For i As Integer = 0 To dtSetDaerah.Tables("tDaerah").Rows.Count - 1
            suggestion.Add(dtSetDaerah.Tables("tDaerah").Rows(i)("Daerah").ToString)
        Next
        txtDaerah.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtDaerah.AutoCompleteCustomSource = suggestion
        txtDaerah.AutoCompleteMode = AutoCompleteMode.Suggest
        lvwCari.GridLines = True
        lvwCari.Columns.Clear()
        lvwCari.Items.Clear()
        Columnheader()
        If dtSetMeta.Tables("tMetadata").Rows.Count <> 0 Then
            PosisiRecord = 0
            stasiun = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Nama Stasiun").ToString
            tipe = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Tipe Stasiun").ToString
            kota = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Kota Stasiun").ToString, VbStrConv.ProperCase)
            If tipe = "STAGEOF" Then
                tipe = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.ProperCase)
                wtrmark = "echo 5.25 0 Stasiun Geofisika " & tipe & " | pstext -J -R -F+f7p,Helvetica -N -O -Y-0.25 -K >> %ps%"
                kop = stasiun
            ElseIf tipe = "PGR"
                sufx = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                wtrmark = "echo 5.25 0 Pusat Gempa Regional " & sufx & " " & kota & " | pstext -J -R -F+f7p,Helvetica -N -O -Y-0.25 -K >> %ps%"
                kop = stasiun
            ElseIf tipe = "PUSAT"
                sufx = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString
                wtrmark = "echo 5.25 0 Pusat " & sufx & " BMKG | pstext -J -R -F+f7p,Helvetica -N -O -Y-0.25 -K >> %ps%"
                kop = ""
            ElseIf tipe = "BALAI"
                sufx = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                wtrmark = "echo 5.25 0 Balai Besar Wilayah " & sufx & " " & kota & " | pstext -J -R -F+f7p,Helvetica -N -O -Y-0.25 -K >> %ps%"
                kop = "Balai Besar Wilayah " & sufx & " " & kota
            End If
        End If
        btExport.Enabled = True
        btPlot.Enabled = True
        bt_Del.Visible = False
    End Sub
    Sub Columnheader()
        Dim col1, col2, col3, col4, col5, col6, col7, col8, col9 As New ColumnHeader
        With col1
            .Text = "Event ID"
            .TextAlign = HorizontalAlignment.Right
            .Width = 85
        End With
        With col2
            .Text = "Tanggal"
            .Width = 75
        End With
        With col3
            .Text = "Jam (UTC)"
            .Width = 63
            .TextAlign = HorizontalAlignment.Center
        End With
        With col4
            .Text = "Lintang"
            .Width = 48
            .TextAlign = HorizontalAlignment.Center
        End With
        With col5
            .Text = "Bujur"
            .Width = 48
            .TextAlign = HorizontalAlignment.Center
        End With
        With col6
            .Text = "Kedlmn (km)"
            .Width = 70
            .TextAlign = HorizontalAlignment.Center
        End With
        With col7
            .Text = "Mag"
            .Width = 35
            .TextAlign = HorizontalAlignment.Center
        End With
        With col8
            .Text = "Keterangan"
            .Width = 145
        End With
        With col9
            .Text = "Informasi"
            .Width = 160
        End With
        With lvwCari
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
    Sub ShowlvwCari(ByVal data As DataTable, ByVal lvw As ListView)
        lvw.GridLines = True
        lvw.Columns.Clear()
        lvw.Items.Clear()
        Columnheader()
        For Each row As DataRow In data.Rows
            Dim lst As New ListViewItem
            lst = lvw.Items.Add(row(0))
            For i As Integer = 1 To data.Columns.Count - 1
                If i = 1 Then
                    lst.SubItems.Add(Format(CDate(row(1).ToString), "dd-MMM-yyyy"))
                ElseIf i = 3 Then
                    lst.SubItems.Add(Format(row(3), "00.00"))
                ElseIf i = 4 Then
                    lst.SubItems.Add(Format(row(4), "000.00"))
                ElseIf i = 6 Then
                    lst.SubItems.Add(Format(row(6), "0.0"))
                Else
                    lst.SubItems.Add(row(i).ToString)
                End If
            Next
        Next
    End Sub
    Sub GetVal()
        If IsNumeric(txtLlon.Text) Then
            If txtLlon.Text < 90 Or txtLlon.Text > 146 Then
                MsgBox("Bujur diluar wilayah Indonesia!", MsgBoxStyle.OkOnly, "Perhatian")
                txtLlon.Focus()
                txtLlon.SelectAll()
                Exit Sub
            End If
            llon = txtLlon.Text
            txtLlon.Text = Format(llon, "000.00")
        End If
        If IsNumeric(txtRlon.Text) Then
            If txtRlon.Text < 90 Or txtRlon.Text > 146 Then
                MsgBox("Bujur diluar wilayah Indonesia!", MsgBoxStyle.OkOnly, "Perhatian")
                txtRlon.Focus()
                txtRlon.SelectAll()
                Exit Sub
            End If
            rlon = txtRlon.Text
            If rlon < llon Then
                txtRlon.Text = Format(llon, "000.00")
                txtLlon.Text = Format(rlon, "000.00")
                rlon = txtRlon.Text
                llon = txtLlon.Text
            End If
            txtRlon.Text = Format(rlon, "000.00")
        End If
        If IsNumeric(txtULat.Text) Then
            If txtULat.Text < -16 Or txtULat.Text > 11 Then
                MsgBox("Lintang diluar wilayah Indonesia!", MsgBoxStyle.OkOnly, "Perhatian")
                txtULat.Focus()
                txtULat.SelectAll()
                Exit Sub
            End If
            ulat = txtULat.Text
            txtULat.Text = Format(ulat, "00.00")
        End If
        If IsNumeric(txtBlat.Text) Then
            If txtBlat.Text < -16 Or txtBlat.Text > 11 Then
                MsgBox("Lintang diluar wilayah Indonesia!", MsgBoxStyle.OkOnly, "Perhatian")
                txtBlat.Focus()
                txtBlat.SelectAll()
                Exit Sub
            End If
            blat = txtBlat.Text
            If blat > ulat Then
                txtBlat.Text = Format(ulat, "00.00")
                txtULat.Text = Format(blat, "00.00")
                blat = txtBlat.Text
                ulat = txtULat.Text
            End If
            txtBlat.Text = Format(blat, "00.00")
        End If
        If String.IsNullOrWhiteSpace(txtFromDepth.Text) Then
            txtFromDepth.Text = "0"
        End If
        If String.IsNullOrWhiteSpace(txtToDepth.Text) Then
            txtToDepth.Text = "800"
        End If
        If String.IsNullOrWhiteSpace(txtMinMag.Text) Then
            txtMinMag.Text = "1.0"
        End If
        If String.IsNullOrWhiteSpace(txtMaxMag.Text) Then
            txtMaxMag.Text = "9.5"
        End If
        magn = txtMinMag.Text
        magx = txtMaxMag.Text
        If Val(txtMinMag.Text) > Val(txtMaxMag.Text) Then
            magx = txtMinMag.Text
            magn = txtMaxMag.Text
        End If
        magx = Val(magx) + 0.01
        fromdepth = txtFromDepth.Text
        todepth = txtToDepth.Text
        If Val(txtFromDepth.Text) > Val(txtToDepth.Text) Then
            fromdepth = txtToDepth.Text
            todepth = txtFromDepth.Text
        End If
    End Sub
    Sub SearchRecord()
        KoneksiBasisData()
        Dim dtAdapter As New MySqlDataAdapter
        jumlahgempa = 0
        fromdate = srcFromDate.Value.Date.ToString("yyyy/MM/dd")
        todate = srcToDate.Value.Date.ToString("yyyy/MM/dd")
        fdate = srcFromDate.Value.Date.ToString("dd/MM/yyyy")
        tdate = srcToDate.Value.Date.ToString("dd/MM/yyyy")
        If srcFromDate.Value > srcToDate.Value Then
            fromdate = srcToDate.Value.Date.ToString("yyyy/MM/dd")
            todate = srcFromDate.Value.Date.ToString("yyyy/MM/dd")
            fdate = srcToDate.Value.Date.ToString("dd/MM/yyyy")
            tdate = srcFromDate.Value.Date.ToString("dd/MM/yyyy")
        End If
        GetVal()
        If String.IsNullOrWhiteSpace(txtMinMag.Text) Then
            If Not String.IsNullOrWhiteSpace(txtLlon.Text) And Not String.IsNullOrWhiteSpace(txtRlon.Text) _
           And Not String.IsNullOrWhiteSpace(txtULat.Text) And Not String.IsNullOrWhiteSpace(txtBlat.Text) Then
                'If rbKordinat.Checked = True Then
                Try
                    koneksi.Open()
                    If cbDrskn.Checked = True Then
                        dtAdapter = New MySqlDataAdapter("Select * from tDataGempa where `Information` Like '%mmi%' and (`Origin Date` between '" _
                                                     & fromdate & "' and '" & todate & "') and (`Latitude` between '" & blat & "' and '" _
                                                     & ulat & "') and (`Longitude` between '" & llon & "' and '" & rlon & "') and (`Depth` between '" _
                                                     & fromdepth & "' and '" & todepth & "')", koneksi)
                    Else
                        dtAdapter = New MySqlDataAdapter("select * from tDataGempa where (`Origin Date` between '" & fromdate & "' and '" _
                                                     & todate & "') and (`Latitude` between '" & blat & "' and '" & ulat & "') and (`Longitude` between '" _
                                                     & llon & "' and '" & rlon & "') and (`Depth` between '" & fromdepth & "' and '" & todepth & "')", koneksi)
                    End If
                    tbCari.Clear()
                    dtAdapter.Fill(tbCari)
                    If tbCari.Rows.Count = Nothing Then
                        MsgBox("Data tidak ditemukan!", MsgBoxStyle.Information)
                        srcFromDate.Text = ""
                        srcToDate.Text = ""
                        btExport.Enabled = False
                        btPlot.Enabled = False
                        lvwCari.GridLines = True
                        lvwCari.Columns.Clear()
                        lvwCari.Items.Clear()
                        Columnheader()
                        koneksi.Close()
                        srcFromDate.Focus()
                        Exit Sub
                    End If
                    koneksi.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            ElseIf String.IsNullOrWhiteSpace(txtLlon.Text) And String.IsNullOrWhiteSpace(txtRlon.Text) _
                     And String.IsNullOrWhiteSpace(txtULat.Text) And String.IsNullOrWhiteSpace(txtBlat.Text) Then
                If String.IsNullOrWhiteSpace(txtDaerah.Text) Then
                    Try
                        koneksi.Open()
                        If cbDrskn.Checked = True Then
                            dtAdapter = New MySqlDataAdapter("select * from tDataGempa where (`Origin Date` between '" _
                                                 & fromdate & "' and '" & todate & "') and (`Depth` between '" _
                                                     & fromdepth & "' and '" & todepth & "') and `Information` like '%mmi%'", koneksi)
                        Else
                            dtAdapter = New MySqlDataAdapter("select * from tDataGempa where (`Origin Date` between '" _
                                                 & fromdate & "' and '" & todate & "') and (`Depth` between '" _
                                                     & fromdepth & "' and '" & todepth & "')", koneksi)
                        End If
                        tbCari.Clear()
                        dtAdapter.Fill(tbCari)
                        If tbCari.Rows.Count = Nothing Then
                            MsgBox("Data tidak ditemukan!", MsgBoxStyle.Information)
                            srcFromDate.Text = ""
                            srcToDate.Text = ""
                            btExport.Enabled = False
                            btPlot.Enabled = False
                            lvwCari.GridLines = True
                            lvwCari.Columns.Clear()
                            lvwCari.Items.Clear()
                            Columnheader()
                            koneksi.Close()
                            srcFromDate.Focus()
                            Exit Sub
                        End If
                        koneksi.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Else
                    Try
                        koneksi.Open()
                        If cbDrskn.Checked = True Then
                            dtAdapter = New MySqlDataAdapter("select * from tDataGempa where `Information` like '%mmi%' and (`Remark` like '%" _
                                                         & txtDaerah.Text & "%' or `Information` like '%" & txtDaerah.Text & "%') and (`Origin Date` between '" _
                                                         & fromdate & "' and '" & todate & "') and (`Depth` between '" & fromdepth & "' and '" & todepth & "')", koneksi)
                        Else
                            dtAdapter = New MySqlDataAdapter("select * from tDataGempa where (`Origin Date` between '" & fromdate &
                                                         "' and '" & todate & "') and (`Remark` like '%" & txtDaerah.Text &
                                                         "%' or `Information` like '%" & txtDaerah.Text & "%') and (`Depth` between '" _
                                                         & fromdepth & "' and '" & todepth & "')", koneksi)
                        End If
                        tbCari.Clear()
                        dtAdapter.Fill(tbCari)
                        If tbCari.Rows.Count = Nothing Then
                            MsgBox("Data tidak ditemukan!", MsgBoxStyle.Information)
                            txtDaerah.Clear()
                            btExport.Enabled = False
                            btPlot.Enabled = False
                            lvwCari.GridLines = True
                            lvwCari.Columns.Clear()
                            lvwCari.Items.Clear()
                            Columnheader()
                            koneksi.Close()
                            txtDaerah.Focus()
                            Exit Sub
                        End If
                        koneksi.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                End If
            End If
        Else
            If Not String.IsNullOrWhiteSpace(txtLlon.Text) And Not String.IsNullOrWhiteSpace(txtRlon.Text) _
           And Not String.IsNullOrWhiteSpace(txtULat.Text) And Not String.IsNullOrWhiteSpace(txtBlat.Text) Then
                'If rbKordinat.Checked = True Then
                Try
                    koneksi.Open()
                    If cbDrskn.Checked = True Then
                        dtAdapter = New MySqlDataAdapter("select * from tDataGempa where `Information` like '%mmi%' and (`Origin Date` between '" _
                                                     & fromdate & "' and '" & todate & "') and (`Latitude` between '" & blat & "' and '" _
                                                     & ulat & "') and (`Longitude` between '" & llon & "' and '" & rlon & "')  and (`Depth` between '" _
                                                     & fromdepth & "' and '" & todepth & "') and (`Magnitude` between '" & magn & "' and '" & magx & "')", koneksi)
                    Else
                        dtAdapter = New MySqlDataAdapter("select * from tDataGempa where (`Origin Date` between '" & fromdate & "' and '" _
                                                     & todate & "') and (`Latitude` between '" & blat & "' and '" & ulat & "') and (`Longitude` between '" _
                                                     & llon & "' and '" & rlon & "') and (`Depth` between '" _
                                                     & fromdepth & "' and '" & todepth & "') and (`Magnitude` between '" & magn & "' and '" & magx & "')", koneksi)
                    End If
                    tbCari.Clear()
                    dtAdapter.Fill(tbCari)
                    If tbCari.Rows.Count = Nothing Then
                        MsgBox("Data tidak ditemukan!", MsgBoxStyle.Information)
                        srcFromDate.Text = ""
                        srcToDate.Text = ""
                        btExport.Enabled = False
                        btPlot.Enabled = False
                        lvwCari.GridLines = True
                        lvwCari.Columns.Clear()
                        lvwCari.Items.Clear()
                        Columnheader()
                        koneksi.Close()
                        srcFromDate.Focus()
                        Exit Sub
                    End If
                    koneksi.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            ElseIf String.IsNullOrWhiteSpace(txtLlon.Text) And String.IsNullOrWhiteSpace(txtRlon.Text) _
                     And String.IsNullOrWhiteSpace(txtULat.Text) And String.IsNullOrWhiteSpace(txtBlat.Text) Then
                'ElseIf rbDaerah.Checked = True Then
                If String.IsNullOrWhiteSpace(txtDaerah.Text) Then
                    'MsgBox("Kata kunci Daerah/Koordinat belum dimasukan", MsgBoxStyle.Information, "Perhatian")
                    'txtDaerah.Focus()
                    Try
                        koneksi.Open()
                        If cbDrskn.Checked = True Then
                            dtAdapter = New MySqlDataAdapter("select * from tDataGempa where (`Origin Date` between '" _
                                                         & fromdate & "' and '" & todate & "') and (`Depth` between '" _
                                                     & fromdepth & "' and '" & todepth & "') and (`Magnitude` between '" _
                                                     & magn & "' and '" & magx & "') and `Information` like '%mmi%'", koneksi)
                        Else
                            dtAdapter = New MySqlDataAdapter("select * from tDataGempa where (`Origin Date` between '" _
                                                         & fromdate & "' and '" & todate & "') and (`Depth` between '" _
                                                     & fromdepth & "' and '" & todepth & "') and (`Magnitude` between '" _
                                                     & magn & "' and '" & magx & "')", koneksi)
                        End If
                        tbCari.Clear()
                        dtAdapter.Fill(tbCari)
                        If tbCari.Rows.Count = Nothing Then
                            MsgBox("Data tidak ditemukan!", MsgBoxStyle.Information)
                            srcFromDate.Text = ""
                            srcToDate.Text = ""
                            btExport.Enabled = False
                            btPlot.Enabled = False
                            lvwCari.GridLines = True
                            lvwCari.Columns.Clear()
                            lvwCari.Items.Clear()
                            Columnheader()
                            koneksi.Close()
                            srcFromDate.Focus()
                            Exit Sub
                        End If
                        koneksi.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Else
                    Try
                        koneksi.Open()
                        If cbDrskn.Checked = True Then
                            dtAdapter = New MySqlDataAdapter("select * from tDataGempa where `Information` like '%mmi%' and (`Remark` like '%" _
                                                         & txtDaerah.Text & "%' or `Information` like '%" & txtDaerah.Text & "%') and (`Origin Date` between '" _
                                                         & fromdate & "' and '" & todate & "') and (`Depth` between '" _
                                                     & fromdepth & "' and '" & todepth & "') and (`Magnitude` between '" & magn & "' and '" & magx & "')", koneksi)
                        Else
                            dtAdapter = New MySqlDataAdapter("select * from tDataGempa where (`Origin Date` between '" & fromdate &
                                                         "' and '" & todate & "') and (`Depth` between '" _
                                                     & fromdepth & "' and '" & todepth & "') and (`Remark` like '%" & txtDaerah.Text &
                                                         "%' or `Information` like '%" & txtDaerah.Text & "%') and (`Magnitude` between '" & magn & "' and '" & magx & "')", koneksi)
                        End If
                        tbCari.Clear()
                        dtAdapter.Fill(tbCari)
                        If tbCari.Rows.Count = Nothing Then
                            MsgBox("Data tidak ditemukan!", MsgBoxStyle.Information)
                            txtDaerah.Clear()
                            btExport.Enabled = False
                            btPlot.Enabled = False
                            lvwCari.GridLines = True
                            lvwCari.Columns.Clear()
                            lvwCari.Items.Clear()
                            Columnheader()
                            koneksi.Close()
                            txtDaerah.Focus()
                            Exit Sub
                        End If
                        koneksi.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                End If
            End If
        End If
        jumlahgempa = tbCari.Rows.Count
        If jumlahgempa > 0 Then
            Dim currentValue As Double, maxValue As Double
            Dim rowIndex As Integer
            Dim dv As DataView = tbCari.DefaultView
            For c As Integer = 0 To tbCari.Rows.Count - 1
                dv.Sort = tbCari.Columns(6).ColumnName + " DESC"
                currentValue = Format(CDbl(dv(0).Item(6)), "0.0")
                If currentValue > maxValue Then
                    rowIndex = tbCari.Rows.IndexOf(dv(0).Row)
                    maxValue = Format(currentValue, "0.0")
                End If
            Next
            lblCount.Text = "Jumlah : " & jumlahgempa & " event," & " Magnitudo terbesar : " & maxValue
            jmlh = jumlahgempa.ToString
        Else : lblCount.Text = ""
        End If
        ShowlvwCari(tbCari, lvwCari)
        btExport.Enabled = True
        btPlot.Enabled = True
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
                    output.Write(""""c)
                    output.Write(value)
                    output.Write(""""c)
                Else
                    output.Write(value)
                End If
                delim = ","
            Next
            output.WriteLine()
        Next
        output.Close()
    End Sub
    Private Sub rbKordinat_CheckedChanged(sender As Object, e As EventArgs)
        'If rbKordinat.Checked = True Then
        ' txtLlon.Focus()
        ' txtLlon.SelectAll()
        ' End If
    End Sub
    Private Sub rbDaerah_CheckedChanged(sender As Object, e As EventArgs)
        'If rbDaerah.Checked = True Then
        ' txtDaerah.Focus()
        ' txtDaerah.SelectAll()
        ' End If
    End Sub
    Private Sub txtDaerah_Enter(sender As Object, e As EventArgs) Handles txtDaerah.Enter
        'If rbDaerah.Checked = False Then
        ' rbDaerah.Checked = True
        ' End If
    End Sub
    Private Sub btCari_Click(sender As Object, e As EventArgs) Handles btCari.Click
        SearchRecord()
        SeismisitasProgress.Visible = False
        If llon < 0 Then
            strbujur1 = "BB"
        Else
            strbujur1 = "BT"
        End If
        If rlon < 0 Then
            strbujur2 = "BB"
        Else
            strbujur2 = "BT"
        End If
        If blat >= 0 Then
            strlintang1 = "LU"
            strlintang2 = "LU"
        Else
            strlintang1 = "LS"
            If ulat < 0 Then
                strlintang2 = "LS"
            Else
                strlintang2 = "LU"
            End If
        End If
        kordinat = Abs(llon) & " " & strbujur1 & " - " & Abs(rlon) & " " & strbujur2 &
            " ^& " & Abs(blat) & " " & strlintang1 & " - " & Abs(ulat) & " " & strlintang2
        lvwCari.Focus()
        'Me.btExport.BringToFront()
    End Sub
    Private Sub btExit_Click(sender As Object, e As EventArgs) Handles btExit.Click
        Close()
    End Sub
    Private Sub btExport_Click(sender As Object, e As EventArgs) Handles btExport.Click
        SaveSearch.ShowDialog()
        SaveSearch.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    End Sub
    Private Sub SaveSearch_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveSearch.FileOk
        Dim SaveFile As String = SaveSearch.FileName
        Export(SaveFile, tbCari)
        Process.Start(SaveFile)
    End Sub
    Private Sub FormSearch_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FormUtama.mnCari.BackColor = Color.WhiteSmoke
    End Sub
    Private Sub btPlot_Click(sender As Object, e As EventArgs) Handles btPlot.Click
        SeismisitasTimer.Interval = 150
        If txtLlon.Text = String.Empty Or txtRlon.Text = String.Empty Or txtULat.Text = String.Empty Or txtBlat.Text = String.Empty Then
            MsgBox("Lengkapi data koordinat terlebih dahulu", MsgBoxStyle.OkOnly)
            txtLlon.Focus()
            Exit Sub
        End If
        'Dim SaveFile As String = SaveSearch.FileName
        btPlot.Enabled = False
        Export("dataseismisitas.xy", tbCari)
        'SaveSearch.ShowDialog()
        'SaveSearch.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim seismisitas As New System.Text.StringBuilder
        seismisitas.AppendLine("del ""seismisitas.jpg""")
        REM Parameter Peta
        seismisitas.AppendLine("::Peta")
        REM seismisitas.AppendLine("set ps=""seismisitas.ps""")
        seismisitas.AppendLine("REM GMT PLOT EPICENTER")
        seismisitas.AppendLine("REM $Id: YEHEZKIEL HALAUWET $")
        seismisitas.AppendLine("REM Purpose: Plot seismisity from search data")
        seismisitas.AppendLine("REM GMT progs: psbasemap, grdimage, grdgradient, psimage, grdmath, grdtrack, psxy, pstext, ps2raster")
        seismisitas.AppendLine("REM Unix progs: gawk")
        seismisitas.AppendLine("Title EQ Map Generator")
        seismisitas.AppendLine(":main")
        seismisitas.AppendLine("cls")
        seismisitas.AppendLine("echo EQ Map Generator")
        seismisitas.AppendLine("echo by eQ H")
        seismisitas.AppendLine("echo.--------------------------------------------------------")
        REM Parameter Peta
        seismisitas.AppendLine("set ps=seismisitas.ps")
        seismisitas.AppendLine("set data=dataseismisitas.xy")
        seismisitas.AppendLine("set R=" & llon - 0.2 & "/" & rlon + 0.2 & "/" & blat - 0.2 & "/" & ulat + 0.2)
        REM __set x = abs(rlon - llon)
        REM __set y = abs(ulat - blat)
        REM ratio x/y
        'seismisitas.AppendLine("set rlon=" & rlon)
        'seismisitas.AppendLine("set llon=124")
        'seismisitas.AppendLine("set ulat=0")
        'seismisitas.AppendLine("set blat=-4")
        REM seismisitas.AppendLine("set R=%llon%/%rlon%/%blat%/%ulat%")
        seismisitas.AppendLine("set R1=0/6/0/1.5")
        seismisitas.AppendLine("set L=legend")
        seismisitas.AppendLine("set L2=legend2")
        seismisitas.AppendLine("set D=gmt/depth.cpt")
        seismisitas.AppendLine("set topo=gmt/my_etopo.cpt")
        seismisitas.AppendLine("set indo=gmt/indonesia.nc")
        seismisitas.AppendLine("set ilum=gmt/iluminasi.nc")
        seismisitas.AppendLine("gmtmath -Q " & rlon + 0.2 & " " & llon - 0.2 & " SUB = x.d")
        seismisitas.AppendLine("set /p x=<x.d")
        seismisitas.AppendLine("del x.d")
        seismisitas.AppendLine("gmtmath -Q " & ulat + 0.2 & " " & blat - 0.2 & " SUB = y.d")
        seismisitas.AppendLine("set /p y=<y.d")
        seismisitas.AppendLine("del y.d")
        seismisitas.AppendLine("gmtmath -Q 16 %y% MUL %x% DIV = m.d")
        seismisitas.AppendLine("set /p m=<m.d")
        seismisitas.AppendLine("del m.d")
        seismisitas.AppendLine("gmtmath -Q %m% %m% 0.25 MUL SUB = yr.d")
        seismisitas.AppendLine("set /p yr=<yr.d")
        seismisitas.AppendLine("del yr.d")
        seismisitas.AppendLine("gmtmath -Q %y% 4 DIV --FORMAT_FLOAT_OUT=%%.3lg = yr1.d")
        seismisitas.AppendLine("set /p yr1=<yr1.d")
        seismisitas.AppendLine("del yr1.d")
        seismisitas.AppendLine("gmtmath -Q %x% 8.89 DIV --FORMAT_FLOAT_OUT=%%.3lg = xl.d")
        seismisitas.AppendLine("set /p xl=<xl.d")
        seismisitas.AppendLine("del xl.d")
        seismisitas.AppendLine("gmtmath -Q %yr1% 3 DIV --FORMAT_FLOAT_OUT=%%.3lg = y1l.d")
        seismisitas.AppendLine("set /p y1l=<y1l.d")
        seismisitas.AppendLine("del y1l.d")
        seismisitas.AppendLine("gmtmath -Q %y1l% %x% 20 DIV ADD --FORMAT_FLOAT_OUT=%%.3lg = y2l.d")
        seismisitas.AppendLine("set /p y2l=<y2l.d")
        seismisitas.AppendLine("del y2l.d")
        seismisitas.AppendLine("gmtmath -Q %x% 10 MUL RINT --FORMAT_FLOAT_OUT=%%.3lg = length.d")
        seismisitas.AppendLine("set /p length=<length.d")
        seismisitas.AppendLine("del length.d")
        seismisitas.AppendLine("set xr=14")
        seismisitas.AppendLine("set R2=0/%x%/0/%yr1%")
        seismisitas.AppendLine("makecpt -Z -Cetopo1 > %topo%")
        seismisitas.AppendLine("echo # color palette for seismicity depend on depth>%D%")
        seismisitas.AppendLine("echo # z0 color z1 color >>%D%")
        seismisitas.AppendLine("echo 0 red 60.1 red >>%D%")
        seismisitas.AppendLine("echo 60.1 yellow 300.1 yellow >>%D%")
        seismisitas.AppendLine("echo 300.1 green 3600 green >>%D%")
        seismisitas.AppendLine("echo G -0.1>%L%")
        seismisitas.AppendLine("echo H 9 5 Legenda >>%L%")
        seismisitas.AppendLine("echo D 0 1p >>%L%")
        seismisitas.AppendLine("echo V 0 1p >>%L%")
        seismisitas.AppendLine("echo N 6 >>%L%")
        seismisitas.AppendLine("echo L 6 5 C Depth (km) >>%L%")
        seismisitas.AppendLine("echo L 6 5 C M = 3 >>%L%")
        seismisitas.AppendLine("echo L 6 5 C M = 4 >>%L%")
        seismisitas.AppendLine("echo L 6 5 C M = 5 >>%L%")
        seismisitas.AppendLine("echo L 6 5 C M = 6 >>%L%")
        seismisitas.AppendLine("echo L 6 5 C M = 7 >>%L%")
        seismisitas.AppendLine("echo D 0 1p >>%L%")
        seismisitas.AppendLine("echo L 6 5 C \074 60 >>%L%")
        seismisitas.AppendLine("echo S 0.5 c 0.09c red 0.5p >>%L%")
        seismisitas.AppendLine("echo S 0.5 c 0.16c red 0.5p >>%L%")
        seismisitas.AppendLine("echo S 0.5 c 0.25c red 0.5p >>%L%")
        seismisitas.AppendLine("echo S 0.5 c 0.36c red 0.5p >>%L%")
        seismisitas.AppendLine("echo S 0.5 c 0.49c red 0.5p >>%L%")
        seismisitas.AppendLine("echo L 6 5 C 60 - 300 >>%L%")
        seismisitas.AppendLine("echo S 0.5 c 0.09c yellow 0.5p >>%L%")
        seismisitas.AppendLine("echo S 0.5 c 0.16c yellow 0.5p >>%L%")
        seismisitas.AppendLine("echo S 0.5 c 0.25c yellow 0.5p >>%L%")
        seismisitas.AppendLine("echo S 0.5 c 0.36c yellow 0.5p >>%L%")
        seismisitas.AppendLine("echo S 0.5 c 0.49c yellow 0.5p >>%L%")
        seismisitas.AppendLine("echo L 6 5 C \076 300 >>%L%")
        seismisitas.AppendLine("echo S 0.5 c 0.09c green 0.5p >>%L%")
        seismisitas.AppendLine("echo S 0.5 c 0.16c green 0.5p >>%L%")
        seismisitas.AppendLine("echo S 0.5 c 0.25c green 0.5p >>%L%")
        seismisitas.AppendLine("echo S 0.5 c 0.36c green 0.5p >>%L%")
        seismisitas.AppendLine("echo S 0.5 c 0.49c green 0.5p >>%L%")
        seismisitas.AppendLine("echo D 0 1p >>%L%")
        seismisitas.AppendLine("echo V 0 1p >>%L%")
        seismisitas.AppendLine("echo N 3 >>%L%")
        seismisitas.AppendLine("echo V 0 1p >>%L%")
        seismisitas.AppendLine("echo G 0.18 >>%L%")
        seismisitas.AppendLine("echo S 1.2 f0.2+l+t 0.6 black 1.5p >>%L%")
        seismisitas.AppendLine("echo S 1.2 f0.2+l+t 0.6 white 1.5p >>%L%")
        seismisitas.AppendLine("echo S 1.2 - 0.6c - 1.5p >>%L%")
        seismisitas.AppendLine("echo G -0.13 >>%L%")
        seismisitas.AppendLine("echo L 6 3 C Jalur Subduksi >>%L%")
        seismisitas.AppendLine("echo L 6 3 C Sesar Naik >>%L%")
        seismisitas.AppendLine("echo L 6 3 C Sesar Geser >>%L%")
        seismisitas.AppendLine("echo D 0 1p >>%L%")
        seismisitas.AppendLine("echo V 0 1p >>%L%")
        REM Legend 2
        seismisitas.AppendLine("echo I img\logo.ps 0.85 CT >%L2%")
        seismisitas.AppendLine("echo G 0.01 >>%L2%")
        seismisitas.AppendLine("echo H 5 5 " & StrConv(kop, VbStrConv.Uppercase) & " >>%L2%")
        seismisitas.AppendLine("echo G 0.1 >>%L2%")
        seismisitas.AppendLine("echo N 3 >>%L2%")
        seismisitas.AppendLine("echo L 6.5 5 L Jumlah Gempabumi >>%L2%")
        seismisitas.AppendLine("echo L 6.5 5 L :  " & jmlh & " >>%L2%")
        seismisitas.AppendLine("echo L 6.5 5 L \000 >>%L2%")
        seismisitas.AppendLine("echo L 6.5 5 L Waktu Kejadian >>%L2%")
        seismisitas.AppendLine("echo L 6.5 5 L :  " & fdate & " - " & tdate & " >>%L2%")
        seismisitas.AppendLine("echo L 6.5 5 L \000 >>%L2%")
        seismisitas.AppendLine("echo L 6.5 5 L Koordinat >>%L2%")
        REM echo koordinat error
        seismisitas.AppendLine("echo L 6.5 5 L :  " & kordinat & " >>%L2%")
        seismisitas.AppendLine("echo L 6.5 5 L \000 >>%L2%")
        seismisitas.AppendLine("echo L 6.5 5 L Kedalaman >>%L2%")
        seismisitas.AppendLine("echo L 6.5 5 L :  " & fromdepth & " - " & todepth & " Km >>%L2%")
        seismisitas.AppendLine("echo L 6.5 5 L \000 >>%L2%")
        seismisitas.AppendLine("echo L 6.5 5 L Magnitudo >>%L2%")
        If String.IsNullOrWhiteSpace(txtMinMag.Text) Then
            seismisitas.AppendLine("echo L 6.5 5 L :  1 - 9.5 >>%L2%")
        Else
            seismisitas.AppendLine("echo L 6.5 5 L :  " & magn & " - " & Format(magx, "0.0") & " >>%L2%")
        End If
        'seismisitas.AppendLine("echo L 6.5 5 L \000 >>%L2%")
        ' seismisitas.AppendLine("if %x% LEQ 1 (")
        ' seismisitas.AppendLine("set grid=0.1")
        ' seismisitas.AppendLine("set annot=0.2")
        ' seismisitas.AppendLine("goto NEXT")
        ' seismisitas.AppendLine(") else if %x% LEQ 2 (")
        ' seismisitas.AppendLine("set grid=0.25")
        ' seismisitas.AppendLine("set annot=0.5")
        '  seismisitas.AppendLine("goto NEXT")
        ' seismisitas.AppendLine(") else if %x% LEQ 3 (")
        '  seismisitas.AppendLine("set grid=0.5")
        ' seismisitas.AppendLine("set annot=1")
        ' seismisitas.AppendLine("goto NEXT")
        ' seismisitas.AppendLine(") else if %x% LEQ 5 (")
        ' seismisitas.AppendLine("set grid=1")
        ' seismisitas.AppendLine("set annot=2")
        ' seismisitas.AppendLine("goto NEXT")
        ' seismisitas.AppendLine(") else (")
        ' seismisitas.AppendLine("set grid=2")
        ' seismisitas.AppendLine("set annot=4")
        ' seismisitas.AppendLine("goto NEXT")
        ' seismisitas.AppendLine(")")
        If rlon - llon <= 1 Then
            seismisitas.AppendLine("set grid=0.1")
            seismisitas.AppendLine("set annot=0.2")
        ElseIf rlon - llon <= 2 Then
            seismisitas.AppendLine("set grid=0.25")
            seismisitas.AppendLine("set annot=0.5")
        ElseIf rlon - llon <= 3 Then
            seismisitas.AppendLine("set grid=0.5")
            seismisitas.AppendLine("set annot=1")
        Else
            seismisitas.AppendLine("set grid=1")
            seismisitas.AppendLine("set annot=2")
        End If
        REM Peta dasar
        seismisitas.AppendLine(":NEXT")
        seismisitas.AppendLine("pslegend %L% -JM16c -Dx-0.15/0+w7.9/4.2+jBL+l2.2 -F --FONT_ANNOT_PRIMARY=5 -K -P > %ps%")
        seismisitas.AppendLine("pslegend %L2% -J -Dx8.26/0+w7.9/4.2+jBL+l2.2 -F --FONT_ANNOT_PRIMARY=5 -K -O >> %ps%")
        seismisitas.AppendLine("grdimage %indo% -J -R%R% -C%topo% -K -O -Y4.65 >> %ps%")
        seismisitas.AppendLine("psbasemap -J -R%R2% -L%xl%/%y1l%/1/%length%k+l+jr -Tf%xl%/%y2l%/1.2/2:: --MAP_ANNOT_MIN_SPACING=0.1p --FONT_LABEL=7 --FONT_ANNOT_PRIMARY=6  --FONT_TITLE=7 -Y%yr% -O -K >> %ps%")
        seismisitas.AppendLine("psbasemap -J -R%R% -Y-%yr% -Ba%annot%g%grid%WsNe --FONT_ANNOT_PRIMARY=9 --FONT_LABEL=10 --FONT_TITLE=9 -O -K >> %ps%")
        seismisitas.AppendLine("psxy gmt/subduksi_moluccas.gmt -JM -R -Wthin -Sf0.8i/0.08i+r+t -Gblack -O -K >> %ps%")
        seismisitas.AppendLine("psxy gmt/fault_moluccas.gmt -JM -R -Wthin -O -K >> %ps%")
        seismisitas.AppendLine("REM psxy gmt/trench-a.gmt -JM -R -Wthick -Sf0.8i/0.08i+l+t -Gblack -O -K >> %ps%")
        seismisitas.AppendLine("REM psxy gmt/trench-b.gmt -JM -R -Wthick -Sf0.8i/0.08i+r+t -Gblack -O -K >> %ps%")
        seismisitas.AppendLine("REM psxy gmt/thrust.gmt -JM -R -Wthick -Sf0.8i/0.08i+r+t -O -K >> %ps%")
        seismisitas.AppendLine("REM psxy gmt/transform.gmt -JM -R -Wthick -O -K >> %ps%")
        seismisitas.AppendLine("gawk -F, ""{print $5, $4, $6, ($7*0.1)^2}"" %data% | psxy -J -R%R% -Sc -Wthin,black -C%D% -O>> %ps%")
        seismisitas.AppendLine("::psimage img/watermarkbmkg.png -Dx0/0+w0.8c -C%xr%/0.7/BC -O -K >> %ps%")
        seismisitas.AppendLine("::echo 5.25 0 BMKG | pstext -J -R%R1% -F+f7p,Helvetica -N -Y0.5 -O -K >> %ps%")
        seismisitas.AppendLine("::" & wtrmark)
        seismisitas.AppendLine("del %L%")
        seismisitas.AppendLine("del %L2%")
        seismisitas.AppendLine("psconvert %ps% -E400 -Tj -P -A")
        REM delete unecessary file
        'seismisitas.AppendLine("del %D%")
        'seismisitas.AppendLine("del %L%")
        'seismisitas.AppendLine("del %L2%")
        'seismisitas.AppendLine("del %data%")
        'seismisitas.AppendLine("del %ps%")
        IO.File.WriteAllText("seismisitas.bat", seismisitas.ToString())
        'GenMapTimer.Interval = 10
        Dim startinfo As New ProcessStartInfo("seismisitas.bat")
        startinfo.WindowStyle = ProcessWindowStyle.Minimized
        startinfo.WindowStyle = ProcessWindowStyle.Hidden
        startinfo.CreateNoWindow = True
        startinfo.UseShellExecute = False
        Dim proc As Process = Process.Start(startinfo)
        SeismisitasTimer.Start()
        'btGenmap.Visible = False
        SeismisitasProgress.Visible = True
        SeismisitasProgress.Value = 5
    End Sub
    Dim tt As New ToolTip
    Private Sub txtULat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtULat.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtBlat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBlat.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtLlon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLlon.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtRlon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRlon.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtFromDepth_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFromDepth.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtToDepth_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtToDepth.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtMinMag_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMinMag.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtMaxMag_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMaxMag.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtULat_Enter(sender As Object, e As EventArgs) Handles txtULat.Enter
        tt.Show("For south latitude use minus sign ("" - "")", txtULat)
    End Sub
    Private Sub txtULat_Leave(sender As Object, e As EventArgs) Handles txtULat.Leave
        tt.Hide(txtULat)
    End Sub
    Private Sub txtBLat_Enter(sender As Object, e As EventArgs) Handles txtBlat.Enter
        tt.Show("For south latitude use minus sign ("" - "")", txtULat)
    End Sub
    Private Sub txtBLat_Leave(sender As Object, e As EventArgs) Handles txtBlat.Leave
        tt.Hide(txtULat)
    End Sub
    Private Sub txtDaerah_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDaerah.Validating

    End Sub
    Private Sub txtDaerah_Leave(sender As Object, e As EventArgs) Handles txtDaerah.Leave
        'If String.IsNullOrWhiteSpace(txtDaerah.Text) Then
        ' rbDaerah.Checked = False
        ' If Not String.IsNullOrWhiteSpace(txtLlon.Text) Then
        ' rbKordinat.Checked = True
        ' End If
        ' End If
    End Sub
    Private Sub txtDaerah_TextChanged(sender As Object, e As EventArgs) Handles txtDaerah.TextChanged
        drCari = dtSetDaerah.Tables("tDaerah").Select("`Daerah`='" & txtDaerah.Text & "'")
        If drCari.Length > 0 Then
            If drCari(0).Item("AreaBarat").ToString = 0 And drCari(0).Item("AreaTimur").ToString = 0 And
                   drCari(0).Item("AreaUtara").ToString = 0 And drCari(0).Item("AreaSelatan").ToString = 0 Then
                txtLlon.Clear()
                txtRlon.Clear()
                txtULat.Clear()
                txtBlat.Clear()
            Else
                txtLlon.Text = drCari(0).Item("AreaBarat").ToString
                txtRlon.Text = drCari(0).Item("AreaTimur").ToString
                txtULat.Text = drCari(0).Item("AreaUtara").ToString
                txtBlat.Text = drCari(0).Item("AreaSelatan").ToString
            End If
        Else
            txtLlon.Clear()
            txtRlon.Clear()
            txtULat.Clear()
            txtBlat.Clear()
        End If
    End Sub
    Private Sub bt_Del_Click(sender As Object, e As EventArgs) Handles bt_Del.Click
        Dim lblID As String
        If lvwCari.SelectedItems.Count > 0 Then
            Dim lvi As ListViewItem = lvwCari.SelectedItems(0)
            lblID = lvi.SubItems(0).Text
            Select Case MsgBox("Hapus Data Gempa " & lblID & "?", MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    'HapusEvent("gempaDELETE")
                    modFungsi.hapusgempa(vevent_id:=lblID)
                    koneksi.Close()
                    modFungsi.hapussc_data(vevent_id:=lblID)
                    If Application.OpenForms.OfType(Of FormInput).Any Then
                        With FormInput
                            .DataGempa()
                            .ShowlvwGempa(dtSetGempa.Tables("tDataGempa"), .lvwGempa)
                        End With
                    End If
            End Select
        End If
        SearchRecord()
        SeismisitasProgress.Visible = False
        If llon < 0 Then
            strbujur1 = "BB"
        Else
            strbujur1 = "BT"
        End If
        If rlon < 0 Then
            strbujur2 = "BB"
        Else
            strbujur2 = "BT"
        End If
        If blat >= 0 Then
            strlintang1 = "LU"
            strlintang2 = "LU"
        Else
            strlintang1 = "LS"
            If ulat < 0 Then
                strlintang2 = "LS"
            Else
                strlintang2 = "LU"
            End If
        End If
        kordinat = Abs(llon) & " " & strbujur1 & " - " & Abs(rlon) & " " & strbujur2 &
            " ^& " & Abs(blat) & " " & strlintang1 & " - " & Abs(ulat) & " " & strlintang2
        lvwCari.Focus()
        Me.bt_Del.Visible = False
    End Sub

    Private Sub lvwCari_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwCari.SelectedIndexChanged
        If bt_Del.Visible = False Then
            Me.bt_Del.Visible = True
        End If
    End Sub
    Private Sub txtMinMag_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtMinMag.Validating
        If IsNumeric(txtMinMag.Text) Then
            magn = txtMinMag.Text
        End If
    End Sub
    Private Sub txtMaxMag_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtMaxMag.Validating
        If IsNumeric(txtMaxMag.Text) Then
            magx = txtMaxMag.Text
        End If
    End Sub
    Private Sub txtLlon_Leave(sender As Object, e As EventArgs) Handles txtLlon.Leave
        If String.IsNullOrWhiteSpace(txtLlon.Text) And String.IsNullOrWhiteSpace(txtRlon.Text) _
            And String.IsNullOrWhiteSpace(txtULat.Text) And String.IsNullOrWhiteSpace(txtBlat.Text) Then
            txtDaerah.Focus()
        End If
    End Sub
    Private Sub SeismisitasTimer_Tick(sender As Object, e As EventArgs) Handles SeismisitasTimer.Tick
        Dim copyseis As New StringBuilder
        Dim seispath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString
        Dim seisjpg As String = seispath & "\seismisitas.jpg"
        SeismisitasProgress.Increment(1)
        If SeismisitasProgress.Value < 40 Then
            If File.Exists(seisjpg) = True Then
                Dim delseis As New StringBuilder
                delseis.AppendLine("del " & seisjpg)
                File.WriteAllText("delseis.bat", delseis.ToString())
                Dim startdel As New ProcessStartInfo("delseis.bat")
                startdel.WindowStyle = ProcessWindowStyle.Minimized
                startdel.WindowStyle = ProcessWindowStyle.Hidden
                startdel.CreateNoWindow = True
                startdel.UseShellExecute = False
                Dim procdel As Process = Process.Start(startdel)
            End If
            If File.Exists(dir & "\seismisitas.jpg") Then
                SeismisitasProgress.Value = 50
            End If
        Else
            If File.Exists(dir & "\seismisitas.jpg") Then
                copyseis.AppendLine("move /Y """ & dir & "\seismisitas.jpg"" """ & seisjpg & """")
                REM copyseis.AppendLine("del seismisitas.ps")
                File.WriteAllText("saveseis.bat", copyseis.ToString())
                Dim startsave As New ProcessStartInfo("saveseis.bat")
                startsave.WindowStyle = ProcessWindowStyle.Minimized
                startsave.WindowStyle = ProcessWindowStyle.Hidden
                startsave.CreateNoWindow = True
                startsave.UseShellExecute = False
                Dim proc As Process = Process.Start(startsave)
            Else
                If File.Exists(seisjpg) = True Then
                    SeismisitasProgress.Value = 100
                    SeismisitasTimer.Stop()
                    MsgBox("seismisitas.jpg tersimpan di Desktop", MsgBoxStyle.OkOnly)
                    btPlot.Enabled = False
                    SeismisitasProgress.Visible = False
                End If
                If SeismisitasProgress.Value = 90 Then
                    If File.Exists(seisjpg) = False Then
                        SeismisitasTimer.Interval = 1000
                    End If
                End If
                If SeismisitasProgress.Value = 100 Then
                    If File.Exists(seisjpg) = False Then
                        SeismisitasProgress.Increment(0)
                        SeismisitasTimer.Stop()
                        MsgBox("Plot seismisitas error, click ""Seismistas Map"" button to retry", MsgBoxStyle.OkOnly)
                        'SeismisitasProgress.Value = 90
                        REM SeismisitasProgress.Visible = False
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtLlon_Enter(sender As Object, e As EventArgs) Handles txtLlon.Enter
        'If rbKordinat.Checked = False Then
        ' rbKordinat.Checked = True
        ' End If
    End Sub
    Private Sub PanelKordinat_Enter(sender As Object, e As EventArgs) Handles PanelKordinat.Enter
        'If rbKordinat.Checked = False Then
        ' rbKordinat.Checked = True
        ' End If
    End Sub
    Private Sub PanelKordinat_Leave(sender As Object, e As EventArgs) Handles PanelKordinat.Leave
        If String.IsNullOrWhiteSpace(txtLlon.Text) And String.IsNullOrWhiteSpace(txtRlon.Text) _
           And String.IsNullOrWhiteSpace(txtULat.Text) And String.IsNullOrWhiteSpace(txtBlat.Text) Then
            txtDaerah.Focus()
            'If rbKordinat.Checked = True Then
            ' rbKordinat.Checked = False
            ' End If
            Exit Sub
        Else
            If String.IsNullOrWhiteSpace(txtLlon.Text) Then
                MsgBox("Batasan koordinat belum lengkap", MsgBoxStyle.OkOnly, "Perhatian")
                txtLlon.Focus()
                txtLlon.SelectAll()
                Exit Sub
            ElseIf String.IsNullOrWhiteSpace(txtRlon.Text) Then
                MsgBox("Batasan koordinat belum lengkap", MsgBoxStyle.OkOnly, "Perhatian")
                txtRlon.Focus()
                txtRlon.SelectAll()
                Exit Sub
            ElseIf String.IsNullOrWhiteSpace(txtULat.Text) Then
                MsgBox("Batasan koordinat belum lengkap", MsgBoxStyle.OkOnly, "Perhatian")
                txtULat.Focus()
                txtULat.SelectAll()
                Exit Sub
            ElseIf String.IsNullOrWhiteSpace(txtBlat.Text) Then
                MsgBox("Batasan koordinat belum lengkap", MsgBoxStyle.OkOnly, "Perhatian")
                txtBlat.Focus()
                txtBlat.SelectAll()
                Exit Sub
            Else
                txtMinMag.Focus()
            End If
        End If
    End Sub

    Private Sub lvwCari_DoubleClick(sender As Object, e As EventArgs) Handles lvwCari.DoubleClick
        If lvwCari.SelectedItems.Count > 0 Then
            Dim lvi As ListViewItem = lvwCari.SelectedItems(0)
            FormInput.MdiParent = FormUtama
            FormInput.Show()
            FormInput.lbEventID.Text = lvi.SubItems(0).Text
            FormInput.DatePicker.Text = lvi.SubItems(1).Text
            FormInput.TimePicker.Text = lvi.SubItems(2).Text
            FormInput.txtLat.Text = lvi.SubItems(3).Text
            FormInput.txtLon.Text = lvi.SubItems(4).Text
            FormInput.txtDepth.Text = lvi.SubItems(5).Text
            FormInput.txtMag.Text = lvi.SubItems(6).Text
            If Not String.IsNullOrWhiteSpace(lvi.SubItems(8).Text) Then
                'Me.chkDirasakan.Checked = True
                'Me.txtInfo.Enabled = True
                FormInput.txtInfo.Text = lvi.SubItems(8).Text
            Else
                'Me.chkDirasakan.Enabled = False
                'Me.txtInfo.Enabled = False
                FormInput.txtInfo.Text = "Informasi Tambahan (Tsunami atau Dirasakan)"
            End If
            drNarasi = dtSetNarasi.Tables("tNarasi").Select("`ID`='" & lvi.SubItems(0).Text & "'")
            FormInput.BringToFront()
        End If
        If drNarasi.Length > 0 Then
            FormInput.btNarasi.Text = "Edit Narasi"
        Else
            FormInput.btNarasi.Text = "Buat Narasi"
        End If
        FormInput.btSave.Text = "&Update"
        Navigasi(True)
        TextboxEnable(True)
        FormInput.DatePicker.Focus()
        'btDelete.Enabled = True
        FormInput.btSave.BringToFront()
    End Sub

    Private Sub txtLlon_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtLlon.Validating
        If IsNumeric(txtLlon.Text) Then
            If txtLlon.Text < 90 Or txtLlon.Text > 146 Then
                MsgBox("Bujur diluar wilayah Indonesia!", MsgBoxStyle.OkOnly, "Perhatian")
                txtLlon.Focus()
                txtLlon.SelectAll()
                Exit Sub
            End If
            llon = txtLlon.Text
            txtLlon.Text = Format(llon, "000.00")
        End If
    End Sub
    Private Sub txtRlon_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtRlon.Validating
        If IsNumeric(txtRlon.Text) Then
            If txtRlon.Text < 90 Or txtRlon.Text > 146 Then
                MsgBox("Bujur diluar wilayah Indonesia!", MsgBoxStyle.OkOnly, "Perhatian")
                txtRlon.Focus()
                txtRlon.SelectAll()
                Exit Sub
            End If
            rlon = txtRlon.Text
            If rlon < llon Then
                txtRlon.Text = Format(llon, "000.00")
                txtLlon.Text = Format(rlon, "000.00")
                rlon = txtRlon.Text
                llon = txtLlon.Text
            End If
            txtRlon.Text = Format(rlon, "000.00")
        End If
    End Sub
    Private Sub txtULat_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtULat.Validating
        If IsNumeric(txtULat.Text) Then
            If txtULat.Text < -16 Or txtULat.Text > 11 Then
                MsgBox("Lintang diluar wilayah Indonesia!", MsgBoxStyle.OkOnly, "Perhatian")
                txtULat.Focus()
                txtULat.SelectAll()
                Exit Sub
            End If
            ulat = txtULat.Text
            txtULat.Text = Format(ulat, "00.00")
        End If
    End Sub
    Private Sub txtBlat_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtBlat.Validating
        If IsNumeric(txtBlat.Text) Then
            If txtBlat.Text < -16 Or txtBlat.Text > 11 Then
                MsgBox("Lintang diluar wilayah Indonesia!", MsgBoxStyle.OkOnly, "Perhatian")
                txtBlat.Focus()
                txtBlat.SelectAll()
                Exit Sub
            End If
            blat = txtBlat.Text
            If blat > ulat Then
                txtBlat.Text = Format(ulat, "00.00")
                txtULat.Text = Format(blat, "00.00")
                blat = txtBlat.Text
                ulat = txtULat.Text
            End If
            txtBlat.Text = Format(blat, "00.00")
        End If
    End Sub
#End Region
End Class