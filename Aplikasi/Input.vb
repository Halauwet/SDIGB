Imports System.Math
Imports System.IO
Imports System.Data
'Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class FormInput
    Dim directoryapp As String = Application.StartupPath
    Dim jsonpath As String = Application.StartupPath.ToString & "\gempaterkini\data"
    Dim tb_week_eq As New DataTable
    Dim tb_day_eq As New DataTable
    Dim lintang, bujur As Double
    Dim strlintang, strbujur, strzonawaktu, pgr, tipe, kode As String
    Dim eventid As String
    Dim od, ot As String
    Dim origin As String
    Dim lat, lon, depth, mag As Double
    Dim remark, info, tsunami, lokasi, sufx, wtrmark As String
    Dim wit, wib, JD As Date
    Dim time_value As Date
    Dim tambahwaktu As Integer
    Dim stasiun, kota, almt, tlp, fx, wb, eml, fbk, twtr, jab, nama, nip, kop1, kop2 As String
    Dim jmlkab As Integer
    Dim publicID, status, type As String
    Dim quality_usedPhaseCount, stationCount As Integer
    Dim idprefix, namapeta As String
    Dim mytt As New ToolTip
    Dim Blat, Ulat, Llon, Rlon, Latm, Lonm, Depmin As Double
    Dim lat1, lat2, lat3, lat4, lat5, lon1, lon2, lon3, lon4, lon5 As Double
    Dim y As Double
    Dim y1 As Double = 1.65
    Dim y2 As Double = 1.5
    Dim y3 As Double = 1.35
    Dim y4 As Double = 1.2
    Dim y5 As Double = 1.05
    Dim x As Double = 2.8
    Dim i As Integer = 1
    Dim daerah5 As String
    Dim daerahsize As Integer
    Dim arrayregID() As String
    Dim arrayreg() As String
    Dim arraylat() As Double
    Dim arraylon() As Double
    Dim jarak() As Double
    Dim azimuth() As String
    Dim arah() As String
    Dim sortjarak() As Double
    Dim reg1, reg2, reg3, reg4, reg5, reg6 As Integer
