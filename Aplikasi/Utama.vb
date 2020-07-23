Imports MySql.Data.MySqlClient
Public Class FormUtama
#Region "METHODS & EVENTS"
    Public Sub backup_data()
        Dim startbackup As New ProcessStartInfo("backup_db/backup_db.bat")
        startbackup.WindowStyle = ProcessWindowStyle.Minimized
        startbackup.WindowStyle = ProcessWindowStyle.Hidden
        startbackup.CreateNoWindow = True
        startbackup.UseShellExecute = False
        Dim proc_backup As Process = Process.Start(startbackup)
    End Sub
    Public Sub close_allform()
        If Application.OpenForms.OfType(Of FormInput).Any Then
            FormInput.Close()
        End If
        If Application.OpenForms.OfType(Of FormSearch).Any Then
            FormSearch.Close()
        End If
        If Application.OpenForms.OfType(Of FormMetadata).Any Then
            FormMetadata.Close()
        End If
        If Application.OpenForms.OfType(Of FormDaerah).Any Then
            FormDaerah.Close()
        End If
        If Application.OpenForms.OfType(Of FormPatahan).Any Then
            FormPatahan.Close()
        End If
        If Application.OpenForms.OfType(Of FormAbout).Any Then
            FormAbout.Close()
        End If
        If Application.OpenForms.OfType(Of FormSettings).Any Then
            FormSettings.Close()
        End If
    End Sub
    Public Sub update_data()
        FormMetadata.Metadata()
        FormInput.DataGempa()
        FormDaerah.DataDaerah()
        FormNarasi.DataNarasi()
        FormPatahan.DataPatahan()
        FormInput.gempa_seminggu()
        FormInput.gempa_terkini()
        If Application.OpenForms.OfType(Of FormMetadata).Any Then
            FormMetadata.ListMetadata()
        End If
        If Application.OpenForms.OfType(Of FormDaerah).Any Then
            With FormDaerah
                If dtSetDaerah.Tables("tDaerah").Rows.Count > 0 Then
                    .Showlvw(dtSetDaerah.Tables("tDaerah"), .lvwDaerah)
                Else
                    .lvwDaerah.GridLines = True
                    .lvwDaerah.Columns.Clear()
                    .lvwDaerah.Items.Clear()
                    .Columnheader()
                End If
            End With
        End If
    End Sub
    Private Sub FormUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_idle
        Me.IsMdiContainer = True
        mnUtama.BackColor = Color.WhiteSmoke
        If dtSetMeta.Tables("tMetadata").Rows.Count <> 0 Then
            PosisiRecord = 0
            Dim tipe As String = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Tipe Stasiun").ToString
            Dim pgr As String
            Dim kota As String
            If tipe = "STAGEOF" Then
                pgr = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                tslbPGR.Text = "STAGEOF " & pgr
            ElseIf tipe = "PGR"
                pgr = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                kota = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Kota Stasiun").ToString, VbStrConv.Uppercase)
                tslbPGR.Text = "PGR " & pgr & " " & kota
            ElseIf tipe = "PUSAT"
                pgr = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                tslbPGR.Text = "PUSAT" & vbCrLf & pgr
            ElseIf tipe = "BALAI"
                pgr = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                kota = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Kota Stasiun").ToString, VbStrConv.Uppercase)
                tslbPGR.Text = "BALAI WILAYAH " & pgr & " " & kota
            End If
        Else
            FormMetadata.MdiParent = Me
            FormMetadata.Show()
        End If
        If dtSetMeta.Tables("tMetadata").Rows.Count <> 0 Then
            PosisiRecord = 0
            Dim tipe As String = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Tipe Stasiun").ToString
            Dim pgr As String
            Dim kota As String
            If tipe = "STAGEOF" Then
                pgr = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                tslbPGR.Text = "STAGEOF " & pgr
            ElseIf tipe = "PGR"
                pgr = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                kota = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Kota Stasiun").ToString, VbStrConv.Uppercase)
                tslbPGR.Text = "PGR " & pgr & " " & kota
            ElseIf tipe = "PUSAT"
                pgr = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                tslbPGR.Text = "PUSAT" & vbCrLf & pgr
            ElseIf tipe = "BALAI"
                pgr = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                kota = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Kota Stasiun").ToString, VbStrConv.Uppercase)
                tslbPGR.Text = "BALAI WILAYAH " & pgr & " " & kota
            End If
        Else
            FormMetadata.MdiParent = Me
            FormMetadata.Show()
        End If
    End Sub
    Private Sub RefreshTimer_Tick(sender As Object, e As EventArgs) Handles RefreshTimer.Tick
        close_allform()
        Try
            koneksi = New MySqlConnection(con)
            koneksi.Open()
            'koneksi.Close()
        Catch ex As Exception
            'formError.ShowDialog()
            'Exit Sub
        End Try
        If koneksi.State <> ConnectionState.Open Then
            If Application.OpenForms.OfType(Of formError).Any Then
                Exit Sub
            Else
                formError.ShowDialog()
            End If
        Else
            If Application.OpenForms.OfType(Of formError).Any Then
                formError.Close()
            End If
            koneksi.Close()
            FormMetadata.Metadata()
            FormInput.DataGempa()
            FormDaerah.DataDaerah()
            FormNarasi.DataNarasi()
            FormPatahan.DataPatahan()
            'If Application.OpenForms.OfType(Of FormInput).Any Then
            ' With FormInput
            ' If dtSetGempa.Tables("tDataGempa").Rows.Count > 0 Then
            ' .ShowlvwGempa(dtSetGempa.Tables("tDataGempa"), .lvwGempa)
            ' Else
            ' .lvwGempa.GridLines = True
            ' .lvwGempa.Columns.Clear()
            ' .lvwGempa.Items.Clear()
            ' .Columnheader()
            'End If
            '    End With
            '    Else
            '    FormInput.MdiParent = Me
            '    FormInput.Show()
            'End If
        End If
    End Sub
    Private Sub Application_idle(sender As Object, e As EventArgs)
        RefreshTimer.Interval = 1800000
        RefreshTimer.Stop()
        RefreshTimer.Start()
        If Format(Date.Today.Day, "00") = "01" Then
            backup_data()
        End If
    End Sub
    Private Sub labelBMKG_DoubleClick(sender As Object, e As EventArgs) Handles labelBMKG.DoubleClick
        update_data()
        If dtSetMeta.Tables("tMetadata").Rows.Count <> 0 Then
            PosisiRecord = 0
            Dim tipe As String = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Tipe Stasiun").ToString
            Dim pgr As String
            Dim kota As String
            If tipe = "STAGEOF" Then
                pgr = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                tslbPGR.Text = "STAGEOF " & pgr
            ElseIf tipe = "PGR"
                pgr = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                kota = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Kota Stasiun").ToString, VbStrConv.Uppercase)
                tslbPGR.Text = "PGR " & pgr & " " & kota
            ElseIf tipe = "PUSAT"
                pgr = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                tslbPGR.Text = "PUSAT" & vbCrLf & pgr
            ElseIf tipe = "BALAI"
                pgr = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                kota = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Kota Stasiun").ToString, VbStrConv.Uppercase)
                tslbPGR.Text = "BALAI WILAYAH " & pgr & " " & kota
            End If
        Else
            FormMetadata.MdiParent = Me
            FormMetadata.Show()
        End If
        backup_data()
    End Sub
    Private Sub mnUtama_Click(sender As Object, e As EventArgs) Handles mnUtama.Click
        If Application.OpenForms.OfType(Of FormInput).Any Then
            FormInput.Close()
        Else
            FormInput.MdiParent = Me
            FormInput.Show()
        End If
    End Sub
    Private Sub mnCari_Click(sender As Object, e As EventArgs) Handles mnCari.Click
        If Application.OpenForms.OfType(Of FormSearch).Any Then
            FormSearch.Close()
        Else
            'Dim FormSearch As New FormSearch
            FormSearch.MdiParent = Me
            FormSearch.Show()
        End If
    End Sub
    Private Sub mnMetadata_Click(sender As Object, e As EventArgs) Handles mnMetadata.Click
        If Application.OpenForms.OfType(Of FormMetadata).Any Then
            FormMetadata.BringToFront()
        Else
            FormMetadata.MdiParent = Me
            FormMetadata.Show()
        End If
    End Sub
    Private Sub mnDaerah_Click(sender As Object, e As EventArgs) Handles mnDaerah.Click
        If Application.OpenForms.OfType(Of FormDaerah).Any Then
            FormDaerah.BringToFront()
        Else
            FormDaerah.MdiParent = Me
            FormDaerah.Show()
        End If
    End Sub
    Private Sub mnPatahan_Click(sender As Object, e As EventArgs) Handles mnPatahan.Click
        If Application.OpenForms.OfType(Of FormPatahan).Any Then
            FormPatahan.BringToFront()
        Else
            FormPatahan.MdiParent = Me
            FormPatahan.Show()
        End If
    End Sub
    Private Sub mnSetting_Click(sender As Object, e As EventArgs) Handles mnSetting.Click
        FormSettings.MdiParent = Me
        FormSettings.Show()
    End Sub
    Private Sub mnTentang_Click(sender As Object, e As EventArgs) Handles mnTentang.Click
        FormAbout.ShowDialog()
    End Sub
    Private Sub mnHelp_Click(sender As Object, e As EventArgs) Handles mnHelp.Click
        System.Windows.Forms.Help.ShowHelp(Me, "help.chm", HelpNavigator.AssociateIndex)
    End Sub
    Private Sub FormUtama_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RefreshTimer.Stop()
        'RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_idle
    End Sub
#End Region
End Class