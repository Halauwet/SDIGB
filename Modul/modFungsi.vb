Imports System.Math
Imports MySql.Data.MySqlClient
Module modFungsi
    Public Function radians(deg) As Double
        radians = deg * PI / 180
    End Function
    Public Function degrees(rad)
        degrees = rad * 180 / PI
    End Function
#Region "DATAGEMPA"
    Public Function simpangempa(ByVal vevent_id As String, ByVal vod As String, ByVal vot As String, ByVal vlat As String,
                                ByVal vlon As String, ByVal vdepth As String, ByVal vmag As String, ByVal vremark As String, ByVal vinfo As String)
        Try
            koneksi.Open()
            Dim SP As String = "gempasave"
            Dim cmd As New MySqlCommand
            cmd.Connection = koneksi
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SP
            Dim event_id As New MySqlParameter
            event_id.ParameterName = "@event_id"
            event_id.Value = vevent_id
            cmd.Parameters.Add(event_id)
            Dim od As New MySqlParameter
            od.ParameterName = "@od"
            od.Value = vod
            cmd.Parameters.Add(od)
            Dim ot As New MySqlParameter
            ot.ParameterName = "@ot"
            ot.Value = vot
            cmd.Parameters.Add(ot)
            Dim lat As New MySqlParameter
            lat.ParameterName = "@lat"
            lat.Value = vlat
            cmd.Parameters.Add(lat)
            Dim lon As New MySqlParameter
            lon.ParameterName = "@lon"
            lon.Value = vlon
            cmd.Parameters.Add(lon)
            Dim depth As New MySqlParameter
            depth.ParameterName = "@depth"
            depth.Value = vdepth
            cmd.Parameters.Add(depth)
            Dim mag As New MySqlParameter
            mag.ParameterName = "@mag"
            mag.Value = vmag
            cmd.Parameters.Add(mag)
            Dim remark As New MySqlParameter
            remark.ParameterName = "@remark"
            remark.Value = vremark
            cmd.Parameters.Add(remark)
            Dim info As New MySqlParameter
            info.ParameterName = "@info"
            info.Value = vinfo
            cmd.Parameters.Add(info)
            Dim hasil As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return hasil
            koneksi.Close()
        Catch sqlex As MySqlException
            Throw New Exception(sqlex.Message)
        End Try
    End Function
    Public Function updategempa(ByVal vevent_id As String, ByVal vod As String, ByVal vot As String, ByVal vlat As String,
                                ByVal vlon As String, ByVal vdepth As String, ByVal vmag As String, ByVal vremark As String, ByVal vinfo As String)
        Try
            koneksi.Open()
            Dim SP As String = "gempaupdate"
            Dim cmd As New MySqlCommand
            cmd.Connection = koneksi
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SP
            Dim event_id As New MySqlParameter
            event_id.ParameterName = "@event_id"
            event_id.Value = vevent_id
            cmd.Parameters.Add(event_id)
            Dim od As New MySqlParameter
            od.ParameterName = "@od"
            od.Value = vod
            cmd.Parameters.Add(od)
            Dim ot As New MySqlParameter
            ot.ParameterName = "@ot"
            ot.Value = vot
            cmd.Parameters.Add(ot)
            Dim lat As New MySqlParameter
            lat.ParameterName = "@lat"
            lat.Value = vlat
            cmd.Parameters.Add(lat)
            Dim lon As New MySqlParameter
            lon.ParameterName = "@lon"
            lon.Value = vlon
            cmd.Parameters.Add(lon)
            Dim depth As New MySqlParameter
            depth.ParameterName = "@depth"
            depth.Value = vdepth
            cmd.Parameters.Add(depth)
            Dim mag As New MySqlParameter
            mag.ParameterName = "@mag"
            mag.Value = vmag
            cmd.Parameters.Add(mag)
            Dim remark As New MySqlParameter
            remark.ParameterName = "@remark"
            remark.Value = vremark
            cmd.Parameters.Add(remark)
            Dim info As New MySqlParameter
            info.ParameterName = "@info"
            info.Value = vinfo
            cmd.Parameters.Add(info)
            Dim hasil As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return hasil
            koneksi.Close()
        Catch sqlex As MySqlException
            Throw New Exception(sqlex.Message)
        End Try
    End Function
    Public Function hapusgempa(ByVal vevent_id As String)
        Try
            koneksi.Open()
            Dim SP As String = "gempadelete"
            Dim cmd As New MySqlCommand
            cmd.Connection = koneksi
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SP
            Dim event_id As New MySqlParameter
            event_id.ParameterName = "@event_id"
            event_id.Value = vevent_id
            cmd.Parameters.Add(event_id)
            Dim hasil As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return hasil
            koneksi.Close()
        Catch sqlex As MySqlException
            Throw New Exception(sqlex.Message)
        End Try
    End Function
