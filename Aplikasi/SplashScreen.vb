'Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public NotInheritable Class SplashScreen

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub frSplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim a1() As Integer = {33, 12}
        Dim a2() As Integer = {12, 10}
        Dim a3() As Integer = {13, 5}
        Dim a4() As Integer = {27, 19}
        Dim a()() As Integer = {a1, a2, a3, a4}
        For Each value In a
            Console.WriteLine(value)
        Next
        lblStatus.Text = ""
        splashTimer.Start()
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        'If My.Application.Info.Title <> "" Then
        ' ApplicationTitle.Text = My.Application.Info.Title
        ' Else
        ' 'If the application title is missing, use the application name, without the extension
        ' ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        ' End If

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Copyright info
        Copyright.Text = My.Application.Info.Copyright
    End Sub

    Private Sub splashTimer_Tick(sender As Object, e As EventArgs) Handles splashTimer.Tick
        Progress.Increment(1)
        splashTimer.Interval = 5
        'If Progress.Value = 1 Then
        'lblStatus.Text = Progress.Value & "% Loading Application.."
        If Progress.Value < 10 Then
            Try
                koneksi = New MySqlConnection(con)
                koneksi.Open()
            Catch ex As Exception
                'MessageBox.Show("Koneksi error : " + ex.Message)
                'splashTimer.Stop()
            End Try
        End If
        'ElseIf Progress.Value = 10 Then
        'lblStatus.Text = Progress.Value & "% Loading Application.."
        'ElseIf Progress.Value = 20 Then
        'lblStatus.Text = Progress.Value & "% Loading Application.."
        'ElseIf Progress.Value = 30 Then
        'lblStatus.Text = Progress.Value & "% Application Loaded"
        'ElseIf Progress.Value = 40 Then
        'lblStatus.Text = Progress.Value & "% Connecting Databases.."
        'Else
        If Progress.Value = 30 Then
            If koneksi.State <> ConnectionState.Open Then
                'FormSettings.lblStatus.Text = "Server is unreachable, please check the settings"
                'FormSettings.lblStatus.ForeColor = Color.Red
                splashTimer.Stop()
                'Me.Visible = False
                'FormSettings.Show()
                MessageBox.Show("Server unreachable, application will exit")
                Close()
            Else
                koneksi.Close()
                FormInput.DataGempa()
                FormDaerah.DataDaerah()
                FormMetadata.Metadata()
                FormNarasi.DataNarasi()
                FormPatahan.DataPatahan()
                FormSettings.SeisConf()
                'lblStatus.Text = Progress.Value & "% Connecting Databases.."
                'ElseIf Progress.Value = 60 Then
                'lblStatus.Text = Progress.Value & "% Connecting Databases.."
                'ElseIf Progress.Value >= 60 And Progress.Value <= 70 Then
                'If koneksi.State = ConnectionState.Connecting Then
                ' splashTimer.Interval = 50
                '    lblStatus.Text = Progress.Value & "% Connecting Databases.."
                'ElseIf koneksi.State = ConnectionState.Open Then
                'Progress.Value = 70
                'splashTimer.Interval = 5
                'koneksi.Close()
                '    lblStatus.Text = Progress.Value & "% Databases Connected"
                'End If
                'ElseIf Progress.Value = 80 Then
                'lblStatus.Text = Progress.Value & "% Databases Connected"
                'ElseIf Progress.Value = 90 Then
                If dtSetMeta.Tables("tMetadata").Rows.Count <> 0 Then
                    PosisiRecord = 0
                    Dim tipe As String = dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Tipe Stasiun").ToString
                    Dim pgr As String
                    Dim kota As String
                    If tipe = "STAGEOF" Then
                        pgr = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                        FormUtama.tslbPGR.Text = "STAGEOF " & pgr
                    ElseIf tipe = "PGR"
                        pgr = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                        kota = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Kota Stasiun").ToString, VbStrConv.Uppercase)
                        FormUtama.tslbPGR.Text = "PGR " & pgr & " " & kota
                    ElseIf tipe = "PUSAT"
                        pgr = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                        FormUtama.tslbPGR.Text = "PUSAT" & vbCrLf & pgr
                    ElseIf tipe = "BALAI"
                        pgr = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("PGR").ToString, VbStrConv.Uppercase)
                        kota = StrConv(dtSetMeta.Tables("tMetadata").Rows(PosisiRecord)("Kota Stasiun").ToString, VbStrConv.Uppercase)
                        FormUtama.tslbPGR.Text = "BALAI WILAYAH " & pgr & " " & kota
                    End If
                End If
            End If
            'lblStatus.Text = Progress.Value & "% Application Started.."
            'ElseIf Progress.Value = 99 Then
            'lblStatus.Text = "100% Application Started.."
        ElseIf Progress.Value = 100 Then
            splashTimer.Stop()
            FormUtama.Show()
            'lblStatus.Text = Progress.Value & "%"
            Close()
        End If
    End Sub
End Class
