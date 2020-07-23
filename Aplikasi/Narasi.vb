Imports System.ComponentModel
Imports System.Math
Imports MySql.Data.MySqlClient
Public Class FormNarasi
    Dim idgempa, sumber_gempa, nama_patahan, mekanisme_patahan, lokasi, daerah, dampak As String
    Dim hari, bulan As String
    Dim wit As Date
    Dim tipe As String
    Dim kota, jab, nama, nip As String
    Dim waktubuat, bulan_narasi, susulan As String
    Dim autoupdate, shakemap, fokal As Boolean
    Dim depth, mag, lintang, bujur As Double
    Dim remark, info, tsunami, tsunaminar, himbauan, desk_makroseismik, desk_arahan, desk_tsunami, desk_sesar, desk_mekanisme, desk_tektonik, desk_depth, deskripsi_sesar, orientasi_sesar, desk_susulan, sufx, jabful As String
    Dim strlintang, strbujur, strzonawaktu As String
    Dim myCulture As System.Globalization.CultureInfo = Globalization.CultureInfo.CurrentCulture
    Dim dayOfWeek As DayOfWeek
    Dim tambahwaktu As Integer
    Dim od, ot As String
    Dim lat, lon As Double
    Dim mytt As New ToolTip

#Region "DATA NARASI"
    Sub DataNarasi()
        idgempa = FormInput.lbEventID.Text
        Dim dtAdapter As New MySqlDataAdapter
        If koneksi.State = ConnectionState.Open Then
            koneksi.Close()
        End If
        Try
            koneksi.Open()
            dtSetNarasi = New DataSet
            sql = "select * from tnarasi"
            dtAdapter.SelectCommand = New MySqlCommand(sql, koneksi)
            dtAdapter.Fill(dtSetNarasi, "tNarasi")
            'PosisiRecord = 0
            koneksi.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub InsertDataNarasi()
        drNarasi = dtSetNarasi.Tables("tNarasi").Select("`ID`='" & idgempa & "'")
        If drNarasi.Length > 0 Then
            timepickerNarasi.Text = CDate(drNarasi(0).Item("Waktu Buat").ToString)
            txtJmlsusulan.Text = drNarasi(0).Item("Jumlah Susulan").ToString
            cbLokasi.Text = drNarasi(0).Item("Lokasi Epicenter").ToString
            txtDaerah.Text = drNarasi(0).Item("Daerah Signifikan").ToString
            cbDampak.Text = drNarasi(0).Item("Dampak").ToString
            chkShakemap.Checked = Convert.ToBoolean(drNarasi(0).Item("Shakemap"))
            cbSumberGempa.Text = drNarasi(0).Item("Sumber Gempa").ToString
            cbNamapatahan.Text = drNarasi(0).Item("Nama Patahan").ToString
            chkFocal.Checked = Convert.ToBoolean(drNarasi(0).Item("fokal"))
            cbMekanismePatahan.Text = drNarasi(0).Item("Mekanisme Patahan").ToString
            deskripsi_sesar = drNarasi(0).Item("Deskripsi Patahan").ToString
            txtNarasi.Text = drNarasi(0).Item("Narasi").ToString
        End If
    End Sub
    Sub fillCBPatahan()
        cbNamapatahan.DataSource = dtSetPatahan.Tables("tPatahan")
        cbNamapatahan.ValueMember = "ID"
        cbNamapatahan.DisplayMember = "Patahan"
    End Sub