#End Region

#Region "DATASEISCOMP"
    Public Function simpansc_data(ByVal vevent_id As String, ByVal vpublicID As String, ByVal vtime_value As String, ByVal vsttus As String,
                                ByVal vPhaseCount As String, ByVal vmag_type As String, ByVal vstationCount As String, ByVal vdescription As String)
        Try
            koneksi.Open()
            Dim SP As String = "sc_datasave"
            Dim cmd As New MySqlCommand
            cmd.Connection = koneksi
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SP
            Dim event_id As New MySqlParameter
            event_id.ParameterName = "@event_id"
            event_id.Value = vevent_id
            cmd.Parameters.Add(event_id)
            Dim publicID As New MySqlParameter
            publicID.ParameterName = "@publicID"
            publicID.Value = vpublicID
            cmd.Parameters.Add(publicID)
            Dim time_value As New MySqlParameter
            time_value.ParameterName = "@time_value"
            time_value.Value = vtime_value
            cmd.Parameters.Add(time_value)
            Dim sttus As New MySqlParameter
            sttus.ParameterName = "@sttus"
            sttus.Value = vsttus
            cmd.Parameters.Add(sttus)
            Dim PhaseCount As New MySqlParameter
            PhaseCount.ParameterName = "@PhaseCount"
            PhaseCount.Value = vPhaseCount
            cmd.Parameters.Add(PhaseCount)
            Dim mag_type As New MySqlParameter
            mag_type.ParameterName = "@mag_type"
            mag_type.Value = vmag_type
            cmd.Parameters.Add(mag_type)
            Dim stationCount As New MySqlParameter
            stationCount.ParameterName = "@stationCount"
            stationCount.Value = vstationCount
            cmd.Parameters.Add(stationCount)
            Dim description As New MySqlParameter
            description.ParameterName = "@description"
            description.Value = vdescription
            cmd.Parameters.Add(description)
            Dim hasil As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return hasil
            koneksi.Close()
        Catch sqlex As MySqlException
            Throw New Exception(sqlex.Message)
        End Try
    End Function
    Public Function updatesc_data(ByVal vevent_id As String, ByVal vpublicID As String, ByVal vtime_value As String, ByVal vsttus As String,
                                ByVal vPhaseCount As String, ByVal vmag_type As String, ByVal vstationCount As String, ByVal vdescription As String)
        Try
            koneksi.Open()
            Dim SP As String = "sc_dataupdate"
            Dim cmd As New MySqlCommand
            cmd.Connection = koneksi
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SP
            Dim event_id As New MySqlParameter
            event_id.ParameterName = "@event_id"
            event_id.Value = vevent_id
            cmd.Parameters.Add(event_id)
            Dim publicID As New MySqlParameter
            publicID.ParameterName = "@publicID"
            publicID.Value = vpublicID
            cmd.Parameters.Add(publicID)
            Dim time_value As New MySqlParameter
            time_value.ParameterName = "@time_value"
            time_value.Value = vtime_value
            cmd.Parameters.Add(time_value)
            Dim sttus As New MySqlParameter
            sttus.ParameterName = "@sttus"
            sttus.Value = vsttus
            cmd.Parameters.Add(sttus)
            Dim PhaseCount As New MySqlParameter
            PhaseCount.ParameterName = "@PhaseCount"
            PhaseCount.Value = vPhaseCount
            cmd.Parameters.Add(PhaseCount)
            Dim mag_type As New MySqlParameter
            mag_type.ParameterName = "@mag_type"
            mag_type.Value = vmag_type
            cmd.Parameters.Add(mag_type)
            Dim stationCount As New MySqlParameter
            stationCount.ParameterName = "@stationCount"
            stationCount.Value = vstationCount
            cmd.Parameters.Add(stationCount)
            Dim description As New MySqlParameter
            description.ParameterName = "@description"
            description.Value = vdescription
            cmd.Parameters.Add(description)
            Dim hasil As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return hasil
            koneksi.Close()
        Catch sqlex As MySqlException
            Throw New Exception(sqlex.Message)
        End Try
    End Function
    Public Function hapussc_data(ByVal vevent_id As String)
        Try
            koneksi.Open()
            Dim SP As String = "sc_datadelete"
            Dim cmd As New MySqlCommand
            cmd.Connection = koneksi
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SP
            Dim event_id As New MySqlParameter
            event_id.ParameterName = "@event_id"
            event_id.Value = vevent_id
            cmd.Parameters.Add(event_id)
            Dim hasil As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return hasil
            koneksi.Close()
        Catch sqlex As MySqlException
            Throw New Exception(sqlex.Message)
        End Try
    End Function
