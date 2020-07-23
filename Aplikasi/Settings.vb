Imports MySql.Data.MySqlClient
Public Class FormSettings
#Region "SEISCOMPCONN"
    Public Sub SeisConf()
        KoneksiBasisData()
        Dim dtAdapter As New MySqlDataAdapter
        Try
            koneksi.Open()
            dtSetSeisConf = New DataSet
            sql = "select * from tserver"
            dtAdapter.SelectCommand = New MySqlCommand(sql, koneksi)
            dtAdapter.Fill(dtSetSeisConf, "tserver")
            PosisiRecord = 0
            koneksi.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ListSeisConf()
        If dtSetSeisConf.Tables("tserver").Rows.Count > 0 Then
            PosisiRecord = 0
            txtHost.Text = dtSetSeisConf.Tables("tserver").Rows(PosisiRecord)("host")
            txtUser.Text = dtSetSeisConf.Tables("tserver").Rows(PosisiRecord)("user")
            txtPass.Text = dtSetSeisConf.Tables("tserver").Rows(PosisiRecord)("pass")
            txtDB.Text = dtSetSeisConf.Tables("tserver").Rows(PosisiRecord)("db_name")
        End If
    End Sub
    Sub GetVal()
        scHost = txtHost.Text
        scUser = txtUser.Text
        scPass = txtPass.Text
        scDB = txtDB.Text
        scID = "01"
    End Sub
#End Region
#Region "STORE POCEDURE"
    Sub SimpanSet(ByVal simpan As String)
        Try
            MsgBox("Configurasi Seiscomp3 disimpan")
            koneksi.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Perhatian")
        End Try
    End Sub
    Sub UpdateSet(ByVal update As String)
        Try
            MsgBox("Configurasi Seiscomp3 berhasil diupdate")
            koneksi.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Perhatian")
        End Try
    End Sub
#End Region
#Region "METHODS & EVENTS"
    Private Sub FormSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If dtSetSeisConf.Tables("tserver").Rows.Count = 0 Then
            TextboxEnable4(True)
            Navigasi4(False)
            txtHost.Focus()
        Else
            ListSeisConf()
            Navigasi4(True)
            TextboxEnable4(False)
            btExit.BringToFront()
        End If
    End Sub
    Private Sub btEdit_Click(sender As Object, e As EventArgs) Handles btEdit.Click
        btSave.Text = "&Update"
        Navigasi4(False)
        TextboxEnable4(True)
        lblStatus.Text = ""
        txtHost.Focus()
        txtHost.SelectAll()
    End Sub
    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        If txtHost.Text = String.Empty Then
            MsgBox("Harap memasukan IP Server SeiscomP3", MsgBoxStyle.OkOnly, "Perhatian")
            txtHost.Focus()
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtUser.Text) Then
            MsgBox("Harap memasukan User Database SeiscomP3", MsgBoxStyle.OkOnly, "Perhatian")
            txtUser.Focus()
            Exit Sub
        ElseIf String.IsNullOrEmpty(txtPass.Text) Then
            MsgBox("Harap memasukan Password Database SeiscomP3", MsgBoxStyle.OkOnly, "Perhatian")
            txtPass.Focus()
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtDB.Text) Then
            MsgBox("Harap memasukan Nama Database SeiscomP3", MsgBoxStyle.OkOnly, "Perhatian")
            txtDB.Focus()
            Exit Sub
        End If
        GetVal()
        If btSave.Text = "&Update" Then
            'Me.UpdateMeta("metadataUPDATE")
            modFungsi.updateseisconf(vsc_id:=scID, vsc_host:=scHost, vsc_user:=scUser, vsc_pass:=scPass, vdb:=scDB)
            MsgBox("Configurasi SeiscomP3 berhasil diupdate", MsgBoxStyle.OkOnly, "Perhatian")
        ElseIf btSave.Text = "&Save" Then
            'Me.SimpanMeta("metadataSAVE")
            modFungsi.simpanseisconf(vsc_id:=scID, vsc_host:=scHost, vsc_user:=scUser, vsc_pass:=scPass, vdb:=scDB)
            MsgBox("Configurasi SeiscomP3 disimpan", MsgBoxStyle.OkOnly, "Perhatian")
        End If
        Navigasi4(True)
        TextboxEnable4(False)
        lblStatus.Text = ""
        btExit.Focus()
        SeisConf()
        ListSeisConf()

        'FormInput.DataGempa()
        'FormDaerah.DataDaerah()
        'FormMetadata.Metadata()
        'MsgBox("Settings aplikasi tersimpan. Database updating...!", MsgBoxStyle.OkOnly)
        'btSave.Enabled = False

    End Sub
    Private Sub btConnect_Click(sender As Object, e As EventArgs) Handles btConnect.Click
        If txtHost.Text = String.Empty Then
            MsgBox("Harap memasukan IP Server SeiscomP3", MsgBoxStyle.OkOnly, "Perhatian")
            txtHost.Focus()
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtUser.Text) Then
            MsgBox("Harap memasukan User Database SeiscomP3", MsgBoxStyle.OkOnly, "Perhatian")
            txtUser.Focus()
            Exit Sub
        ElseIf String.IsNullOrEmpty(txtPass.Text) Then
            MsgBox("Harap memasukan Password Database SeiscomP3", MsgBoxStyle.OkOnly, "Perhatian")
            txtPass.Focus()
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtDB.Text) Then
            MsgBox("Harap memasukan Nama Database SeiscomP3", MsgBoxStyle.OkOnly, "Perhatian")
            txtDB.Focus()
            Exit Sub
        End If
        GetVal()
        sc_con = "server=" & scHost & ";user id=" & scUser & ";password=" & scPass & ";database=" & scDB
        sc_koneksi = New MySqlConnection(sc_con)
        Try
            sc_koneksi.Open()
            If sc_koneksi.State = ConnectionState.Open Then
                lblStatus.Text = "Koneksi OK"
                lblStatus.ForeColor = Color.Green
                If btSave.Enabled = True Then
                    MsgBox("Koneksi OK, save settings to connect SeiscomP3")
                End If
            End If
                sc_koneksi.Close()
        Catch ex As Exception
            MessageBox.Show("Koneksi error : " + ex.Message & vbCrLf & vbCrLf & """Check network connection or contact your administrator""")
        End Try
    End Sub
    Private Sub btExit_Click(sender As Object, e As EventArgs) Handles btExit.Click
        lblStatus.Text = ""
        Close()
    End Sub
    Private Sub txtHost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHost.KeyPress
        If Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
#End Region
End Class