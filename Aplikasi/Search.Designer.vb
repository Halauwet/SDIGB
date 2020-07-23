<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSearch
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PanelSearch = New System.Windows.Forms.Panel()
        Me.gbListCari = New System.Windows.Forms.GroupBox()
        Me.lvwCari = New System.Windows.Forms.ListView()
        Me.gbAdvance = New System.Windows.Forms.GroupBox()
        Me.SeismisitasProgress = New System.Windows.Forms.ProgressBar()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.btPlot = New System.Windows.Forms.Button()
        Me.btExport = New System.Windows.Forms.Button()
        Me.gbMenuCari = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMaxMag = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtToDepth = New System.Windows.Forms.TextBox()
        Me.txtFromDepth = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bt_Del = New System.Windows.Forms.Button()
        Me.PanelKordinat = New System.Windows.Forms.Panel()
        Me.txtULat = New System.Windows.Forms.TextBox()
        Me.txtLlon = New System.Windows.Forms.TextBox()
        Me.txtRlon = New System.Windows.Forms.TextBox()
        Me.txtBlat = New System.Windows.Forms.TextBox()
        Me.txtMinMag = New System.Windows.Forms.TextBox()
        Me.lblMag = New System.Windows.Forms.Label()
        Me.lblTanggal = New System.Windows.Forms.Label()
        Me.cbDrskn = New System.Windows.Forms.CheckBox()
        Me.btExit = New System.Windows.Forms.Button()
        Me.btCari = New System.Windows.Forms.Button()
        Me.txtDaerah = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.srcToDate = New System.Windows.Forms.DateTimePicker()
        Me.srcFromDate = New System.Windows.Forms.DateTimePicker()
        Me.SaveSearch = New System.Windows.Forms.SaveFileDialog()
        Me.SeismisitasTimer = New System.Windows.Forms.Timer(Me.components)
        Me.PanelSearch.SuspendLayout()
        Me.gbListCari.SuspendLayout()
        Me.gbAdvance.SuspendLayout()
        Me.gbMenuCari.SuspendLayout()
        Me.PanelKordinat.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelSearch
        '
        Me.PanelSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelSearch.Controls.Add(Me.gbListCari)
        Me.PanelSearch.Controls.Add(Me.gbAdvance)
        Me.PanelSearch.Controls.Add(Me.gbMenuCari)
        Me.PanelSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelSearch.Location = New System.Drawing.Point(0, 0)
        Me.PanelSearch.Name = "PanelSearch"
        Me.PanelSearch.Size = New System.Drawing.Size(759, 478)
        Me.PanelSearch.TabIndex = 0
        '
        'gbListCari
        '
        Me.gbListCari.Controls.Add(Me.lvwCari)
        Me.gbListCari.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbListCari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbListCari.Location = New System.Drawing.Point(0, 219)
        Me.gbListCari.Name = "gbListCari"
        Me.gbListCari.Size = New System.Drawing.Size(755, 203)
        Me.gbListCari.TabIndex = 11
        Me.gbListCari.TabStop = False
        Me.gbListCari.Text = "| Hasil Pencarian |"
        '
        'lvwCari
        '
        Me.lvwCari.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwCari.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwCari.FullRowSelect = True
        Me.lvwCari.GridLines = True
        Me.lvwCari.Location = New System.Drawing.Point(3, 17)
        Me.lvwCari.Name = "lvwCari"
        Me.lvwCari.Size = New System.Drawing.Size(749, 183)
        Me.lvwCari.TabIndex = 0
        Me.lvwCari.UseCompatibleStateImageBehavior = False
        '
        'gbAdvance
        '
        Me.gbAdvance.Controls.Add(Me.SeismisitasProgress)
        Me.gbAdvance.Controls.Add(Me.lblCount)
        Me.gbAdvance.Controls.Add(Me.btPlot)
        Me.gbAdvance.Controls.Add(Me.btExport)
        Me.gbAdvance.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbAdvance.Location = New System.Drawing.Point(0, 422)
        Me.gbAdvance.Name = "gbAdvance"
        Me.gbAdvance.Size = New System.Drawing.Size(755, 52)
        Me.gbAdvance.TabIndex = 12
        Me.gbAdvance.TabStop = False
        '
        'SeismisitasProgress
        '
        Me.SeismisitasProgress.Location = New System.Drawing.Point(10, 14)
        Me.SeismisitasProgress.Name = "SeismisitasProgress"
        Me.SeismisitasProgress.Size = New System.Drawing.Size(551, 30)
        Me.SeismisitasProgress.Step = 2
        Me.SeismisitasProgress.TabIndex = 14
        Me.SeismisitasProgress.Visible = False
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(17, 22)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(0, 13)
        Me.lblCount.TabIndex = 10
        '
        'btPlot
        '
        Me.btPlot.Location = New System.Drawing.Point(567, 11)
        Me.btPlot.Name = "btPlot"
        Me.btPlot.Size = New System.Drawing.Size(97, 35)
        Me.btPlot.TabIndex = 16
        Me.btPlot.Text = "&Seismicity Map"
        Me.btPlot.UseVisualStyleBackColor = True
        '
        'btExport
        '
        Me.btExport.Location = New System.Drawing.Point(670, 11)
        Me.btExport.Name = "btExport"
        Me.btExport.Size = New System.Drawing.Size(75, 35)
        Me.btExport.TabIndex = 15
        Me.btExport.Text = "Expo&rt"
        Me.btExport.UseVisualStyleBackColor = True
        '
        'gbMenuCari
        '
        Me.gbMenuCari.Controls.Add(Me.Label6)
        Me.gbMenuCari.Controls.Add(Me.txtMaxMag)
        Me.gbMenuCari.Controls.Add(Me.Label5)
        Me.gbMenuCari.Controls.Add(Me.txtToDepth)
        Me.gbMenuCari.Controls.Add(Me.txtFromDepth)
        Me.gbMenuCari.Controls.Add(Me.Label4)
        Me.gbMenuCari.Controls.Add(Me.Label3)
        Me.gbMenuCari.Controls.Add(Me.Label2)
        Me.gbMenuCari.Controls.Add(Me.bt_Del)
        Me.gbMenuCari.Controls.Add(Me.PanelKordinat)
        Me.gbMenuCari.Controls.Add(Me.txtMinMag)
        Me.gbMenuCari.Controls.Add(Me.lblMag)
        Me.gbMenuCari.Controls.Add(Me.lblTanggal)
        Me.gbMenuCari.Controls.Add(Me.cbDrskn)
        Me.gbMenuCari.Controls.Add(Me.btExit)
        Me.gbMenuCari.Controls.Add(Me.btCari)
        Me.gbMenuCari.Controls.Add(Me.txtDaerah)
        Me.gbMenuCari.Controls.Add(Me.Label1)
        Me.gbMenuCari.Controls.Add(Me.srcToDate)
        Me.gbMenuCari.Controls.Add(Me.srcFromDate)
        Me.gbMenuCari.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbMenuCari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMenuCari.Location = New System.Drawing.Point(0, 0)
        Me.gbMenuCari.Name = "gbMenuCari"
        Me.gbMenuCari.Size = New System.Drawing.Size(755, 219)
        Me.gbMenuCari.TabIndex = 2
        Me.gbMenuCari.TabStop = False
        Me.gbMenuCari.Text = "| Parameter Pencarian |"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(304, 186)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 15)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "to"
        '
        'txtMaxMag
        '
        Me.txtMaxMag.Location = New System.Drawing.Point(345, 183)
        Me.txtMaxMag.Name = "txtMaxMag"
        Me.txtMaxMag.Size = New System.Drawing.Size(68, 21)
        Me.txtMaxMag.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(304, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 15)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "to"
        '
        'txtToDepth
        '
        Me.txtToDepth.Location = New System.Drawing.Point(345, 153)
        Me.txtToDepth.Name = "txtToDepth"
        Me.txtToDepth.Size = New System.Drawing.Size(68, 21)
        Me.txtToDepth.TabIndex = 10
        '
        'txtFromDepth
        '
        Me.txtFromDepth.Location = New System.Drawing.Point(212, 153)
        Me.txtFromDepth.Name = "txtFromDepth"
        Me.txtFromDepth.Size = New System.Drawing.Size(68, 21)
        Me.txtFromDepth.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(85, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 15)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Kedalaman"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(85, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 15)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Daerah"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(85, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 15)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Batasan koordinat"
        '
        'bt_Del
        '
        Me.bt_Del.BackColor = System.Drawing.Color.Red
        Me.bt_Del.Location = New System.Drawing.Point(670, 80)
        Me.bt_Del.Name = "bt_Del"
        Me.bt_Del.Size = New System.Drawing.Size(75, 35)
        Me.bt_Del.TabIndex = 20
        Me.bt_Del.Text = "Delete"
        Me.bt_Del.UseVisualStyleBackColor = False
        Me.bt_Del.Visible = False
        '
        'PanelKordinat
        '
        Me.PanelKordinat.Controls.Add(Me.txtULat)
        Me.PanelKordinat.Controls.Add(Me.txtLlon)
        Me.PanelKordinat.Controls.Add(Me.txtRlon)
        Me.PanelKordinat.Controls.Add(Me.txtBlat)
        Me.PanelKordinat.Location = New System.Drawing.Point(206, 51)
        Me.PanelKordinat.Name = "PanelKordinat"
        Me.PanelKordinat.Size = New System.Drawing.Size(252, 70)
        Me.PanelKordinat.TabIndex = 3
        '
        'txtULat
        '
        Me.txtULat.Location = New System.Drawing.Point(96, 6)
        Me.txtULat.Name = "txtULat"
        Me.txtULat.Size = New System.Drawing.Size(67, 21)
        Me.txtULat.TabIndex = 6
        '
        'txtLlon
        '
        Me.txtLlon.Location = New System.Drawing.Point(6, 24)
        Me.txtLlon.Name = "txtLlon"
        Me.txtLlon.Size = New System.Drawing.Size(67, 21)
        Me.txtLlon.TabIndex = 4
        '
        'txtRlon
        '
        Me.txtRlon.Location = New System.Drawing.Point(180, 24)
        Me.txtRlon.Name = "txtRlon"
        Me.txtRlon.Size = New System.Drawing.Size(67, 21)
        Me.txtRlon.TabIndex = 5
        '
        'txtBlat
        '
        Me.txtBlat.Location = New System.Drawing.Point(96, 42)
        Me.txtBlat.Name = "txtBlat"
        Me.txtBlat.Size = New System.Drawing.Size(67, 21)
        Me.txtBlat.TabIndex = 7
        '
        'txtMinMag
        '
        Me.txtMinMag.Location = New System.Drawing.Point(212, 183)
        Me.txtMinMag.Name = "txtMinMag"
        Me.txtMinMag.Size = New System.Drawing.Size(68, 21)
        Me.txtMinMag.TabIndex = 11
        '
        'lblMag
        '
        Me.lblMag.AutoSize = True
        Me.lblMag.Location = New System.Drawing.Point(85, 186)
        Me.lblMag.Name = "lblMag"
        Me.lblMag.Size = New System.Drawing.Size(66, 15)
        Me.lblMag.TabIndex = 13
        Me.lblMag.Text = "Magnitudo"
        '
        'lblTanggal
        '
        Me.lblTanggal.AutoSize = True
        Me.lblTanggal.Location = New System.Drawing.Point(85, 31)
        Me.lblTanggal.Name = "lblTanggal"
        Me.lblTanggal.Size = New System.Drawing.Size(52, 15)
        Me.lblTanggal.TabIndex = 12
        Me.lblTanggal.Text = "Tanggal"
        '
        'cbDrskn
        '
        Me.cbDrskn.AutoSize = True
        Me.cbDrskn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDrskn.Location = New System.Drawing.Point(530, 179)
        Me.cbDrskn.Name = "cbDrskn"
        Me.cbDrskn.Size = New System.Drawing.Size(185, 19)
        Me.cbDrskn.TabIndex = 13
        Me.cbDrskn.Text = "&Hanya Gempa Dirasakan"
        Me.cbDrskn.UseVisualStyleBackColor = True
        '
        'btExit
        '
        Me.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btExit.Location = New System.Drawing.Point(580, 109)
        Me.btExit.Name = "btExit"
        Me.btExit.Size = New System.Drawing.Size(75, 35)
        Me.btExit.TabIndex = 17
        Me.btExit.Text = "E&xit"
        Me.btExit.UseVisualStyleBackColor = True
        '
        'btCari
        '
        Me.btCari.Location = New System.Drawing.Point(580, 59)
        Me.btCari.Name = "btCari"
        Me.btCari.Size = New System.Drawing.Size(75, 35)
        Me.btCari.TabIndex = 14
        Me.btCari.Text = "Se&arch"
        Me.btCari.UseVisualStyleBackColor = True
        '
        'txtDaerah
        '
        Me.txtDaerah.AutoCompleteCustomSource.AddRange(New String() {"ambon", "tual", "jakarta"})
        Me.txtDaerah.Location = New System.Drawing.Point(212, 123)
        Me.txtDaerah.Name = "txtDaerah"
        Me.txtDaerah.Size = New System.Drawing.Size(113, 21)
        Me.txtDaerah.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(345, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "-"
        '
        'srcToDate
        '
        Me.srcToDate.CustomFormat = "dd/MM/yyyy"
        Me.srcToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.srcToDate.Location = New System.Drawing.Point(377, 28)
        Me.srcToDate.Name = "srcToDate"
        Me.srcToDate.Size = New System.Drawing.Size(113, 21)
        Me.srcToDate.TabIndex = 1
        '
        'srcFromDate
        '
        Me.srcFromDate.CustomFormat = "dd/MM/yyyy"
        Me.srcFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.srcFromDate.Location = New System.Drawing.Point(212, 28)
        Me.srcFromDate.Name = "srcFromDate"
        Me.srcFromDate.Size = New System.Drawing.Size(113, 21)
        Me.srcFromDate.TabIndex = 0
        '
        'SaveSearch
        '
        Me.SaveSearch.Filter = "Text Files(*.txt, *.dat)|*.txt; *.dat"
        '
        'SeismisitasTimer
        '
        Me.SeismisitasTimer.Interval = 150
        '
        'FormSearch
        '
        Me.AcceptButton = Me.btCari
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btExit
        Me.ClientSize = New System.Drawing.Size(759, 478)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelSearch)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelSearch.ResumeLayout(False)
        Me.gbListCari.ResumeLayout(False)
        Me.gbAdvance.ResumeLayout(False)
        Me.gbAdvance.PerformLayout()
        Me.gbMenuCari.ResumeLayout(False)
        Me.gbMenuCari.PerformLayout()
        Me.PanelKordinat.ResumeLayout(False)
        Me.PanelKordinat.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelSearch As System.Windows.Forms.Panel
    Friend WithEvents gbMenuCari As System.Windows.Forms.GroupBox
    Friend WithEvents btCari As System.Windows.Forms.Button
    Friend WithEvents txtDaerah As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents srcToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents srcFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btExit As System.Windows.Forms.Button
    Friend WithEvents btExport As System.Windows.Forms.Button
    Friend WithEvents SaveSearch As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cbDrskn As System.Windows.Forms.CheckBox
    Friend WithEvents gbAdvance As System.Windows.Forms.GroupBox
    Friend WithEvents gbListCari As System.Windows.Forms.GroupBox
    Friend WithEvents lvwCari As System.Windows.Forms.ListView
    Friend WithEvents btPlot As System.Windows.Forms.Button
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents lblTanggal As Label
    Friend WithEvents lblMag As Label
    Friend WithEvents txtMinMag As TextBox
    Friend WithEvents PanelKordinat As Panel
    Friend WithEvents txtULat As TextBox
    Friend WithEvents txtLlon As TextBox
    Friend WithEvents txtRlon As TextBox
    Friend WithEvents txtBlat As TextBox
    Friend WithEvents SeismisitasTimer As Timer
    Friend WithEvents SeismisitasProgress As ProgressBar
    Friend WithEvents bt_Del As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtToDepth As TextBox
    Friend WithEvents txtFromDepth As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtMaxMag As TextBox
End Class