#End Region

#Region "NARASI"
    Public Function simpannarasi(ByVal vevent_id As String, ByVal vwaktubuat As String, ByVal vsusulan As String, ByVal vlokasi As String, ByVal vdaerah As String,
                                ByVal vdampak As String, ByVal vshakemap As Boolean, ByVal vsumber As String, ByVal vpatahan As String, ByVal vdeskripsi As String,
                                ByVal vfokal As Boolean, ByVal vmekanisme As String, ByVal vnarasi As String)
        Try
            koneksi.Open()
            Dim SP As String = "narasisave"
            Dim cmd As New MySqlCommand
            cmd.Connection = koneksi
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SP
            Dim event_id As New MySqlParameter
            event_id.ParameterName = "@event_id"
            event_id.Value = vevent_id
            cmd.Parameters.Add(event_id)
            Dim waktubuat As New MySqlParameter
            waktubuat.ParameterName = "@waktubuat"
            waktubuat.Value = vwaktubuat
            cmd.Parameters.Add(waktubuat)
            Dim susulan As New MySqlParameter
            susulan.ParameterName = "@susulan"
            susulan.Value = vsusulan
            cmd.Parameters.Add(susulan)
            Dim lokasi As New MySqlParameter
            lokasi.ParameterName = "@lokasi"
            lokasi.Value = vlokasi
            cmd.Parameters.Add(lokasi)
            Dim daerah As New MySqlParameter
            daerah.ParameterName = "@daerah"
            daerah.Value = vdaerah
            cmd.Parameters.Add(daerah)
            Dim dampak As New MySqlParameter
            dampak.ParameterName = "@dampak"
            dampak.Value = vdampak
            cmd.Parameters.Add(dampak)
            Dim shakemap As New MySqlParameter
            shakemap.ParameterName = "@shakemap"
            shakemap.Value = vshakemap
            cmd.Parameters.Add(shakemap)
            Dim sumber As New MySqlParameter
            sumber.ParameterName = "@sumber"
            sumber.Value = vsumber
            cmd.Parameters.Add(sumber)
            Dim patahan As New MySqlParameter
            patahan.ParameterName = "@patahan"
            patahan.Value = vpatahan
            cmd.Parameters.Add(patahan)
            Dim deskripsi As New MySqlParameter
            deskripsi.ParameterName = "@deskripsi"
            deskripsi.Value = vdeskripsi
            cmd.Parameters.Add(deskripsi)
            Dim fokal As New MySqlParameter
            fokal.ParameterName = "@fokal"
            fokal.Value = vfokal
            cmd.Parameters.Add(fokal)
            Dim mekanisme As New MySqlParameter
            mekanisme.ParameterName = "@mekanisme"
            mekanisme.Value = vmekanisme
            cmd.Parameters.Add(mekanisme)
            Dim narasi As New MySqlParameter
            narasi.ParameterName = "@narasi"
            narasi.Value = vnarasi
            cmd.Parameters.Add(narasi)
            Dim hasil As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return hasil
            koneksi.Close()
        Catch sqlex As MySqlException
            Throw New Exception(sqlex.Message)
        End Try
    End Function
    Public Function updatenarasi(ByVal vevent_id As String, ByVal vwaktubuat As String, ByVal vsusulan As String, ByVal vlokasi As String, ByVal vdaerah As String,
                                ByVal vdampak As String, ByVal vshakemap As Boolean, ByVal vsumber As String, ByVal vpatahan As String, ByVal vdeskripsi As String,
                                ByVal vfokal As Boolean, ByVal vmekanisme As String, ByVal vnarasi As String)
        Try
            koneksi.Open()
            Dim SP As String = "narasiupdate"
            Dim cmd As New MySqlCommand
            cmd.Connection = koneksi
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SP
            Dim event_id As New MySqlParameter
            event_id.ParameterName = "@event_id"
            event_id.Value = vevent_id
            cmd.Parameters.Add(event_id)
            Dim waktubuat As New MySqlParameter
            waktubuat.ParameterName = "@waktubuat"
            waktubuat.Value = vwaktubuat
            cmd.Parameters.Add(waktubuat)
            Dim susulan As New MySqlParameter
            susulan.ParameterName = "@susulan"
            susulan.Value = vsusulan
            cmd.Parameters.Add(susulan)
            Dim lokasi As New MySqlParameter
            lokasi.ParameterName = "@lokasi"
            lokasi.Value = vlokasi
            cmd.Parameters.Add(lokasi)
            Dim daerah As New MySqlParameter
            daerah.ParameterName = "@daerah"
            daerah.Value = vdaerah
            cmd.Parameters.Add(daerah)
            Dim dampak As New MySqlParameter
            dampak.ParameterName = "@dampak"
            dampak.Value = vdampak
            cmd.Parameters.Add(dampak)
            Dim shakemap As New MySqlParameter
            shakemap.ParameterName = "@shakemap"
            shakemap.Value = vshakemap
            cmd.Parameters.Add(shakemap)
            Dim sumber As New MySqlParameter
            sumber.ParameterName = "@sumber"
            sumber.Value = vsumber
            cmd.Parameters.Add(sumber)
            Dim patahan As New MySqlParameter
            patahan.ParameterName = "@patahan"
            patahan.Value = vpatahan
            cmd.Parameters.Add(patahan)
            Dim deskripsi As New MySqlParameter
            deskripsi.ParameterName = "@deskripsi"
            deskripsi.Value = vdeskripsi
            cmd.Parameters.Add(deskripsi)
            Dim fokal As New MySqlParameter
            fokal.ParameterName = "@fokal"
            fokal.Value = vfokal
            cmd.Parameters.Add(fokal)
            Dim mekanisme As New MySqlParameter
            mekanisme.ParameterName = "@mekanisme"
            mekanisme.Value = vmekanisme
            cmd.Parameters.Add(mekanisme)
            Dim narasi As New MySqlParameter
            narasi.ParameterName = "@narasi"
            narasi.Value = vnarasi
            cmd.Parameters.Add(narasi)
            Dim hasil As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return hasil
            koneksi.Close()
        Catch sqlex As MySqlException
            Throw New Exception(sqlex.Message)
        End Try
    End Function
    Public Function hapusnarasi(ByVal vevent_id As String)
        Try
            koneksi.Open()
            Dim SP As String = "narasidelete"
            Dim cmd As New MySqlCommand
            cmd.Connection = koneksi
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SP
            Dim event_id As New MySqlParameter
            event_id.ParameterName = "@event_id"
            event_id.Value = vevent_id
            cmd.Parameters.Add(event_id)
            Dim hasil As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return hasil
            koneksi.Close()
        Catch sqlex As MySqlException
            Throw New Exception(sqlex.Message)
        End Try
    End Function