#End Region
#Region "KALKULASI"
    Sub GetPar()
        idgempa = lbIDgempa.Text
        With FormInput
            od = .DatePicker.Value.Date.ToString("yyyy/MM/dd")
            ot = .TimePicker.Text
            lat = Val(.txtLat.Text)
            lon = Val(.txtLon.Text)
            depth = Val(.txtDepth.Text)
            If depth > 60 Then
                cbSumberGempa.Text = "Subduksi"
            End If
            mag = Val(.txtMag.Text)
            If .txtDepth.Text <= 60 And .txtMag.Text >= 7 Then
                Select Case MsgBox("Berpotensi Tsunami?", MsgBoxStyle.YesNo, "Perhatian")
                    Case MsgBoxResult.Yes
                        tsunami = "Gempa ini BERPOTENSI TSUNAMI, Untuk diteruskan Kepada Masyarakat"
                        If .txtInfo.Text = "Informasi Tambahan (Tsunami atau Dirasakan)" Or String.IsNullOrWhiteSpace(.txtInfo.Text) Then
                            .txtInfo.Text = tsunami
                        Else
                            info = .txtInfo.Text
                        End If
                        tsunaminar = "BERPOTENSI TSUNAMI"
                        himbauan = ""
                    Case MsgBoxResult.No
                        tsunami = "Gempa ini TIDAK BERPOTENSI TSUNAMI"
                        tsunaminar = "TIDAK BERPOTENSI TSUNAMI"
                        himbauan = "Khususnya masyarakat di pesisir pantai dihimbau agar tidak terpancing isu, karena gempabumi yang terjadi TIDAK BERPOTENSI TSUNAMI."
                        'desk_tsunami = "Meskipun dangkal dan terjadi di laut, gempabumi ini tidak berpotensi tsunami karena kekuatannya tidak cukup besar untuk membangkitkan perubahan di dasar laut yang dapat memicu terjadinya tsunami."
                End Select
            Else
                tsunami = "Gempa ini TIDAK BERPOTENSI TSUNAMI"
                tsunaminar = "TIDAK BERPOTENSI TSUNAMI"
                himbauan = "Khususnya masyarakat di pesisir pantai dihimbau agar tidak terpancing isu, karena gempabumi yang terjadi TIDAK BERPOTENSI TSUNAMI."
                'desk_tsunami = "Meskipun dangkal dan terjadi di laut, gempabumi ini tidak berpotensi tsunami karena kekuatannya tidak cukup besar untuk membangkitkan perubahan di dasar laut yang dapat memicu terjadinya tsunami."
            End If
            If .txtInfo.Text = "Informasi Tambahan (Tsunami atau Dirasakan)" Or String.IsNullOrWhiteSpace(.txtInfo.Text) Then
                info = ""
            Else
                info = .txtInfo.Text
            End If
            PosisiRecord = 0
            strzonawaktu = ""
            tambahwaktu = 0
            If dtSetMeta.Tables("tMetadata").Rows.Count = 0 Then
                tambahwaktu = 0
                strzonawaktu = "UTC"
            ElseIf dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Zona Waktu").ToString = "WIB" Then
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
            kota = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Kota Stasiun").ToString
            kota = StrConv(kota, VbStrConv.ProperCase)
            jab = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Jabatan").ToString
            nama = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Nama").ToString
            nip = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("NIP").ToString
            tipe = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Tipe Stasiun").ToString
            If tipe = "STAGEOF" Then
                jabful = jab & " Stasiun Geofisika " & kota
            ElseIf tipe = "PGR"
                jabful = jab & " Stasiun Geofisika " & kota
            ElseIf tipe = "PUSAT"
                sufx = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString
                jabful = jab & " Pusat " & sufx
            ElseIf tipe = "BALAI"
                sufx = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString
                jabful = jab & " Balai Besar Wilayah " & sufx & " " & kota
            End If
            wit = .DatePicker.Value.Date & " " & .TimePicker.Text
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
        End With
    End Sub
    Sub GetVal()
        If String.IsNullOrWhiteSpace(timepickerNarasi.Text) Then
            MsgBox("Waktu pembuatan narasi belum dimasukan", MsgBoxStyle.OkOnly, "Perhatian")
            timepickerNarasi.Focus()
            SendKeys.Send("{F4}")
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtJmlsusulan.Text) Then
            txtJmlsusulan.Text = 0
        ElseIf cbLokasi.Text = "-- pilih darat/laut --" Then
            MsgBox("Pilih lokasi di darat/laut", MsgBoxStyle.OkOnly, "Perhatian")
            cbLokasi.Focus()
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtDaerah.Text) Then
            MsgBox("Daerah terdampak paling signifikan belum dimasukan", MsgBoxStyle.OkOnly, "Perhatian")
            txtDaerah.Focus()
            Exit Sub
        ElseIf cbDampak.Text = "-- pilih --" Then
            MsgBox("Pilih dampak guncangan di daerah " & txtDaerah.Text, MsgBoxStyle.OkOnly, "Perhatian")
            cbDampak.Focus()
            Exit Sub
        ElseIf cbSumberGempa.Text = "-- pilih --" Then
            MsgBox("Pilih jenis sumber gempa Sesar/Subduksi", MsgBoxStyle.OkOnly, "Perhatian")
            cbSumberGempa.Focus()
            Exit Sub
        End If
        idgempa = lbIDgempa.Text
        'waktubuat = timepickerNarasi.Value.ToString("yyyy/MM/dd")
        If timepickerNarasi.Value.Date > wit.Date Then
            If CDate(timepickerNarasi.Value) >= CDate(DateAdd(DateInterval.Minute, 9, wit)) Then
                waktubuat = timepickerNarasi.Value.ToString("dd/MM/yyyy") & " pukul " & timepickerNarasi.Value.ToString("HH:mm") & " " & strzonawaktu
            Else
                MsgBox("Waktu pembuatan narasi paling cepat 10 menit setelah waktu kejadian gempabumi", MsgBoxStyle.OkOnly, "Perhatian")
                GetPar()
                timepickerNarasi.Text = DateAdd(DateInterval.Minute, 10, wit)
                timepickerNarasi.Focus()
                Exit Sub
            End If
        ElseIf timepickerNarasi.Value.Date = wit.Date Then
            If CDate(timepickerNarasi.Value) >= CDate(DateAdd(DateInterval.Minute, 9, wit)) Then
                waktubuat = "pukul " & timepickerNarasi.Value.ToString("HH:mm") & " " & strzonawaktu
            Else
                MsgBox("Waktu pembuatan narasi paling cepat 10 menit setelah waktu kejadian gempabumi", MsgBoxStyle.OkOnly, "Perhatian")
                GetPar()
                timepickerNarasi.Text = DateAdd(DateInterval.Minute, 10, wit)
                timepickerNarasi.Focus()
                    Exit Sub
                End If
            Else
                MsgBox("Waktu pembuatan narasi tidak bisa lebih dulu dari waktu kejadian gempabumi", MsgBoxStyle.OkOnly, "Perhatian")
            timepickerNarasi.Focus()
            Exit Sub
        End If
        dayOfWeek = myCulture.Calendar.GetDayOfWeek(wit)
        hari = myCulture.DateTimeFormat.GetDayName(dayOfWeek).ToString
        bulan = Format(wit, "MM")
        bulan_narasi = Format(timepickerNarasi.Value, "MM")
        If Val(txtJmlsusulan.Text) <> 0 Then
            susulan = "menunjukan terjadi aktivitas gempabumi susulan (aftershock) sebanyak " & txtJmlsusulan.Text & " kali."
        Else
            susulan = "belum menunjukan adanya aktivitas gempabumi susulan (aftershock)."
        End If
        lokasi = cbLokasi.Text
        daerah = StrConv(txtDaerah.Text, VbStrConv.ProperCase)
        If cbDampak.Text = "1. Dirasakan beberapa orang" Then
            dampak = "dirasakan oleh beberapa orang."
        ElseIf cbDampak.Text = "2. Dirasakan banyak orang" Then
            dampak = "dirasakan oleh banyak orang."
        ElseIf cbDampak.Text = "3. Beberapa orang berhamburan keluar" Then
            dampak = "dirasakan oleh banyak orang, bahkan ada beberapa warga yang berhamburan keluar untuk menyelamatkan diri."
        ElseIf cbDampak.Text = "4. Banyak orang berhamburan keluar"
            dampak = "dirasakan oleh banyak orang yang berhamburan keluar untuk menyelamatkan diri."
        End If
        shakemap = chkShakemap.CheckState
        If depth <= 60 Then
            desk_depth = "dangkal"
        Else : desk_depth = "dalam"
        End If
        If cbNamapatahan.Enabled = True Then
            nama_patahan = cbNamapatahan.Text
            sumber_gempa = nama_patahan
            drPatahan = dtSetPatahan.Tables("tPatahan").Select("`Patahan`='" & cbNamapatahan.Text & "'")
            If drPatahan.Length > 0 Then
                If drPatahan(0).Item("Deskripsi").ToString <> "" Then
                    deskripsi_sesar = drPatahan(0).Item("Deskripsi").ToString
                Else
                    deskripsi_sesar = ""
                End If
            End If
        Else
            sumber_gempa = cbSumberGempa.Text
            nama_patahan = ""
            deskripsi_sesar = ""
        End If
        fokal = chkFocal.CheckState
        If fokal = True Then
            If cbMekanismePatahan.Text = "thrust (naik)" Or cbMekanismePatahan.Text = "thrust" Or cbMekanismePatahan.Text = "naik" Then 'Or
                'cbMekanismePatahan.Text = "sesar naik" Or cbMekanismePatahan.Text = "patahan naik" Or cbMekanismePatahan.Text = "sesar thrust" Then
                orientasi_sesar = "naik"
                mekanisme_patahan = "naik"
            ElseIf cbMekanismePatahan.Text = "normal (turun)" Or cbMekanismePatahan.Text = "normal" Or cbMekanismePatahan.Text = "turun" 'Or
                'cbMekanismePatahan.Text = "sesar turun" Or cbMekanismePatahan.Text = "patahan turun" Or cbMekanismePatahan.Text = "sesar normal"
                orientasi_sesar = "turun"
                mekanisme_patahan = "turun"
            ElseIf cbMekanismePatahan.Text = "oblique (miring)" Or cbMekanismePatahan.Text = "oblique" Or cbMekanismePatahan.Text = "miring" 'Or
                'cbMekanismePatahan.Text = "sesar miring" Or cbMekanismePatahan.Text = "patahan miring" Or cbMekanismePatahan.Text = "sesar oblique"
                orientasi_sesar = "oblique/miring"
                mekanisme_patahan = "oblique/miring"
            ElseIf cbMekanismePatahan.Text = "strike-slip dekstral (kanan)" Or cbMekanismePatahan.Text = "strike-slip dekstral" 'Or
                'cbMekanismePatahan.Text = "sesar datar menganan" Or cbMekanismePatahan.Text = "patahan menganan" Or cbMekanismePatahan.Text = "sesar menganan"
                orientasi_sesar = "mendatar menganan"
                mekanisme_patahan = "mendatar"
            ElseIf cbMekanismePatahan.Text = "strike-slip sinistral (kiri)" Or cbMekanismePatahan.Text = "strike-slip sinistral" 'Or
                ' cbMekanismePatahan.Text = "sesar datar mengiri" Or cbMekanismePatahan.Text = "patahan mengiri" Or cbMekanismePatahan.Text = "sesar mengiri"
                orientasi_sesar = "mendatar mengiri"
                mekanisme_patahan = "mendatar"
            End If
        ElseIf fokal = False
            mekanisme_patahan = ""
            cbMekanismePatahan.Text = ""
        End If
        drGempa = dtSetGempa.Tables("tDataGempa").Select("`Event ID`='" & idgempa & "'")
        If drGempa.Length > 0 Then
            remark = drGempa(0).Item("Remark").ToString
            remark = remark.Split(","c)(0)
        End If
        Indo()
        Narasi()
    End Sub
    Sub GetVal2()
        If String.IsNullOrWhiteSpace(timepickerNarasi.Text) Then
            MsgBox("Tanggal kejadian gempa belum dimasukan", MsgBoxStyle.OkOnly, "Perhatian")
            timepickerNarasi.Focus()
            SendKeys.Send("{F4}")
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtJmlsusulan.Text) Then
            txtJmlsusulan.Text = 0
        ElseIf cbLokasi.Text = "-- pilih darat/laut --" Then
            MsgBox("Pilih lokasi di darat/laut", MsgBoxStyle.OkOnly, "Perhatian")
            cbLokasi.Focus()
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtDaerah.Text) Then
            MsgBox("Daerah terdampak paling signifikan belum dimasukan", MsgBoxStyle.OkOnly, "Perhatian")
            txtDaerah.Focus()
            Exit Sub
        ElseIf cbDampak.Text = "-- pilih --" Then
            MsgBox("Pilih dampak guncangan di daerah " & txtDaerah.Text, MsgBoxStyle.OkOnly, "Perhatian")
            cbDampak.Focus()
            Exit Sub
        ElseIf cbSumberGempa.Text = "-- pilih --" Then
            MsgBox("Pilih jenis sumber gempa Sesar/Subduksi", MsgBoxStyle.OkOnly, "Perhatian")
            cbSumberGempa.Focus()
            Exit Sub
        End If
        idgempa = lbIDgempa.Text
        'waktubuat = timepickerNarasi.Value.ToString("yyyy/MM/dd")
        If timepickerNarasi.Value.Date > wit.Date Then
            waktubuat = timepickerNarasi.Value.ToString("dd/MM/yyyy") & " pukul " & timepickerNarasi.Value.ToString("HH:mm") & " " & strzonawaktu
        ElseIf timepickerNarasi.Value.Date = wit.Date Then
            If CDate(timepickerNarasi.Value) > CDate(wit) Then
                waktubuat = "pukul " & timepickerNarasi.Value.ToString("HH:mm") & " " & strzonawaktu
            Else
                MsgBox("Waktu pembuatan narasi tidak bisa lebih dulu dari waktu kejadian gempabumi", MsgBoxStyle.OkOnly, "Perhatian")
                timepickerNarasi.Focus()
                Exit Sub
            End If
        Else
            MsgBox("Waktu pembuatan narasi tidak bisa lebih dulu dari waktu kejadian gempabumi", MsgBoxStyle.OkOnly, "Perhatian")
            timepickerNarasi.Focus()
            Exit Sub
        End If
        dayOfWeek = myCulture.Calendar.GetDayOfWeek(wit)
        hari = myCulture.DateTimeFormat.GetDayName(dayOfWeek).ToString
        bulan = Format(wit, "MM")
        bulan_narasi = Format(timepickerNarasi.Value, "MM")
        If Val(txtJmlsusulan.Text) <> 0 Then
            susulan = "menunjukan terjadi aktivitas gempabumi susulan (aftershock) sebanyak " & txtJmlsusulan.Text & " kali."
        Else
            susulan = "belum menunjukan adanya aktivitas gempabumi susulan (aftershock)."
        End If
        lokasi = cbLokasi.Text
        daerah = StrConv(txtDaerah.Text, VbStrConv.ProperCase)
        If cbDampak.Text = "1. Dirasakan beberapa orang" Then
            dampak = "dirasakan oleh beberapa orang."
        ElseIf cbDampak.Text = "2. Dirasakan banyak orang" Then
            dampak = "dirasakan oleh banyak orang."
        ElseIf cbDampak.Text = "3. Beberapa orang berhamburan keluar" Then
            dampak = "dirasakan oleh banyak orang, bahkan ada beberapa warga yang berhamburan keluar untuk menyelamatkan diri."
        ElseIf cbDampak.Text = "4. Banyak orang berhamburan keluar"
            dampak = "dirasakan oleh banyak orang yang berhamburan keluar untuk menyelamatkan diri."
        End If
        shakemap = chkShakemap.CheckState
        If depth <= 60 Then
            desk_depth = "dangkal"
        Else : desk_depth = "dalam"
        End If
        If cbNamapatahan.Enabled = True Then
            nama_patahan = cbNamapatahan.Text
            sumber_gempa = nama_patahan
            drPatahan = dtSetPatahan.Tables("tPatahan").Select("`Patahan`='" & cbNamapatahan.Text & "'")
            If drPatahan.Length > 0 Then
                If drPatahan(0).Item("Deskripsi").ToString <> "" Then
                    deskripsi_sesar = drPatahan(0).Item("Deskripsi").ToString
                Else
                    deskripsi_sesar = ""
                End If
            End If
        Else
            sumber_gempa = cbSumberGempa.Text
            nama_patahan = ""
            deskripsi_sesar = ""
        End If
        fokal = chkFocal.CheckState
        If fokal = True Then
            If cbMekanismePatahan.Text = "thrust (naik)" Or cbMekanismePatahan.Text = "thrust" Or cbMekanismePatahan.Text = "naik" Then 'Or
                'cbMekanismePatahan.Text = "sesar naik" Or cbMekanismePatahan.Text = "patahan naik" Or cbMekanismePatahan.Text = "sesar thrust" Then
                orientasi_sesar = "naik"
                mekanisme_patahan = "naik (thrust fault)"
            ElseIf cbMekanismePatahan.Text = "normal (turun)" Or cbMekanismePatahan.Text = "normal" Or cbMekanismePatahan.Text = "turun"Then 'Or
                'cbMekanismePatahan.Text = "sesar turun" Or cbMekanismePatahan.Text = "patahan turun" Or cbMekanismePatahan.Text = "sesar normal"
                orientasi_sesar = "turun"
                mekanisme_patahan = "turun (normal fault)"
            ElseIf cbMekanismePatahan.Text = "oblique (miring)" Or cbMekanismePatahan.Text = "oblique" Or cbMekanismePatahan.Text = "miring"Then 'Or
                'cbMekanismePatahan.Text = "sesar miring" Or cbMekanismePatahan.Text = "patahan miring" Or cbMekanismePatahan.Text = "sesar oblique"
                orientasi_sesar = "oblique/miring"
                mekanisme_patahan = "oblique/miring"
            ElseIf cbMekanismePatahan.Text = "strike-slip dekstral (kanan)" Or cbMekanismePatahan.Text = "strike-slip dekstral" 'Or
                'cbMekanismePatahan.Text = "sesar datar menganan" Or cbMekanismePatahan.Text = "patahan menganan" Or cbMekanismePatahan.Text = "sesar menganan"
                orientasi_sesar = "mendatar menganan"
                mekanisme_patahan = "mendatar (strike-slip fault)"
            ElseIf cbMekanismePatahan.Text = "strike-slip sinistral (kiri)" Or cbMekanismePatahan.Text = "strike-slip sinistral"Then 'Or
                ' cbMekanismePatahan.Text = "sesar datar mengiri" Or cbMekanismePatahan.Text = "patahan mengiri" Or cbMekanismePatahan.Text = "sesar mengiri"
                orientasi_sesar = "mendatar mengiri"
                mekanisme_patahan = "mendatar (strike-slip fault)"
            End If
        ElseIf fokal = False
            mekanisme_patahan = ""
            cbMekanismePatahan.Text = ""
        End If
        drGempa = dtSetGempa.Tables("tDataGempa").Select("`Event ID`='" & idgempa & "'")
        If drGempa.Length > 0 Then
            remark = drGempa(0).Item("Remark").ToString
            remark = remark.Split(","c)(0)
        End If
    End Sub
    Sub Indo()
        If hari = "Sunday" Then
            hari = "Minggu"
        ElseIf hari = "Monday" Then
            hari = "Senin"
        ElseIf hari = "Tuesday" Then
            hari = "Selasa"
        ElseIf hari = "Wednesday" Then
            hari = "Rabu"
        ElseIf hari = "Thursday" Then
            hari = "Kamis"
        ElseIf hari = "Friday" Then
            hari = "Jumat"
        ElseIf hari = "Saturday" Then
            hari = "Sabtu"
        End If
        If Val(bulan) = 1 Then
            bulan = "Januari"
        ElseIf Val(bulan) = 2 Then
            bulan = "Februari"
        ElseIf Val(bulan) = 3 Then
            bulan = "Maret"
        ElseIf Val(bulan) = 4 Then
            bulan = "April"
        ElseIf Val(bulan) = 5 Then
            bulan = "Mei"
        ElseIf Val(bulan) = 6 Then
            bulan = "Juni"
        ElseIf Val(bulan) = 7 Then
            bulan = "Juli"
        ElseIf Val(bulan) = 8 Then
            bulan = "Agustus"
        ElseIf Val(bulan) = 9 Then
            bulan = "September"
        ElseIf Val(bulan) = 10 Then
            bulan = "Oktober"
        ElseIf Val(bulan) = 11 Then
            bulan = "November"
        ElseIf Val(bulan) = 12 Then
            bulan = "Desember"
        End If
        If Val(bulan_narasi) = 1 Then
            bulan_narasi = "Januari"
        ElseIf Val(bulan_narasi) = 2 Then
            bulan_narasi = "Februari"
        ElseIf Val(bulan_narasi) = 3 Then
            bulan_narasi = "Maret"
        ElseIf Val(bulan_narasi) = 4 Then
            bulan_narasi = "April"
        ElseIf Val(bulan_narasi) = 5 Then
            bulan_narasi = "Mei"
        ElseIf Val(bulan_narasi) = 6 Then
            bulan_narasi = "Juni"
        ElseIf Val(bulan_narasi) = 7 Then
            bulan_narasi = "Juli"
        ElseIf Val(bulan_narasi) = 8 Then
            bulan_narasi = "Agustus"
        ElseIf Val(bulan_narasi) = 9 Then
            bulan_narasi = "September"
        ElseIf Val(bulan_narasi) = 10 Then
            bulan_narasi = "Oktober"
        ElseIf Val(bulan_narasi) = 11 Then
            bulan_narasi = "November"
        ElseIf Val(bulan_narasi) = 12 Then
            bulan_narasi = "Desember"
        End If
    End Sub
    Sub Narasi()
        If cbNamapatahan.Enabled = True Then
            If fokal = True Then
                'If tsunaminar = "TIDAK BERPOTENSI TSUNAMI" Then
                ' If lokasi = "laut" And desk_depth = "dangkal" Then
                ' desk_tsunami = "Meskipun dangkal dan terjadi di laut, gempabumi ini tidak berpotensi tsunami karena kekuatannya tidak cukup besar untuk membangkitkan perubahan di dasar laut yang dapat memicu terjadinya tsunami."
                ' Else desk_tsunami = ""
                ' End If
                ' Else desk_tsunami = ""
                ' End If
                If tsunaminar = "TIDAK BERPOTENSI TSUNAMI" Then
                    desk_tsunami = "tidak berpotensi tsunami."
                Else
                    desk_tsunami = "BERPOTENSI TSUNAMI."
                End If
                desk_mekanisme = "Hasil analisis mekanisme sumber menunjukan bahwa gempabumi ini memiliki mekanisme pergerakan " &
                    mekanisme_patahan & ". Mekanisme sumber ini sesuai dan relevan dengan kondisi " & nama_patahan & " yang memiliki orientasi patahan " & orientasi_sesar &
                    " di kedalaman " & depth & " km di daerah tersebut. "
                If deskripsi_sesar = "" Then
                    desk_sesar = ""
                Else
                    desk_sesar = "Dalam hal ini, " & nama_patahan & " " & deskripsi_sesar & " yang menyebabkan terjadi deformasi batuan, sehingga memicu terjadinya gempabumi. "
                End If
                desk_tektonik = "• Dengan memperhatikan lokasi episenter dan kedalaman hiposenter, gempabumi yang terjadi merupakan jenis gempabumi " & desk_depth & " akibat aktivitas " &
                sumber_gempa & ". " & desk_sesar & desk_mekanisme
                If shakemap = True Then
                    desk_makroseismik = "• Dampak gempabumi berdasarkan peta tingkat guncangan (shakemap) BMKG menunjukan bahwa dampak gempabumi berupa guncangan " & info &
                ". Hal ini sesuai dengan informasi yang disampaikan masyarakat, bahwa di daerah tersebut guncangan gempabumi " & dampak &
                " Hingga saat ini belum ada laporan dampak kerusakan yang ditimbulkan akibat gempabumi tersebut. Hasil pemodelan menunjukan bahwa gempabumi ini " &
                desk_tsunami
                Else
                    desk_makroseismik = "• Dampak gempabumi berdasarkan informasi dari masyarakat " & info & ". Di daerah tersebut, guncangan gempabumi " &
                dampak & " Hingga saat ini belum ada laporan dampak kerusakan yang ditimbulkan akibat gempabumi tersebut. Hasil pemodelan menunjukan bahwa gempabumi ini " &
                desk_tsunami
                End If
                If mag >= 3 Then
                    desk_susulan = "• Hingga " & waktubuat & ", hasil monitoring BMKG " & susulan & vbCrLf & vbCrLf & '& himbauan
                    "• Kepada masyarakat dihimbau agar tetap tenang dan tidak terpengaruh oleh isu yang tidak dapat dipertanggungjawabkan kebenarannya, serta menghindari bangunan yang retak atau rusak diakibatkan oleh gempa. Periksa dan pastikan bangunan tempat tinggal anda cukup tahan gempa, ataupun tidak ada kerusakan yang membahayakan kestabilan bangunan sebelum anda kembali kedalam rumah."
                Else
                    desk_susulan = "• Kepada masyarakat dihimbau agar tetap tenang dan tidak terpengaruh oleh isu yang tidak dapat dipertanggungjawabkan kebenarannya, serta menghindari bangunan yang retak atau rusak diakibatkan oleh gempa. Periksa dan pastikan bangunan tempat tinggal anda cukup tahan gempa, ataupun tidak ada kerusakan yang membahayakan kestabilan bangunan sebelum anda kembali kedalam rumah."
                End If
            Else : desk_mekanisme = ""
                If tsunaminar = "TIDAK BERPOTENSI TSUNAMI" Then
                    desk_tsunami = "tidak berpotensi tsunami."
                Else
                    desk_tsunami = "BERPOTENSI TSUNAMI."
                End If
                If deskripsi_sesar = "" Then
                    desk_sesar = ""
                Else
                    desk_sesar = "Dalam hal ini, " & nama_patahan & " " & deskripsi_sesar & " yang menyebabkan terjadi deformasi batuan, sehingga memicu terjadinya gempabumi. "
                End If
                desk_tektonik = "• Dengan memperhatikan lokasi episenter dan kedalaman hiposenter, gempabumi yang terjadi merupakan jenis gempabumi " & desk_depth & " yang diduga akibat aktivitas " &
                sumber_gempa & ". " & desk_sesar & desk_mekanisme
                If shakemap = True Then
                    desk_makroseismik = "• Dampak gempabumi berdasarkan peta tingkat guncangan (shakemap) BMKG menunjukan bahwa dampak gempabumi berupa guncangan " & info &
                ". Hal ini sesuai dengan informasi yang disampaikan masyarakat, bahwa di daerah tersebut guncangan gempabumi " & dampak &
                " Hingga saat ini belum ada laporan dampak kerusakan yang ditimbulkan akibat gempabumi tersebut. Hasil pemodelan menunjukan bahwa gempabumi ini " &
                desk_tsunami
                Else
                    desk_makroseismik = "• Dampak gempabumi berdasarkan informasi dari masyarakat " & info & ". Di daerah tersebut, guncangan gempabumi " &
                dampak & " Hingga saat ini belum ada laporan dampak kerusakan yang ditimbulkan akibat gempabumi tersebut. Hasil pemodelan menunjukan bahwa gempabumi ini " &
                desk_tsunami
                End If
                If mag >= 3 Then
                    desk_susulan = "• Hingga " & waktubuat & ", hasil monitoring BMKG " & susulan & vbCrLf & vbCrLf & '& himbauan
                    "• Kepada masyarakat dihimbau agar tetap tenang dan tidak terpengaruh oleh isu yang tidak dapat dipertanggungjawabkan kebenarannya, serta menghindari bangunan yang retak atau rusak diakibatkan oleh gempa. Periksa dan pastikan bangunan tempat tinggal anda cukup tahan gempa, ataupun tidak ada kerusakan yang membahayakan kestabilan bangunan sebelum anda kembali kedalam rumah."
                Else
                    desk_susulan = "• Kepada masyarakat dihimbau agar tetap tenang dan tidak terpengaruh oleh isu yang tidak dapat dipertanggungjawabkan kebenarannya, serta menghindari bangunan yang retak atau rusak diakibatkan oleh gempa. Periksa dan pastikan bangunan tempat tinggal anda cukup tahan gempa, ataupun tidak ada kerusakan yang membahayakan kestabilan bangunan sebelum anda kembali kedalam rumah."
                End If
            End If
        Else
            desk_sesar = ""
            If fokal = True Then
                If tsunaminar = "TIDAK BERPOTENSI TSUNAMI" Then
                    desk_tsunami = "tidak berpotensi tsunami."
                Else
                    desk_tsunami = "BERPOTENSI TSUNAMI."
                End If
                desk_mekanisme = "Hasil analisis mekanisme sumber menunjukan bahwa gempabumi ini memiliki mekanisme pergerakan " &
                    mekanisme_patahan & ". "
                desk_tektonik = "• Dengan memperhatikan lokasi episenter dan kedalaman hiposenter, gempabumi yang terjadi merupakan jenis gempabumi " & desk_depth & " akibat aktivitas " &
                sumber_gempa & ". " & desk_sesar & desk_mekanisme
                If shakemap = True Then
                    desk_makroseismik = "• Dampak gempabumi berdasarkan peta tingkat guncangan (shakemap) BMKG menunjukan bahwa dampak gempabumi berupa guncangan " & info &
                ". Hal ini sesuai dengan informasi yang disampaikan masyarakat, bahwa di daerah tersebut guncangan gempabumi " & dampak &
                " Hingga saat ini belum ada laporan dampak kerusakan yang ditimbulkan akibat gempabumi tersebut. Hasil pemodelan menunjukan bahwa gempabumi ini " &
                desk_tsunami
                Else
                    desk_makroseismik = "• Dampak gempabumi berdasarkan informasi dari masyarakat " & info & ". Di daerah tersebut, guncangan gempabumi " &
                dampak & " Hingga saat ini belum ada laporan dampak kerusakan yang ditimbulkan akibat gempabumi tersebut. Hasil pemodelan menunjukan bahwa gempabumi ini " &
                desk_tsunami
                End If
                If mag >= 3 Then
                    desk_susulan = "• Hingga " & waktubuat & ", hasil monitoring BMKG " & susulan & vbCrLf & vbCrLf & '& himbauan
                    "• Kepada masyarakat dihimbau agar tetap tenang dan tidak terpengaruh oleh isu yang tidak dapat dipertanggungjawabkan kebenarannya, serta menghindari bangunan yang retak atau rusak diakibatkan oleh gempa. Periksa dan pastikan bangunan tempat tinggal anda cukup tahan gempa, ataupun tidak ada kerusakan yang membahayakan kestabilan bangunan sebelum anda kembali kedalam rumah."
                Else
                    desk_susulan = "• Kepada masyarakat dihimbau agar tetap tenang dan tidak terpengaruh oleh isu yang tidak dapat dipertanggungjawabkan kebenarannya, serta menghindari bangunan yang retak atau rusak diakibatkan oleh gempa. Periksa dan pastikan bangunan tempat tinggal anda cukup tahan gempa, ataupun tidak ada kerusakan yang membahayakan kestabilan bangunan sebelum anda kembali kedalam rumah."
                End If
            Else : desk_mekanisme = ""
                If tsunaminar = "TIDAK BERPOTENSI TSUNAMI" Then
                    desk_tsunami = "tidak berpotensi tsunami."
                Else
                    desk_tsunami = "BERPOTENSI TSUNAMI."
                End If
                desk_tektonik = "• Dengan memperhatikan lokasi episenter dan kedalaman hiposenter, gempabumi yang terjadi merupakan jenis gempabumi " & desk_depth & " akibat aktivitas " &
                sumber_gempa & ". " & desk_sesar & desk_mekanisme
                If shakemap = True Then
                    desk_makroseismik = "• Dampak gempabumi berdasarkan peta tingkat guncangan (shakemap) BMKG menunjukan bahwa dampak gempabumi berupa guncangan " & info &
                ". Hal ini sesuai dengan informasi yang disampaikan masyarakat, bahwa di daerah tersebut guncangan gempabumi " & dampak &
                " Hingga saat ini belum ada laporan dampak kerusakan yang ditimbulkan akibat gempabumi tersebut. Hasil pemodelan menunjukan bahwa gempabumi ini " &
                desk_tsunami
                Else
                    desk_makroseismik = "• Dampak gempabumi berdasarkan informasi dari masyarakat " & info & ". Di daerah tersebut, guncangan gempabumi " &
                dampak & " Hingga saat ini belum ada laporan dampak kerusakan yang ditimbulkan akibat gempabumi tersebut. Hasil pemodelan menunjukan bahwa gempabumi ini " &
                desk_tsunami
                End If
                If mag >= 3 Then
                    desk_susulan = "• Hingga " & waktubuat & ", hasil monitoring BMKG " & susulan & vbCrLf & vbCrLf & '& himbauan
                    "• Kepada masyarakat dihimbau agar tetap tenang dan tidak terpengaruh oleh isu yang tidak dapat dipertanggungjawabkan kebenarannya, serta menghindari bangunan yang retak atau rusak diakibatkan oleh gempa. Periksa dan pastikan bangunan tempat tinggal anda cukup tahan gempa, ataupun tidak ada kerusakan yang membahayakan kestabilan bangunan sebelum anda kembali kedalam rumah."
                Else
                    desk_susulan = "• Kepada masyarakat dihimbau agar tetap tenang dan tidak terpengaruh oleh isu yang tidak dapat dipertanggungjawabkan kebenarannya, serta menghindari bangunan yang retak atau rusak diakibatkan oleh gempa. Periksa dan pastikan bangunan tempat tinggal anda cukup tahan gempa, ataupun tidak ada kerusakan yang membahayakan kestabilan bangunan sebelum anda kembali kedalam rumah."
                End If
            End If
        End If
        txtNarasi.Text = "GEMPABUMI TEKTONIK M" & Format(mag, "0.0") & " GUNCANG " & StrConv(daerah, VbStrConv.Uppercase) & ", " & StrConv(tsunaminar, VbStrConv.Uppercase) & vbCrLf & vbCrLf &
            "• Hari " & hari & ", " & Format(wit, "dd ") & bulan & Format(wit, " yyyy") & ", pukul " & Format(wit, "HH:mm:ss ") & strzonawaktu & " wilayah " &
            StrConv(daerah, VbStrConv.ProperCase) & " dan sekitarnya diguncang gempabumi tektonik. Hasil analisis BMKG menunjukan gempabumi ini memiliki kekuatan M=" &
            Format(mag, "0.0") & ". Episenter gempabumi terletak pada koordinat " & lintang & " " & strlintang & " dan " & bujur & " " & strbujur &
            ", atau tepatnya berlokasi di " & lokasi & " " & remark & " pada kedalaman " & depth & " km." & vbCrLf & vbCrLf &
            desk_tektonik & vbCrLf & vbCrLf &
            desk_makroseismik & vbCrLf & vbCrLf &
            desk_susulan & vbCrLf & vbCrLf &
            "• Pastikan informasi resmi hanya bersumber dari BMKG yang disebarkan melalui kanal komunikasi resmi yang telah terverifikasi (Instagram/Twitter @infoBMKG), website (www.bmkg.go.id atau inatews.bmkg.go.id), atau melalui Mobile Apps (IOS dan Android): wrs-bmkg atau infobmkg." & vbCrLf & vbCrLf &
            kota & ", " & Format(timepickerNarasi.Value, "dd") & " " & bulan_narasi & " " & Format(timepickerNarasi.Value, "yyyy") & vbCrLf & vbCrLf & vbCrLf &
            nama & vbCrLf & jabful
    End Sub
