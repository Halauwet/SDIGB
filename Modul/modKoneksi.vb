Imports System.Data
'Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Net
Module modKoneksi
#Region "ConnectionString"
    Dim mydb As MySqlDbType
    Public sc_con As String
    Public koneksi As MySqlConnection = Nothing
    Public sc_koneksi As MySqlConnection = Nothing
    Public dtAdapter As MySqlDataAdapter = Nothing
    Public dtReader As MySqlDataReader = Nothing
    'Public host As String = "mysql-server IP"
    'Public proxy As Boolean = False
    'Public my_proxy As New WebProxy("yourproxy",yourport)
    'Public user As String = "mysql username"
    'Public pass As String = "mysql password"
    'Public db As String = "mysql database name"
    Public scHost As String
    Public scUser As String
    Public scPass As String
    Public scDB As String
    Public scID As String
    Public dtRow As DataRow = Nothing
    Public dtSetGempa As DataSet = Nothing
    Public dtSetSC As DataSet = Nothing
    Public dtSetMeta As DataSet = Nothing
    Public dtSetDaerah As DataSet = Nothing
    Public dtSetPatahan As DataSet = Nothing
    Public dtSetSeisConf As DataSet = Nothing
    Public dtSetCari As DataSet = Nothing
    Public dtSetNarasi As DataSet = Nothing
    Public dtTable As DataTable = Nothing
    Public dtNarasi As DataTable = Nothing
    Public drGempa() As DataRow = Nothing
    Public drNarasi() As DataRow = Nothing
    Public drPatahan() As DataRow = Nothing
    Public drCari() As DataRow = Nothing
    Public cmd As MySqlCommand = Nothing
    Public strResult As String = Nothing
    Public sql As String = Nothing
    Public PosisiRecord As Integer
    'Public con As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Document's\Visual Studio 2013\Projects\DisseminationMap\Data\Database.mdf;Integrated Security=True" 'String.format("Data Source=(LocalDB)\v11.0;AttachDbFilename={0}\Database.mdf;Integrated Security=True", My.Application.Info.DirectoryPath)  "Data Source=192.168.1.31\SQLSERVER;Initial Catalog=Dissemination;Integrated Security=True" '"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Data\Database.mdf;Integrated Security=True"   '
    Public con As String = "server=" & host & ";user id=" & user & ";password=" & pass & ";database=" & db
    'Public con As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Data\Database.mdf;Integrated Security=True"  '"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Data\Database.mdf;Integrated Security=True"  'Data Source=EQ-PC\SQLSERVER;Initial Catalog=diseminasi;Integrated Security=True" 'String.Format("Data Source=(LocalDB)\v11.0;AttachDbFilename={0}\Data\Database.mdf;Integrated Security=True", My.Application.Info.DirectoryPath)
    'Public con As String = "server=" & host & ";user id=" & user & ";database=datin;allowuservariables=True;Convert Zero Datetime=True"
    Public Sub KoneksiBasisData()
        Try
            koneksi = New MySqlConnection(con)
            If proxy = True Then
                'my_proxy.Credentials = New NetworkCredential("yehezkiel", "05532727")
                'koneksi.proxy
            End If
            koneksi.Open()
            koneksi.Close()
        Catch ex As Exception
            MessageBox.Show("Koneksi error : " + ex.Message)
        End Try
    End Sub
    Public Sub KoneksiSeiscomP3()
        Try
            sc_koneksi = New MySqlConnection(sc_con)
            sc_koneksi.Open()
            sc_koneksi.Close()
        Catch ex As Exception
            MessageBox.Show("Koneksi error : " + ex.Message & vbCrLf & vbCrLf & """Check network connection or contact your administrator""")
        End Try
    End Sub
#End Region
End Module