#End Region

#Region "METADATA"
    Public Function simpanmeta(ByVal vnomor_sts As String, ByVal vkode_sts As String, ByVal vnama_sts As String, ByVal vkota_sts As String,
                               ByVal vtipe_sts As String, ByVal vpgr As String, ByVal vlintang As String, ByVal vbujur As String, ByVal velev As String,
                               ByVal valamat As String, ByVal vtelp As String, ByVal vfax As String, ByVal vweb As String,
                               ByVal vmail As String, ByVal vfb As String, ByVal vjmlhkab As String, ByVal vzona As String,
                               ByVal vtwtr As String, ByVal vjab As String, ByVal vnama As String, ByVal vnip As String)
        Try
            koneksi.Open()
            Dim SP As String = "metadatasave"
            Dim cmd As New MySqlCommand
            cmd.Connection = koneksi
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SP
            Dim nomor_sts As New MySqlParameter
            nomor_sts.ParameterName = "@nomor_sts"
            nomor_sts.Value = vnomor_sts
            cmd.Parameters.Add(nomor_sts)
            Dim kode_sts As New MySqlParameter
            kode_sts.ParameterName = "@kode_sts"
            kode_sts.Value = vkode_sts
            cmd.Parameters.Add(kode_sts)
            Dim nama_sts As New MySqlParameter
            nama_sts.ParameterName = "@nama_sts"
            nama_sts.Value = vnama_sts
            cmd.Parameters.Add(nama_sts)
            Dim kota_sts As New MySqlParameter
            kota_sts.ParameterName = "@kota_sts"
            kota_sts.Value = vkota_sts
            cmd.Parameters.Add(kota_sts)
            Dim tipe_sts As New MySqlParameter
            tipe_sts.ParameterName = "@tipe_sts"
            tipe_sts.Value = vtipe_sts
            cmd.Parameters.Add(tipe_sts)
            Dim pgr As New MySqlParameter
            pgr.ParameterName = "@pgr"
            pgr.Value = vpgr
            cmd.Parameters.Add(pgr)
            Dim lintang As New MySqlParameter
            lintang.ParameterName = "@lintang"
            lintang.Value = vlintang
            cmd.Parameters.Add(lintang)
            Dim bujur As New MySqlParameter
            bujur.ParameterName = "@bujur"
            bujur.Value = vbujur
            cmd.Parameters.Add(bujur)
            Dim elev As New MySqlParameter
            elev.ParameterName = "@elev"
            elev.Value = velev
            cmd.Parameters.Add(elev)
            Dim alamat As New MySqlParameter
            alamat.ParameterName = "@alamat"
            alamat.Value = valamat
            cmd.Parameters.Add(alamat)
            Dim telp As New MySqlParameter
            telp.ParameterName = "@telp"
            telp.Value = vtelp
            cmd.Parameters.Add(telp)
            Dim fax As New MySqlParameter
            fax.ParameterName = "@fax"
            fax.Value = vfax
            cmd.Parameters.Add(fax)
            Dim web As New MySqlParameter
            web.ParameterName = "@web"
            web.Value = vweb
            cmd.Parameters.Add(web)
            Dim mail As New MySqlParameter
            mail.ParameterName = "@mail"
            mail.Value = vmail
            cmd.Parameters.Add(mail)
            Dim fb As New MySqlParameter
            fb.ParameterName = "@fb"
            fb.Value = vfb
            cmd.Parameters.Add(fb)
            Dim jmlhkab As New MySqlParameter
            jmlhkab.ParameterName = "@jmlhkab"
            jmlhkab.Value = vjmlhkab
            cmd.Parameters.Add(jmlhkab)
            Dim zona As New MySqlParameter
            zona.ParameterName = "@zona"
            zona.Value = vzona
            cmd.Parameters.Add(zona)
            Dim twitter As New MySqlParameter
            twitter.ParameterName = "@twitter"
            twitter.Value = vtwtr
            cmd.Parameters.Add(twitter)
            Dim jab As New MySqlParameter
            jab.ParameterName = "@jab"
            jab.Value = vjab
            cmd.Parameters.Add(jab)
            Dim nama As New MySqlParameter
            nama.ParameterName = "@nama"
            nama.Value = vnama
            cmd.Parameters.Add(nama)
            Dim nip As New MySqlParameter
            nip.ParameterName = "@nip"
            nip.Value = vnip
            cmd.Parameters.Add(nip)
            Dim hasil As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return hasil
            koneksi.Close()
        Catch sqlex As MySqlException
            Throw New Exception(sqlex.Message)
        End Try
    End Function
    Public Function updatemeta(ByVal vnomor_sts As String, ByVal vkode_sts As String, ByVal vnama_sts As String, ByVal vkota_sts As String,
                               ByVal vtipe_sts As String, ByVal vpgr As String, ByVal vlintang As String, ByVal vbujur As String, ByVal velev As String,
                               ByVal valamat As String, ByVal vtelp As String, ByVal vfax As String, ByVal vweb As String,
                               ByVal vmail As String, ByVal vfb As String, ByVal vjmlhkab As String, ByVal vzona As String,
                               ByVal vtwtr As String, ByVal vjab As String, ByVal vnama As String, ByVal vnip As String)
        Try
            koneksi.Open()
            Dim SP As String = "metadataupdate"
            Dim cmd As New MySqlCommand
            cmd.Connection = koneksi
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SP
            Dim nomor_sts As New MySqlParameter
            nomor_sts.ParameterName = "@nomor_sts"
            nomor_sts.Value = vnomor_sts
            cmd.Parameters.Add(nomor_sts)
            Dim kode_sts As New MySqlParameter
            kode_sts.ParameterName = "@kode_sts"
            kode_sts.Value = vkode_sts
            cmd.Parameters.Add(kode_sts)
            Dim nama_sts As New MySqlParameter
            nama_sts.ParameterName = "@nama_sts"
            nama_sts.Value = vnama_sts
            cmd.Parameters.Add(nama_sts)
            Dim kota_sts As New MySqlParameter
            kota_sts.ParameterName = "@kota_sts"
            kota_sts.Value = vkota_sts
            cmd.Parameters.Add(kota_sts)
            Dim tipe_sts As New MySqlParameter
            tipe_sts.ParameterName = "@tipe_sts"
            tipe_sts.Value = vtipe_sts
            cmd.Parameters.Add(tipe_sts)
            Dim pgr As New MySqlParameter
            pgr.ParameterName = "@pgr"
            pgr.Value = vpgr
            cmd.Parameters.Add(pgr)
            Dim lintang As New MySqlParameter
            lintang.ParameterName = "@lintang"
            lintang.Value = vlintang
            cmd.Parameters.Add(lintang)
            Dim bujur As New MySqlParameter
            bujur.ParameterName = "@bujur"
            bujur.Value = vbujur
            cmd.Parameters.Add(bujur)
            Dim elev As New MySqlParameter
            elev.ParameterName = "@elev"
            elev.Value = velev
            cmd.Parameters.Add(elev)
            Dim alamat As New MySqlParameter
            alamat.ParameterName = "@alamat"
            alamat.Value = valamat
            cmd.Parameters.Add(alamat)
            Dim telp As New MySqlParameter
            telp.ParameterName = "@telp"
            telp.Value = vtelp
            cmd.Parameters.Add(telp)
            Dim fax As New MySqlParameter
            fax.ParameterName = "@fax"
            fax.Value = vfax
            cmd.Parameters.Add(fax)
            Dim web As New MySqlParameter
            web.ParameterName = "@web"
            web.Value = vweb
            cmd.Parameters.Add(web)
            Dim mail As New MySqlParameter
            mail.ParameterName = "@mail"
            mail.Value = vmail
            cmd.Parameters.Add(mail)
            Dim fb As New MySqlParameter
            fb.ParameterName = "@fb"
            fb.Value = vfb
            cmd.Parameters.Add(fb)
            Dim jmlhkab As New MySqlParameter
            jmlhkab.ParameterName = "@jmlhkab"
            jmlhkab.Value = vjmlhkab
            cmd.Parameters.Add(jmlhkab)
            Dim zona As New MySqlParameter
            zona.ParameterName = "@zona"
            zona.Value = vzona
            cmd.Parameters.Add(zona)
            Dim twitter As New MySqlParameter
            twitter.ParameterName = "@twitter"
            twitter.Value = vtwtr
            cmd.Parameters.Add(twitter)
            Dim jab As New MySqlParameter
            jab.ParameterName = "@jab"
            jab.Value = vjab
            cmd.Parameters.Add(jab)
            Dim nama As New MySqlParameter
            nama.ParameterName = "@nama"
            nama.Value = vnama
            cmd.Parameters.Add(nama)
            Dim nip As New MySqlParameter
            nip.ParameterName = "@nip"
            nip.Value = vnip
            cmd.Parameters.Add(nip)
            Dim hasil As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return hasil
            koneksi.Close()
        Catch sqlex As MySqlException
            Throw New Exception(sqlex.Message)
        End Try
    End Function
