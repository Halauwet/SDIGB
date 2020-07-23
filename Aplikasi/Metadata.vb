Imports System.Data
Imports MySql.Data.MySqlClient
'Imports System.Data.SqlClient
Public Class FormMetadata
    Dim NomorSts, KotaSts, NamaSts, KodeSts, TipeSts, PGR, Alamat, Telp, Fax, Web, Email, Fb, ElevasiSts, JumlahKab, Zonawaktu, Twtr, Jab, Nama, NIP As String
    Dim LintangSts, BujurSts As Double
#Region "METADATA"
    Public Sub Metadata()
        KoneksiBasisData()
        Dim dtAdapter As New MySqlDataAdapter
        Try
            koneksi.Open()
            dtSetMeta = New DataSet
            sql = "select * from tmetadata"
            dtAdapter.SelectCommand = New MySqlCommand(sql, koneksi)
            dtAdapter.Fill(dtSetMeta, "tMetadata")
            PosisiRecord = 0
            koneksi.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ListMetadata()
        If dtSetMeta.Tables("tMetadata").Rows.Count > 0 Then
            PosisiRecord = 0
            txtNamasts.Text = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Nama Stasiun")
            txtNomorsts.Text = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Nomor Stasiun")
            txtKodests.Text = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Kode Stasiun")
            txtKotasts.Text = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Kota Stasiun")
            cbTipests.Text = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Tipe Stasiun")
            txtPGR.Text = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR")
            txtLintangsts.Text = Format(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Lintang"), "0.000")
            txtBujursts.Text = Format(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Bujur"), "0.000")
            txtElevsts.Text = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Elevasi")
            txtAlamat.Text = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Alamat")
            txtTelp.Text = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Telp")
            txtFax.Text = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Fax")
            txtWeb.Text = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Website")
            txtMail.Text = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Email")
            txtFB.Text = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Facebook")
            txtJmlhKab.Text = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Jumlah Kab/Kota")
            cbZona.Text = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Zona Waktu")
            txtTwtr.Text = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Twitter")
            txtPJ.Text = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Jabatan")
            txtNama.Text = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Nama")
            txtNIP.Text = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("NIP")
        End If
    End Sub
    Sub GetVal()
        NomorSts = txtNomorsts.Text
        KodeSts = txtKodests.Text
        NamaSts = txtNamasts.Text
        KotaSts = txtKotaSts.Text
        TipeSts = cbTipests.Text
        PGR = txtPGR.Text
        Alamat = txtAlamat.Text
        JumlahKab = txtJmlhKab.Text
        Telp = txtTelp.Text
        Web = txtWeb.Text
        Email = txtMail.Text
        Fb = txtFB.Text
        Twtr = txtTwtr.Text
        Jab = txtPJ.Text
        Nama = txtNama.Text
        NIP = txtNIP.Text
        LintangSts = Val(txtLintangsts.Text)
        BujurSts = Val(txtBujursts.Text)
        If txtElevsts.Text = String.Empty Then
            ElevasiSts = ""
        Else : ElevasiSts = txtElevsts.Text
        End If
        If txtFax.Text = String.Empty Then
            Fax = ""
        Else : Fax = txtFax.Text
        End If
        Zonawaktu = cbZona.Text
    End Sub
#End Region
#Region "STORE POCEDURE"
    'Sub SimpanMeta(ByVal simpan As String)
    'Me.GetVal()
    'Try
    '    koneksi.Open()
    '    cmd = New MySqlCommand()
    '    With cmd
    '        .Connection = koneksi
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = simpan
    '        .Parameters.AddWithValue("@nama_sts", NamaSts)
    '        .Parameters.AddWithValue("@nomor_sts", NomorSts)
    '        .Parameters.AddWithValue("@kode_sts", KodeSts)
    '        .Parameters.AddWithValue("@pgr", PGR)
    '        .Parameters.AddWithValue("@lintang", LintangSts)
    '        .Parameters.AddWithValue("@bujur", BujurSts)
    '        .Parameters.AddWithValue("@elev", ElevasiSts)
    '        .Parameters.AddWithValue("@alamat", Alamat)
    '        .Parameters.AddWithValue("@telp", Telp)
    '        .Parameters.AddWithValue("@fax", Fax)
    '        .Parameters.AddWithValue("@web", Web)
    '        .Parameters.AddWithValue("@mail", Email)
    '        .Parameters.AddWithValue("@fb", Fb)
    '        .Parameters.AddWithValue("@jmlhkab", JumlahKab)
    '        .Parameters.AddWithValue("@zona", Zonawaktu)
    '        .ExecuteNonQuery()
    '    End With
    '    MsgBox("Data Stasiun berhasil disimpan")
    '    koneksi.Close()
    'Catch ex As Exception
    '    MsgBox(ex.Message, MsgBoxStyle.Information, "Perhatian")
    'End Try
    'End Sub
    'Sub UpdateMeta(ByVal update As String)
    ' Me.GetVal()
    ' Try
    ' koneksi.Open()
    ' cmd = New MySqlCommand()
    ' With cmd
    '     .Connection = koneksi
    '     .CommandType = CommandType.StoredProcedure
    '     .CommandText = update
    '     .Parameters.AddWithValue("@nama_sts", NamaSts)
    '     .Parameters.AddWithValue("@nomor_sts", NomorSts)
    '     .Parameters.AddWithValue("@kode_sts", KodeSts)
    '     .Parameters.AddWithValue("@pgr", PGR)
    '     .Parameters.AddWithValue("@lintang", LintangSts)
    '     .Parameters.AddWithValue("@bujur", BujurSts)
    '     .Parameters.AddWithValue("@elev", ElevasiSts)
    '     .Parameters.AddWithValue("@alamat", Alamat)
    '     .Parameters.AddWithValue("@telp", Telp)
    '     .Parameters.AddWithValue("@fax", Fax)
    '     .Parameters.AddWithValue("@web", Web)
    '     .Parameters.AddWithValue("@mail", Email)
    '     .Parameters.AddWithValue("@fb", Fb)
    '     .Parameters.AddWithValue("@jmlhkab", JumlahKab)
    '     .Parameters.AddWithValue("@zona", Zonawaktu)
    '     .ExecuteNonQuery()
    '  End With
    '   MsgBox("Data Stasiun berhasil diupdate")
    '    koneksi.Close()
    ' Catch ex As Exception
    '      MsgBox(ex.Message, MsgBoxStyle.Information, "Perhatian")
    '   End Try
    'End Sub
#End Region
#Region "METHODS & EVENTS"
    Private Sub Metadata_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If dtSetMeta.Tables("tMetadata").Rows.Count = 0 Then
            Navigasi2(False)
            'txtPGR.Text = "IX"
            txtNomorsts.Enabled = True
            txtNomorsts.Focus()
        Else
            ListMetadata()
            Navigasi2(True)
            TextboxEnable2(False)
            txtNomorsts.Enabled = False
            btExit.BringToFront()
        End If
    End Sub
    Private Sub btEdit_Click(sender As Object, e As EventArgs) Handles btEdit.Click
        'Me.btSave.BringToFront()
        btSave.Text = "&Update"
        txtNomorsts.Enabled = False
        Navigasi2(False)
        TextboxEnable2(True)
        txtNamasts.Focus()
        txtNamasts.SelectAll()
    End Sub
    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        If txtNomorsts.Text = String.Empty Then
            MsgBox("Harap memasukan Nomor Stasiun", MsgBoxStyle.OkOnly, "Perhatian")
            txtNomorsts.Focus()
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtKodests.Text) Then
            MsgBox("Harap memasukan Kode Stasiun", MsgBoxStyle.OkOnly, "Perhatian")
            txtKodests.Focus()
            Exit Sub
        ElseIf String.IsNullOrEmpty(txtNamasts.Text) Then
            MsgBox("Harap memasukan Nama Stasiun", MsgBoxStyle.OkOnly, "Perhatian")
            txtNamasts.Focus()
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtKotasts.Text) Then
            MsgBox("Harap memasukan Kota Stasiun", MsgBoxStyle.OkOnly, "Perhatian")
            txtKotaSts.Focus()
            Exit Sub
        ElseIf cbTipests.Text = "-- pilih --" Or cbTipests.Text = String.Empty Then
            MsgBox("Harap memasukan Tipe Stasiun", MsgBoxStyle.OkOnly, "Perhatian")
            cbTipests.Focus()
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtPGR.Text) Then
            MsgBox("Harap memasukan Nomor PGR/Stasiun", MsgBoxStyle.OkOnly, "Perhatian")
            txtPGR.Focus()
            Exit Sub
        ElseIf txtLintangsts.Text = String.Empty Then
            MsgBox("Koordinat Stasiun belum lengkap", MsgBoxStyle.OkOnly, "Perhatian")
            txtLintangsts.Focus()
            Exit Sub
        ElseIf txtBujursts.Text = String.Empty Then
            MsgBox("Koordinat Stasiun belum lengkap", MsgBoxStyle.OkOnly, "Perhatian")
            txtBujursts.Focus()
            Exit Sub
        ElseIf Val(txtLintangsts.Text) > 12 Or Val(txtLintangsts.Text) < -17 Then
            MsgBox("Lintang diluar wilayah Indonesia!", MsgBoxStyle.OkOnly, "Perhatian")
            txtLintangsts.Focus()
            txtLintangsts.SelectAll()
            Exit Sub
        ElseIf Val(txtBujursts.Text) > 147 Or Val(txtBujursts.Text) < 89 Then
            MsgBox("Bujur diluar wilayah Indonesia!", MsgBoxStyle.OkOnly, "Perhatian")
            txtBujursts.Focus()
            txtBujursts.SelectAll()
            Exit Sub
        ElseIf txtAlamat.Text = String.Empty Then
            MsgBox("Harap memasukan Alamat Stasiun", MsgBoxStyle.OkOnly, "Perhatian")
            txtAlamat.Focus()
            Exit Sub
        ElseIf cbZona.Text = "-- pilih --" Or cbZona.Text = String.Empty Then
            MsgBox("Harap memasukan Zona Waktu", MsgBoxStyle.OkOnly, "Perhatian")
            cbZona.Focus()
            Exit Sub
        ElseIf txtJmlhKab.Text = String.Empty Then
            MsgBox("Harap memasukan Jumlah Kabupaten/Kota Data Daerah", MsgBoxStyle.OkOnly, "Perhatian")
            txtJmlhKab.Focus()
            Exit Sub
        ElseIf txtTelp.Text = String.Empty Then
            MsgBox("Harap memasukan Nomer Telp Stasiun", MsgBoxStyle.OkOnly, "Perhatian")
            txtTelp.Focus()
            Exit Sub
        ElseIf txtWeb.Text = String.Empty Then
            txtWeb.Text = "http://www.bmkg.go.id"
        ElseIf txtMail.Text = String.Empty Then
            MsgBox("Harap memasukan E-mail Stasiun", MsgBoxStyle.OkOnly, "Perhatian")
            txtMail.Focus()
            Exit Sub
        ElseIf txtFB.Text = String.Empty Then
            txtFB.Text = "info BMKG"
        ElseIf txtTwtr.Text = String.Empty Then
            txtTwtr.Text = "@@infoBMKG"
        ElseIf txtPJ.Text = String.Empty Then
            MsgBox("Harap memasukan Jabatan penanggung jawab informasi gempabumi", MsgBoxStyle.OkOnly, "Perhatian")
            txtPJ.Focus()
            Exit Sub
        ElseIf txtNama.Text = String.Empty Then
            MsgBox("Harap memasukan Nama penanggung jawab informasi gempabumi", MsgBoxStyle.OkOnly, "Perhatian")
            txtNama.Focus()
            Exit Sub
        ElseIf txtNIP.Text = String.Empty Then
            MsgBox("Harap memasukan NIP penanggung jawab informasi gempabumi", MsgBoxStyle.OkOnly, "Perhatian")
            txtNIP.Focus()
            Exit Sub
        End If
        GetVal()
        If btSave.Text = "&Update" Then
            'Me.UpdateMeta("metadataUPDATE")
            modFungsi.updatemeta(vnomor_sts:=NomorSts, vkode_sts:=KodeSts, vnama_sts:=NamaSts, vkota_sts:=KotaSts, vtipe_sts:=TipeSts, vpgr:=PGR,
                                 vlintang:=LintangSts, vbujur:=BujurSts, velev:=ElevasiSts, valamat:=Alamat,
                                 vtelp:=Telp, vfax:=Fax, vweb:=Web, vmail:=Email, vfb:=Fb, vjmlhkab:=JumlahKab, vzona:=Zonawaktu,
                                 vtwtr:=Twtr, vjab:=Jab, vnama:=Nama, vnip:=NIP)
        ElseIf btSave.Text = "&Save" Then
            'Me.SimpanMeta("metadataSAVE")
            modFungsi.simpanmeta(vnomor_sts:=NomorSts, vkode_sts:=KodeSts, vnama_sts:=NamaSts, vkota_sts:=KotaSts, vtipe_sts:=TipeSts, vpgr:=PGR,
                                 vlintang:=LintangSts, vbujur:=BujurSts, velev:=ElevasiSts, valamat:=Alamat,
                                 vtelp:=Telp, vfax:=Fax, vweb:=Web, vmail:=Email, vfb:=Fb, vjmlhkab:=JumlahKab, vzona:=Zonawaktu,
                                 vtwtr:=Twtr, vjab:=Jab, vnama:=Nama, vnip:=NIP)
            MsgBox("Metadata Stasiun tersimpan. Restart aplikasi!", MsgBoxStyle.OkOnly, "Restart Aplikasi")
            MdiParent.Close()
        End If
        Navigasi2(True)
        TextboxEnable2(False)
        txtNomorsts.Enabled = False
        btExit.Focus()
        Metadata()
        ListMetadata()
        If Application.OpenForms.OfType(Of FormInput).Any Then
            FormInput.Close()
        End If
        If Application.OpenForms.OfType(Of FormSearch).Any Then
            FormSearch.Close()
        End If
        If Application.OpenForms.OfType(Of FormDaerah).Any Then
            FormDaerah.Close()
        End If
        If Application.OpenForms.OfType(Of FormAbout).Any Then
            FormAbout.Close()
        End If
        If Application.OpenForms.OfType(Of FormSettings).Any Then
            FormSettings.Close()
        End If
    End Sub
    Private Sub btCancel_Click(sender As Object, e As EventArgs) Handles btCancel.Click
        Navigasi2(True)
        TextboxEnable2(False)
        txtNomorsts.Enabled = False
        btExit.Focus()
        ListMetadata()
    End Sub
    Private Sub btExit_Click(sender As Object, e As EventArgs) Handles btExit.Click
        Close()
    End Sub
