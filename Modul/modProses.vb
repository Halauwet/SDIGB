Imports System.Data
'Imports System.Data.SqlClient
Module modProses
#Region "UMUM"
    Sub aturPosisiObjek()
        With FormInput
            .Text = ".: Input Parameter :."
            .BackColor = Color.DarkSeaGreen
            .WindowState = FormWindowState.Maximized
            '.PanelLuar.Location = New System.Drawing.Point(203, 75) '203, 127
            '.PanelLuar.Size = New System.Drawing.Point(869, 565) '869; 551
            '.PanelLuar.BackColor = Color.WhiteSmoke
            .txtInfo.Text = "Informasi Tambahan (Tsunami atau Dirasakan)"
            .btCopy.Enabled = False
            .txtBerita.ReadOnly = True
        End With
        With FormMetadata
            .Text = "Metadata Stasiun"
            .BackColor = Color.DarkSeaGreen
            '.WindowState = FormWindowState.Maximized
        End With
    End Sub
#End Region

#Region "NAVIGASI"
    Public Sub Navigasi(ByVal tombol As Boolean)
        With FormInput
            .btInput.Enabled = Not tombol
            .btSave.Enabled = tombol
            .btEdit.Enabled = Not tombol
            .btDelete.Enabled = Not tombol
            .btCancel.Enabled = tombol
            .btSaveMap.Enabled = tombol
            .btGenmap.Visible = Not tombol
            .btShake.Enabled = Not tombol
            .btNarasi.Enabled = Not tombol
            .MapProgress.Visible = Not tombol
            '.btCopy.Enabled = Not tombol
        End With
    End Sub
    Public Sub Navigasi2(ByVal tombol As Boolean)
        With FormMetadata
            .btEdit.Enabled = tombol
            .btSave.Enabled = Not tombol
            .btCancel.Enabled = Not tombol
            .btExit.Enabled = tombol
        End With
    End Sub
    Public Sub Navigasi3(ByVal tombol As Boolean)
        With FormDaerah
            .btAdd.Enabled = tombol
            .btEdit.Enabled = tombol
            .btSave.Enabled = Not tombol
            .btDelete.Enabled = tombol
            .btCancel.Enabled = Not tombol
            .btExit.Enabled = tombol
        End With
    End Sub
    Public Sub Navigasi4(ByVal tombol As Boolean)
        With FormSettings
            .btEdit.Enabled = tombol
            .btSave.Enabled = Not tombol
            '.btConnect.Enabled = Not tombol
            .btExit.Enabled = tombol
        End With
    End Sub
    Public Sub Navigasi5(ByVal tombol As Boolean)
        With FormNarasi
            .btSave.Enabled = Not tombol
            '.btCopyNarasi.Enabled = tombol
            .btDelete.Enabled = tombol
            '.btExit.Enabled = tombol
        End With
    End Sub
    Public Sub Navigasi6(ByVal tombol As Boolean)
        With FormPatahan
            .btAdd.Enabled = tombol
            .btEdit.Enabled = tombol
            .btSave.Enabled = Not tombol
            .btDelete.Enabled = tombol
            .btCancel.Enabled = Not tombol
            .btExit.Enabled = tombol
        End With
    End Sub
#End Region

#Region "TEXTBOX"
    Public Sub TextboxEnable(ByRef aktif As Boolean)
        With FormInput
            .DatePicker.Enabled = aktif
            .TimePicker.Enabled = aktif
            .txtLat.Enabled = aktif
            .txtLon.Enabled = aktif
            .txtDepth.Enabled = aktif
            .txtMag.Enabled = aktif
            '.txtLokasi.Enabled = aktif
            '.Enabled = aktif
            .txtInfo.Enabled = aktif
            '.txtInfo.Text = "Informasi Tambahan (Tsunami atau Dirasakan)"
            '.lvwGempa.Enabled = Not aktif
        End With
    End Sub
    Public Sub TextboxEnable2(ByRef aktif As Boolean)
        With FormMetadata
            .txtNamasts.Enabled = aktif
            .txtKotaSts.Enabled = aktif
            .txtKodests.Enabled = aktif
            .cbTipests.Enabled = aktif
            .txtPGR.Enabled = aktif
            .txtLintangsts.Enabled = aktif
            .txtBujursts.Enabled = aktif
            .txtElevsts.Enabled = aktif
            .txtAlamat.Enabled = aktif
            .txtTelp.Enabled = aktif
            .txtFax.Enabled = aktif
            .txtWeb.Enabled = aktif
            .txtMail.Enabled = aktif
            .txtFB.Enabled = aktif
            .txtTwtr.Enabled = aktif
            .txtPJ.Enabled = aktif
            .txtNama.Enabled = aktif
            .txtNIP.Enabled = aktif
            .txtJmlhKab.Enabled = aktif
            .cbZona.Enabled = aktif
        End With
    End Sub
    Public Sub TextboxEnable3(ByRef aktif As Boolean)
        With FormDaerah
            .txtDaerah.Enabled = aktif
            .txtLintang.Enabled = aktif
            .txtBujur.Enabled = aktif
            .txtBarat.Enabled = aktif
            .txtTimur.Enabled = aktif
            .txtUtara.Enabled = aktif
            .txtSelatan.Enabled = aktif
        End With
    End Sub
    Public Sub TextboxEnable4(ByRef aktif As Boolean)
        With FormSettings
            .txtHost.Enabled = aktif
            .txtUser.Enabled = aktif
            .txtPass.Enabled = aktif
            .txtDB.Enabled = aktif
        End With
    End Sub
    Public Sub TextboxEnable5(ByRef aktif As Boolean)
        With FormNarasi
            .cbNamapatahan.Enabled = aktif
            .panelMekanisme.Enabled = aktif
        End With
    End Sub
    Public Sub TextboxEnable6(ByRef aktif As Boolean)
        With FormPatahan
            .txtPatahan.Enabled = aktif
            .txtDeskripsi.Enabled = aktif
            .cbMekanisme.Enabled = aktif
            .txtBarat.Enabled = aktif
            .txtTimur.Enabled = aktif
            .txtUtara.Enabled = aktif
            .txtSelatan.Enabled = aktif
            .txtSumberdata.Enabled = aktif
        End With
    End Sub