#End Region
#Region "METHODS & EVENTS"
    Private Sub FormNarasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetPar()
        Navigasi5(False)
        If FormInput.btNarasi.Text = "Buat Narasi" Then
            btSave.Text = "&Save"
            timepickerNarasi.Text = DateAdd(DateInterval.Minute, 10, wit)
            cbNamapatahan.Enabled = False
            panelMekanisme.Enabled = False
            ' autoupdate = True
        ElseIf FormInput.btNarasi.Text = "Edit Narasi"
            btSave.Text = "&Update"
            DataNarasi()
            InsertDataNarasi()
            'autoupdate = False
        End If
    End Sub
    Private Sub panelMekanisme_Leave(sender As Object, e As EventArgs) Handles panelMekanisme.Leave
        If fokal = True And cbMekanismePatahan.Text = "-- pilih --" Or fokal = True And cbMekanismePatahan.Text = "" Then
            Select Case MsgBox("Apakah ada data mekanisme fokal?", MsgBoxStyle.YesNo, "Perhatian")
                Case MsgBoxResult.Yes
                    MsgBox("Pilih jenis patahan naik/turun/geser", MsgBoxStyle.OkOnly, "Perhatian")
                    cbMekanismePatahan.DroppedDown = True
                    cbMekanismePatahan.Focus()
                    Exit Sub
                Case MsgBoxResult.No
                    chkFocal.Checked = False
            End Select
        End If
    End Sub
    Private Sub Panel1_Leave(sender As Object, e As EventArgs) Handles panelPatahan.Leave
        If cbSumberGempa.Text = "Sesar (terdefinisi)" And cbNamapatahan.Text = "" Or cbSumberGempa.Text = "Sesar (terdefinisi)" And cbNamapatahan.Text = "-- pilih --" Then
            Select Case MsgBox("Apakah patahan gempa terdefinisi?", MsgBoxStyle.YesNo, "Perhatian")
                Case MsgBoxResult.Yes
                    MsgBox("Pilih nama patahan sumber gempa", MsgBoxStyle.OkOnly, "Perhatian")
                    cbNamapatahan.Focus()
                    If dtSetPatahan.Tables("tPatahan").Rows.Count > 0 Then
                        fillCBPatahan()
                        cbNamapatahan.DroppedDown = True
                    End If
                    Exit Sub
                Case MsgBoxResult.No
                    MsgBox("Ubah jenis patahan Sesar lokal/Subduksi", MsgBoxStyle.OkOnly, "Perhatian")
                    cbSumberGempa.DroppedDown = True
                    cbSumberGempa.SelectedIndex = 0
                    cbSumberGempa.Focus()
                    cbNamapatahan.Enabled = False
                    cbNamapatahan.Text = ""
                    Exit Sub
            End Select
        End If
        GetVal()
        'Indo()
        'Narasi()
        ' If autoupdate = False Then
        ' autoupdate = True
        ' End If
    End Sub
    Private Sub cbNamapatahan_Click(sender As Object, e As EventArgs) Handles cbNamapatahan.Click
        If dtSetPatahan.Tables("tPatahan").Rows.Count > 0 Then
            fillCBPatahan()
        End If
    End Sub
    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        If fokal = True And cbMekanismePatahan.Text = "-- pilih --" Or fokal = True And cbMekanismePatahan.Text = "" Then
            Select Case MsgBox("Apakah ada data mekanisme fokal?", MsgBoxStyle.YesNo, "Perhatian")
                Case MsgBoxResult.Yes
                    MsgBox("Pilih jenis patahan naik/turun/geser", MsgBoxStyle.OkOnly, "Perhatian")
                    cbMekanismePatahan.DroppedDown = True
                    cbMekanismePatahan.Focus()
                    Exit Sub
                Case MsgBoxResult.No
                    chkFocal.Checked = False
            End Select
        End If
        If cbSumberGempa.Text = "Sesar (terdefinisi)" And cbNamapatahan.Text = "" Or cbSumberGempa.Text = "Sesar (terdefinisi)" And cbNamapatahan.Text = "-- pilih --" Then
            Select Case MsgBox("Apakah patahan gempa terdefinisi?", MsgBoxStyle.YesNo, "Perhatian")
                Case MsgBoxResult.Yes
                    MsgBox("Pilih nama patahan sumber gempa", MsgBoxStyle.OkOnly, "Perhatian")
                    cbNamapatahan.Focus()
                    If dtSetPatahan.Tables("tPatahan").Rows.Count > 0 Then
                        fillCBPatahan()
                        cbNamapatahan.DroppedDown = True
                    End If
                    Exit Sub
                Case MsgBoxResult.No
                    MsgBox("Ubah jenis patahan Sesar lokal/Subduksi", MsgBoxStyle.OkOnly, "Perhatian")
                    cbSumberGempa.DroppedDown = True
                    cbSumberGempa.SelectedIndex = 0
                    cbSumberGempa.Focus()
                    cbNamapatahan.Enabled = False
                    cbNamapatahan.Text = ""
                    Exit Sub
            End Select
        End If
        GetVal2()
        'Indo()
        'Narasi()
        If btSave.Text = "&Save" Then
            modFungsi.simpannarasi(vevent_id:=idgempa, vwaktubuat:=timepickerNarasi.Value.ToString("yyyy/MM/dd HH:mm"), vsusulan:=txtJmlsusulan.Text,
                                   vlokasi:=lokasi, vdaerah:=daerah, vdampak:=cbDampak.Text, vshakemap:=shakemap, vsumber:=cbSumberGempa.Text,
                                   vpatahan:=nama_patahan, vdeskripsi:=deskripsi_sesar, vfokal:=fokal, vmekanisme:=cbMekanismePatahan.Text, vnarasi:=txtNarasi.Text)
        ElseIf btSave.Text = "&Update"
            modFungsi.updatenarasi(vevent_id:=idgempa, vwaktubuat:=timepickerNarasi.Value.ToString("yyyy/MM/dd HH:mm"), vsusulan:=txtJmlsusulan.Text,
                                   vlokasi:=lokasi, vdaerah:=daerah, vdampak:=cbDampak.Text, vshakemap:=shakemap, vsumber:=cbSumberGempa.Text,
                                   vpatahan:=nama_patahan, vdeskripsi:=deskripsi_sesar, vfokal:=fokal, vmekanisme:=cbMekanismePatahan.Text, vnarasi:=txtNarasi.Text)
            btSave.Text = "&Save"
        End If
        Navigasi5(True)
        DataNarasi()
        drNarasi = dtSetNarasi.Tables("tNarasi").Select("`ID`='" & idgempa & "'")
        If drNarasi.Length > 0 Then
            FormInput.btNarasi.Text = "Edit Narasi"
        Else
            FormInput.btNarasi.Text = "Buat Narasi"
        End If
        btExit.BringToFront()
        btExit.Focus()
    End Sub
    Private Sub btDelete_Click(sender As Object, e As EventArgs) Handles btDelete.Click
        If lbIDgempa.Text <> "" Then
            Select Case MsgBox("Hapus Narasi " & lbIDgempa.Text & "?", MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    txtNarasi.Clear()
                    modFungsi.hapusnarasi(vevent_id:=idgempa)
                    Navigasi5(False)
                    LayarBersih5()
                    TextboxEnable5(False)
                    DataNarasi()
                    btSave.Text = "&Save"
                    btSave.BringToFront()
                    btSave.Focus()
            End Select
            drNarasi = dtSetNarasi.Tables("tNarasi").Select("`ID`='" & lbIDgempa.Text & "'")
            If drNarasi.Length > 0 Then
                FormInput.btNarasi.Text = "Edit Narasi"
            Else
                FormInput.btNarasi.Text = "Buat Narasi"
            End If
        End If
    End Sub
    Private Sub btCopyNarasi_Click(sender As Object, e As EventArgs) Handles btCopyNarasi.Click
        Clipboard.Clear()
        If String.IsNullOrWhiteSpace(txtNarasi.Text) Then
        Else
            Clipboard.SetText(txtNarasi.Text)
            'btCopyNarasi.Enabled = False
        End If
    End Sub
    Private Sub btExit_Click(sender As Object, e As EventArgs) Handles btExit.Click
        Close()
    End Sub
#End Region
#Region "VALIDASI"
    Private Sub timepickerNarasi_Enter(sender As Object, e As EventArgs) Handles timepickerNarasi.Enter
        mytt.Show("Waktu pembuatan narasi dalam waktu lokal", timepickerNarasi)
    End Sub
    Private Sub timepickerNarasi_Leave(sender As Object, e As EventArgs) Handles timepickerNarasi.Leave
        mytt.Hide(timepickerNarasi)
        'txtJmlsusulan.Text = CDate(timepickerNarasi.Value)
        'txtDaerah.Text = CDate(wit)
        If timepickerNarasi.Value.Date > wit.Date Then
            If CDate(timepickerNarasi.Value) >= CDate(DateAdd(DateInterval.Minute, 9, wit)) Then
                waktubuat = timepickerNarasi.Value.ToString("dd/MM/yyyy") & " pukul " & timepickerNarasi.Value.ToString("HH:mm") & " " & strzonawaktu
            Else
                MsgBox("Waktu pembuatan narasi paling cepat 10 menit setelah waktu kejadian gempabumi", MsgBoxStyle.OkOnly, "Perhatian")
                GetPar()
                timepickerNarasi.Text = DateAdd(DateInterval.Minute, 10, wit)
                timepickerNarasi.Focus()
                Exit Sub
            End If
        ElseIf timepickerNarasi.Value.Date = wit.Date Then
            If CDate(timepickerNarasi.Value) >= CDate(DateAdd(DateInterval.Minute, 9, wit)) Then
                waktubuat = "pukul " & timepickerNarasi.Value.ToString("HH:mm") & " " & strzonawaktu
            Else
                MsgBox("Waktu pembuatan narasi paling cepat 10 menit setelah waktu kejadian gempabumi", MsgBoxStyle.OkOnly, "Perhatian")
                GetPar()
                timepickerNarasi.Text = DateAdd(DateInterval.Minute, 10, wit)
                timepickerNarasi.Focus()
                Exit Sub
            End If
        Else
            MsgBox("Waktu pembuatan narasi tidak bisa lebih dulu dari waktu kejadian gempabumi", MsgBoxStyle.OkOnly, "Perhatian")
            timepickerNarasi.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub panelMekanisme_EnabledChanged(sender As Object, e As EventArgs) Handles panelMekanisme.EnabledChanged
        If panelMekanisme.Enabled = False Then
            chkFocal.Checked = False
            cbMekanismePatahan.Text = ""
        End If
    End Sub
    Private Sub cbSumberGempa_TextChanged(sender As Object, e As EventArgs) Handles cbSumberGempa.TextChanged
        If cbSumberGempa.Text = "Sesar lokal" Then
            cbNamapatahan.Enabled = False
            panelMekanisme.Enabled = False
        ElseIf cbSumberGempa.Text = "Subduksi" Then
            cbNamapatahan.Enabled = False
            panelMekanisme.Enabled = True
        Else
            cbNamapatahan.Enabled = True
            panelMekanisme.Enabled = True
        End If
        If txtNarasi.Text <> "" Then
            GetVal()
            If btSave.Enabled = False Then
                Navigasi5(False)
                btSave.Text = "&Update"
            End If
            ' Indo()
            'Narasi()
        End If
    End Sub
    Private Sub cbSumberGempa_Validating(sender As Object, e As CancelEventArgs) Handles cbSumberGempa.Validating
        If cbSumberGempa.Text = "Sesar lokal" Then
            cbNamapatahan.Enabled = False
            panelMekanisme.Enabled = False
        ElseIf cbSumberGempa.Text = "Subduksi" Then
            cbNamapatahan.Enabled = False
            panelMekanisme.Enabled = True
        Else
            cbNamapatahan.Enabled = True
            panelMekanisme.Enabled = True
        End If
    End Sub
    Private Sub cbMekanismePatahan_TextChanged(sender As Object, e As EventArgs) Handles cbMekanismePatahan.TextChanged
        If cbMekanismePatahan.Text = "-- pilih --" Or String.IsNullOrWhiteSpace(cbMekanismePatahan.Text) Then
            chkFocal.Checked = False
        Else : chkFocal.Checked = True
        End If
        If txtNarasi.Text <> "" Then
            If btSave.Enabled = False Then
                Navigasi5(False)
                btSave.Text = "&Update"
            End If
            GetVal()
            'Indo()
            'Narasi()
        End If
    End Sub
    Private Sub cbNamapatahan_TextChanged(sender As Object, e As EventArgs) Handles cbNamapatahan.TextChanged
        If cbNamapatahan.Text = "" Or cbNamapatahan.Text = "-- pilih --" Then
            cbNamapatahan.Enabled = False
        Else : cbNamapatahan.Enabled = True
            drPatahan = dtSetPatahan.Tables("tPatahan").Select("`Patahan`='" & cbNamapatahan.Text & "'")
            If drPatahan.Length > 0 Then
                If drPatahan(0).Item("Mekanisme").ToString <> "" Then
                    cbMekanismePatahan.Text = drPatahan(0).Item("Mekanisme").ToString
                Else
                    cbMekanismePatahan.Text = "-- pilih --"
                End If
            End If
        End If
        If txtNarasi.Text <> "" Then
            If btSave.Enabled = False Then
                Navigasi5(False)
                btSave.Text = "&Update"
            End If
            GetVal()
            '  Indo()
            '   Narasi()
        End If
    End Sub
    Private Sub cbNamapatahan_GotFocus(sender As Object, e As EventArgs) Handles cbNamapatahan.GotFocus
        If dtSetPatahan.Tables("tPatahan").Rows.Count > 0 Then
            fillCBPatahan()
            cbNamapatahan.DroppedDown = True
        End If
    End Sub
    Private Sub chkShakemap_CheckedChanged(sender As Object, e As EventArgs) Handles chkShakemap.CheckedChanged
        If txtNarasi.Text <> "" Then
            If btSave.Enabled = False Then
                Navigasi5(False)
                btSave.Text = "&Update"
            End If
            GetVal()
            ' Indo()
            'Narasi()
        End If
    End Sub
    Private Sub chkFocal_CheckedChanged(sender As Object, e As EventArgs) Handles chkFocal.CheckedChanged
        If txtNarasi.Text <> "" Then
            GetVal()
            If btSave.Enabled = False Then
                Navigasi5(False)
                btSave.Text = "&Update"
            End If
            ' Indo()
            'Narasi()
        End If
    End Sub
    Private Sub cbDampak_TextChanged(sender As Object, e As EventArgs) Handles cbDampak.TextChanged
        If txtNarasi.Text <> "" Then
            GetVal()
            If btSave.Enabled = False Then
                Navigasi5(False)
                btSave.Text = "&Update"
            End If
            'Indo()
            'Narasi()
        End If
    End Sub
    Private Sub txtDaerah_TextChanged(sender As Object, e As EventArgs) Handles txtDaerah.TextChanged
        If txtNarasi.Text <> "" Then
            GetVal()
            If btSave.Enabled = False Then
                Navigasi5(False)
                btSave.Text = "&Update"
            End If
            ' Indo()
            ' Narasi()
        End If
    End Sub
    Private Sub cbLokasi_TextChanged(sender As Object, e As EventArgs) Handles cbLokasi.TextChanged
        If txtNarasi.Text <> "" Then
            GetVal()
            If btSave.Enabled = False Then
                Navigasi5(False)
                btSave.Text = "&Update"
            End If
            'Indo()
            'Narasi()
        End If
    End Sub
    Private Sub txtJmlsusulan_TextChanged(sender As Object, e As EventArgs) Handles txtJmlsusulan.TextChanged
        If txtNarasi.Text <> "" Then
            GetVal()
            If btSave.Enabled = False Then
                Navigasi5(False)
                btSave.Text = "&Update"
            End If
            'Indo()
            'Narasi()
        End If
    End Sub
    Private Sub timepickerNarasi_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles timepickerNarasi.Validating
        If txtNarasi.Text <> "" Then
            GetVal()
            If btSave.Enabled = False Then
                Navigasi5(False)
                btSave.Text = "&Update"
            End If
            ' Indo()
            'Narasi()
        End If
    End Sub
    Private Sub cbLokasi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbLokasi.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            e.Handled = True
        End If
    End Sub
    Private Sub cbMMI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbDampak.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            e.Handled = True
        End If
    End Sub
    Private Sub cbJenisPatahan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbMekanismePatahan.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            e.Handled = True
        End If
    End Sub
    Private Sub cbNamapatahan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbNamapatahan.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            e.Handled = True
        End If
    End Sub
    Private Sub cbSumberGempa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbSumberGempa.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            e.Handled = True
        End If
    End Sub

    Private Sub btCopyNarasi_EnabledChanged(sender As Object, e As EventArgs) Handles btCopyNarasi.EnabledChanged
        If btCopyNarasi.Enabled = True Then
            btCopyNarasi.Text = "&Copy Narasi"
        Else : btCopyNarasi.Text = "Copied"
        End If
    End Sub
#End Region
End Class