#End Region

#Region "DATADAERAH"
    Public Function simpandaerah(ByVal vid As String, ByVal vdaerah As String, ByVal vlintang As String, ByVal vbujur As String,
                                 ByVal vbarat As String, ByVal vtimur As String, ByVal vutara As String, ByVal vselatan As String)
        Try
            koneksi.Open()
            Dim SP As String = "daerahsave"
            Dim cmd As New MySqlCommand
            cmd.Connection = koneksi
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SP
            Dim ids As New MySqlParameter
            ids.ParameterName = "@ids"
            ids.Value = vid
            cmd.Parameters.Add(ids)
            Dim daerah As New MySqlParameter
            daerah.ParameterName = "@daerah"
            daerah.Value = vdaerah
            cmd.Parameters.Add(daerah)
            Dim lintang As New MySqlParameter
            lintang.ParameterName = "@lintang"
            lintang.Value = vlintang
            cmd.Parameters.Add(lintang)
            Dim bujur As New MySqlParameter
            bujur.ParameterName = "@bujur"
            bujur.Value = vbujur
            cmd.Parameters.Add(bujur)
            Dim barat As New MySqlParameter
            barat.ParameterName = "@barat"
            barat.Value = vbarat
            cmd.Parameters.Add(barat)
            Dim timur As New MySqlParameter
            timur.ParameterName = "@timur"
            timur.Value = vtimur
            cmd.Parameters.Add(timur)
            Dim utara As New MySqlParameter
            utara.ParameterName = "@utara"
            utara.Value = vutara
            cmd.Parameters.Add(utara)
            Dim selatan As New MySqlParameter
            selatan.ParameterName = "@selatan"
            selatan.Value = vselatan
            cmd.Parameters.Add(selatan)
            Dim hasil As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return hasil
            koneksi.Close()
        Catch sqlex As MySqlException
            Throw New Exception(sqlex.Message)
        End Try
    End Function
    Public Function updatedaerah(ByVal vid As String, ByVal vdaerah As String, ByVal vlintang As String, ByVal vbujur As String,
                                  ByVal vbarat As String, ByVal vtimur As String, ByVal vutara As String, ByVal vselatan As String)
        Try
            koneksi.Open()
            Dim SP As String = "daerahupdt"
            Dim cmd As New MySqlCommand
            cmd.Connection = koneksi
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SP
            Dim ids As New MySqlParameter
            ids.ParameterName = "@ids"
            ids.Value = vid
            cmd.Parameters.Add(ids)
            Dim daerah As New MySqlParameter
            daerah.ParameterName = "@daerah"
            daerah.Value = vdaerah
            cmd.Parameters.Add(daerah)
            Dim lintang As New MySqlParameter
            lintang.ParameterName = "@lintang"
            lintang.Value = vlintang
            cmd.Parameters.Add(lintang)
            Dim bujur As New MySqlParameter
            bujur.ParameterName = "@bujur"
            bujur.Value = vbujur
            cmd.Parameters.Add(bujur)
            Dim barat As New MySqlParameter
            barat.ParameterName = "@barat"
            barat.Value = vbarat
            cmd.Parameters.Add(barat)
            Dim timur As New MySqlParameter
            timur.ParameterName = "@timur"
            timur.Value = vtimur
            cmd.Parameters.Add(timur)
            Dim utara As New MySqlParameter
            utara.ParameterName = "@utara"
            utara.Value = vutara
            cmd.Parameters.Add(utara)
            Dim selatan As New MySqlParameter
            selatan.ParameterName = "@selatan"
            selatan.Value = vselatan
            cmd.Parameters.Add(selatan)
            Dim hasil As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return hasil
            koneksi.Close()
        Catch sqlex As MySqlException
            Throw New Exception(sqlex.Message)
        End Try
    End Function
    Public Function hapusdaerah(ByVal vid As String)
        Try
            koneksi.Open()
            Dim SP As String = "daerahdelete"
            Dim cmd As New MySqlCommand
            cmd.Connection = koneksi
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SP
            Dim ids As New MySqlParameter
            ids.ParameterName = "@ids"
            ids.Value = vid
            cmd.Parameters.Add(ids)
            Dim hasil As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return hasil
            koneksi.Close()
        Catch sqlex As MySqlException
            Throw New Exception(sqlex.Message)
        End Try
    End Function
