<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNarasi
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
        Me.gbControl = New System.Windows.Forms.GroupBox()
        Me.panelPatahan = New System.Windows.Forms.Panel()
        Me.cbNamapatahan = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbSumberGempa = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbIDgempa = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.timepickerNarasi = New System.Windows.Forms.DateTimePicker()
        Me.txtJmlsusulan = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.panelMekanisme = New System.Windows.Forms.Panel()
        Me.cbMekanismePatahan = New System.Windows.Forms.ComboBox()
        Me.chkFocal = New System.Windows.Forms.CheckBox()
        Me.chkShakemap = New System.Windows.Forms.CheckBox()
        Me.cbLokasi = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbDampak = New System.Windows.Forms.ComboBox()
        Me.txtDaerah = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btExit = New System.Windows.Forms.Button()
        Me.btDelete = New System.Windows.Forms.Button()
        Me.btSave = New System.Windows.Forms.Button()
        Me.gbNarasi = New System.Windows.Forms.GroupBox()
        Me.btCopyNarasi = New System.Windows.Forms.Button()
        Me.txtNarasi = New System.Windows.Forms.TextBox()
        Me.ttNarasi = New System.Windows.Forms.ToolTip(Me.components)
        Me.gbControl.SuspendLayout()
        Me.panelPatahan.SuspendLayout()
        Me.panelMekanisme.SuspendLayout()
        Me.gbNarasi.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbControl
        '
        Me.gbControl.Controls.Add(Me.panelPatahan)
        Me.gbControl.Controls.Add(Me.lbIDgempa)
        Me.gbControl.Controls.Add(Me.Label7)
        Me.gbControl.Controls.Add(Me.timepickerNarasi)
        Me.gbControl.Controls.Add(Me.txtJmlsusulan)
        Me.gbControl.Controls.Add(Me.Label6)
        Me.gbControl.Controls.Add(Me.Label5)
        Me.gbControl.Controls.Add(Me.panelMekanisme)
        Me.gbControl.Controls.Add(Me.chkShakemap)
        Me.gbControl.Controls.Add(Me.cbLokasi)
        Me.gbControl.Controls.Add(Me.Label2)
        Me.gbControl.Controls.Add(Me.cbDampak)
        Me.gbControl.Controls.Add(Me.txtDaerah)
        Me.gbControl.Controls.Add(Me.Label1)
        Me.gbControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbControl.Location = New System.Drawing.Point(0, 0)
        Me.gbControl.Name = "gbControl"
        Me.gbControl.Size = New System.Drawing.Size(830, 172)
        Me.gbControl.TabIndex = 0
        Me.gbControl.TabStop = False
        Me.gbControl.Text = "| Narasi Gempabumi Dirasakan |"
        '
        'panelPatahan
        '
        Me.panelPatahan.Controls.Add(Me.cbNamapatahan)
        Me.panelPatahan.Controls.Add(Me.Label3)
        Me.panelPatahan.Controls.Add(Me.cbSumberGempa)
        Me.panelPatahan.Controls.Add(Me.Label4)
        Me.panelPatahan.Location = New System.Drawing.Point(14, 113)
        Me.panelPatahan.Name = "panelPatahan"
        Me.panelPatahan.Size = New System.Drawing.Size(556, 30)
        Me.panelPatahan.TabIndex = 17
        '
        'cbNamapatahan
        '
        Me.cbNamapatahan.AutoCompleteCustomSource.AddRange(New String() {"--pilih intensitas--", "<= II MMI", "= III MMI", ">= IV MMI"})
        Me.cbNamapatahan.FormattingEnabled = True
        Me.cbNamapatahan.Location = New System.Drawing.Point(366, 4)
        Me.cbNamapatahan.Name = "cbNamapatahan"
        Me.cbNamapatahan.Size = New System.Drawing.Size(179, 21)
        Me.cbNamapatahan.TabIndex = 7
        Me.cbNamapatahan.Text = "-- pilih --"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Sumber Gempa"
        '
        'cbSumberGempa
        '
        Me.cbSumberGempa.AutoCompleteCustomSource.AddRange(New String() {"--pilih intensitas--", "<= II MMI", "= III MMI", ">= IV MMI"})
        Me.cbSumberGempa.FormattingEnabled = True
        Me.cbSumberGempa.Items.AddRange(New Object() {"Sesar lokal", "Subduksi", "Sesar (terdefinisi)"})
        Me.cbSumberGempa.Location = New System.Drawing.Point(140, 4)
        Me.cbSumberGempa.Name = "cbSumberGempa"
        Me.cbSumberGempa.Size = New System.Drawing.Size(128, 21)
        Me.cbSumberGempa.TabIndex = 6
        Me.cbSumberGempa.Text = "-- pilih --"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(282, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Nama Patahan"
        '
        'lbIDgempa
        '
        Me.lbIDgempa.AutoSize = True
        Me.lbIDgempa.Location = New System.Drawing.Point(19, 27)
        Me.lbIDgempa.Name = "lbIDgempa"
        Me.lbIDgempa.Size = New System.Drawing.Size(18, 13)
        Me.lbIDgempa.TabIndex = 16
        Me.lbIDgempa.Text = "ID"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(296, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Dampak"
        '
        'timepickerNarasi
        '
        Me.timepickerNarasi.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.timepickerNarasi.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timepickerNarasi.Location = New System.Drawing.Point(154, 55)
        Me.timepickerNarasi.Name = "timepickerNarasi"
        Me.timepickerNarasi.Size = New System.Drawing.Size(128, 20)
        Me.timepickerNarasi.TabIndex = 0
        '
        'txtJmlsusulan
        '
        Me.txtJmlsusulan.Location = New System.Drawing.Point(380, 55)
        Me.txtJmlsusulan.Name = "txtJmlsusulan"
        Me.txtJmlsusulan.Size = New System.Drawing.Size(179, 20)
        Me.txtJmlsusulan.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(296, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Jumlah Susulan"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Waktu Pembuatan Narasi"
        '
        'panelMekanisme
        '
        Me.panelMekanisme.Controls.Add(Me.cbMekanismePatahan)
        Me.panelMekanisme.Controls.Add(Me.chkFocal)
        Me.panelMekanisme.Enabled = False
        Me.panelMekanisme.Location = New System.Drawing.Point(572, 113)
        Me.panelMekanisme.Name = "panelMekanisme"
        Me.panelMekanisme.Size = New System.Drawing.Size(240, 30)
        Me.panelMekanisme.TabIndex = 8
        '
        'cbMekanismePatahan
        '
        Me.cbMekanismePatahan.AutoCompleteCustomSource.AddRange(New String() {"Dekstral (geser menganan)", "Sinistral (geser mengiri)", "Thrust (naik)", "Normal (turun)", "Oblique (miring)"})
        Me.cbMekanismePatahan.FormattingEnabled = True
        Me.cbMekanismePatahan.Items.AddRange(New Object() {"thrust (naik)", "normal (turun)", "oblique (miring)", "strike-slip dekstral (kanan)", "strike-slip sinistral (kiri)"})
        Me.cbMekanismePatahan.Location = New System.Drawing.Point(130, 4)
        Me.cbMekanismePatahan.Name = "cbMekanismePatahan"
        Me.cbMekanismePatahan.Size = New System.Drawing.Size(104, 21)
        Me.cbMekanismePatahan.TabIndex = 10
        Me.cbMekanismePatahan.Text = "-- pilih --"
        '
        'chkFocal
        '
        Me.chkFocal.AutoSize = True
        Me.chkFocal.Location = New System.Drawing.Point(4, 6)
        Me.chkFocal.Name = "chkFocal"
        Me.chkFocal.Size = New System.Drawing.Size(123, 17)
        Me.chkFocal.TabIndex = 9
        Me.chkFocal.Text = "Mekanisme Patahan"
        Me.chkFocal.UseVisualStyleBackColor = True
        '
        'chkShakemap
        '
        Me.chkShakemap.AutoSize = True
        Me.chkShakemap.Location = New System.Drawing.Point(576, 88)
        Me.chkShakemap.Name = "chkShakemap"
        Me.chkShakemap.Size = New System.Drawing.Size(77, 17)
        Me.chkShakemap.TabIndex = 5
        Me.chkShakemap.Text = "Shakemap"
        Me.chkShakemap.UseVisualStyleBackColor = True
        '
        'cbLokasi
        '
        Me.cbLokasi.AutoCompleteCustomSource.AddRange(New String() {"--pilih--", "darat", "laut"})
        Me.cbLokasi.FormattingEnabled = True
        Me.cbLokasi.Items.AddRange(New Object() {"darat", "laut"})
        Me.cbLokasi.Location = New System.Drawing.Point(702, 55)
        Me.cbLokasi.Name = "cbLokasi"
        Me.cbLokasi.Size = New System.Drawing.Size(104, 21)
        Me.cbLokasi.TabIndex = 2
        Me.cbLokasi.Text = "-- pilih darat/laut --"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(573, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Lokasi Episenter"
        '
        'cbDampak
        '
        Me.cbDampak.AutoCompleteCustomSource.AddRange(New String() {"dirasakan oleh beberapa orang.", "dirasakan oleh banyak orang.", "dirasakan oleh banyak orang, bahkan ada beberapa warga yang berhamburan keluar un" &
                "tuk menyelamatkan diri.", "dirasakan oleh banyak orang yang berhamburan keluar untuk menyelamatkan diri."})
        Me.cbDampak.FormattingEnabled = True
        Me.cbDampak.Items.AddRange(New Object() {"1. Dirasakan beberapa orang", "2. Dirasakan banyak orang", "3. Beberapa orang berhamburan keluar", "4. Banyak orang berhamburan keluar"})
        Me.cbDampak.Location = New System.Drawing.Point(380, 86)
        Me.cbDampak.Name = "cbDampak"
        Me.cbDampak.Size = New System.Drawing.Size(179, 21)
        Me.cbDampak.TabIndex = 4
        Me.cbDampak.Text = "-- pilih --"
        '
        'txtDaerah
        '
        Me.txtDaerah.Location = New System.Drawing.Point(154, 86)
        Me.txtDaerah.Name = "txtDaerah"
        Me.txtDaerah.Size = New System.Drawing.Size(128, 20)
        Me.txtDaerah.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Daerah Terdampak"
        '
        'btExit
        '
        Me.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btExit.Location = New System.Drawing.Point(731, 256)
        Me.btExit.Name = "btExit"
        Me.btExit.Size = New System.Drawing.Size(80, 40)
        Me.btExit.TabIndex = 4
        Me.btExit.Text = "&Exit"
        Me.btExit.UseVisualStyleBackColor = True
        '
        'btDelete
        '
        Me.btDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btDelete.Location = New System.Drawing.Point(731, 178)
        Me.btDelete.Name = "btDelete"
        Me.btDelete.Size = New System.Drawing.Size(80, 40)
        Me.btDelete.TabIndex = 3
        Me.btDelete.Text = "&Delete"
        Me.btDelete.UseVisualStyleBackColor = True
        '
        'btSave
        '
        Me.btSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSave.Location = New System.Drawing.Point(731, 22)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(80, 40)
        Me.btSave.TabIndex = 1
        Me.btSave.Text = "&Save"
        Me.btSave.UseVisualStyleBackColor = True
        '
        'gbNarasi
        '
        Me.gbNarasi.Controls.Add(Me.btExit)
        Me.gbNarasi.Controls.Add(Me.btCopyNarasi)
        Me.gbNarasi.Controls.Add(Me.btDelete)
        Me.gbNarasi.Controls.Add(Me.txtNarasi)
        Me.gbNarasi.Controls.Add(Me.btSave)
        Me.gbNarasi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbNarasi.Location = New System.Drawing.Point(0, 172)
        Me.gbNarasi.Name = "gbNarasi"
        Me.gbNarasi.Size = New System.Drawing.Size(830, 322)
        Me.gbNarasi.TabIndex = 1
        Me.gbNarasi.TabStop = False
        Me.gbNarasi.Text = "| Narasi Berita Gempabumi |"
        '
        'btCopyNarasi
        '
        Me.btCopyNarasi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCopyNarasi.Location = New System.Drawing.Point(731, 100)
        Me.btCopyNarasi.Name = "btCopyNarasi"
        Me.btCopyNarasi.Size = New System.Drawing.Size(80, 40)
        Me.btCopyNarasi.TabIndex = 2
        Me.btCopyNarasi.Text = "&Copy Narasi"
        Me.btCopyNarasi.UseVisualStyleBackColor = True
        '
        'txtNarasi
        '
        Me.txtNarasi.Location = New System.Drawing.Point(14, 19)
        Me.txtNarasi.Multiline = True
        Me.txtNarasi.Name = "txtNarasi"
        Me.txtNarasi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNarasi.Size = New System.Drawing.Size(689, 291)
        Me.txtNarasi.TabIndex = 0
        '
        'FormNarasi
        '
        Me.AcceptButton = Me.btSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btExit
        Me.ClientSize = New System.Drawing.Size(830, 494)
        Me.ControlBox = False
        Me.Controls.Add(Me.gbNarasi)
        Me.Controls.Add(Me.gbControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormNarasi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbControl.ResumeLayout(False)
        Me.gbControl.PerformLayout()
        Me.panelPatahan.ResumeLayout(False)
        Me.panelPatahan.PerformLayout()
        Me.panelMekanisme.ResumeLayout(False)
        Me.panelMekanisme.PerformLayout()
        Me.gbNarasi.ResumeLayout(False)
        Me.gbNarasi.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbControl As GroupBox
    Friend WithEvents gbNarasi As GroupBox
    Friend WithEvents txtDaerah As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbLokasi As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbDampak As ComboBox
    Friend WithEvents cbSumberGempa As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents chkShakemap As CheckBox
    Friend WithEvents cbNamapatahan As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents panelMekanisme As Panel
    Friend WithEvents chkFocal As CheckBox
    Friend WithEvents timepickerNarasi As DateTimePicker
    Friend WithEvents txtJmlsusulan As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cbMekanismePatahan As ComboBox
    Friend WithEvents lbIDgempa As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtNarasi As TextBox
    Friend WithEvents btCopyNarasi As Button
    Friend WithEvents btSave As Button
    Friend WithEvents btDelete As Button
    Friend WithEvents btExit As Button
    Friend WithEvents ttNarasi As ToolTip
    Friend WithEvents panelPatahan As Panel
End Class
