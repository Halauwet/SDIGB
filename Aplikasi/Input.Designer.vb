<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInput
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.gbInput = New System.Windows.Forms.GroupBox()
        Me.btQuerySC = New System.Windows.Forms.Button()
        Me.btNarasi = New System.Windows.Forms.Button()
        Me.btShake = New System.Windows.Forms.Button()
        Me.btSaveMap = New System.Windows.Forms.Button()
        Me.btInput = New System.Windows.Forms.Button()
        Me.PanelInfo = New System.Windows.Forms.Panel()
        Me.lblInfoTambahan = New System.Windows.Forms.Label()
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbEventID = New System.Windows.Forms.Label()
        Me.lblDaerah4 = New System.Windows.Forms.Label()
        Me.lblDaerah3 = New System.Windows.Forms.Label()
        Me.lblDaerah2 = New System.Windows.Forms.Label()
        Me.lblDaerah1 = New System.Windows.Forms.Label()
        Me.lblDaerah = New System.Windows.Forms.Label()
        Me.btDelete = New System.Windows.Forms.Button()
        Me.btCancel = New System.Windows.Forms.Button()
        Me.btSave = New System.Windows.Forms.Button()
        Me.btEdit = New System.Windows.Forms.Button()
        Me.TimePicker = New System.Windows.Forms.DateTimePicker()
        Me.txtLokasi = New System.Windows.Forms.TextBox()
        Me.txtMag = New System.Windows.Forms.TextBox()
        Me.txtDepth = New System.Windows.Forms.TextBox()
        Me.txtLon = New System.Windows.Forms.TextBox()
        Me.txtLat = New System.Windows.Forms.TextBox()
        Me.DatePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbMessage = New System.Windows.Forms.GroupBox()
        Me.btCopy = New System.Windows.Forms.Button()
        Me.txtBerita = New System.Windows.Forms.TextBox()
        Me.gbListGempa = New System.Windows.Forms.GroupBox()
        Me.lvwGempa = New System.Windows.Forms.ListView()
        Me.PanelLuar = New System.Windows.Forms.Panel()
        Me.SaveEpic = New System.Windows.Forms.SaveFileDialog()
        Me.GenMapTimer = New System.Windows.Forms.Timer(Me.components)
        Me.btGenmap = New System.Windows.Forms.Button()
        Me.MapProgress = New System.Windows.Forms.ProgressBar()
        Me.MyToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.PBEpisenter = New System.Windows.Forms.PictureBox()
        Me.gbInput.SuspendLayout()
        Me.PanelInfo.SuspendLayout()
        Me.gbMessage.SuspendLayout()
        Me.gbListGempa.SuspendLayout()
        Me.PanelLuar.SuspendLayout()
        CType(Me.PBEpisenter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbInput
        '
        Me.gbInput.Controls.Add(Me.btQuerySC)
        Me.gbInput.Controls.Add(Me.btNarasi)
        Me.gbInput.Controls.Add(Me.btShake)
        Me.gbInput.Controls.Add(Me.btSaveMap)
        Me.gbInput.Controls.Add(Me.btInput)
        Me.gbInput.Controls.Add(Me.PanelInfo)
        Me.gbInput.Controls.Add(Me.Label9)
        Me.gbInput.Controls.Add(Me.lbEventID)
        Me.gbInput.Controls.Add(Me.lblDaerah4)
        Me.gbInput.Controls.Add(Me.lblDaerah3)
        Me.gbInput.Controls.Add(Me.lblDaerah2)
        Me.gbInput.Controls.Add(Me.lblDaerah1)
        Me.gbInput.Controls.Add(Me.lblDaerah)
        Me.gbInput.Controls.Add(Me.btDelete)
        Me.gbInput.Controls.Add(Me.btCancel)
        Me.gbInput.Controls.Add(Me.btSave)
        Me.gbInput.Controls.Add(Me.btEdit)
        Me.gbInput.Controls.Add(Me.TimePicker)
        Me.gbInput.Controls.Add(Me.txtLokasi)
        Me.gbInput.Controls.Add(Me.txtMag)
        Me.gbInput.Controls.Add(Me.txtDepth)
        Me.gbInput.Controls.Add(Me.txtLon)
        Me.gbInput.Controls.Add(Me.txtLat)
        Me.gbInput.Controls.Add(Me.DatePicker)
        Me.gbInput.Controls.Add(Me.Label7)
        Me.gbInput.Controls.Add(Me.Label6)
        Me.gbInput.Controls.Add(Me.Label5)
        Me.gbInput.Controls.Add(Me.Label4)
        Me.gbInput.Controls.Add(Me.Label3)
        Me.gbInput.Controls.Add(Me.Label2)
        Me.gbInput.Controls.Add(Me.Label1)
        Me.gbInput.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbInput.Location = New System.Drawing.Point(0, 294)
        Me.gbInput.Name = "gbInput"
        Me.gbInput.Size = New System.Drawing.Size(926, 322)
        Me.gbInput.TabIndex = 1
        Me.gbInput.TabStop = False
        Me.gbInput.Text = "| Input Gempabumi Terkini |"
        '
        'btQuerySC
        '
        Me.btQuerySC.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btQuerySC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btQuerySC.Location = New System.Drawing.Point(39, 23)
        Me.btQuerySC.Name = "btQuerySC"
        Me.btQuerySC.Size = New System.Drawing.Size(248, 39)
        Me.btQuerySC.TabIndex = 0
        Me.btQuerySC.Text = "&Query SeiscomP3"
        Me.btQuerySC.UseVisualStyleBackColor = False
        '
        'btNarasi
        '
        Me.btNarasi.Location = New System.Drawing.Point(696, 21)
        Me.btNarasi.Name = "btNarasi"
        Me.btNarasi.Size = New System.Drawing.Size(85, 35)
        Me.btNarasi.TabIndex = 61
        Me.btNarasi.Text = "Buat Narasi"
        Me.btNarasi.UseVisualStyleBackColor = True
        '
        'btShake
        '
        Me.btShake.Location = New System.Drawing.Point(603, 21)
        Me.btShake.Name = "btShake"
        Me.btShake.Size = New System.Drawing.Size(85, 35)
        Me.btShake.TabIndex = 60
        Me.btShake.Text = "Shake XML"
        Me.btShake.UseVisualStyleBackColor = True
        '
        'btSaveMap
        '
        Me.btSaveMap.BackColor = System.Drawing.SystemColors.Control
        Me.btSaveMap.Location = New System.Drawing.Point(818, 129)
        Me.btSaveMap.Name = "btSaveMap"
        Me.btSaveMap.Size = New System.Drawing.Size(75, 35)
        Me.btSaveMap.TabIndex = 15
        Me.btSaveMap.Text = "Sa&ve Map"
        Me.btSaveMap.UseVisualStyleBackColor = False
        '
        'btInput
        '
        Me.btInput.Location = New System.Drawing.Point(818, 41)
        Me.btInput.Name = "btInput"
        Me.btInput.Size = New System.Drawing.Size(75, 35)
        Me.btInput.TabIndex = 14
        Me.btInput.Text = "I&nput"
        Me.btInput.UseVisualStyleBackColor = True
        '
        'PanelInfo
        '
        Me.PanelInfo.Controls.Add(Me.lblInfoTambahan)
        Me.PanelInfo.Controls.Add(Me.txtInfo)
        Me.PanelInfo.Location = New System.Drawing.Point(325, 68)
        Me.PanelInfo.Name = "PanelInfo"
        Me.PanelInfo.Size = New System.Drawing.Size(244, 107)
        Me.PanelInfo.TabIndex = 7
        '
        'lblInfoTambahan
        '
        Me.lblInfoTambahan.AutoSize = True
        Me.lblInfoTambahan.Location = New System.Drawing.Point(3, 2)
        Me.lblInfoTambahan.Name = "lblInfoTambahan"
        Me.lblInfoTambahan.Size = New System.Drawing.Size(90, 15)
        Me.lblInfoTambahan.TabIndex = 20
        Me.lblInfoTambahan.Text = "Info Tambahan"
        '
        'txtInfo
        '
        Me.txtInfo.Location = New System.Drawing.Point(4, 27)
        Me.txtInfo.Multiline = True
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtInfo.Size = New System.Drawing.Size(237, 77)
        Me.txtInfo.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(36, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 15)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "EventID"
        '
        'lbEventID
        '
        Me.lbEventID.AutoSize = True
        Me.lbEventID.Location = New System.Drawing.Point(129, 72)
        Me.lbEventID.Name = "lbEventID"
        Me.lbEventID.Size = New System.Drawing.Size(49, 15)
        Me.lbEventID.TabIndex = 58
        Me.lbEventID.Text = "EventID"
        '
        'lblDaerah4
        '
        Me.lblDaerah4.AutoSize = True
        Me.lblDaerah4.Location = New System.Drawing.Point(330, 294)
        Me.lblDaerah4.Name = "lblDaerah4"
        Me.lblDaerah4.Size = New System.Drawing.Size(0, 15)
        Me.lblDaerah4.TabIndex = 53
        '
        'lblDaerah3
        '
        Me.lblDaerah3.AutoSize = True
        Me.lblDaerah3.Location = New System.Drawing.Point(330, 266)
        Me.lblDaerah3.Name = "lblDaerah3"
        Me.lblDaerah3.Size = New System.Drawing.Size(0, 15)
        Me.lblDaerah3.TabIndex = 52
        '
        'lblDaerah2
        '
        Me.lblDaerah2.AutoSize = True
        Me.lblDaerah2.Location = New System.Drawing.Point(330, 238)
        Me.lblDaerah2.Name = "lblDaerah2"
        Me.lblDaerah2.Size = New System.Drawing.Size(0, 15)
        Me.lblDaerah2.TabIndex = 51
        '
        'lblDaerah1
        '
        Me.lblDaerah1.AutoSize = True
        Me.lblDaerah1.Location = New System.Drawing.Point(330, 210)
        Me.lblDaerah1.Name = "lblDaerah1"
        Me.lblDaerah1.Size = New System.Drawing.Size(0, 15)
        Me.lblDaerah1.TabIndex = 50
        '
        'lblDaerah
        '
        Me.lblDaerah.AutoSize = True
        Me.lblDaerah.Location = New System.Drawing.Point(330, 178)
        Me.lblDaerah.Name = "lblDaerah"
        Me.lblDaerah.Size = New System.Drawing.Size(101, 15)
        Me.lblDaerah.TabIndex = 49
        Me.lblDaerah.Text = "Daerah terdekat :"
        '
        'btDelete
        '
        Me.btDelete.Enabled = False
        Me.btDelete.Location = New System.Drawing.Point(818, 217)
        Me.btDelete.Name = "btDelete"
        Me.btDelete.Size = New System.Drawing.Size(75, 35)
        Me.btDelete.TabIndex = 12
        Me.btDelete.Text = "Dele&te"
        Me.btDelete.UseVisualStyleBackColor = True
        '
        'btCancel
        '
        Me.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancel.Location = New System.Drawing.Point(818, 261)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(75, 35)
        Me.btCancel.TabIndex = 13
        Me.btCancel.Text = "&Cancel"
        Me.btCancel.UseVisualStyleBackColor = True
        '
        'btSave
        '
        Me.btSave.Location = New System.Drawing.Point(818, 85)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(75, 35)
        Me.btSave.TabIndex = 10
        Me.btSave.Text = "&Save"
        Me.btSave.UseVisualStyleBackColor = True
        '
        'btEdit
        '
        Me.btEdit.Location = New System.Drawing.Point(818, 173)
        Me.btEdit.Name = "btEdit"
        Me.btEdit.Size = New System.Drawing.Size(75, 35)
        Me.btEdit.TabIndex = 11
        Me.btEdit.Text = "&Edit"
        Me.btEdit.UseVisualStyleBackColor = True
        '
        'TimePicker
        '
        Me.TimePicker.CustomFormat = "HH:mm:ss"
        Me.TimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TimePicker.Location = New System.Drawing.Point(132, 128)
        Me.TimePicker.Name = "TimePicker"
        Me.TimePicker.ShowUpDown = True
        Me.TimePicker.Size = New System.Drawing.Size(155, 21)
        Me.TimePicker.TabIndex = 1
        '
        'txtLokasi
        '
        Me.txtLokasi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtLokasi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList
        Me.txtLokasi.Enabled = False
        Me.txtLokasi.Location = New System.Drawing.Point(132, 283)
        Me.txtLokasi.Name = "txtLokasi"
        Me.txtLokasi.Size = New System.Drawing.Size(155, 21)
        Me.txtLokasi.TabIndex = 6
        '
        'txtMag
        '
        Me.txtMag.Location = New System.Drawing.Point(132, 252)
        Me.txtMag.Name = "txtMag"
        Me.txtMag.Size = New System.Drawing.Size(155, 21)
        Me.txtMag.TabIndex = 5
        '
        'txtDepth
        '
        Me.txtDepth.Location = New System.Drawing.Point(132, 221)
        Me.txtDepth.Name = "txtDepth"
        Me.txtDepth.Size = New System.Drawing.Size(155, 21)
        Me.txtDepth.TabIndex = 4
        '
        'txtLon
        '
        Me.txtLon.Location = New System.Drawing.Point(132, 190)
        Me.txtLon.Name = "txtLon"
        Me.txtLon.Size = New System.Drawing.Size(155, 21)
        Me.txtLon.TabIndex = 3
        '
        'txtLat
        '
        Me.txtLat.Location = New System.Drawing.Point(132, 159)
        Me.txtLat.Name = "txtLat"
        Me.txtLat.Size = New System.Drawing.Size(155, 21)
        Me.txtLat.TabIndex = 2
        Me.MyToolTip.SetToolTip(Me.txtLat, "For south latitude use minus sign ("" - "")")
        '
        'DatePicker
        '
        Me.DatePicker.CustomFormat = "dd/MM/yyyy"
        Me.DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DatePicker.Location = New System.Drawing.Point(132, 97)
        Me.DatePicker.Name = "DatePicker"
        Me.DatePicker.Size = New System.Drawing.Size(155, 21)
        Me.DatePicker.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(36, 282)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 15)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Lokasi"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(36, 252)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 15)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Magnitudo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(36, 222)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 15)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Kedalaman"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 15)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Bujur"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 15)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Lintang"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Jam"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Tanggal"
        '
        'gbMessage
        '
        Me.gbMessage.Controls.Add(Me.btCopy)
        Me.gbMessage.Controls.Add(Me.txtBerita)
        Me.gbMessage.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMessage.Location = New System.Drawing.Point(0, 0)
        Me.gbMessage.Name = "gbMessage"
        Me.gbMessage.Size = New System.Drawing.Size(926, 96)
        Me.gbMessage.TabIndex = 2
        Me.gbMessage.TabStop = False
        Me.gbMessage.Text = "| Berita Informasi Gempabumi |"
        '
        'btCopy
        '
        Me.btCopy.Location = New System.Drawing.Point(832, 20)
        Me.btCopy.Name = "btCopy"
        Me.btCopy.Size = New System.Drawing.Size(84, 70)
        Me.btCopy.TabIndex = 2
        Me.btCopy.Text = "Cop&y"
        Me.btCopy.UseVisualStyleBackColor = True
        '
        'txtBerita
        '
        Me.txtBerita.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBerita.Location = New System.Drawing.Point(3, 20)
        Me.txtBerita.Multiline = True
        Me.txtBerita.Name = "txtBerita"
        Me.txtBerita.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBerita.Size = New System.Drawing.Size(823, 76)
        Me.txtBerita.TabIndex = 0
        Me.txtBerita.TabStop = False
        '
        'gbListGempa
        '
        Me.gbListGempa.Controls.Add(Me.lvwGempa)
        Me.gbListGempa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbListGempa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbListGempa.Location = New System.Drawing.Point(0, 96)
        Me.gbListGempa.Name = "gbListGempa"
        Me.gbListGempa.Size = New System.Drawing.Size(926, 198)
        Me.gbListGempa.TabIndex = 0
        Me.gbListGempa.TabStop = False
        Me.gbListGempa.Text = "| 60 Gempabumi Terakhir |"
        '
        'lvwGempa
        '
        Me.lvwGempa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwGempa.FullRowSelect = True
        Me.lvwGempa.GridLines = True
        Me.lvwGempa.Location = New System.Drawing.Point(3, 17)
        Me.lvwGempa.Name = "lvwGempa"
        Me.lvwGempa.Size = New System.Drawing.Size(920, 178)
        Me.lvwGempa.TabIndex = 0
        Me.lvwGempa.UseCompatibleStateImageBehavior = False
        '
        'PanelLuar
        '
        Me.PanelLuar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelLuar.Controls.Add(Me.gbListGempa)
        Me.PanelLuar.Controls.Add(Me.gbMessage)
        Me.PanelLuar.Controls.Add(Me.gbInput)
        Me.PanelLuar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelLuar.Location = New System.Drawing.Point(0, 0)
        Me.PanelLuar.Name = "PanelLuar"
        Me.PanelLuar.Size = New System.Drawing.Size(930, 620)
        Me.PanelLuar.TabIndex = 20
        '
        'SaveEpic
        '
        Me.SaveEpic.Filter = "Image Files(*.jpg)|*.jpg"
        '
        'GenMapTimer
        '
        Me.GenMapTimer.Interval = 10
        '
        'btGenmap
        '
        Me.btGenmap.Location = New System.Drawing.Point(617, 470)
        Me.btGenmap.Name = "btGenmap"
        Me.btGenmap.Size = New System.Drawing.Size(157, 25)
        Me.btGenmap.TabIndex = 8
        Me.btGenmap.Text = "&Generate Map"
        Me.MyToolTip.SetToolTip(Me.btGenmap, "Click to generate map from this event")
        Me.btGenmap.UseVisualStyleBackColor = True
        '
        'MapProgress
        '
        Me.MapProgress.Location = New System.Drawing.Point(617, 470)
        Me.MapProgress.Name = "MapProgress"
        Me.MapProgress.Size = New System.Drawing.Size(157, 25)
        Me.MapProgress.Step = 1
        Me.MapProgress.TabIndex = 69
        '
        'PBEpisenter
        '
        Me.PBEpisenter.Location = New System.Drawing.Point(605, 365)
        Me.PBEpisenter.Name = "PBEpisenter"
        Me.PBEpisenter.Size = New System.Drawing.Size(180, 245)
        Me.PBEpisenter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PBEpisenter.TabIndex = 67
        Me.PBEpisenter.TabStop = False
        '
        'FormInput
        '
        Me.AcceptButton = Me.btSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btCancel
        Me.ClientSize = New System.Drawing.Size(930, 620)
        Me.ControlBox = False
        Me.Controls.Add(Me.btGenmap)
        Me.Controls.Add(Me.MapProgress)
        Me.Controls.Add(Me.PBEpisenter)
        Me.Controls.Add(Me.PanelLuar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormInput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbInput.ResumeLayout(False)
        Me.gbInput.PerformLayout()
        Me.PanelInfo.ResumeLayout(False)
        Me.PanelInfo.PerformLayout()
        Me.gbMessage.ResumeLayout(False)
        Me.gbMessage.PerformLayout()
        Me.gbListGempa.ResumeLayout(False)
        Me.PanelLuar.ResumeLayout(False)
        CType(Me.PBEpisenter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbInput As System.Windows.Forms.GroupBox
    Friend WithEvents PanelInfo As System.Windows.Forms.Panel
    Friend WithEvents txtInfo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbEventID As System.Windows.Forms.Label
    Friend WithEvents lblDaerah4 As System.Windows.Forms.Label
    Friend WithEvents lblDaerah3 As System.Windows.Forms.Label
    Friend WithEvents lblDaerah2 As System.Windows.Forms.Label
    Friend WithEvents lblDaerah1 As System.Windows.Forms.Label
    Friend WithEvents lblDaerah As System.Windows.Forms.Label
    Friend WithEvents btDelete As System.Windows.Forms.Button
    Friend WithEvents btCancel As System.Windows.Forms.Button
    Friend WithEvents btSave As System.Windows.Forms.Button
    Friend WithEvents btEdit As System.Windows.Forms.Button
    Friend WithEvents TimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtLokasi As System.Windows.Forms.TextBox
    Friend WithEvents txtMag As System.Windows.Forms.TextBox
    Friend WithEvents txtDepth As System.Windows.Forms.TextBox
    Friend WithEvents txtLon As System.Windows.Forms.TextBox
    Friend WithEvents txtLat As System.Windows.Forms.TextBox
    Friend WithEvents DatePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbMessage As System.Windows.Forms.GroupBox
    Friend WithEvents btCopy As System.Windows.Forms.Button
    Friend WithEvents txtBerita As System.Windows.Forms.TextBox
    Friend WithEvents gbListGempa As System.Windows.Forms.GroupBox
    Friend WithEvents lvwGempa As System.Windows.Forms.ListView
    Friend WithEvents PanelLuar As System.Windows.Forms.Panel
    Friend WithEvents btInput As System.Windows.Forms.Button
    Friend WithEvents btSaveMap As System.Windows.Forms.Button
    Friend WithEvents SaveEpic As System.Windows.Forms.SaveFileDialog
    Friend WithEvents GenMapTimer As System.Windows.Forms.Timer
    Friend WithEvents lblInfoTambahan As System.Windows.Forms.Label
    Friend WithEvents PBEpisenter As System.Windows.Forms.PictureBox
    Friend WithEvents btGenmap As System.Windows.Forms.Button
    Friend WithEvents MapProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents MyToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents btShake As System.Windows.Forms.Button
    Friend WithEvents btNarasi As Button
    Friend WithEvents btQuerySC As Button
End Class