#End Region

#Region "DATAPATAHAN"
    Public Function simpanpatahan(ByVal vid As String, ByVal vpatahan As String, ByVal vdeskripsi As String, ByVal vmekanisme As String,
                                 ByVal vbarat As String, ByVal vtimur As String, ByVal vutara As String, ByVal vselatan As String, ByVal vsumber As String)
        Try
            koneksi.Open()
            Dim SP As String = "sesarsave"
            Dim cmd As New MySqlCommand
            cmd.Connection = koneksi
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SP
            Dim ids As New MySqlParameter
            ids.ParameterName = "@ids"
            ids.Value = vid
            cmd.Parameters.Add(ids)
            Dim patahan As New MySqlParameter
            patahan.ParameterName = "@patahan"
            patahan.Value = vpatahan
            cmd.Parameters.Add(patahan)
            Dim deskripsi As New MySqlParameter
            deskripsi.ParameterName = "@deskripsi"
            deskripsi.Value = vdeskripsi
            cmd.Parameters.Add(deskripsi)
            Dim mekanisme As New MySqlParameter
            mekanisme.ParameterName = "@mekanisme"
            mekanisme.Value = vmekanisme
            cmd.Parameters.Add(mekanisme)
            Dim barat As New MySqlParameter
            barat.ParameterName = "@barat"
            barat.Value = vbarat
            cmd.Parameters.Add(barat)
            Dim timur As New MySqlParameter
            timur.ParameterName = "@timur"
            timur.Value = vtimur
            cmd.Parameters.Add(timur)
            Dim utara As New MySqlParameter
            utara.ParameterName = "@utara"
            utara.Value = vutara
            cmd.Parameters.Add(utara)
            Dim selatan As New MySqlParameter
            selatan.ParameterName = "@selatan"
            selatan.Value = vselatan
            cmd.Parameters.Add(selatan)
            Dim sumber As New MySqlParameter
            sumber.ParameterName = "@sumber"
            sumber.Value = vsumber
            cmd.Parameters.Add(sumber)
            Dim hasil As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return hasil
            koneksi.Close()
        Catch sqlex As MySqlException
            Throw New Exception(sqlex.Message)
        End Try
    End Function
    Public Function updatepatahan(ByVal vid As String, ByVal vpatahan As String, ByVal vdeskripsi As String, ByVal vmekanisme As String,
                                 ByVal vbarat As String, ByVal vtimur As String, ByVal vutara As String, ByVal vselatan As String, ByVal vsumber As String)
        Try
            koneksi.Open()
            Dim SP As String = "sesarupdate"
            Dim cmd As New MySqlCommand
            cmd.Connection = koneksi
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SP
            Dim ids As New MySqlParameter
            ids.ParameterName = "@ids"
            ids.Value = vid
            cmd.Parameters.Add(ids)
            Dim patahan As New MySqlParameter
            patahan.ParameterName = "@patahan"
            patahan.Value = vpatahan
            cmd.Parameters.Add(patahan)
            Dim deskripsi As New MySqlParameter
            deskripsi.ParameterName = "@deskripsi"
            deskripsi.Value = vdeskripsi
            cmd.Parameters.Add(deskripsi)
            Dim mekanisme As New MySqlParameter
            mekanisme.ParameterName = "@mekanisme"
            mekanisme.Value = vmekanisme
            cmd.Parameters.Add(mekanisme)
            Dim barat As New MySqlParameter
            barat.ParameterName = "@barat"
            barat.Value = vbarat
            cmd.Parameters.Add(barat)
            Dim timur As New MySqlParameter
            timur.ParameterName = "@timur"
            timur.Value = vtimur
            cmd.Parameters.Add(timur)
            Dim utara As New MySqlParameter
            utara.ParameterName = "@utara"
            utara.Value = vutara
            cmd.Parameters.Add(utara)
            Dim selatan As New MySqlParameter
            selatan.ParameterName = "@selatan"
            selatan.Value = vselatan
            cmd.Parameters.Add(selatan)
            Dim sumber As New MySqlParameter
            sumber.ParameterName = "@sumber"
            sumber.Value = vsumber
            cmd.Parameters.Add(sumber)
            Dim hasil As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return hasil
            koneksi.Close()
        Catch sqlex As MySqlException
            Throw New Exception(sqlex.Message)
        End Try
    End Function
    Public Function hapuspatahan(ByVal vid As String)
        Try
            koneksi.Open()
            Dim SP As String = "sesardelete"
            Dim cmd As New MySqlCommand
            cmd.Connection = koneksi
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SP
            Dim ids As New MySqlParameter
            ids.ParameterName = "@ids"
            ids.Value = vid
            cmd.Parameters.Add(ids)
            Dim hasil As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return hasil
            koneksi.Close()
        Catch sqlex As MySqlException
            Throw New Exception(sqlex.Message)
        End Try
    End Function