#End Region
#Region "VALIDASI"
    Private Sub txtNomorsts_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNomorsts.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub cbTipests_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbTipests.KeyPress
        e.Handled = True
    End Sub
    Private Sub txtLintangsts_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLintangsts.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtBujursts_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBujursts.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtElevsts_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtElevsts.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub cbZona_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbZona.KeyPress
        e.Handled = True
    End Sub
    Private Sub txtJmlhKab_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJmlhKab.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtTelp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelp.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "(" And e.KeyChar <> ")" And e.KeyChar <> "-" And e.KeyChar <> "+" And e.KeyChar <> " " Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtFax_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFax.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "(" And e.KeyChar <> ")" And e.KeyChar <> "-" And e.KeyChar <> "+" And e.KeyChar <> " " Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtKotaSts_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtKotaSts.Validating
        If Not String.IsNullOrWhiteSpace(txtKotaSts.Text) Then
            KotaSts = txtKotaSts.Text
            txtKotaSts.Text = StrConv(KotaSts, VbStrConv.ProperCase)
        End If
    End Sub
    Private Sub txtNamasts_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNamasts.Validating
        If Not String.IsNullOrWhiteSpace(txtNamasts.Text) Then
            NamaSts = txtNamasts.Text
            txtNamasts.Text = StrConv(NamaSts, VbStrConv.Uppercase)
        End If
    End Sub
    Private Sub txtKodests_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtKodests.Validating
        If txtKodests.Text <> String.Empty Then
            KodeSts = txtKodests.Text
            txtKodests.Text = StrConv(KodeSts, VbStrConv.Uppercase)
        End If
    End Sub
    Private Sub txtPGR_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPGR.Validating
        'If txtPGR.Text <> String.Empty Then
        ' PGR = txtPGR.Text
        ' txtPGR.Text = StrConv(PGR, VbStrConv.Uppercase)
        ' End If
    End Sub
    Private Sub txtAlamat_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAlamat.Validating
        If Not String.IsNullOrWhiteSpace(txtAlamat.Text) Then
            Alamat = txtAlamat.Text
        End If
    End Sub
    Private Sub txtTelp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtTelp.Validating
        If txtTelp.Text <> String.Empty Then
            Telp = txtTelp.Text
        End If
    End Sub
    Private Sub txtFax_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtFax.Validating
        If txtFax.Text <> String.Empty Then
            Fax = txtFax.Text
        End If
    End Sub
    Private Sub txtWeb_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtWeb.Validating
        If txtWeb.Text = String.Empty Then
            txtWeb.Text = "http://www.bmkg.go.id"
        End If
    End Sub
    Private Sub txtMail_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtMail.Validating
        If txtMail.Text <> String.Empty Then
            Email = txtMail.Text
        End If
    End Sub
    Private Sub txtFB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtFB.Validating
        If Me.txtFB.Text = String.Empty Then
            Me.txtFB.Text = "Info BMKG"
        End If
    End Sub
    Private Sub txtLintangsts_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtLintangsts.Validating
        If txtLintangsts.Text <> String.Empty Then
            LintangSts = txtLintangsts.Text
            txtLintangsts.Text = Format(LintangSts, "00.000")
        End If
    End Sub
    Private Sub txtBujursts_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtBujursts.Validating
        If txtBujursts.Text <> String.Empty Then
            BujurSts = txtBujursts.Text
            txtBujursts.Text = Format(BujurSts, "000.000")
        End If
    End Sub
    Private Sub cbZona_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cbZona.Validating
        If cbZona.Text <> String.Empty Then
            Zonawaktu = cbZona.Text
            cbZona.Text = StrConv(Zonawaktu, VbStrConv.Uppercase)
        End If
    End Sub
    Private Sub txtPJ_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPJ.Validating
        If txtPJ.Text <> String.Empty Then
            Jab = txtPJ.Text
            txtPJ.Text = StrConv(Jab, VbStrConv.ProperCase)
        End If
    End Sub
    Private Sub txtTwtr_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtTwtr.Validating
        If txtTwtr.Text = String.Empty Then
            txtTwtr.Text = "@@infoBMKG"
        End If
    End Sub
    Private Sub txtNama_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNama.Validating

    End Sub
    Private Sub txtNIP_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNIP.Validating

    End Sub
#End Region

End Class