#Region "DATA GEMPA"
    Sub DataGempa()
        KoneksiBasisData()
        Dim dtAdapter As New MySqlDataAdapter
        Try
            koneksi.Open()
            dtSetGempa = New DataSet
            sql = "select * from tdatagempa order by `Event ID` desc limit 60"
            dtAdapter.SelectCommand = New MySqlCommand(sql, koneksi)
            dtAdapter.Fill(dtSetGempa, "tDataGempa")
            'PosisiRecord = 0
            koneksi.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub gempa_terkini()
        dtTable = dtSetGempa.Tables("tDataGempa")
        If (Not System.IO.Directory.Exists(jsonpath)) Then
            System.IO.Directory.CreateDirectory(jsonpath)
        End If
        wit = CDate(dtTable.Rows(0)(1)) & " " & dtTable.Rows(0)(2).ToString
        wit = DateAdd(DateInterval.Hour, tambahwaktu, wit)
        Dim genjson As New System.Text.StringBuilder
        Dim jsonterkini As String = jsonpath & "\gempa_terkini.js"
        genjson.AppendLine("var json_gempa_terkini = {")
        genjson.AppendLine("""type"": ""FeatureCollection"",")
        genjson.AppendLine("""name"": ""gempa_terkini"",")
        genjson.AppendLine("""crs"": { ""type"": ""name"", ""properties"": { ""name"": ""urn:ogc:def:crs:OGC:1.3:CRS84"" } },")
        genjson.AppendLine("""features"": [")
        genjson.AppendLine("{ ""type"": ""Feature"", ""properties"": { ""Event ID"": """ & dtTable.Rows(0)(0).ToString & """, ""Origin Time"": """ &
                         Format(wit, "dd-MMM-yyyy HH:mm:ss") & " " & strzonawaktu & """, ""Latitude"": " & Format(dtTable.Rows(0)(3), "0.00") &
                         ", ""Longitude"": " & Format(dtTable.Rows(0)(4), "00.00") & ", ""Depth"": " & dtTable.Rows(0)(5).ToString & ", ""Magnitude"": " & Format(dtTable.Rows(0)(6), "0.0") &
                         ", ""Remark"": """ & dtTable.Rows(0)(7).ToString & """, ""Information"": """ & dtTable.Rows(0)(8).ToString &
                         """ }, ""geometry"": { ""type"": ""Point"", ""coordinates"": [ " & Format(dtTable.Rows(0)(4), "00.00") & ", " & Format(dtTable.Rows(0)(3), "0.00") & " ] } }")
        'genjson.AppendLine("{ ""type"": ""Feature"", ""properties"": { ""Event ID"": """ & eventid & """, ""Origin Time"": """ &
        'DatePicker.Value.Date.ToString("dd-MMM-yyyy ") & ot & """, ""Latitude"": " & Format(lat, "0.00") & ", ""Longitude"": " & Format(lon, "00.00") &
        '                  ", ""Depth"": " & depth & ", ""Magnitude"": " & Format(mag, "0.0") & ", ""Remark"": """ & remark & """, ""Information"": """ & info &
        '                 """ }, ""geometry"": { ""type"": ""Point"", ""coordinates"": [ " & Format(lon, "00.00") & ", " & Format(lat, "0.00") & " ] } }")
        genjson.AppendLine("]")
        genjson.AppendLine("}")
        IO.File.WriteAllText(jsonterkini, genjson.ToString())
    End Sub
    Sub gempa_seminggu()
        Dim lastweek As Date
        Dim lastday As Date
        lastweek = DateAdd(DateInterval.Day, -7, Date.Today)
        lastday = DateAdd(DateInterval.Day, 1, Date.Today)
        Try
            koneksi.Open()
            dtAdapter = New MySqlDataAdapter("Select * from tdatagempa where `Origin Date` between '" _
                                                     & Format(lastweek, "yyyy/MM/dd hh:mm:ss") & "' and '" & Format(lastday, "yyyy/MM/dd hh:mm:ss") & "'", koneksi)
            'dtAdapter = New MySqlDataAdapter("SELECT * FROM tdatagempa WHERE DAY(`Origin Date` = " & Format(lastweek, "dd") _
            '            & "And MONTH(`Origin Date`) = " & Format(lastweek, "MM") & " And YEAR(`Origin Date`) = " & Format(lastweek, "yyyy") & "", koneksi)
            tb_week_eq.Clear()
            dtAdapter.Fill(tb_week_eq)
            koneksi.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        If (Not System.IO.Directory.Exists(jsonpath)) Then
            System.IO.Directory.CreateDirectory(jsonpath)
        End If
        'FormSearch.Export(jsonpath & "\bulanan.csv", tb_week_eq)
        Dim genjson As New System.Text.StringBuilder
        Dim jsonseminggu As String = jsonpath & "\gempa.js"
        genjson.AppendLine("var json_gempa = {")
        genjson.AppendLine("""type"": ""FeatureCollection"",")
        genjson.AppendLine("""name"": ""gempa"",")
        genjson.AppendLine("""crs"": { ""type"": ""name"", ""properties"": { ""name"": ""urn:ogc:def:crs:OGC:1.3:CRS84"" } },")
        genjson.AppendLine("""features"": [")
        For Each row As DataRow In tb_week_eq.Rows
            wit = CDate(row(1).ToString) & " " & row(2).ToString
            wit = DateAdd(DateInterval.Hour, tambahwaktu, wit)
            genjson.AppendLine("{ ""type"": ""Feature"", ""properties"": { ""Event ID"": """ & row(0).ToString & """, ""Origin Time"": """ &
                        Format(wit, "dd-MMM-yyyy HH:mm:ss") & " " & strzonawaktu & """, ""Latitude"": " & Format(row(3), "0.00") &
                        ", ""Longitude"": " & Format(row(4), "00.00") & ", ""Depth"": " & row(5).ToString & ", ""Magnitude"": " & Format(row(6), "0.0") &
                        ", ""Remark"": """ & row(7).ToString & """, ""Information"": """ & row(8).ToString &
                        """ }, ""geometry"": { ""type"": ""Point"", ""coordinates"": [ " & Format(row(4), "00.00") & ", " & Format(row(3), "0.00") & " ] } },")
        Next
        genjson.AppendLine("]")
        genjson.AppendLine("}")
        IO.File.WriteAllText(jsonseminggu, genjson.ToString())
    End Sub
    Sub Columnheader()
        Dim col1, col2, col3, col4, col5, col6, col7, col8, col9 As New ColumnHeader
        With col1
            .Text = "Event ID"
            .TextAlign = HorizontalAlignment.Right
            .Width = 100
        End With
        With col2
            .Text = "Tanggal"
            .Width = 90
        End With
        With col3
            .Text = "Jam (UTC)"
            .Width = 75
            .TextAlign = HorizontalAlignment.Center
        End With
        With col4
            .Text = "Lintang"
            .Width = 60
            .TextAlign = HorizontalAlignment.Center
        End With
        With col5
            .Text = "Bujur"
            .Width = 60
            .TextAlign = HorizontalAlignment.Center
        End With
        With col6
            .Text = "Kedlmn (km)"
            .Width = 85
            .TextAlign = HorizontalAlignment.Center
        End With
        With col7
            .Text = "Mag"
            .Width = 40
            .TextAlign = HorizontalAlignment.Center
        End With
        With col8
            .Text = "Keterangan"
            .Width = 188
        End With
        With col9
            .Text = "Informasi"
            .Width = 200
        End With
        With lvwGempa
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
    Sub BuatKodeGempa()
        If dtSetMeta.Tables("tMetadata").Rows.Count = 0 Then
            MsgBox("Lengkapi Metadata Stasiun (alt + U) terlebih dahulu", vbOKOnly, "Perhatian")
            FormMetadata.MdiParent = FormUtama
            FormMetadata.Show()
            Me.Close()
            Exit Sub
        Else
            PosisiRecord = 0
            tipe = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Tipe Stasiun").ToString
            If tipe = "STAGEOF" Then
                idprefix = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Kode Stasiun").ToString, VbStrConv.Uppercase)
                idprefix = "sta" & idprefix & "-evt"
            ElseIf tipe = "PGR"
                idprefix = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                idprefix = "pgr" & idprefix & "-evt"
            ElseIf tipe = "PUSAT"
                idprefix = "pgn-evt"
            ElseIf tipe = "BALAI"
                idprefix = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                idprefix = "pgr" & idprefix & "-evt"
            End If
            'End With
            'DataGempa()
            JD = DatePicker.Value.Date & " " & TimePicker.Text
            'wit = Me.DatePicker.Value.Date & " " & Me.TimePicker.Text
            lbEventID.Text = idprefix & JD.ToString("yyyyMMddHHmmss")
            eventid = lbEventID.Text
            'If dtSetGempa.Tables("tDataGempa").Rows.Count = 0 Then
            'lbEventID.Text = idprefix & "00001"
            'Else
            'PosisiRecord = dtSetGempa.Tables("tDataGempa").Rows.Count - 1
            'recTerakhir = dtSetGempa.Tables("tDataGempa").Rows(PosisiRecord)("Event ID").ToString
            'ambilTengah = Mid(recTerakhir, Len(idprefix) + 1, Len(recTerakhir) - 1)
            'EventID = Format(Val(ambilTengah) + 1, "00000").ToString
            'lbEventID.Text = idprefix & EventID
            'End If
            'Catch ex As Exception
            'MessageBox.Show(ex.Message)
            'End Try
        End If
    End Sub
    Sub ShowlvwGempa(ByVal data As DataTable, ByVal lvw As ListView)
        lvw.GridLines = True
        lvw.Columns.Clear()
        lvw.Items.Clear()
        Columnheader()
        'Dim row As DataRow
        For Each row As DataRow In data.Rows
            'For row = data.Rows.Count - 1 To 1 Step -1
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
        'lvwGempa.Sorting = Windows.Forms.SortOrder.Descending
    End Sub
#End Region

#Region "STORE PROCEDURE"
    Sub SimpanEvent(ByVal tambah As String)
        'Me.GetVal()
        Try
            koneksi.Open()
            cmd = New MySqlCommand()
            With cmd
                .Connection = koneksi
                .CommandType = CommandType.StoredProcedure
                .CommandText = tambah
                .Parameters.AddWithValue("@event_id", eventid)
                .Parameters.AddWithValue("@Date", MySqlDbType.Date).Value = od
                .Parameters.AddWithValue("@ot", MySqlDbType.Time).Value = ot
                .Parameters.AddWithValue("@lat", lat)
                .Parameters.AddWithValue("@lon", lon)
                .Parameters.AddWithValue("@depth", depth)
                .Parameters.AddWithValue("@mag", mag)
                .Parameters.AddWithValue("@REM", remark)
                .Parameters.AddWithValue("@info", info)
                .ExecuteNonQuery()
            End With
            MsgBox("Event berhasil disimpan")
            koneksi.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Perhatian")
        End Try
    End Sub
    Sub UpdateEvent(ByVal update As String)
        'Me.GetVal()
        Try
            koneksi.Open()
            cmd = New MySqlCommand()
            With cmd
                .Connection = koneksi
                .CommandType = CommandType.StoredProcedure
                .CommandText = update
                .Parameters.AddWithValue("@event_id", eventid)
                .Parameters.AddWithValue("@date", od)
                .Parameters.AddWithValue("@ot", ot)
                .Parameters.AddWithValue("@lat", lat)
                .Parameters.AddWithValue("@lon", lon)
                .Parameters.AddWithValue("@depth", depth)
                .Parameters.AddWithValue("@mag", mag)
                .Parameters.AddWithValue("@rem", remark)
                .Parameters.AddWithValue("@info", info)
                .ExecuteNonQuery()
            End With
            MsgBox("Event berhasil diupdate")
            koneksi.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Perhatian")
        End Try
    End Sub
    Sub HapusEvent(ByVal hapus As String)
        'Me.GetVal()
        Try
            koneksi.Open()
            cmd = New MySqlCommand()
            With cmd
                .Connection = koneksi
                .CommandType = CommandType.StoredProcedure
                .CommandText = hapus
                .Parameters.AddWithValue("@event_id", eventid)
                .ExecuteNonQuery()
            End With
            MsgBox("Event berhasil dihapus")
            koneksi.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Perhatian")
        End Try
    End Sub
#End Region

#Region "KALKULASI"
    Sub QuerySeiscomP3()
        publicID = dtSetSC.Tables("tseisquery").Rows(PosisiRecord)("publicID").ToString
        time_value = DateTime.Parse(dtSetSC.Tables("tseisquery").Rows(PosisiRecord)("time_value").ToString)
        origin = time_value.ToString("yyyy-MM-dd HH:mm:ss")
        status = dtSetSC.Tables("tseisquery").Rows(PosisiRecord)("evaluationMode").ToString
        quality_usedPhaseCount = dtSetSC.Tables("tseisquery").Rows(PosisiRecord)("quality_usedPhaseCount").ToString
        type = dtSetSC.Tables("tseisquery").Rows(PosisiRecord)("type").ToString
        stationCount = dtSetSC.Tables("tseisquery").Rows(PosisiRecord)("stationCount").ToString
        DatePicker.Text = time_value.Date
        TimePicker.Text = Format(time_value, "HH:mm:ss")
        txtLat.Text = dtSetSC.Tables("tseisquery").Rows(PosisiRecord)("ROUND(Origin.latitude_value,2)").ToString
        txtLon.Text = dtSetSC.Tables("tseisquery").Rows(PosisiRecord)("ROUND(Origin.longitude_value,2)").ToString
        txtDepth.Text = dtSetSC.Tables("tseisquery").Rows(PosisiRecord)("ROUND(Origin.depth_value)").ToString
        txtMag.Text = dtSetSC.Tables("tseisquery").Rows(PosisiRecord)("ROUND(Magnitude.magnitude_value,1)").ToString
        txtLokasi.Text = dtSetSC.Tables("tseisquery").Rows(PosisiRecord)("text").ToString
    End Sub
    Sub QueryFormating()
        DatePicker.CustomFormat = "dd-MMM-yyyy"
        wit = DatePicker.Value.Date & " " & TimePicker.Text
        wit = DateAdd(DateInterval.Hour, 9, wit)
        If btSave.Text = "&Save" Then
            BuatKodeGempa()
        End If
        If IsNumeric(txtLat.Text) Then
            lat = txtLat.Text
            txtLat.Text = Format(lat, "00.00")
            If lat < 0 Then
                strlintang = "LS"
            Else : strlintang = "LU"
            End If
            lintang = Format(Abs(lat), "00.00")
        End If
        If IsNumeric(txtLon.Text) Then
            lon = txtLon.Text
            txtLon.Text = Format(lon, "000.00")
            If lon < 0 Then
                strbujur = "BB"
            Else : strbujur = "BT"
            End If
            bujur = Format(Abs(lon), "000.00")
            Hitung()
        End If
        If IsNumeric(txtDepth.Text) Then
            depth = txtDepth.Text
        End If
        If IsNumeric(txtMag.Text) Then
            mag = txtMag.Text
            If mag < 9.5 Then
                txtMag.Text = Format(mag, "0.0")
            ElseIf mag >= 9.5 Then
                Select Case MsgBox("Benar Magnitudo Gempa = " & mag & " ?", MsgBoxStyle.YesNo, "Perhatian")
                    Case MsgBoxResult.Yes
                        txtMag.Text = Format(mag, "0.0")
                    Case MsgBoxResult.No
                        txtMag.Focus()
                        txtMag.SelectAll()
                End Select
                Exit Sub
            End If
            If txtDepth.Text <= 60 And txtMag.Text >= 6.5 Then
                Select Case MsgBox("Berpotensi Tsunami?", MsgBoxStyle.YesNo, "Perhatian")
                    Case MsgBoxResult.Yes
                        tsunami = "Gempa ini BERPOTENSI TSUNAMI, Untuk diteruskan Kepada Masyarakat"
                        If txtInfo.Text = "Informasi Tambahan (Tsunami atau Dirasakan)" Or String.IsNullOrWhiteSpace(txtInfo.Text) Then
                            txtInfo.Text = tsunami
                        Else
                            info = txtInfo.Text
                        End If
                    Case MsgBoxResult.No
                        tsunami = "Gempa ini TIDAK BERPOTENSI TSUNAMI"
                End Select
            Else
                tsunami = "Gempa ini TIDAK BERPOTENSI TSUNAMI"
            End If
            If PBEpisenter.Image Is Nothing Then
                'Me.btGenmap.Text = "&Generate Map"
            Else
                btGenmap.Text = "Update Ma&p"
            End If
        End If
        GetVal()
        Hitung()
        Berita()
        btNarasi.Enabled = True
        btShake.Enabled = True
        btGenmap.Visible = True
    End Sub
    Sub GetVal()
        If String.IsNullOrWhiteSpace(DatePicker.Text) Then
            MsgBox("Tanggal kejadian gempa belum dimasukan", MsgBoxStyle.OkOnly, "Perhatian")
            DatePicker.Focus()
            SendKeys.Send("{F4}")
            Exit Sub
        ElseIf DatePicker.Value.Date > Date.Today Then
            MsgBox("Periksa masukan tanggal", MsgBoxStyle.OkOnly, "Perhatian")
            DatePicker.Focus()
            SendKeys.Send("{F4}")
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(TimePicker.Text) Then
            MsgBox("Waktu kejadian gempa belum dimasukan", MsgBoxStyle.OkOnly, "Perhatian")
            TimePicker.Focus()
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtLat.Text) Then
            MsgBox("Koordinat gempa belum dimasukan", MsgBoxStyle.OkOnly, "Perhatian")
            txtLat.Focus()
            txtLat.SelectAll()
            Exit Sub
        ElseIf Not IsNumeric(txtLat.Text) Then
            MsgBox("Koordinat Gempa salah!", MsgBoxStyle.OkOnly, "Perhatian")
            txtLat.Focus()
            txtLat.SelectAll()
            Exit Sub
        ElseIf txtLat.Text < -16 Or txtLat.Text > 11 Then
            MsgBox("Lintang diluar wilayah Indonesia!", MsgBoxStyle.OkOnly, "Perhatian")
            txtLat.Focus()
            txtLat.SelectAll()
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtLon.Text) Then
            MsgBox("Koordinat gempa belum dimasukan", MsgBoxStyle.OkOnly, "Perhatian")
            txtLon.Focus()
            txtLon.SelectAll()
            Exit Sub
        ElseIf Not IsNumeric(txtLon.Text) Then
            MsgBox("Koordinat Gempa salah!", MsgBoxStyle.OkOnly, "Perhatian")
            txtLon.Focus()
            txtLon.SelectAll()
            Exit Sub
        ElseIf txtLon.Text < 90 Or txtLon.Text > 146 Then
            MsgBox("Bujur diluar wilayah Indonesia!", MsgBoxStyle.OkOnly, "Perhatian")
            txtLon.Focus()
            txtLon.SelectAll()
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtDepth.Text) Then
            MsgBox("Kedalaman gempa belum dimasukan", MsgBoxStyle.OkOnly, "Perhatian")
            txtDepth.Focus()
            txtDepth.SelectAll()
            Exit Sub
        ElseIf Not IsNumeric(txtDepth.Text) Then
            MsgBox("Kedalaman salah!", MsgBoxStyle.OkOnly, "Perhatian")
            txtDepth.Focus()
            txtDepth.SelectAll()
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtMag.Text) Then
            MsgBox("Magnitudo gempa belum dimasukan", MsgBoxStyle.OkOnly, "Perhatian")
            txtMag.Focus()
            txtMag.SelectAll()
            Exit Sub
        ElseIf Not IsNumeric(txtMag.Text) Then
            MsgBox("Magnitudo salah!", MsgBoxStyle.OkOnly, "Perhatian")
            txtMag.Focus()
            txtMag.SelectAll()
            Exit Sub
        End If
        eventid = lbEventID.Text
        od = DatePicker.Value.Date.ToString("yyyy/MM/dd")
        'od = od.ToString("yyyy/MM/dd")
        ot = TimePicker.Text
        lat = Val(txtLat.Text)
        lon = Val(txtLon.Text)
        depth = Val(txtDepth.Text)
        mag = Val(txtMag.Text)
        If Not String.IsNullOrWhiteSpace(lblDaerah1.Text) And Not String.IsNullOrWhiteSpace(lblDaerah2.Text) Then
            remark = lblDaerah1.Text & ", " & lblDaerah2.Text
        ElseIf Not String.IsNullOrWhiteSpace(lblDaerah1.Text) Then
            remark = lblDaerah1.Text
        Else : remark = ""
        End If
        'If Me.chkDirasakan.Checked = True Then
        If txtInfo.Text = "Informasi Tambahan (Tsunami atau Dirasakan)" Or String.IsNullOrWhiteSpace(txtInfo.Text) Then
            'MsgBox("Informasi tambahan belum dimasukan", MsgBoxStyle.OkOnly, "Perhatian")
            'Me.txtInfo.Focus()
            'Me.txtInfo.SelectAll()
            'Exit Sub
            info = ""
        Else
            Dim text As String = txtInfo.Text
            info = text.Replace(System.Environment.NewLine, " ")
            txtInfo.Text = info
        End If
        'Else
        ''info = ""
        'End If
        lokasi = txtLokasi.Text
        PosisiRecord = 0
        If dtSetMeta.Tables("tMetadata").Rows.Count = 0 Then
            stasiun = "STASIUN GEOFISIKA KELAS I KARANGPANJANG AMBON"
            wb = "http://www.bmkg.go.id"
            fbk = "www.bmkg.go.id"
        Else
            stasiun = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Nama Stasiun").ToString
            kota = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Kota Stasiun").ToString
            almt = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Alamat").ToString
            tlp = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Telp").ToString
            fx = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Fax").ToString
            wb = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Website").ToString
            eml = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Email").ToString
            fbk = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Facebook").ToString
            twtr = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Twitter").ToString
            jab = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Jabatan").ToString
            nama = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Nama").ToString
            nip = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("NIP").ToString
            jmlkab = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Jumlah Kab/Kota").ToString
        End If
        If String.IsNullOrWhiteSpace(stasiun) Then
            stasiun = "STASIUN GEOFISIKA KELAS I KARANGPANJANG AMBON"
        End If
        If String.IsNullOrWhiteSpace(wb) Then
            wb = "http://www.bmkg.go.id"
        End If
        'If String.IsNullOrWhiteSpace(Me.fbk) Then
        'Me.fbk = "www.bmkg.go.id"
        'End If
        If Not String.IsNullOrWhiteSpace(fx) Then
            kop1 = almt & ", Telp: " & tlp & ", Fax: " & fx
        Else : kop1 = almt & ", Telp: " & tlp
        End If
        If Not String.IsNullOrWhiteSpace(fbk) And Not String.IsNullOrWhiteSpace(twtr) Then
            kop2 = "Website: " & wb & ", E-Mail: " & eml & ", Facebook Page: " & fbk & ", Twitter: " & twtr
        ElseIf String.IsNullOrWhiteSpace(fbk) And Not String.IsNullOrWhiteSpace(twtr) Then
            kop2 = "Website: " & wb & ", E-Mail: " & eml & ", Twitter: " & twtr
        ElseIf Not String.IsNullOrWhiteSpace(fbk) And String.IsNullOrWhiteSpace(twtr) Then
            kop2 = "Website: " & wb & ", E-Mail: " & eml & ", Facebook Page: " & fbk
        Else : kop2 = "Website: " & wb & ", E-Mail: " & eml
        End If
        'strzonawaktu = ""
        'tambahwaktu = 0
        wit = DatePicker.Value.Date & " " & TimePicker.Text
        wit = DateAdd(DateInterval.Hour, tambahwaktu, wit)
        If lat < 0 Then
            strlintang = "LS"
        Else : strlintang = "LU"
        End If
        lintang = Format(Abs(lat), "00.00")
        If lon < 0 Then
            strbujur = "BB"
        Else : strbujur = "BT"
        End If
        bujur = Format(Abs(lon), "000.00")

        Blat = lat - 2.25
        Ulat = lat + 2.25
        Llon = lon - 3
        Rlon = lon + 3
        Latm = lat - 2
        Lonm = lon - 1
        Depmin = -depth - 100
    End Sub
    Sub Hitung()
        'FormDaerah.DataDaerah()
        daerahsize = dtSetDaerah.Tables("tDaerah").Rows.Count
        ReDim arrayregID(daerahsize)
        ReDim arrayreg(daerahsize)
        ReDim arraylat(daerahsize)
        ReDim arraylon(daerahsize)
        ReDim jarak(daerahsize)
        ReDim azimuth(daerahsize)
        ReDim arah(daerahsize)
        ReDim sortjarak(daerahsize)
        For rec = 0 To dtSetDaerah.Tables("tDaerah").Rows.Count - 1
            arrayregID(rec) = dtSetDaerah.Tables("tDaerah").Rows(rec)("ID")
            arrayreg(rec) = dtSetDaerah.Tables("tDaerah").Rows(rec)("Daerah")
            arraylat(rec) = dtSetDaerah.Tables("tDaerah").Rows(rec)("Lintang")
            arraylon(rec) = dtSetDaerah.Tables("tDaerah").Rows(rec)("Bujur")
            jarak(rec) = Acos(Cos(radians(90 - arraylat(rec))) * Cos(radians(90 - lat)) + Sin(radians(90 - arraylat(rec))) * Sin(radians(90 - lat)) * Cos(radians(arraylon(rec) - lon))) * 6371
            azimuth(rec) = degrees(Atan2((lon - arraylon(rec)), (lat - arraylat(rec))))
            If azimuth(rec) < 0 Then
                azimuth(rec) = azimuth(rec) + 360
            End If
            If azimuth(rec) > 337.5 Then
                arah(rec) = "Utara"
            ElseIf azimuth(rec) > 292.5 Then
                arah(rec) = "Baratlaut"
            ElseIf azimuth(rec) > 247.5 Then
                arah(rec) = "Barat"
            ElseIf azimuth(rec) > 202.5 Then
                arah(rec) = "Baratdaya"
            ElseIf azimuth(rec) > 157.5 Then
                arah(rec) = "Selatan"
            ElseIf azimuth(rec) > 112.5 Then
                arah(rec) = "Tenggara"
            ElseIf azimuth(rec) > 67.5 Then
                arah(rec) = "Timur"
            ElseIf azimuth(rec) > 22.5 Then
                arah(rec) = "Timurlaut"
            Else : arah(rec) = "Utara"
            End If
        Next
        Array.Copy(jarak, sortjarak, daerahsize)
        Array.Sort(sortjarak)
        If daerahsize = 1 Then
            reg1 = Array.IndexOf(jarak, sortjarak(1))
            lblDaerah1.Text = CInt(sortjarak(1)) & " km " & arah(reg1) & " " & arrayreg(reg1)
            lat1 = arraylat(reg1)
            lon1 = arraylon(reg1)
        ElseIf daerahsize = 2 Then
            reg1 = Array.IndexOf(jarak, sortjarak(1))
            reg2 = Array.IndexOf(jarak, sortjarak(2))
            lblDaerah1.Text = CInt(sortjarak(1)) & " km " & arah(reg1) & " " & arrayreg(reg1)
            lblDaerah2.Text = CInt(sortjarak(2)) & " km " & arah(reg2) & " " & arrayreg(reg2)
            lat1 = arraylat(reg1)
            lon1 = arraylon(reg1)
            lat2 = arraylat(reg2)
            lon2 = arraylon(reg2)
        ElseIf daerahsize = 3 Then
            reg1 = Array.IndexOf(jarak, sortjarak(1))
            reg2 = Array.IndexOf(jarak, sortjarak(2))
            reg3 = Array.IndexOf(jarak, sortjarak(3))
            lblDaerah1.Text = CInt(sortjarak(1)) & " km " & arah(reg1) & " " & arrayreg(reg1)
            lblDaerah2.Text = CInt(sortjarak(2)) & " km " & arah(reg2) & " " & arrayreg(reg2)
            lblDaerah3.Text = CInt(sortjarak(3)) & " km " & arah(reg3) & " " & arrayreg(reg3)
            lat1 = arraylat(reg1)
            lon1 = arraylon(reg1)
            lat2 = arraylat(reg2)
            lon2 = arraylon(reg2)
            lat3 = arraylat(reg3)
            lon3 = arraylon(reg3)
        ElseIf daerahsize > 3 Then
            reg1 = Array.IndexOf(jarak, sortjarak(1))
            reg2 = Array.IndexOf(jarak, sortjarak(2))
            reg3 = Array.IndexOf(jarak, sortjarak(3))
            reg4 = Array.IndexOf(jarak, sortjarak(4))
            reg5 = Array.IndexOf(jarak, sortjarak(5))
            lblDaerah1.Text = CInt(sortjarak(1)) & " km " & arah(reg1) & " " & arrayreg(reg1)
            lblDaerah2.Text = CInt(sortjarak(2)) & " km " & arah(reg2) & " " & arrayreg(reg2)
            lblDaerah3.Text = CInt(sortjarak(3)) & " km " & arah(reg3) & " " & arrayreg(reg3)
            lblDaerah4.Text = CInt(sortjarak(4)) & " km " & arah(reg4) & " " & arrayreg(reg4)
            daerah5 = CInt(sortjarak(5)) & " km " & arah(reg5) & " " & arrayreg(reg5)
            lat1 = arraylat(reg1)
            lon1 = arraylon(reg1)
            lat2 = arraylat(reg2)
            lon2 = arraylon(reg2)
            lat3 = arraylat(reg3)
            lon3 = arraylon(reg3)
            lat4 = arraylat(reg4)
            lon4 = arraylon(reg4)
            lat5 = arraylat(reg5)
            lon5 = arraylon(reg5)
            'ElseIf daerahsize = 5 Then
            '   reg1 = Array.IndexOf(jarak, sortjarak(1))
            '  reg2 = Array.IndexOf(jarak, sortjarak(2))
            ' reg3 = Array.IndexOf(jarak, sortjarak(3))
            'reg4 = Array.IndexOf(jarak, sortjarak(4))
            '    reg5 = Array.IndexOf(jarak, sortjarak(5))
            '   lblDaerah1.Text = CInt(sortjarak(1)) & " km " & arah(reg1) & " " & arrayreg(reg1)
            '  lblDaerah2.Text = CInt(sortjarak(2)) & " km " & arah(reg2) & " " & arrayreg(reg2)
            '            lblDaerah3.Text = CInt(sortjarak(3)) & " km " & arah(reg3) & " " & arrayreg(reg3)
            '           lblDaerah4.Text = CInt(sortjarak(4)) & " km " & arah(reg4) & " " & arrayreg(reg4)
            '          lblDaerah5.Text = CInt(sortjarak(5)) & " km " & arah(reg5) & " " & arrayreg(reg5)
            '     ElseIf daerahsize > 5 Then
            '        reg1 = Array.IndexOf(jarak, sortjarak(1))
            '       reg2 = Array.IndexOf(jarak, sortjarak(2))
            '      reg3 = Array.IndexOf(jarak, sortjarak(3))
            '     reg4 = Array.IndexOf(jarak, sortjarak(4))
            '    reg5 = Array.IndexOf(jarak, sortjarak(5))
            ''   reg6 = Array.IndexOf(jarak, sortjarak(6))
            ' lblDaerah1.Text = CInt(sortjarak(1)) & " km " & arah(reg1) & " " & arrayreg(reg1)
            'lblDaerah2.Text = CInt(sortjarak(2)) & " km " & arah(reg2) & " " & arrayreg(reg2)
            '           lblDaerah3.Text = CInt(sortjarak(3)) & " km " & arah(reg3) & " " & arrayreg(reg3)
            '            lblDaerah4.Text = CInt(sortjarak(4)) & " km " & arah(reg4) & " " & arrayreg(reg4)
            '          lblDaerah5.Text = CInt(sortjarak(5)) & " km " & arah(reg5) & " " & arrayreg(reg5)
            '         lblDaerah6.Text = CInt(sortjarak(6)) & " km " & arah(reg6) & " " & arrayreg(reg6)
        End If
        If Not String.IsNullOrWhiteSpace(lblDaerah1.Text) And Not String.IsNullOrWhiteSpace(lblDaerah2.Text) Then
            remark = lblDaerah1.Text & ", " & lblDaerah2.Text
        ElseIf Not String.IsNullOrWhiteSpace(lblDaerah1.Text) Then
            remark = lblDaerah1.Text
        Else : remark = ""
        End If
    End Sub
    Sub Berita()
        If txtInfo.Text = "Informasi Tambahan (Tsunami atau Dirasakan)" Or String.IsNullOrWhiteSpace(txtInfo.Text) Then
            txtBerita.Text = "Info Gempa Mag:" & Format(mag, "0.0") & " SR, " &
                       Format(wit, "dd-MMM-yy HH:mm:ss ") & strzonawaktu & ", Lok:" &
                       lintang & " " & strlintang & "-" & bujur & " " & strbujur &
                       " (" & remark & "), Kedlmn:" & depth & " km ::BMKG" & sufx
        Else
            info = txtInfo.Text
            txtBerita.Text = "Info Gempa Mag:" & Format(mag, "0.0") & " SR, " &
                        Format(wit, "dd-MMM-yy HH:mm:ss ") & strzonawaktu & ", Lok:" &
                        lintang & " " & strlintang & "-" & bujur & " " & strbujur &
                        " (" & remark & "), Kedlmn:" & depth & " km, " & info & " ::BMKG" & sufx
        End If
    End Sub
#End Region

#Region "METHODS & EVENTS"
    Private Sub FormInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'DataGempa()
        'FormNarasi.DataNarasi()
        KoneksiBasisData()
        LayarBersih()
        Navigasi(True)
        TextboxEnable(True)
        FormUtama.mnUtama.BackColor = Color.Gainsboro
        btCopy.Enabled = False
        btCopy.Text = "&Copy"
        strlintang = "LU"
        strbujur = "BT"
        If dtSetGempa.Tables("tDataGempa").Rows.Count > 0 Then
            ShowlvwGempa(dtSetGempa.Tables("tDataGempa"), lvwGempa)
        Else
            lvwGempa.GridLines = True
            lvwGempa.Columns.Clear()
            lvwGempa.Items.Clear()
            Columnheader()
        End If
        DatePicker.Focus()
        If dtSetMeta.Tables("tMetadata").Rows.Count <> 0 Then
            PosisiRecord = 0
            tipe = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Tipe Stasiun").ToString
            kota = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Kota Stasiun").ToString, VbStrConv.ProperCase)
            If tipe = "STAGEOF" Then
                sufx = "-" & dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Kode Stasiun").ToString
                tipe = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.ProperCase)
                wtrmark = "echo 4.2 0.15 Stasiun Geofisika " & tipe & " | pstext -J -R -F+f9p,Helvetica -N -O -K >> %ps%"
            ElseIf tipe = "PGR"
                sufx = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                wtrmark = "echo 4.2 0.15 Pusat Gempa Regional " & sufx & " " & kota & " | pstext -J -R -F+f9p,Helvetica -N -O -K >> %ps%"
                sufx = "-PGR " & sufx
            ElseIf tipe = "PUSAT"
                sufx = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString
                wtrmark = "echo 4.2 0.15 Pusat " & sufx & " BMKG | pstext -J -R -F+f9p,Helvetica -N -O -K >> %ps%"
                sufx = ""
            ElseIf tipe = "BALAI"
                sufx = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                wtrmark = "echo 4.2 0.15 Balai Besar Wilayah " & sufx & " " & kota & " | pstext -J -R -F+f9p,Helvetica -N -O -K >> %ps%"
                sufx = "-PGR " & sufx
            End If
            If dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Zona Waktu").ToString = "WIB" Then
                tambahwaktu = 7
                strzonawaktu = "WIB"
            ElseIf dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Zona Waktu").ToString = "WITA" Then
                tambahwaktu = 8
                strzonawaktu = "WITA"
            ElseIf dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Zona Waktu").ToString = "WIT" Then
                tambahwaktu = 9
                strzonawaktu = "WIT"
            Else : tambahwaktu = 0
                strzonawaktu = "UTC"
            End If
        Else
            tambahwaktu = 0
            strzonawaktu = "UTC"
        End If
        'btSave.BringToFront()
    End Sub
    Private Sub DatePicker_ValueChanged(sender As Object, e As EventArgs) Handles DatePicker.ValueChanged
        'SendKeys.Send("{right}")
    End Sub
    Private Sub TimePicker_ValueChanged(sender As Object, e As EventArgs) Handles TimePicker.ValueChanged
        SendKeys.Send("{right}")
    End Sub
    Private Sub DatePicker_Enter(sender As Object, e As EventArgs) Handles DatePicker.Enter
        DatePicker.Format = DateTimePickerFormat.Custom
        DatePicker.CustomFormat = "dd/MM/yyyy"
        If btCopy.Enabled = True Then
            btCopy.Enabled = False
        End If
        btCopy.Text = "&Copy"
        mytt.Show("Origin Time in UTC", DatePicker)
    End Sub
    Private Sub DatePicker_Leave(sender As Object, e As EventArgs) Handles DatePicker.Leave
        mytt.Hide(DatePicker)
    End Sub
    Private Sub TimePicker_Enter(sender As Object, e As EventArgs) Handles TimePicker.Enter
        mytt.Show("Origin Time in UTC", TimePicker)
    End Sub
    Private Sub TimePicker_Leave(sender As Object, e As EventArgs) Handles TimePicker.Leave
        mytt.Hide(TimePicker)
    End Sub
    Private Sub txtLat_Enter(sender As Object, e As EventArgs) Handles txtLat.Enter
        mytt.Show("For south latitude use minus sign ("" - "")", txtLat)
    End Sub
    Private Sub txtLat_Leave(sender As Object, e As EventArgs) Handles txtLat.Leave
        mytt.Hide(txtLat)
    End Sub
    Private Sub btCopy_Click(sender As Object, e As EventArgs) Handles btCopy.Click
        Clipboard.Clear()
        If Len(txtBerita.Text) > 160 Then
            MsgBox("Informasi Gempa lebih dari 1 pesan, " & vbCrLf & "edit sebelum di-diseminasikan!", MsgBoxStyle.OkOnly, "Perhatian")
        End If
        If String.IsNullOrWhiteSpace(txtBerita.Text) Then
        Else
            Clipboard.SetText(txtBerita.Text)
            btCopy.Enabled = False
        End If
    End Sub
    Private Sub btCopy_EnabledChanged(sender As Object, e As EventArgs) Handles btCopy.EnabledChanged
        If btCopy.Enabled = True Then
            btCopy.Text = "&Copy"
        Else : btCopy.Text = "Copied"
        End If
    End Sub
    Private Sub lvwGempa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwGempa.SelectedIndexChanged
        Navigasi(False)
        btEdit.BringToFront()
        TextboxEnable(False)
        'Me.txtInfo.Enabled = False
        If lvwGempa.SelectedItems.Count > 0 Then
            Dim lvi As ListViewItem = lvwGempa.SelectedItems(0)
            lbEventID.Text = lvi.SubItems(0).Text
            DatePicker.Text = lvi.SubItems(1).Text
            TimePicker.Text = lvi.SubItems(2).Text
            txtLat.Text = lvi.SubItems(3).Text
            txtLon.Text = lvi.SubItems(4).Text
            txtDepth.Text = lvi.SubItems(5).Text
            txtMag.Text = lvi.SubItems(6).Text
            If Not String.IsNullOrWhiteSpace(lvi.SubItems(8).Text) Then
                'Me.chkDirasakan.Checked = True
                txtInfo.Text = lvi.SubItems(8).Text
            Else
                'Me.chkDirasakan.Checked = False
                txtInfo.Text = "Informasi Tambahan (Tsunami atau Dirasakan)"
            End If
            If System.IO.File.Exists(directoryapp & "\gempa" & lbEventID.Text & ".jpg") Then
                Dim fs As System.IO.FileStream
                fs = New System.IO.FileStream(directoryapp & "\gempa" & lbEventID.Text & ".jpg",
                     IO.FileMode.Open, IO.FileAccess.Read)
                PBEpisenter.Image = System.Drawing.Image.FromStream(fs)
                fs.Close()
                btSaveMap.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption)
                btSaveMap.Enabled = True
                MapProgress.Visible = False
                btGenmap.Visible = False
            Else
                PBEpisenter.Image = Nothing
                btGenmap.Text = "&Generate Map"
            End If
            '    For row As DataRow In dtNarasi.rows then

            'Next
            If koneksi.State = ConnectionState.Open Then
                koneksi.Close()
            End If
            drNarasi = dtSetNarasi.Tables("tNarasi").Select("`ID`='" & lvi.SubItems(0).Text & "'")
            If drNarasi.Length > 0 Then
                btNarasi.Text = "Edit Narasi"
            Else
                btNarasi.Text = "Buat Narasi"
            End If
            'Try
            ' koneksi.Open()
            ' cmd = New MySqlCommand()
            ' With cmd
            ' .Connection = koneksi
            ' .CommandType = CommandType.Text
            ' .CommandText = "select `Waktu Buat` from tnarasi where `ID`='" & lvi.SubItems(0).Text & "'"
            ' strResult = .ExecuteScalar()
            ' End With
            ' koneksi.Close()
            ' Catch ex As Exception
            ' MsgBox(ex.Message, MsgBoxStyle.Information, "Perhatian")
            ' End Try
            ' If IsNothing(strResult) Then
            ' btNarasi.Text = "Buat Narasi"
            ' Else
            '         btNarasi.Text = "Edit Narasi"
            ' End If
        End If
        lblBersih()
        txtBerita.Clear()
        'btSave.BringToFront()
    End Sub
    Private Sub lblDaerah1_TextChanged(sender As Object, e As EventArgs) Handles lblDaerah1.TextChanged
        lblDaerah.Visible = True
    End Sub
    Private Sub btQuerySC_Click(sender As Object, e As EventArgs) Handles btQuerySC.Click
        If dtSetSeisConf.Tables("tserver").Rows.Count = 0 Then
            Select Case MsgBox("Apakah SDIGB sudah terkoneksi dengan SeiscomP3?", MsgBoxStyle.YesNo, "Perhatian")
                Case MsgBoxResult.Yes
                    If Application.OpenForms.OfType(Of FormSettings).Any Then
                        FormSettings.BringToFront()
                    Else
                        FormSettings.Show()
                    End If
            End Select
            Exit Sub
        Else
            PosisiRecord = 0
            scHost = dtSetSeisConf.Tables("tserver").Rows(PosisiRecord)("host").ToString
            scUser = dtSetSeisConf.Tables("tserver").Rows(PosisiRecord)("user").ToString
            scPass = dtSetSeisConf.Tables("tserver").Rows(PosisiRecord)("pass").ToString
            scDB = dtSetSeisConf.Tables("tserver").Rows(PosisiRecord)("db_name").ToString
            sc_con = "server=" & scHost & ";user id=" & scUser & ";password=" & scPass & ";database=" & scDB
            sc_koneksi = New MySqlConnection(sc_con)
            Dim dtAdapter As New MySqlDataAdapter
            Try
                sc_koneksi.Open()
                dtSetSC = New DataSet
                sql = "select PEvent.publicID, Origin.time_value, Origin.evaluationMode, Origin.quality_usedPhaseCount, ROUND(Magnitude.magnitude_value,1), Magnitude.type, Magnitude.stationCount, ROUND(Origin.latitude_value,2), ROUND(Origin.longitude_value,2), ROUND(Origin.depth_value), EventDescription.text from Event, PublicObject as PEvent, Origin, PublicObject as POrigin, Magnitude, PublicObject as PMagnitude, EventDescription, PublicObject as PEventDescription where Event._oid=PEvent._oid and Origin._oid=POrigin._oid and Magnitude._oid=PMagnitude._oid and Event.preferredOriginID=POrigin.publicID and Event.preferredMagnitudeID=PMagnitude.publicID and EventDescription._parent_oid=PEvent._oid order by Origin.time_value desc limit 1"
                REM seiscomP2008 sql = "select PEvent.publicID, Origin.time_value, Origin.status, Origin.quality_definingPhaseCount, ROUND(NetworkMagnitude.magnitude_value,1), NetworkMagnitude.type, NetworkMagnitude.stationCount, ROUND(Origin.latitude_value,2), ROUND(Origin.longitude_value,2), ROUND(Origin.depth_value), Event.description from Event, PublicObject as PEvent, Origin, PublicObject as POrigin, NetworkMagnitude, PublicObject as PNetworkMagnitude where Event._oid=PEvent._oid and Origin._oid=POrigin._oid and NetworkMagnitude._oid=PNetworkMagnitude._oid and Event.preferredOriginID=POrigin.publicID and Event.preferredMagnitudeID=PNetworkMagnitude.publicID order by Origin.time_value desc limit 1"
                dtAdapter.SelectCommand = New MySqlCommand(sql, sc_koneksi) With {.CommandTimeout = 600}
                dtAdapter.Fill(dtSetSC, "tseisquery")
                sc_koneksi.Close()
            Catch ex As Exception
                MessageBox.Show("Koneksi error : " + ex.Message & vbCrLf & vbCrLf & """Check network connection or contact your administrator""")
                Exit Sub
            End Try
            Navigasi(True)
            TextboxEnable(True)
            btCopy.Text = "&Copy"
            QuerySeiscomP3()
            QueryFormating()
            btGenmap.BringToFront()
            btSaveMap.Enabled = False
        End If
    End Sub
    Private Sub btInput_Click(sender As Object, e As EventArgs) Handles btInput.Click
        btSave.Text = "&Save"
        Navigasi(True)
        TextboxEnable(True)
        LayarBersih()
        lblBersih()
        txtBerita.Clear()
        DatePicker.Focus()
        btSave.BringToFront()
    End Sub
    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        GetVal()
        Hitung()
        Berita()
        gempa_seminggu()
        If txtLokasi.Text = String.Empty Then
            If btSave.Text = "&Save" Then
                If String.IsNullOrEmpty(lbEventID.Text) Then
                    BuatKodeGempa()
                End If
                modFungsi.simpangempa(vevent_id:=eventid, vod:=od, vot:=ot, vlat:=lat, vlon:=lon,
                                      vdepth:=depth, vmag:=mag, vremark:=remark, vinfo:=info)
                'Me.SimpanEvent("gempaSAVE")
            ElseIf btSave.Text = "&Update" Then
                modFungsi.updategempa(vevent_id:=eventid, vod:=od, vot:=ot, vlat:=lat, vlon:=lon,
                                      vdepth:=depth, vmag:=mag, vremark:=remark, vinfo:=info)
                'Me.UpdateEvent("gempaUPDATE")
                btSave.Text = "&Save"
            End If
        Else
            If btSave.Text = "&Save" Then
                If String.IsNullOrEmpty(lbEventID.Text) Then
                    BuatKodeGempa()
                End If
                modFungsi.simpangempa(vevent_id:=eventid, vod:=od, vot:=ot, vlat:=lat, vlon:=lon,
                                      vdepth:=depth, vmag:=mag, vremark:=remark, vinfo:=info)
                koneksi.Close()
                modFungsi.simpansc_data(vevent_id:=eventid, vpublicID:=publicID, vtime_value:=origin, vsttus:=status,
                                        vPhaseCount:=quality_usedPhaseCount, vmag_type:=type, vstationCount:=stationCount, vdescription:=lokasi)
            ElseIf btSave.Text = "&Update" Then
                modFungsi.updategempa(vevent_id:=eventid, vod:=od, vot:=ot, vlat:=lat, vlon:=lon,
                                      vdepth:=depth, vmag:=mag, vremark:=remark, vinfo:=info)
                koneksi.Close()
                modFungsi.updatesc_data(vevent_id:=eventid, vpublicID:=publicID, vtime_value:=origin, vsttus:=status,
                                        vPhaseCount:=quality_usedPhaseCount, vmag_type:=type, vstationCount:=stationCount, vdescription:=lokasi)
                btSave.Text = "&Save"
            End If
        End If
        TextboxEnable(False)
        Navigasi(False)
        btGenmap.Visible = False
        MapProgress.Visible = False
        btDelete.Enabled = False
        DataGempa()
        If dtSetGempa.Tables("tDataGempa").Rows.Count > 0 Then
            ShowlvwGempa(dtSetGempa.Tables("tDataGempa"), lvwGempa)
        End If
        gempa_terkini()
        LayarBersih()
        If btCopy.Enabled = False Then
            btCopy.Enabled = True
        End If
        btCopy.BringToFront()
        btCopy.Focus()
    End Sub
    Private Sub btEdit_Click(sender As Object, e As EventArgs) Handles btEdit.Click
        If lvwGempa.SelectedItems.Count > 0 Then
            Dim lvi As ListViewItem = lvwGempa.SelectedItems(0)
            lbEventID.Text = lvi.SubItems(0).Text
            DatePicker.Text = lvi.SubItems(1).Text
            TimePicker.Text = lvi.SubItems(2).Text
            txtLat.Text = lvi.SubItems(3).Text
            txtLon.Text = lvi.SubItems(4).Text
            txtDepth.Text = lvi.SubItems(5).Text
            txtMag.Text = lvi.SubItems(6).Text
            If Not String.IsNullOrWhiteSpace(lvi.SubItems(8).Text) Then
                'Me.chkDirasakan.Checked = True
                'Me.txtInfo.Enabled = True
                txtInfo.Text = lvi.SubItems(8).Text
            Else
                'Me.chkDirasakan.Enabled = False
                'Me.txtInfo.Enabled = False
                txtInfo.Text = "Informasi Tambahan (Tsunami atau Dirasakan)"
            End If
        End If
        btSave.Text = "&Update"
        Navigasi(True)
        TextboxEnable(True)
        DatePicker.Focus()
        'btDelete.Enabled = True
        btSave.BringToFront()
    End Sub
    Private Sub btDelete_Click(sender As Object, e As EventArgs) Handles btDelete.Click
        Select Case MsgBox("Hapus Data Gempa " & lbEventID.Text & "?", MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
                'HapusEvent("gempaDELETE")
                GetVal()
                modFungsi.hapusgempa(vevent_id:=eventid)
                koneksi.Close()
                modFungsi.hapussc_data(vevent_id:=eventid)
                DataGempa()
        End Select
        Navigasi(True)
        TextboxEnable(True)
        lvwGempa.Focus()
        ShowlvwGempa(dtSetGempa.Tables("tDataGempa"), lvwGempa)
        LayarBersih()
        txtBerita.Clear()
    End Sub
    Private Sub btCancel_Click(sender As Object, e As EventArgs) Handles btCancel.Click
        TextboxEnable(True)
        Navigasi(True)
        DataGempa()
        btSave.Text = "&Save"
        If dtSetGempa.Tables("tDataGempa").Rows.Count > 0 Then
            ShowlvwGempa(dtSetGempa.Tables("tDataGempa"), lvwGempa) 'ListDaerah()
        End If
        LayarBersih()
        txtBerita.Clear()
        lvwGempa.Focus()
    End Sub
    Private Sub btShake_Click(sender As Object, e As EventArgs) Handles btShake.Click
        If txtInfo.Enabled = False Then
            GetVal()
        End If
        Hitung()
        wib = DatePicker.Value.Date & " " & TimePicker.Text
        wib = DateAdd(DateInterval.Hour, 7, wib)
        Dim genxml As New System.Text.StringBuilder
        Dim xmlpath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString
        Dim eventxml As String = xmlpath & "\event.xml"
        'Me.btShake.Text = xmlpath
        genxml.AppendLine("<?xml version=""1.0"" encoding=""US-ASCII"" standalone=""yes""?>")
        genxml.AppendLine("<!DOCTYPE earthquake [")
        genxml.AppendLine("<!ELEMENT  earthquake EMPTY>")
        genxml.AppendLine("<!ATTLIST earthquake")
        genxml.AppendLine("  id 		ID	#REQUIRED")
        genxml.AppendLine("  lat		CDATA	#REQUIRED")
        genxml.AppendLine("  lon		CDATA	#REQUIRED")
        genxml.AppendLine("  mag		CDATA	#REQUIRED")
        genxml.AppendLine("  year          CDATA   #REQUIRED")
        genxml.AppendLine("  month         CDATA   #REQUIRED")
        genxml.AppendLine("  day           CDATA   #REQUIRED")
        genxml.AppendLine("  hour          CDATA   #REQUIRED")
        genxml.AppendLine("  minute        CDATA   #REQUIRED")
        genxml.AppendLine("  second        CDATA   #REQUIRED")
        genxml.AppendLine("  timezone      CDATA   #REQUIRED")
        genxml.AppendLine("  depth		CDATA	#REQUIRED")
        genxml.AppendLine("  locstring	CDATA	#REQUIRED")
        genxml.AppendLine("  type  	CDATA	#REQUIRED")
        genxml.AppendLine("  pga		CDATA   #REQUIRED")
        genxml.AppendLine("  pgv		CDATA   #REQUIRED")
        genxml.AppendLine("  sp03		CDATA   #REQUIRED")
        genxml.AppendLine("  sp10		CDATA   #REQUIRED")
        genxml.AppendLine("  sp30		CDATA   #REQUIRED")
        genxml.AppendLine("  created	CDATA	#REQUIRED")
        genxml.AppendLine(">")
        genxml.AppendLine("]>")
        genxml.AppendLine("<earthquake id=""" & Format(wib, "yyyyMMddHHmmss") & """ lat=""" & lat & """ lon=""" &
                          lon & """ mag=""" & mag & """ year=""" & Format(wib, "yyyy") & """ month=""" & Format(wib, "MM") &
                          """ day=""" & Format(wib, "dd") & """ hour=""" & Format(wib, "HH") & """ minute=""" & Format(wib, "mm") &
                          """ second=""" & Format(wib, "ss") & """ timezone=""WIB"" depth=""" & depth & """ type=""ALL"" created=""" &
                          Format(wib, "yyyyMMddHHmmss") & """ locstring=""" & lblDaerah1.Text & """ />")
        IO.File.WriteAllText(eventxml, genxml.ToString())
        MsgBox("event.xml tersimpan di Desktop", MsgBoxStyle.OkOnly)
    End Sub
    Private Sub btNarasi_Click(sender As Object, e As EventArgs) Handles btNarasi.Click
        If String.IsNullOrWhiteSpace(txtInfo.Text) Or txtInfo.Text = "Informasi Tambahan (Tsunami atau Dirasakan)" Then
            MsgBox("Informasi dirasakan belum dimasukan", MsgBoxStyle.OkOnly, "Perhatian")
            txtInfo.Focus()
            Exit Sub
        Else
            With FormNarasi
                .MdiParent = FormUtama
                .Show()
                .lbIDgempa.Text = lbEventID.Text
            End With
        End If
    End Sub
    Private Sub btGenmap_Click(sender As Object, e As EventArgs) Handles btGenmap.Click
        If txtInfo.Enabled = False Then
            If txtDepth.Text <= 60 And txtMag.Text >= 6.5 Then
                Select Case MsgBox("Berpotensi Tsunami?", MsgBoxStyle.YesNo, "Perhatian")
                    Case MsgBoxResult.Yes
                        tsunami = "Gempa ini BERPOTENSI TSUNAMI, Untuk diteruskan Kepada Masyarakat"
                        'Me.chkDirasakan.Checked = True
                        If txtInfo.Text = "Informasi Tambahan (Tsunami atau Dirasakan)" Or String.IsNullOrWhiteSpace(txtInfo.Text) Then
                            txtInfo.Text = tsunami
                        Else
                            info = txtInfo.Text
                            'Me.txtInfo.Text = Me.tsunami & ", " & Me.info
                        End If
                    Case MsgBoxResult.No
                        tsunami = "Gempa ini TIDAK BERPOTENSI TSUNAMI"
                End Select
            Else
                tsunami = "Gempa ini TIDAK BERPOTENSI TSUNAMI"
            End If
            GetVal()
        End If
        Hitung()
        Berita()
        If btCopy.Enabled = False Then
            btCopy.Enabled = True
        End If
        daerahsize = dtSetDaerah.Tables("tDaerah").Rows.Count
        Dim genmap As New System.Text.StringBuilder
        If btGenmap.Text = "&Generate Map" Then
        ElseIf btGenmap.Text = "Update Ma&p" Then
            PBEpisenter.Image = Nothing
            genmap.AppendLine("del ""gempa" & eventid & ".jpg""")
            btGenmap.Text = "&Generate Map"
        End If
        Select Case MsgBox("Plot Layout Social Media?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1 + MsgBoxStyle.Question, "Perhatian")
            Case MsgBoxResult.Yes
                genmap.AppendLine("REM GMT PLOT EPICENTER")
                genmap.AppendLine("REM $Id: YEHEZKIEL HALAUWET $")
                genmap.AppendLine("REM Purpose: Plot EQ Epic from interactive input")
                genmap.AppendLine("REM GMT progs: psbasemap, grdimage, grdgradient, psimage, grdmath, grdtrack, psxy, pstext, ps2raster")
                genmap.AppendLine("REM Unix progs: gawk")
                genmap.AppendLine("Title EQ Map Generator")
                genmap.AppendLine(":main")
                genmap.AppendLine("cls")
                genmap.AppendLine("echo EQ Map Generator")
                genmap.AppendLine("echo by eQ H")
                genmap.AppendLine("echo.--------------------------------------------------------")
                REM Parameter Gempa
                genmap.AppendLine("::Parameter")
                genmap.AppendLine("set sta=" & stasiun)
                genmap.AppendLine("set kop1=" & kop1)
                genmap.AppendLine("set kop2=" & kop2)
                genmap.AppendLine("set tgl=" & Format(wit, "dd MMM yyyy"))
                genmap.AppendLine("set ot=" & Format(wit, "HH:mm:ss") & " " & strzonawaktu)
                genmap.AppendLine("set lat=" & lat)
                genmap.AppendLine("set lon=" & lon)
                genmap.AppendLine("set latitude=" & lintang & " " & strlintang)
                genmap.AppendLine("set longitude=" & bujur & " " & strbujur)
                genmap.AppendLine("set dep=" & depth)
                genmap.AppendLine("set mag=" & Format(mag, "0.0"))
                genmap.AppendLine("set lokasi=" & lokasi)
                genmap.AppendLine("set latm=" & Latm)
                genmap.AppendLine("set lonm=" & Lonm)
                If tsunami = "" Or tsunami = "Gempa ini TIDAK BERPOTENSI TSUNAMI" Then
                    genmap.AppendLine("set tsunami=TIDAK BERPOTENSI TSUNAMI")
                Else : genmap.AppendLine("set tsunami=BERPOTENSI TSUNAMI")
                End If
                REM Parameter Peta
                genmap.AppendLine("::Peta")
                genmap.AppendLine("set ps=""gempa" & eventid & ".ps""")
                genmap.AppendLine("set llon=" & Llon)
                genmap.AppendLine("set rlon=" & Rlon)
                genmap.AppendLine("set blat=" & Blat)
                genmap.AppendLine("set ulat=" & Ulat)
                genmap.AppendLine("set R=%llon%/%rlon%/%blat%/%ulat%")
                genmap.AppendLine("set R_inset=" & Llon - 4 & "/" & Rlon + 4 & "/" & Blat - 3 & "/" & Ulat + 3)
                genmap.AppendLine("set R1=0/5/0/1")
                genmap.AppendLine("set R2=0/5/0/2")
                genmap.AppendLine("set R3=0/2/0/1")
                genmap.AppendLine("set R4=0/6/0/1.5")
                genmap.AppendLine("set H=" & Depmin & "/" & depth)
                genmap.AppendLine("set az=180")
                genmap.AppendLine("set elev=90")
                genmap.AppendLine("set L=legend")
                genmap.AppendLine("set D=gmt/depth.cpt")
                genmap.AppendLine("set topo=gmt/my_etopo.cpt")
                genmap.AppendLine("set indo=gmt/indonesia.nc")
                genmap.AppendLine("set ilum=gmt/iluminasi.nc")
                REM Peta dasar
                genmap.AppendLine("::grdgradient %indo% -A0 -Nt0.9 -G%ilum%")
                'genmap.AppendLine("makecpt -Z -Cetopo1 > %topo%")
                genmap.AppendLine("echo # color palette for seismicity depend on depth > %D%")
                genmap.AppendLine("echo # z0 color z1 color >> %D%")
                genmap.AppendLine("echo 0 red 60.1 red >> %D%")
                genmap.AppendLine("echo 60.1 yellow 300.1 yellow >> %D%")
                genmap.AppendLine("echo 300.1 green 3600 green >> %D%")
                If System.IO.File.Exists("img/smbg.ps") = True Then
                    genmap.AppendLine("psimage img/smbg.ps -Dx0/0+w21c -X-0.1 -Y4 -P -K > %ps%")
                    genmap.AppendLine("grdimage %indo% -JM15.5 -R%R% -I%ilum% -C%topo% -Y7.35 -X2.76 -Ba1g1wSnE --MAP_FRAME_TYPE=plain --FONT_ANNOT_PRIMARY=9 --FONT_LABEL=9 --FONT_TITLE=10 -O -K >> %ps%")
                ElseIf System.IO.File.Exists("img/smbg.eps") = True Then
                    genmap.AppendLine("psimage img/smbg.eps -Dx0/0+w21c -X-0.1 -Y4 -P -K > %ps%")
                    genmap.AppendLine("grdimage %indo% -JM15.5 -R%R% -I%ilum% -C%topo% -Y7.35 -X2.76 -Ba1g1wSnE --MAP_FRAME_TYPE=plain --FONT_ANNOT_PRIMARY=9 --FONT_LABEL=9 --FONT_TITLE=10 -O -K >> %ps%")
                ElseIf System.IO.File.Exists("img/smbg.jpg") = True Then
                    genmap.AppendLine("psimage img/smbg.jpg -Dx0/0+w21c -X-0.1 -Y4 -P -K > %ps%")
                    genmap.AppendLine("grdimage %indo% -JM15.5 -R%R% -I%ilum% -C%topo% -Y7.35 -X2.76 -Ba1g1wSnE --MAP_FRAME_TYPE=plain --FONT_ANNOT_PRIMARY=9 --FONT_LABEL=9 --FONT_TITLE=10 -O -K >> %ps%")
                Else : genmap.AppendLine("grdimage %indo% -JM15.5 -R%R% -I%ilum% -C%topo% -Y11.35 -X2.76 -Ba1g1wSnE --MAP_FRAME_TYPE=plain --FONT_ANNOT_PRIMARY=9 --FONT_LABEL=9 --FONT_TITLE=10 -P -K > %ps%")
                End If
                genmap.AppendLine("psxy gmt/subduksi_moluccas.gmt -JM -R -Wthin -Sf0.8i/0.08i+r+t -Gblack -O -K >> %ps%")
                genmap.AppendLine("psxy gmt/fault_moluccas.gmt -JM -R -Wthin -O -K >> %ps%")
                genmap.AppendLine("REM psxy gmt/trench-a.gmt -JM -R -Wthick -Sf0.8i/0.08i+l+t -Gblack -O -K >> %ps%")
                genmap.AppendLine("REM psxy gmt/trench-b.gmt -JM -R -Wthick -Sf0.8i/0.08i+r+t -Gblack -O -K >> %ps%")
                genmap.AppendLine("REM psxy gmt/thrust.gmt -JM -R -Wthick -Sf0.8i/0.08i+r+t -O -K >> %ps%")
                genmap.AppendLine("REM psxy gmt/transform.gmt -JM -R -Wthick -O -K >> %ps%")
                genmap.AppendLine("psbasemap -J -R%R4% -L0.6/0.35/1/100k+l+jr -Tf0.6/0.8/1.6/1:\000,\000,\000,U: --FONT_ANNOT_PRIMARY=9 --FONT_LABEL=9 --FONT_TITLE=9 -Y7.75 -O -K >> %ps%")
                genmap.AppendLine("psimage img/watermarkbmkg.png -Dg4.2/0.34+w1c+jcb -J -R%R1% -Y-7.75 -O -K >> %ps%")
                genmap.AppendLine("echo 4.2 0.25 BMKG | pstext -J -R%R1% -F+f9p,Helvetica -N -O -K >> %ps%")
                genmap.AppendLine(wtrmark)
                x = 0.32
                y1 = 0.62
                y2 = 0.36
                y3 = -1
                y4 = -1
                y5 = -1
                REM plot poligon jarak gempa
                If daerahsize = 1 Then
                    i = 1
                    If lat1 < Ulat And lat1 > Blat Then
                        If lon1 < Rlon And lon1 > Llon Then
                            genmap.AppendLine("echo " & lon1 & " " & lat1 & " > reg1.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg1.dat")
                            genmap.AppendLine("psxy reg1.dat -R%R% -JM15.5 -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            End If
                            If reg1 < jmlkab Then
                                genmap.AppendLine("echo " & lon1 & " " & lat1 & " " & x & " " & y & " " & lblDaerah1.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon1 & " " & lat1 & " " & x & " " & y & " " & lblDaerah1.Text & " >> kec.dat")
                            End If
                        End If
                    End If
                ElseIf daerahsize = 2 Then
                    i = 1
                    If lat1 < Ulat And lat1 > Blat Then
                        If lon1 < Rlon And lon1 > Llon Then
                            genmap.AppendLine("echo " & lon1 & " " & lat1 & " > reg1.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg1.dat")
                            genmap.AppendLine("psxy reg1.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            End If
                            If reg1 < jmlkab Then
                                genmap.AppendLine("echo " & lon1 & " " & lat1 & " " & x & " " & y & " " & lblDaerah1.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon1 & " " & lat1 & " " & x & " " & y & " " & lblDaerah1.Text & " >> kec.dat")
                            End If
                            i += 1
                        End If
                    End If
                    If lat2 < Ulat And lat2 > Blat Then
                        If lon2 < Rlon And lon2 > Llon Then
                            genmap.AppendLine("echo " & lon2 & " " & lat2 & " > reg2.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg2.dat")
                            genmap.AppendLine("psxy reg2.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            ElseIf i = 2 Then
                                y = y2
                            ElseIf i = 3 Then
                                y = y3
                            ElseIf i = 4 Then
                                y = y4
                            ElseIf i = 5 Then
                                y = y5
                            End If
                            If reg2 < jmlkab Then
                                genmap.AppendLine("echo " & lon2 & " " & lat2 & " " & x & " " & y & " " & lblDaerah2.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon2 & " " & lat2 & " " & x & " " & y & " " & lblDaerah2.Text & " >> kec.dat")
                            End If
                            i += 1
                        End If
                    End If
                ElseIf daerahsize = 3 Then
                    i = 1
                    If lat1 < Ulat And lat1 > Blat Then
                        If lon1 < Rlon And lon1 > Llon Then
                            genmap.AppendLine("echo " & lon1 & " " & lat1 & " > reg1.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg1.dat")
                            genmap.AppendLine("psxy reg1.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            ElseIf i = 2 Then
                                y = y2
                            ElseIf i = 3 Then
                                y = y3
                            ElseIf i = 4 Then
                                y = y4
                            ElseIf i = 5 Then
                                y = y5
                            End If
                            If reg1 < jmlkab Then
                                genmap.AppendLine("echo " & lon1 & " " & lat1 & " " & x & " " & y & " " & lblDaerah1.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon1 & " " & lat1 & " " & x & " " & y & " " & lblDaerah1.Text & " >> kec.dat")
                            End If
                            i += 1
                        End If
                    End If
                    If lat2 < Ulat And lat2 > Blat Then
                        If lon2 < Rlon And lon2 > Llon Then
                            genmap.AppendLine("echo " & lon2 & " " & lat2 & " > reg2.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg2.dat")
                            genmap.AppendLine("psxy reg2.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            ElseIf i = 2 Then
                                y = y2
                            ElseIf i = 3 Then
                                y = y3
                            ElseIf i = 4 Then
                                y = y4
                            ElseIf i = 5 Then
                                y = y5
                            End If
                            If reg2 < jmlkab Then
                                genmap.AppendLine("echo " & lon2 & " " & lat2 & " " & x & " " & y & " " & lblDaerah2.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon2 & " " & lat2 & " " & x & " " & y & " " & lblDaerah2.Text & " >> kec.dat")
                            End If
                            i += 1
                        End If
                    End If
                    If lat3 < Ulat And lat3 > Blat Then
                        If lon3 < Rlon And lon3 > Llon Then
                            genmap.AppendLine("echo " & lon3 & " " & lat3 & " > reg3.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg3.dat")
                            genmap.AppendLine("psxy reg3.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            ElseIf i = 2 Then
                                y = y2
                            ElseIf i = 3 Then
                                y = y3
                            ElseIf i = 4 Then
                                y = y4
                            ElseIf i = 5 Then
                                y = y5
                            End If
                            If reg3 < jmlkab Then
                                genmap.AppendLine("echo " & lon3 & " " & lat3 & " " & x & " " & y & " " & lblDaerah3.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon3 & " " & lat3 & " " & x & " " & y & " " & lblDaerah3.Text & " >> kec.dat")
                            End If
                            i += 1
                        End If
                    End If
                ElseIf daerahsize > 3 Then
                    i = 1
                    If lat1 < Ulat And lat1 > Blat Then
                        If lon1 < Rlon And lon1 > Llon Then
                            genmap.AppendLine("echo " & lon1 & " " & lat1 & " > reg1.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg1.dat")
                            genmap.AppendLine("psxy reg1.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            ElseIf i = 2 Then
                                y = y2
                            ElseIf i = 3 Then
                                y = y3
                            ElseIf i = 4 Then
                                y = y4
                            ElseIf i = 5 Then
                                y = y5
                            End If
                            If reg1 < jmlkab Then
                                genmap.AppendLine("echo " & lon1 & " " & lat1 & " " & x & " " & y & " " & lblDaerah1.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon1 & " " & lat1 & " " & x & " " & y & " " & lblDaerah1.Text & " >> kec.dat")
                            End If
                            i += 1
                        End If
                    End If
                    If lat2 < Ulat And lat2 > Blat Then
                        If lon2 < Rlon And lon2 > Llon Then
                            genmap.AppendLine("echo " & lon2 & " " & lat2 & " > reg2.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg2.dat")
                            genmap.AppendLine("psxy reg2.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            ElseIf i = 2 Then
                                y = y2
                            ElseIf i = 3 Then
                                y = y3
                            ElseIf i = 4 Then
                                y = y4
                            ElseIf i = 5 Then
                                y = y5
                            End If
                            If reg2 < jmlkab Then
                                genmap.AppendLine("echo " & lon2 & " " & lat2 & " " & x & " " & y & " " & lblDaerah2.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon2 & " " & lat2 & " " & x & " " & y & " " & lblDaerah2.Text & " >> kec.dat")
                            End If
                            i += 1
                        End If
                    End If
                    If lat3 < Ulat And lat3 > Blat Then
                        If lon3 < Rlon And lon3 > Llon Then
                            genmap.AppendLine("echo " & lon3 & " " & lat3 & " > reg3.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg3.dat")
                            genmap.AppendLine("psxy reg3.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            ElseIf i = 2 Then
                                y = y2
                            ElseIf i = 3 Then
                                y = y3
                            ElseIf i = 4 Then
                                y = y4
                            ElseIf i = 5 Then
                                y = y5
                            End If
                            If reg3 < jmlkab Then
                                genmap.AppendLine("echo " & lon3 & " " & lat3 & " " & x & " " & y & " " & lblDaerah3.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon3 & " " & lat3 & " " & x & " " & y & " " & lblDaerah3.Text & " >> kec.dat")
                            End If
                            i += 1
                        End If
                    End If
                    If lat4 < Ulat And lat4 > Blat Then
                        If lon4 < Rlon And lon4 > Llon Then
                            genmap.AppendLine("echo " & lon4 & " " & lat4 & " > reg4.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg4.dat")
                            genmap.AppendLine("psxy reg4.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            ElseIf i = 2 Then
                                y = y2
                            ElseIf i = 3 Then
                                y = y3
                            ElseIf i = 4 Then
                                y = y4
                            ElseIf i = 5 Then
                                y = y5
                            End If
                            If reg4 < jmlkab Then
                                genmap.AppendLine("echo " & lon4 & " " & lat4 & " " & x & " " & y & " " & lblDaerah4.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon4 & " " & lat4 & " " & x & " " & y & " " & lblDaerah4.Text & " >> kec.dat")
                            End If
                            i += 1
                        End If
                    End If
                    If lat5 < Ulat And lat5 > Blat Then
                        If lon5 < Rlon And lon5 > Llon Then
                            genmap.AppendLine("echo " & lon5 & " " & lat5 & " > reg5.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg5.dat")
                            genmap.AppendLine("psxy reg5.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            ElseIf i = 2 Then
                                y = y2
                            ElseIf i = 3 Then
                                y = y3
                            ElseIf i = 4 Then
                                y = y4
                            ElseIf i = 5 Then
                                y = y5
                            End If
                            If reg5 < jmlkab Then
                                genmap.AppendLine("echo " & lon5 & " " & lat5 & " " & x & " " & y & " " & daerah5 & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon5 & " " & lat5 & " " & x & " " & y & " " & daerah5 & " >> kec.dat")
                            End If
                        End If
                    End If
                End If
                genmap.AppendLine("psimage img/epic.png -Dg" & lon & "/" & lat & "+w0.8+jcm -J -R%R% -O -K >> %ps%")
                REM genmap.AppendLine("echo " & lon & " " & lat & " " & depth & " " & mag & " > datagempa.xy")
                REM If depth >= 300 Then
                REM genmap.AppendLine("psimage img/epic3.png -Dg" & lon & "/" & lat & "+w0.8+jcm -J -R%R% -O -K >> %ps%")
                REM ElseIf depth >= 60
                REM genmap.AppendLine("psimage img/epic2.png -Dg" & lon & "/" & lat & "+w0.8+jcm -J -R%R% -O -K >> %ps%")
                REM Else
                REM genmap.AppendLine("psimage img/epic1.png -Dg" & lon & "/" & lat & "+w0.8+jcm -J -R%R% -O -K >> %ps%")
                REM End If
                genmap.AppendLine("psxy -JM -R%R% kota.dat -Ss0.4 -Gred -Wthick -O -K >> %ps%")
                genmap.AppendLine("psxy -JM -R%R% kec.dat -Ss0.3 -Gred -Wthin -O -K >> %ps%")
                genmap.AppendLine("gawk ""{print $1, $2, $8, $9, $10, $11}"" kota.dat | pstext -J -R -F+f12p,Helvetica+jCT -O -K >> %ps%")
                genmap.AppendLine("gawk ""{print $1, $2, $8, $9, $10, $11}"" kec.dat | pstext -J -R -F+f9p,Helvetica+jCT -O -K >> %ps%")
                genmap.AppendLine("pscoast -R%R_inset% -JM3.5 -Dh -W0.25p,black -Gwhite -S58/181/217 -B5::WsNe --MAP_FRAME_TYPE=plain --FONT_ANNOT_PRIMARY=6 -O -K >> %ps%")
                genmap.AppendLine("echo %llon% %blat% > box")
                genmap.AppendLine("echo %llon% %ulat% >> box")
                genmap.AppendLine("echo %rlon% %ulat% >> box")
                genmap.AppendLine("echo %rlon% %blat% >> box")
                genmap.AppendLine("echo %llon% %blat% >> box")
                genmap.AppendLine("psxy -R -JM box -Wthin,red -O -K >> %ps%")
                genmap.AppendLine("psimage img/epic.png -Dg" & lon & "/" & lat & "+w0.2+jcm -J -R -O -K >> %ps%")
                REM If depth >= 300 Then
                REM genmap.AppendLine("psimage img/epic3.png -Dg" & lon & "/" & lat & "+w0.2+jcm -J -R -O -K >> %ps%")
                REM ElseIf depth >= 60
                REM genmap.AppendLine("psimage img/epic2.png -Dg" & lon & "/" & lat & "+w0.2+jcm -J -R -O -K >> %ps%")
                REM Else
                REM genmap.AppendLine("psimage img/epic1.png -Dg" & lon & "/" & lat & "+w0.2+jcm -J -R -O -K >> %ps%")
                REM End If
                genmap.AppendLine("psbasemap -JX15.5/4 -R%R2% -Bx -Y-4.75 --FONT_ANNOT_PRIMARY=5 -O -K >> %ps%")
                genmap.AppendLine("echo -0.46 1.05 %mag% | pstext -R -J -F+f40p,Helvetica-Narrow-BoldOblique,red+jCM -N -O -K >> %ps%")
                genmap.AppendLine("echo 0.4 1.6 %tgl% | pstext -R -J -F+f11.5p,AvantGarde-DemiOblique+jLT -N -O -K >> %ps%")
                genmap.AppendLine("echo 0.4 1.35 %ot% | pstext -R -J -F+f11.5p,,AvantGarde-DemiOblique+jLT -N -O -K >> %ps%")
                genmap.AppendLine("echo 2.2 1.55 %dep% km | pstext -R -J -F+f11.5p,,AvantGarde-DemiOblique+jLT -N -O -K >> %ps%")
                genmap.AppendLine("echo 3.5 1.55 %latitude% -%longitude% | pstext -R -J -F+f11.5p,,AvantGarde-DemiOblique+jLT -N -O -K >> %ps%")
                If tsunami = "Gempa ini BERPOTENSI TSUNAMI, Untuk diteruskan Kepada Masyarakat" Then
                    genmap.AppendLine("echo 1 -0.48 %tsunami% | pstext -R -J -F+f17p,,AvantGarde-DemiOblique,white+jLB -Gred -N -O -K >> %ps%")
                Else
                    genmap.AppendLine("echo 1 -0.48 %tsunami% | pstext -R -J -F+f17p,,AvantGarde-DemiOblique+jLB -Ggreen -N -O -K >> %ps%")
                End If
                If info = "" Or info = "Informasi Tambahan (Tsunami atau Dirasakan)" Then
                    genmap.AppendLine("gawk ""{print $3, $4, $5, $6, $7, $8, $9, $10, $11}"" kota.dat | pstext -J -R -F+f11.5p,AvantGarde-DemiOblique+jLT -O -K >> %ps%")
                    genmap.AppendLine("gawk ""{print $3, $4, $5, $6, $7, $8, $9, $10, $11}"" kec.dat | pstext -J -R -F+f11.5p,AvantGarde-DemiOblique+jLT -O >> %ps%")
                Else
                    genmap.AppendLine("gawk ""{print $3, $4, $5, $6, $7, $8, $9, $10, $11}"" kota.dat | pstext -J -R -F+f11.5p,AvantGarde-DemiOblique+jLT -O -K >> %ps%")
                    genmap.AppendLine("gawk ""{print $3, $4, $5, $6, $7, $8, $9, $10, $11}"" kec.dat | pstext -J -R -F+f11.5p,AvantGarde-DemiOblique+jLT -O -K >> %ps%")
                    genmap.AppendLine("echo ^> 3.05 0.75 0.35 6 l > info")
                    genmap.AppendLine("echo " & info & " >> info")
                    genmap.AppendLine("pstext info -R -J -F+f11.5p,AvantGarde-DemiOblique+jLT -M -O >> %ps%")
                End If
                genmap.AppendLine("psconvert %ps% -E256 -Tj -A")
                genmap.AppendLine("del del kota.dat kec.dat reg1.dat reg2.dat reg3.dat reg4.dat reg5.dat box")
                genmap.AppendLine("del %ps%")
            Case MsgBoxResult.No
                genmap.AppendLine("REM GMT PLOT EPICENTER")
                genmap.AppendLine("REM $Id: YEHEZKIEL HALAUWET $")
                genmap.AppendLine("REM Purpose: Plot EQ Epic from interactive input")
                genmap.AppendLine("REM GMT progs: psbasemap, grdimage, grdgradient, psimage, grdmath, grdtrack, psxy, pstext, ps2raster")
                genmap.AppendLine("REM Unix progs: gawk")
                genmap.AppendLine("Title EQ Map Generator")
                genmap.AppendLine(":main")
                genmap.AppendLine("cls")
                genmap.AppendLine("echo EQ Map Generator")
                genmap.AppendLine("echo by eQ H")
                genmap.AppendLine("echo.--------------------------------------------------------")
                REM Parameter Gempa
                genmap.AppendLine("::Parameter")
                genmap.AppendLine("set sta=" & stasiun)
                genmap.AppendLine("set kop1=" & kop1)
                genmap.AppendLine("set kop2=" & kop2)
                genmap.AppendLine("set tgl=" & Format(wit, "dd MMM yyyy"))
                genmap.AppendLine("set ot=" & Format(wit, "HH:mm:ss") & " " & strzonawaktu)
                genmap.AppendLine("set lat=" & lat)
                genmap.AppendLine("set lon=" & lon)
                genmap.AppendLine("set latitude=" & lintang & " " & strlintang)
                genmap.AppendLine("set longitude=" & bujur & " " & strbujur)
                genmap.AppendLine("set dep=" & depth)
                genmap.AppendLine("set mag=" & Format(mag, "0.0"))
                genmap.AppendLine("set lokasi=" & lokasi)
                genmap.AppendLine("set latm=" & Latm)
                genmap.AppendLine("set lonm=" & Lonm)
                If tsunami = "" Then
                    genmap.AppendLine("set tsunami=Gempa ini TIDAK BERPOTENSI TSUNAMI")
                Else : genmap.AppendLine("set tsunami=" & tsunami)
                End If
                REM Parameter Peta
                genmap.AppendLine("::Peta")
                genmap.AppendLine("set ps=""gempa" & eventid & ".ps""")
                genmap.AppendLine("set llon=" & Llon)
                genmap.AppendLine("set rlon=" & Rlon)
                genmap.AppendLine("set blat=" & Blat)
                genmap.AppendLine("set ulat=" & Ulat)
                genmap.AppendLine("set R=%llon%/%rlon%/%blat%/%ulat%")
                genmap.AppendLine("set R_inset=" & Llon - 4 & "/" & Rlon + 4 & "/" & Blat - 3 & "/" & Ulat + 3)
                genmap.AppendLine("set R1=0/5/0/1")
                genmap.AppendLine("set R2=0/5/0/2")
                genmap.AppendLine("set R3=0/2/0/1")
                genmap.AppendLine("set R4=0/6/0/1.5")
                genmap.AppendLine("set H=" & Depmin & "/" & depth)
                genmap.AppendLine("set az=180")
                genmap.AppendLine("set elev=90")
                genmap.AppendLine("set L=legend")
                genmap.AppendLine("set D=gmt\depth.cpt")
                genmap.AppendLine("set topo=gmt\my_etopo.cpt")
                genmap.AppendLine("set indo=gmt\indonesia.nc")
                genmap.AppendLine("set ilum=gmt\iluminasi.nc")
                REM Peta dasar
                genmap.AppendLine("::grdgradient %indo% -A0 -Nt0.9 -G%ilum%")
                'genmap.AppendLine("makecpt -Z -Cetopo1 > %topo%")
                genmap.AppendLine("echo # color palette for seismicity depend on depth > %D%")
                genmap.AppendLine("echo # z0 color z1 color >> %D%")
                genmap.AppendLine("echo 0 red 60.1 red >> %D%")
                genmap.AppendLine("echo 60.1 yellow 300.1 yellow >> %D%")
                genmap.AppendLine("echo 300.1 green 3600 green >> %D%")
                If System.IO.File.Exists("img\bg.ps") = True Then
                    genmap.AppendLine("psimage img\bg.ps -Dx0/0+w21.5c -X-0.1 -Y-0.1 -K -P > %ps%")
                    genmap.AppendLine("psimage img\logo.png -Dx0/0+w1.8c -X1.7 -Y25.5 -K -O >> %ps%")
                ElseIf System.IO.File.Exists("img\bg.eps") = True Then
                    genmap.AppendLine("psimage img\bg.eps -Dx0/0+w21.5c -X-0.1 -Y-0.1 -K -P > %ps%")
                    genmap.AppendLine("psimage img\logo.png -Dx0/0+w1.8c -X1.7 -Y25.5 -K -O >> %ps%")
                ElseIf System.IO.File.Exists("img\bg.jpg") = True Then
                    genmap.AppendLine("psimage img\bg.jpg -Dx0/0+w21.5c -X-0.1 -Y-0.1 -K -P > %ps%")
                    genmap.AppendLine("psimage img\logo.png -Dx0/0+w1.8c -X1.7 -Y25.5 -K -O >> %ps%")
                Else : genmap.AppendLine("psimage img\logo.png -Dx0/0+w1.8c -X1.7 -Y25.5 -K -P > %ps%")
                End If
                genmap.AppendLine("echo 2.85 0.9 BADAN METEOROLOGI KLIMATOLOGI DAN GEOFISIKA | pstext -JM17.5c -R%R1% -F+f16p,Helvetica-Narrow-Bold -Y-1.1 -N -O -K >> %ps%")
                genmap.AppendLine("echo 2.85 0.7 %sta% | pstext -JM17.5c -R%R1% -F+f18.5p,Helvetica-Narrow-Bold -N -O -K >> %ps%")
                genmap.AppendLine("echo 2.85 0.5 %kop1% | pstext -JM17.5c -R%R1% -F+f9p,Helvetica-Narrow-Bold -N -O -K >> %ps%")
                genmap.AppendLine("echo 2.85 0.35 %kop2% | pstext -JM17.5c -R%R1% -F+f8p,Helvetica-Narrow-Bold -N -O -K >> %ps%")
                genmap.AppendLine("echo 0 0.25 > line.xy")
                genmap.AppendLine("echo 5 0.25 >> line.xy")
                genmap.AppendLine("psxy line.xy -J -R -Wthin,black -Gblack -O -K >> %ps%")
                genmap.AppendLine("echo 0 0.22 > linethick.xy")
                genmap.AppendLine("echo 5 0.22 >> linethick.xy")
                genmap.AppendLine("psxy linethick.xy -J -R -Wthicker,black -O -K >> %ps%")
                'genmap.AppendLine("grdimage %indo% -J -R%R% -C%topo% -Y-19 -O -K >> %ps%")
                genmap.AppendLine("grdimage %indo% -J -R%R% -I%ilum% -C%topo% -Y-19 -O -K >> %ps%")
                genmap.AppendLine("psbasemap -J -R%R4% -L0.6/0.35/1/100k+l+jr -Tf0.6/0.8/1.6/1:\000,\000,\000,U: --FONT_ANNOT_PRIMARY=9 --FONT_LABEL=9 --FONT_TITLE=9 -Y8.75 -O -K >> %ps%")
                REM Plot Parameter gempa
                genmap.AppendLine("echo 0 1.9 TELAH TERJADI GEMPABUMI DENGAN PARAMETER SEBAGAI BERIKUT : | pstext -R%R2% -J -F+f11.5p,Helvetica+jLT -Y3.5 -N -O -K >> %ps%")
                genmap.AppendLine("echo 0 1.65 Kekuatan %mag% | pstext -R -J -F+f11.5p,Helvetica+jLT -N -O -K >> %ps%")
                genmap.AppendLine("echo 0 1.5 Tanggal %tgl% | pstext -R -J -F+f11.5p,Helvetica+jLT -N -O -K >> %ps%")
                genmap.AppendLine("echo 0 1.35 Waktu Gempa %ot% | pstext -R -J -F+f11.5p,Helvetica+jLT -N -O -K >> %ps%")
                genmap.AppendLine("echo 0 1.2 Koordinat %latitude% -%longitude% | pstext -R -J -F+f11.5p,Helvetica+jLT -N -O -K >> %ps%")
                genmap.AppendLine("echo 0 1.05 Kedalaman %dep% km | pstext -R -J -F+f11.5p,Helvetica+jLT -N -O -K >> %ps%")
                genmap.AppendLine("echo 0 0.85 Informasi Tsunami : | pstext -R -J -F+f11.5p,Helvetica+jLT -N -O -K >> %ps%")
                If tsunami = "Gempa ini BERPOTENSI TSUNAMI, Untuk diteruskan Kepada Masyarakat" Then
                    genmap.AppendLine("echo 0.5 0.61 %tsunami% | pstext -R -J -F+f11.5p,Helvetica,red+jLT -N -O -K >> %ps%")
                Else
                    genmap.AppendLine("echo 0.5 0.61 %tsunami% | pstext -R -J -F+f11.5p,Helvetica+jLT -N -O -K >> %ps%")
                End If
                genmap.AppendLine("psbasemap -J -R%R% -Y-12.25 -Ba1g1WSne --FONT_ANNOT_PRIMARY=9 --FONT_LABEL=10 --FONT_TITLE=9 -O -K >> %ps%")
                genmap.AppendLine("psxy gmt/subduksi_moluccas.gmt -JM -R -Wthin -Sf0.8i/0.08i+r+t -Gblack -O -K >> %ps%")
                genmap.AppendLine("psxy gmt/fault_moluccas.gmt -JM -R -Wthin -O -K >> %ps%")
                genmap.AppendLine("REM psxy gmt/trench-a.gmt -JM -R -Wthick -Sf0.8i/0.08i+l+t -Gblack -O -K >> %ps%")
                genmap.AppendLine("REM psxy gmt/trench-b.gmt -JM -R -Wthick -Sf0.8i/0.08i+r+t -Gblack -O -K >> %ps%")
                genmap.AppendLine("REM psxy gmt/thrust.gmt -JM -R -Wthick -Sf0.8i/0.08i+r+t -O -K >> %ps%")
                genmap.AppendLine("REM psxy gmt/transform.gmt -JM -R -Wthick -O -K >> %ps%")
                genmap.AppendLine("psimage img/watermarkbmkg.png -Dx0/0+w1c -X14.196 -Y1.09 -O -K >> %ps%")
                genmap.AppendLine("echo 4.2 0.25 BMKG | pstext -J -R%R1% -F+f9p,Helvetica -X-14.196 -Y-1.09 -N -O -K >> %ps%")
                genmap.AppendLine(wtrmark)
                REM plot poligon jarak gempa
                Dim y1 As Double = 1.65
                Dim y2 As Double = 1.5
                Dim y3 As Double = 1.35
                Dim y4 As Double = 1.2
                Dim y5 As Double = 1.05
                Dim x As Double = 2.8
                If daerahsize = 1 Then
                    i = 1
                    If lat1 < Ulat And lat1 > Blat Then
                        If lon1 < Rlon And lon1 > Llon Then
                            genmap.AppendLine("echo " & lon1 & " " & lat1 & " > reg1.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg1.dat")
                            genmap.AppendLine("psxy reg1.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            End If
                            If reg1 < jmlkab Then
                                genmap.AppendLine("echo " & lon1 & " " & lat1 & " " & x & " " & y & " " & lblDaerah1.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon1 & " " & lat1 & " " & x & " " & y & " " & lblDaerah1.Text & " >> kec.dat")
                            End If
                        End If
                    End If
                ElseIf daerahsize = 2 Then
                    i = 1
                    If lat1 < Ulat And lat1 > Blat Then
                        If lon1 < Rlon And lon1 > Llon Then
                            genmap.AppendLine("echo " & lon1 & " " & lat1 & " > reg1.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg1.dat")
                            genmap.AppendLine("psxy reg1.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            End If
                            If reg1 < jmlkab Then
                                genmap.AppendLine("echo " & lon1 & " " & lat1 & " " & x & " " & y & " " & lblDaerah1.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon1 & " " & lat1 & " " & x & " " & y & " " & lblDaerah1.Text & " >> kec.dat")
                            End If
                            i += 1
                        End If
                    End If
                    If lat2 < Ulat And lat2 > Blat Then
                        If lon2 < Rlon And lon2 > Llon Then
                            genmap.AppendLine("echo " & lon2 & " " & lat2 & " > reg2.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg2.dat")
                            genmap.AppendLine("psxy reg2.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            ElseIf i = 2 Then
                                y = y2
                            ElseIf i = 3 Then
                                y = y3
                            ElseIf i = 4 Then
                                y = y4
                            ElseIf i = 5 Then
                                y = y5
                            End If
                            If reg2 < jmlkab Then
                                genmap.AppendLine("echo " & lon2 & " " & lat2 & " " & x & " " & y & " " & lblDaerah2.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon2 & " " & lat2 & " " & x & " " & y & " " & lblDaerah2.Text & " >> kec.dat")
                            End If
                            i += 1
                        End If
                    End If
                ElseIf daerahsize = 3 Then
                    i = 1
                    If lat1 < Ulat And lat1 > Blat Then
                        If lon1 < Rlon And lon1 > Llon Then
                            genmap.AppendLine("echo " & lon1 & " " & lat1 & " > reg1.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg1.dat")
                            genmap.AppendLine("psxy reg1.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            ElseIf i = 2 Then
                                y = y2
                            ElseIf i = 3 Then
                                y = y3
                            ElseIf i = 4 Then
                                y = y4
                            ElseIf i = 5 Then
                                y = y5
                            End If
                            If reg1 < jmlkab Then
                                genmap.AppendLine("echo " & lon1 & " " & lat1 & " " & x & " " & y & " " & lblDaerah1.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon1 & " " & lat1 & " " & x & " " & y & " " & lblDaerah1.Text & " >> kec.dat")
                            End If
                            i += 1
                        End If
                    End If
                    If lat2 < Ulat And lat2 > Blat Then
                        If lon2 < Rlon And lon2 > Llon Then
                            genmap.AppendLine("echo " & lon2 & " " & lat2 & " > reg2.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg2.dat")
                            genmap.AppendLine("psxy reg2.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            ElseIf i = 2 Then
                                y = y2
                            ElseIf i = 3 Then
                                y = y3
                            ElseIf i = 4 Then
                                y = y4
                            ElseIf i = 5 Then
                                y = y5
                            End If
                            If reg2 < jmlkab Then
                                genmap.AppendLine("echo " & lon2 & " " & lat2 & " " & x & " " & y & " " & lblDaerah2.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon2 & " " & lat2 & " " & x & " " & y & " " & lblDaerah2.Text & " >> kec.dat")
                            End If
                            i += 1
                        End If
                    End If
                    If lat3 < Ulat And lat3 > Blat Then
                        If lon3 < Rlon And lon3 > Llon Then
                            genmap.AppendLine("echo " & lon3 & " " & lat3 & " > reg3.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg3.dat")
                            genmap.AppendLine("psxy reg3.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            ElseIf i = 2 Then
                                y = y2
                            ElseIf i = 3 Then
                                y = y3
                            ElseIf i = 4 Then
                                y = y4
                            ElseIf i = 5 Then
                                y = y5
                            End If
                            If reg3 < jmlkab Then
                                genmap.AppendLine("echo " & lon3 & " " & lat3 & " " & x & " " & y & " " & lblDaerah3.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon3 & " " & lat3 & " " & x & " " & y & " " & lblDaerah3.Text & " >> kec.dat")
                            End If
                            i += 1
                        End If
                    End If
                ElseIf daerahsize > 3 Then
                    i = 1
                    If lat1 < Ulat And lat1 > Blat Then
                        If lon1 < Rlon And lon1 > Llon Then
                            genmap.AppendLine("echo " & lon1 & " " & lat1 & " > reg1.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg1.dat")
                            genmap.AppendLine("psxy reg1.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            ElseIf i = 2 Then
                                y = y2
                            ElseIf i = 3 Then
                                y = y3
                            ElseIf i = 4 Then
                                y = y4
                            ElseIf i = 5 Then
                                y = y5
                            End If
                            If reg1 < jmlkab Then
                                genmap.AppendLine("echo " & lon1 & " " & lat1 & " " & x & " " & y & " " & lblDaerah1.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon1 & " " & lat1 & " " & x & " " & y & " " & lblDaerah1.Text & " >> kec.dat")
                            End If
                            i += 1
                        End If
                    End If
                    If lat2 < Ulat And lat2 > Blat Then
                        If lon2 < Rlon And lon2 > Llon Then
                            genmap.AppendLine("echo " & lon2 & " " & lat2 & " > reg2.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg2.dat")
                            genmap.AppendLine("psxy reg2.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            ElseIf i = 2 Then
                                y = y2
                            ElseIf i = 3 Then
                                y = y3
                            ElseIf i = 4 Then
                                y = y4
                            ElseIf i = 5 Then
                                y = y5
                            End If
                            If reg2 < jmlkab Then
                                genmap.AppendLine("echo " & lon2 & " " & lat2 & " " & x & " " & y & " " & lblDaerah2.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon2 & " " & lat2 & " " & x & " " & y & " " & lblDaerah2.Text & " >> kec.dat")
                            End If
                            i += 1
                        End If
                    End If
                    If lat3 < Ulat And lat3 > Blat Then
                        If lon3 < Rlon And lon3 > Llon Then
                            genmap.AppendLine("echo " & lon3 & " " & lat3 & " > reg3.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg3.dat")
                            genmap.AppendLine("psxy reg3.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            ElseIf i = 2 Then
                                y = y2
                            ElseIf i = 3 Then
                                y = y3
                            ElseIf i = 4 Then
                                y = y4
                            ElseIf i = 5 Then
                                y = y5
                            End If
                            If reg3 < jmlkab Then
                                genmap.AppendLine("echo " & lon3 & " " & lat3 & " " & x & " " & y & " " & lblDaerah3.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon3 & " " & lat3 & " " & x & " " & y & " " & lblDaerah3.Text & " >> kec.dat")
                            End If
                            i += 1
                        End If
                    End If
                    If lat4 < Ulat And lat4 > Blat Then
                        If lon4 < Rlon And lon4 > Llon Then
                            genmap.AppendLine("echo " & lon4 & " " & lat4 & " > reg4.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg4.dat")
                            genmap.AppendLine("psxy reg4.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            ElseIf i = 2 Then
                                y = y2
                            ElseIf i = 3 Then
                                y = y3
                            ElseIf i = 4 Then
                                y = y4
                            ElseIf i = 5 Then
                                y = y5
                            End If
                            If reg4 < jmlkab Then
                                genmap.AppendLine("echo " & lon4 & " " & lat4 & " " & x & " " & y & " " & lblDaerah4.Text & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon4 & " " & lat4 & " " & x & " " & y & " " & lblDaerah4.Text & " >> kec.dat")
                            End If
                            i += 1
                        End If
                    End If
                    If lat5 < Ulat And lat5 > Blat Then
                        If lon5 < Rlon And lon5 > Llon Then
                            genmap.AppendLine("echo " & lon5 & " " & lat5 & " > reg5.dat")
                            genmap.AppendLine("echo " & lon & " " & lat & " >> reg5.dat")
                            genmap.AppendLine("psxy reg5.dat -R%R% -JM -N -O -K -Wthick,black,- >> %ps%")
                            If i = 1 Then
                                y = y1
                            ElseIf i = 2 Then
                                y = y2
                            ElseIf i = 3 Then
                                y = y3
                            ElseIf i = 4 Then
                                y = y4
                            ElseIf i = 5 Then
                                y = y5
                            End If
                            If reg5 < jmlkab Then
                                genmap.AppendLine("echo " & lon5 & " " & lat5 & " " & x & " " & y & " " & daerah5 & " >> kota.dat")
                            Else
                                genmap.AppendLine("echo " & lon5 & " " & lat5 & " " & x & " " & y & " " & daerah5 & " >> kec.dat")
                            End If
                        End If
                    End If
                End If
                genmap.AppendLine("echo " & lon & " " & lat & " " & depth & " " & mag & " > datagempa.xy")
                genmap.AppendLine("psxy datagempa.xy -J -R%R% -Sa0.8 -Wthick,black -Gred -O -K >> %ps%")
                genmap.AppendLine("psxy -JM -R%R% kota.dat -Ss0.4 -Gred -Wthick -O -K >> %ps%")
                genmap.AppendLine("psxy -JM -R%R% kec.dat -Ss0.3 -Gred -Wthin -O -K >> %ps%")
                genmap.AppendLine("gawk ""{print $1, $2, $8, $9, $10, $11}"" kota.dat | pstext -J -R -F+f12p,Helvetica+jCT -O -K >> %ps%")
                genmap.AppendLine("gawk ""{print $1, $2, $8, $9, $10, $11}"" kec.dat | pstext -J -R -F+f9p,Helvetica+jCT -O -K >> %ps%")
                genmap.AppendLine("echo 1 0.9 " & jab & " | pstext -JM8.75c -R%R3% -F+f11.5p,Helvetica -X8.75 -Y-5 -N -O -K >> %ps%")
                genmap.AppendLine("echo 1 0.7 ttd. | pstext -J -R -F+f11.5p,Helvetica -N -O -K >> %ps%")
                genmap.AppendLine("echo 1 0.5 " & nama & " | pstext -J -R -F+f11.5p,Helvetica -N -O -K >> %ps%")
                'genmap.AppendLine("echo 1 0.4 NIP. " & nip & " | pstext -J -R -F+f11.5p,Helvetica -N -O -K >> %ps%")
                genmap.AppendLine("gawk ""{print $3, $4, $5, $6, $7, $8, $9, $10, $11}"" kota.dat | pstext -JM17.5c -R%R2% -X-8.75c -Y17.25 -F+f11.5p,Helvetica+jLT -N -O -K >> %ps%")
                genmap.AppendLine("gawk ""{print $3, $4, $5, $6, $7, $8, $9, $10, $11}"" kec.dat | pstext -J -R%R2% -F+f11.5p,Helvetica+jLT -N -O >> %ps%")
                genmap.AppendLine("psconvert %ps% -E256 -Tj")
                genmap.AppendLine("del line.xy")
                genmap.AppendLine("del linethick.xy")
                genmap.AppendLine("del kota.dat")
                genmap.AppendLine("del kec.dat")
                'genmap.AppendLine("del %topo%")
                genmap.AppendLine("del %D%")
                genmap.AppendLine("del reg1.dat")
                genmap.AppendLine("del reg2.dat")
                genmap.AppendLine("del reg3.dat")
                genmap.AppendLine("del reg4.dat")
                genmap.AppendLine("del reg5.dat")
                genmap.AppendLine("del DataGempa.xy")
                genmap.AppendLine("del %ps%")
        End Select
        IO.File.WriteAllText("episenter.bat", genmap.ToString())
        GenMapTimer.Interval = 10
        Dim startinfo As New ProcessStartInfo("episenter.bat")
        startinfo.WindowStyle = ProcessWindowStyle.Minimized
        startinfo.WindowStyle = ProcessWindowStyle.Hidden
        startinfo.CreateNoWindow = True
        startinfo.UseShellExecute = False
        Dim proc As Process = Process.Start(startinfo)
        GenMapTimer.Start()
        btGenmap.Visible = False
        MapProgress.Visible = True
        MapProgress.Value = 5
    End Sub
    Private Sub btSaveMap_Click(sender As Object, e As EventArgs) Handles btSaveMap.Click
        'GetVal()
        If PBEpisenter.Image Is Nothing Then
            btSaveMap.Enabled = False
        Else
            '1SaveEpic.ShowDialog()
            '1SaveEpic.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            '1
            Dim copymap As New System.Text.StringBuilder
            Dim mappath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString
            Dim mapjpg As String = mappath & "\gempaterkini.jpg"
            If File.Exists(mapjpg) = True Then
                Dim delmap As New System.Text.StringBuilder
                delmap.AppendLine("del " & mapjpg)
                IO.File.WriteAllText("delmap.bat", delmap.ToString())
                Dim startdel As New ProcessStartInfo("delmap.bat")
                startdel.WindowStyle = ProcessWindowStyle.Minimized
                startdel.WindowStyle = ProcessWindowStyle.Hidden
                startdel.CreateNoWindow = True
                startdel.UseShellExecute = False
                Dim procdel As Process = Process.Start(startdel)
            End If
            copymap.AppendLine("move /Y """ & directoryapp & "\gempa" & eventid & ".jpg"" """ & mapjpg & """")
            copymap.AppendLine("del gempa" & eventid & ".ps")
            IO.File.WriteAllText("save.bat", copymap.ToString())
            Dim startsave As New ProcessStartInfo("save.bat")
            startsave.WindowStyle = ProcessWindowStyle.Minimized
            startsave.WindowStyle = ProcessWindowStyle.Hidden
            startsave.CreateNoWindow = True
            startsave.UseShellExecute = False
            Dim proc As Process = Process.Start(startsave)
            '1
        End If
        MsgBox("""gempaterkini.jpg"" tersimpan di Desktop", MsgBoxStyle.OkOnly)
        'btSaveMap.BackColor = Color.FromKnownColor(KnownColor.Control)
        btSaveMap.Enabled = False
    End Sub
    Private Sub SaveEpic_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveEpic.FileOk
        Dim SaveImage As String = SaveEpic.FileName
        Dim directorypeta As String = Path.GetDirectoryName(SaveImage)
        Dim extensi As String = Path.GetExtension(SaveImage)
        namapeta = Path.GetFileName(SaveImage)
        namapeta = Microsoft.VisualBasic.Left(namapeta, (Len(namapeta) - Len(extensi)))
        Dim copymap As New System.Text.StringBuilder
        copymap.AppendLine("@echo off")
        'copymap.AppendLine(":: BatchGotAdmin")
        'copymap.AppendLine(":-------------------------------------")
        'copymap.AppendLine("REM  --> Check for permissions")
        'copymap.AppendLine(">nul 2>&1 ""%SYSTEMROOT%\system32\cacls.exe"" ""%SYSTEMROOT%\system32\config\system""")
        'copymap.AppendLine("REM --> If error flag set, we do not have admin.")
        'copymap.AppendLine("if '%errorlevel%' NEQ '0' (")
        'copymap.AppendLine("    echo Requesting administrative privileges...")
        'copymap.AppendLine("    goto UACPrompt")
        'copymap.AppendLine(") else ( goto gotAdmin )")
        'copymap.AppendLine(":UACPrompt")
        'copymap.AppendLine("    echo Set UAC = CreateObject^(""Shell.Application""^) > ""%temp%\getadmin.vbs""")
        'copymap.AppendLine("    set params = %*:""=""""")
        'copymap.AppendLine("    echo UAC.ShellExecute ""cmd.exe"", ""/c %~s0 %params%"", """", ""runas"", 1 >> ""%temp%\getadmin.vbs""")
        'copymap.AppendLine("    ""%temp%\getadmin.vbs""")
        'copymap.AppendLine("    del ""%temp%\getadmin.vbs""")
        'copymap.AppendLine("    exit /B")
        'copymap.AppendLine(":gotAdmin")
        'copymap.AppendLine("    pushd ""%CD%""")
        'copymap.AppendLine("    CD /D ""%~dp0""")
        'copymap.AppendLine(":--------------------------------------")
        copymap.AppendLine("move /Y """ & directoryapp & "\gempa" & eventid & ".jpg"" """ & SaveImage & """")
        copymap.AppendLine("del gempa" & eventid & ".ps")
        IO.File.WriteAllText("save.bat", copymap.ToString())
        Dim startsave As New ProcessStartInfo("save.bat")
        startsave.WindowStyle = ProcessWindowStyle.Minimized
        startsave.WindowStyle = ProcessWindowStyle.Hidden
        startsave.CreateNoWindow = True
        startsave.UseShellExecute = False
        Dim proc As Process = Process.Start(startsave)
    End Sub
    Private Sub GenMapTimer_Tick(sender As Object, e As EventArgs) Handles GenMapTimer.Tick
        If MapProgress.Value < 30 Then
            MapProgress.Increment(1)
        ElseIf MapProgress.Value < 85 Then
            MapProgress.Increment(1)
            If System.IO.File.Exists(directoryapp & "\gempa" & eventid & ".jpg") Then
                MapProgress.Value = 90
            End If
        Else
            If System.IO.File.Exists(directoryapp & "\gempa" & eventid & ".jpg") Then
                Dim fs As System.IO.FileStream
                MapProgress.Increment(1)
                Try
                    fs = New System.IO.FileStream(directoryapp & "\gempa" & eventid & ".jpg",
                            IO.FileMode.Open, IO.FileAccess.Read)
                    PBEpisenter.Image = System.Drawing.Image.FromStream(fs)
                    fs.Close()
                Catch
                End Try
                If PBEpisenter.Image Is Nothing Then
                Else
                    MapProgress.Value = 100
                    GenMapTimer.Stop()
                    btSaveMap.Enabled = True
                    btSaveMap.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption)
                    MapProgress.Visible = False
                End If
            Else
                MapProgress.Increment(0)
            End If
        End If
    End Sub
    Private Sub PBEpisenter_MouseEnter(sender As Object, e As EventArgs) Handles PBEpisenter.MouseEnter
        If PBEpisenter.Image Is Nothing Then
        Else
            PBEpisenter.Size = New Size(500, 500)
            PBEpisenter.Location = New Point(300, 120)
            'Me.PBEpisenter.BringToFront()
        End If
    End Sub
    Private Sub PBEpisenter_MouseLeave(sender As Object, e As EventArgs) Handles PBEpisenter.MouseLeave
        If PBEpisenter.Image Is Nothing Then
        Else
            PBEpisenter.Size = New Size(180, 245)
            PBEpisenter.Location = New Point(605, 365)
            'Me.PBEpisenter.SendToBack()
        End If
    End Sub
    Private Sub btSaveMap_EnabledChanged(sender As Object, e As EventArgs) Handles btSaveMap.EnabledChanged
        If btSaveMap.Enabled = False Then
            btSaveMap.BackColor = Color.FromKnownColor(KnownColor.Control)
        End If
    End Sub
    Private Sub lvwGempa_DoubleClick(sender As Object, e As EventArgs) Handles lvwGempa.DoubleClick
        If lvwGempa.SelectedItems.Count > 0 Then
            Dim lvi As ListViewItem = lvwGempa.SelectedItems(0)
            lbEventID.Text = lvi.SubItems(0).Text
            DatePicker.Text = lvi.SubItems(1).Text
            TimePicker.Text = lvi.SubItems(2).Text
            txtLat.Text = lvi.SubItems(3).Text
            txtLon.Text = lvi.SubItems(4).Text
            txtDepth.Text = lvi.SubItems(5).Text
            txtMag.Text = lvi.SubItems(6).Text
            If Not String.IsNullOrWhiteSpace(lvi.SubItems(8).Text) Then
                'Me.chkDirasakan.Checked = True
                'Me.txtInfo.Enabled = True
                txtInfo.Text = lvi.SubItems(8).Text
            Else
                'Me.chkDirasakan.Enabled = False
                'Me.txtInfo.Enabled = False
                txtInfo.Text = "Informasi Tambahan (Tsunami atau Dirasakan)"
            End If
        End If
        btSave.Text = "&Update"
        Navigasi(True)
        TextboxEnable(True)
        DatePicker.Focus()
        'btDelete.Enabled = True
        btSave.BringToFront()
    End Sub
    Private Sub FormInput_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        btSave.Text = "&Save"
        If Application.OpenForms.OfType(Of FormNarasi).Any Then
            FormNarasi.Close()
        End If
        FormUtama.mnUtama.BackColor = Color.WhiteSmoke
    End Sub
#End Region

#Region "VALIDASI"
    Private Sub DatePicker_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DatePicker.Validating
        DatePicker.CustomFormat = "dd-MMM-yyyy"
        'If Me.btSave.Text = "&Save" Then
        'BuatKodeGempa()
        'End If
    End Sub
    Private Sub TimePicker_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TimePicker.Validating
        wit = DatePicker.Value.Date & " " & TimePicker.Text
        wit = DateAdd(DateInterval.Hour, 9, wit)
        If btSave.Text = "&Save" Then
            BuatKodeGempa()
        End If
        'Me.txtBerita.Text = "Info Gempa " & Format(wit, "dd-MMM-yyyy HH:mm:ss") & " WIT ::BMKG-PGR IX"
    End Sub
    Private Sub txtLat_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtLat.Validating
        If IsNumeric(txtLat.Text) Then
            lat = txtLat.Text
            txtLat.Text = Format(lat, "00.00")
            If lat < 0 Then
                strlintang = "LS"
            Else : strlintang = "LU"
            End If
            lintang = Format(Abs(lat), "00.00")
            'Me.txtBerita.Text = "Info Gempa " & Format(wit, "dd-MMM-yyyy HH:mm:ss") & " WIT, Lok:" & _
            '                   lintang & " " & strlintang & " ::BMKG-PGR IX"
        End If
    End Sub
    Private Sub txtLon_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtLon.Validating
        If IsNumeric(txtLon.Text) Then
            lon = txtLon.Text
            txtLon.Text = Format(lon, "000.00")
            If lon < 0 Then
                strbujur = "BB"
            Else : strbujur = "BT"
            End If
            bujur = Format(Abs(lon), "000.00")
            Hitung()
            'Me.txtBerita.Text = "Info Gempa " & Format(wit, "dd-MMM-yyyy HH:mm:ss") & " WIT, Lok:" & _
            '                    lintang & " " & strlintang & " - " & bujur & " " & strbujur & _
            '                   " (" & remark & ") ::BMKG-PGR IX"
        End If
    End Sub
    Private Sub txtDepth_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDepth.Validating
        If IsNumeric(txtDepth.Text) Then
            depth = txtDepth.Text
            'Me.txtBerita.Text = "Info Gempa " & Format(wit, "dd-MMM-yyyy HH:mm:ss") & " WIT, Lok:" & _
            '                lintang & " " & strlintang & " - " & bujur & " " & strbujur & _
            '                " (" & remark & "), Kedlmn:" & depth & " km ::BMKG-PGR IX"
        End If
    End Sub
    Private Sub txtMag_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtMag.Validating
        If IsNumeric(txtMag.Text) Then
            mag = txtMag.Text
            If mag < 9.5 Then
                txtMag.Text = Format(mag, "0.0")
            ElseIf mag >= 9.5 Then
                Select Case MsgBox("Benar Magnitudo Gempa = " & mag & " ?", MsgBoxStyle.YesNo, "Perhatian")
                    Case MsgBoxResult.Yes
                        txtMag.Text = Format(mag, "0.0")
                    Case MsgBoxResult.No
                        txtMag.Focus()
                        txtMag.SelectAll()
                End Select
                Exit Sub
            End If
            If txtDepth.Text <= 60 And txtMag.Text >= 6.5 Then
                Select Case MsgBox("Berpotensi Tsunami?", MsgBoxStyle.YesNo, "Perhatian")
                    Case MsgBoxResult.Yes
                        tsunami = "Gempa ini BERPOTENSI TSUNAMI, Untuk diteruskan Kepada Masyarakat"
                        'Me.chkDirasakan.Checked = True
                        If txtInfo.Text = "Informasi Tambahan (Tsunami atau Dirasakan)" Or String.IsNullOrWhiteSpace(txtInfo.Text) Then
                            txtInfo.Text = tsunami
                        Else
                            info = txtInfo.Text
                            'Me.txtInfo.Text = Me.tsunami & ", " & Me.info
                        End If
                    Case MsgBoxResult.No
                        tsunami = "Gempa ini TIDAK BERPOTENSI TSUNAMI"
                End Select
            Else
                tsunami = "Gempa ini TIDAK BERPOTENSI TSUNAMI"
            End If
            If PBEpisenter.Image Is Nothing Then
                'Me.btGenmap.Text = "&Generate Map"
            Else
                btGenmap.Text = "Update Ma&p"
            End If
            GetVal()
            'Hitung()
            'Berita()
            btGenmap.Visible = True
        End If
    End Sub
    Private Sub txtLokasi_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtLokasi.Validating
        If Not String.IsNullOrWhiteSpace(txtLokasi.Text) Then
            txtLokasi.Text = StrConv(txtLokasi.Text, VbStrConv.ProperCase)
            'Else
            '   MsgBox("Lokasi gempa belum dimasukan!", MsgBoxStyle.OkOnly, "Perhatian")
            '  Me.txtLokasi.Focus()
            ' Me.txtLokasi.SelectAll()
        End If
    End Sub
    Private Sub txtInfo_TextChanged(sender As Object, e As EventArgs) Handles txtInfo.TextChanged
        'If Me.txtInfo.Text = "Informasi Tambahan (Tsunami atau Dirasakan)" Or String.IsNullOrWhiteSpace(Me.txtInfo.Text) Then
        'Me.chkDirasakan.Checked = False
        'Else
        'Me.chkDirasakan.Checked = False
        'End If
    End Sub
    Private Sub PanelInfo_Leave(sender As Object, e As EventArgs) Handles PanelInfo.Leave
        'If Me.txtInfo.Text = "Informasi Tambahan (Tsunami atau Dirasakan)" Or String.IsNullOrWhiteSpace(Me.txtInfo.Text) Then
        'Me.chkDirasakan.Checked = False
        'Else
        'Me.chkDirasakan.Checked = True
        'End If
        'info = Me.txtInfo.Text
        If PBEpisenter.Image Is Nothing Then
            'Me.btGenmap.Text = "&Generate Map"
        Else
            btGenmap.Text = "Update Ma&p"
        End If
        GetVal()
        Hitung()
        Berita()
        btNarasi.Enabled = True
        btShake.Enabled = True
        btGenmap.Visible = True
    End Sub
    Private Sub txtLat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLat.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtLon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLon.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtDepth_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDepth.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtMag_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMag.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
#End Region
End Class