#End Region

#Region "LAYARBERSIH"
    Public Sub LayarBersih()
        With FormInput
            .lbEventID.Text = ""
            .TimePicker.Text = ""
            .DatePicker.Text = ""
            .txtLat.Clear()
            .txtLon.Clear()
            .txtDepth.Clear()
            .txtMag.Clear()
            .txtLokasi.Clear()
            .txtInfo.Clear()
            '.chkDirasakan.Checked = False
            .lblDaerah.Visible = False
            .lblDaerah1.Text = ""
            .lblDaerah2.Text = ""
            .lblDaerah3.Text = ""
            .lblDaerah4.Text = ""
            .DatePicker.Format = DateTimePickerFormat.Custom
            .TimePicker.Format = DateTimePickerFormat.Custom
            .DatePicker.CustomFormat = "dd/MM/yyyy"
            .TimePicker.CustomFormat = "HH:mm:ss"
            .PBEpisenter.Image = Nothing
        End With
    End Sub
    Public Sub lblBersih()
        With FormInput
            .lblDaerah1.Text = ""
            .lblDaerah2.Text = ""
            .lblDaerah3.Text = ""
            .lblDaerah4.Text = ""
        End With
    End Sub
    Public Sub LayarBersih2()
        With FormMetadata
            .txtNomorsts.Clear()
            .txtKotaSts.Clear()
            .txtNamasts.Clear()
            .txtKodests.Clear()
            .txtPGR.Clear()
            .txtLintangsts.Clear()
            .txtBujursts.Clear()
            .txtElevsts.Clear()
            .txtAlamat.Clear()
            .txtTelp.Clear()
            .txtFax.Clear()
            .txtWeb.Clear()
            .txtMail.Clear()
            .txtFB.Clear()
            .txtTwtr.Clear()
            .txtPJ.Clear()
            .txtNama.Clear()
            .txtNIP.Clear()
            .cbZona.Text = ""
        End With
    End Sub
    Public Sub LayarBersih3()
        With FormDaerah
            .lblID.Text = ""
            .txtDaerah.Clear()
            .txtLintang.Clear()
            .txtBujur.Clear()
            .txtBarat.Clear()
            .txtTimur.Clear()
            .txtUtara.Clear()
            .txtSelatan.Clear()
        End With
    End Sub
    Public Sub LayarBersih4()
        With FormSettings
            .txtHost.Clear()
            .txtUser.Clear()
            .txtPass.Clear()
        End With
    End Sub
    Public Sub LayarBersih5()
        With FormNarasi
            .txtJmlsusulan.Clear()
            .cbLokasi.Text = "-- pilih darat/laut --"
            .txtDaerah.Clear()
            .cbDampak.Text = "-- pilih --"
            .chkShakemap.Checked = False
            .cbSumberGempa.Text = "-- pilih --"
            .cbNamapatahan.Text = "-- pilih --"
            .chkFocal.Checked = False
            .cbMekanismePatahan.Text = ""
            .txtNarasi.Clear()
        End With
    End Sub
    Public Sub LayarBersih6()
        With FormPatahan
            .lblID.Text = ""
            .txtPatahan.Clear()
            .txtDeskripsi.Clear()
            .cbMekanisme.Text = "-- pilih --"
            .txtBarat.Clear()
            .txtTimur.Clear()
            .txtUtara.Clear()
            .txtSelatan.Clear()
            .txtSumberdata.Clear()
        End With
    End Sub
#End Region
End Module
