<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUtama
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUtama))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.labelBMKG = New System.Windows.Forms.ToolStripLabel()
        Me.tslbPGR = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnUtama = New System.Windows.Forms.ToolStripButton()
        Me.Separator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnCari = New System.Windows.Forms.ToolStripButton()
        Me.Separator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnData = New System.Windows.Forms.ToolStripDropDownButton()
        Me.mnMetadata = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnDaerah = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnPatahan = New System.Windows.Forms.ToolStripMenuItem()
        Me.Separator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnBantuan = New System.Windows.Forms.ToolStripDropDownButton()
        Me.mnSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnTentang = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.Separator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStrip.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripMargin = New System.Windows.Forms.Padding(5)
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(40, 40)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelBMKG, Me.tslbPGR, Me.ToolStripSeparator1, Me.mnUtama, Me.Separator1, Me.mnCari, Me.Separator2, Me.mnData, Me.Separator3, Me.mnBantuan, Me.Separator4})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(291, 602)
        Me.ToolStrip.TabIndex = 21
        '
        'labelBMKG
        '
        Me.labelBMKG.AutoSize = False
        Me.labelBMKG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.labelBMKG.DoubleClickEnabled = True
        Me.labelBMKG.Font = New System.Drawing.Font("Arial Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelBMKG.Image = Global.DatinGB.My.Resources.Resources.new_logo
        Me.labelBMKG.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.labelBMKG.Margin = New System.Windows.Forms.Padding(0, 25, 0, 0)
        Me.labelBMKG.Name = "labelBMKG"
        Me.labelBMKG.Size = New System.Drawing.Size(105, 150)
        Me.labelBMKG.Text = "BMKG"
        Me.labelBMKG.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.labelBMKG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.labelBMKG.ToolTipText = "Double click here to synchronize data with server"
        '
        'tslbPGR
        '
        Me.tslbPGR.Font = New System.Drawing.Font("Arial Black", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tslbPGR.Name = "tslbPGR"
        Me.tslbPGR.Size = New System.Drawing.Size(289, 27)
        Me.tslbPGR.Text = "PUSAT GEMPA REGIONAL"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Margin = New System.Windows.Forms.Padding(0, 30, 0, 5)
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(289, 6)
        '
        'mnUtama
        '
        Me.mnUtama.BackColor = System.Drawing.Color.WhiteSmoke
        Me.mnUtama.Image = Global.DatinGB.My.Resources.Resources.utama
        Me.mnUtama.ImageTransparentColor = System.Drawing.Color.White
        Me.mnUtama.Margin = New System.Windows.Forms.Padding(0, 1, 9, 2)
        Me.mnUtama.Name = "mnUtama"
        Me.mnUtama.Size = New System.Drawing.Size(280, 64)
        Me.mnUtama.Text = "Data dan &Informasi"
        Me.mnUtama.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnUtama.ToolTipText = "Data dan Informasi Gempabumi"
        '
        'Separator1
        '
        Me.Separator1.Margin = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.Separator1.Name = "Separator1"
        Me.Separator1.Size = New System.Drawing.Size(289, 6)
        '
        'mnCari
        '
        Me.mnCari.Image = Global.DatinGB.My.Resources.Resources.search6
        Me.mnCari.ImageTransparentColor = System.Drawing.Color.White
        Me.mnCari.Margin = New System.Windows.Forms.Padding(0, 1, 9, 2)
        Me.mnCari.Name = "mnCari"
        Me.mnCari.Size = New System.Drawing.Size(280, 64)
        Me.mnCari.Text = "&Cari Gempa"
        Me.mnCari.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Separator2
        '
        Me.Separator2.Margin = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.Separator2.Name = "Separator2"
        Me.Separator2.Size = New System.Drawing.Size(289, 6)
        '
        'mnData
        '
        Me.mnData.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnMetadata, Me.mnDaerah, Me.mnPatahan})
        Me.mnData.Image = Global.DatinGB.My.Resources.Resources.db3
        Me.mnData.ImageTransparentColor = System.Drawing.Color.White
        Me.mnData.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.mnData.Name = "mnData"
        Me.mnData.Size = New System.Drawing.Size(289, 64)
        Me.mnData.Text = "&Metadata"
        Me.mnData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnData.ToolTipText = "Metadata Stasiun dan Data Daerah (Kota/Kab serta Kec)"
        '
        'mnMetadata
        '
        Me.mnMetadata.Name = "mnMetadata"
        Me.mnMetadata.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.mnMetadata.Size = New System.Drawing.Size(222, 24)
        Me.mnMetadata.Text = "Data Stasiun"
        '
        'mnDaerah
        '
        Me.mnDaerah.Name = "mnDaerah"
        Me.mnDaerah.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.mnDaerah.Size = New System.Drawing.Size(222, 24)
        Me.mnDaerah.Text = "Data Daerah"
        '
        'mnPatahan
        '
        Me.mnPatahan.Name = "mnPatahan"
        Me.mnPatahan.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.mnPatahan.Size = New System.Drawing.Size(222, 24)
        Me.mnPatahan.Text = "Data Patahan"
        '
        'Separator3
        '
        Me.Separator3.Margin = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.Separator3.Name = "Separator3"
        Me.Separator3.Size = New System.Drawing.Size(289, 6)
        '
        'mnBantuan
        '
        Me.mnBantuan.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnSetting, Me.ToolStripSeparator2, Me.mnTentang, Me.mnHelp})
        Me.mnBantuan.Image = Global.DatinGB.My.Resources.Resources.help
        Me.mnBantuan.ImageTransparentColor = System.Drawing.Color.White
        Me.mnBantuan.Name = "mnBantuan"
        Me.mnBantuan.Size = New System.Drawing.Size(289, 64)
        Me.mnBantuan.Text = "Setting && &Bantuan"
        Me.mnBantuan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnBantuan.ToolTipText = "Tentang Aplikasi dan Bantuan"
        '
        'mnSetting
        '
        Me.mnSetting.Name = "mnSetting"
        Me.mnSetting.Size = New System.Drawing.Size(261, 24)
        Me.mnSetting.Text = "Koneksi SeiscomP3"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(258, 6)
        '
        'mnTentang
        '
        Me.mnTentang.Name = "mnTentang"
        Me.mnTentang.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F11), System.Windows.Forms.Keys)
        Me.mnTentang.Size = New System.Drawing.Size(261, 24)
        Me.mnTentang.Text = "Tentang Aplikasi"
        '
        'mnHelp
        '
        Me.mnHelp.Name = "mnHelp"
        Me.mnHelp.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.mnHelp.Size = New System.Drawing.Size(261, 24)
        Me.mnHelp.Text = "Bantuan"
        '
        'Separator4
        '
        Me.Separator4.Name = "Separator4"
        Me.Separator4.Size = New System.Drawing.Size(289, 6)
        '
        'RefreshTimer
        '
        Me.RefreshTimer.Interval = 7200000
        '
        'FormUtama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.DatinGB.My.Resources.Resources.background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(851, 602)
        Me.Controls.Add(Me.ToolStrip)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "FormUtama"
        Me.Text = "Sistem Database dan Informasi Gempabumi"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents mnData As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnMetadata As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnDaerah As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Separator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnCari As System.Windows.Forms.ToolStripButton
    Friend WithEvents Separator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnBantuan As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnTentang As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Separator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents labelBMKG As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tslbPGR As System.Windows.Forms.ToolStripLabel
    Friend WithEvents mnUtama As System.Windows.Forms.ToolStripButton
    Friend WithEvents Separator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnSetting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshTimer As System.Windows.Forms.Timer
    Friend WithEvents mnPatahan As ToolStripMenuItem
End Class