#End Region

#Region "SERVER"
    Public Function simpanseisconf(ByVal vsc_id As String, ByVal vsc_host As String, ByVal vsc_user As String, ByVal vsc_pass As String, ByVal vdb As String)
        Try
            koneksi.Open()
            Dim SP As String = "seisconfsave"
            Dim cmd As New MySqlCommand
            cmd.Connection = koneksi
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SP
            Dim sc_id As New MySqlParameter
            sc_id.ParameterName = "@sc_id"
            sc_id.Value = vsc_id
            cmd.Parameters.Add(sc_id)
            Dim sc_host As New MySqlParameter
            sc_host.ParameterName = "@sc_host"
            sc_host.Value = vsc_host
            cmd.Parameters.Add(sc_host)
            Dim sc_user As New MySqlParameter
            sc_user.ParameterName = "@sc_user"
            sc_user.Value = vsc_user
            cmd.Parameters.Add(sc_user)
            Dim sc_pass As New MySqlParameter
            sc_pass.ParameterName = "@sc_pass"
            sc_pass.Value = vsc_pass
            cmd.Parameters.Add(sc_pass)
            Dim db As New MySqlParameter
            db.ParameterName = "@db"
            db.Value = vdb
            cmd.Parameters.Add(db)
            Dim hasil As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return hasil
            koneksi.Close()
        Catch sqlex As MySqlException
            Throw New Exception(sqlex.Message)
        End Try
    End Function
    Public Function updateseisconf(ByVal vsc_id As String, ByVal vsc_host As String, ByVal vsc_user As String, ByVal vsc_pass As String, ByVal vdb As String)
        Try
            koneksi.Open()
            Dim SP As String = "seisconfupdate"
            Dim cmd As New MySqlCommand
            cmd.Connection = koneksi
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SP
            Dim sc_id As New MySqlParameter
            sc_id.ParameterName = "@sc_id"
            sc_id.Value = vsc_id
            cmd.Parameters.Add(sc_id)
            Dim sc_host As New MySqlParameter
            sc_host.ParameterName = "@sc_host"
            sc_host.Value = vsc_host
            cmd.Parameters.Add(sc_host)
            Dim sc_user As New MySqlParameter
            sc_user.ParameterName = "@sc_user"
            sc_user.Value = vsc_user
            cmd.Parameters.Add(sc_user)
            Dim sc_pass As New MySqlParameter
            sc_pass.ParameterName = "@sc_pass"
            sc_pass.Value = vsc_pass
            cmd.Parameters.Add(sc_pass)
            Dim db As New MySqlParameter
            db.ParameterName = "@db"
            db.Value = vdb
            cmd.Parameters.Add(db)
            Dim hasil As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return hasil
            koneksi.Close()
        Catch sqlex As MySqlException
            Throw New Exception(sqlex.Message)
        End Try
    End Function
#End Region
End Module
