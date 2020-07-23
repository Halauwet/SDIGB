<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPatahan
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
        Me.PanelDaerah = New System.Windows.Forms.Panel()
        Me.gbListDaerah = New System.Windows.Forms.GroupBox()
        Me.btExport = New System.Windows.Forms.Button()
        Me.lvwPatahan = New System.Windows.Forms.ListView()
        Me.gbMenuDaerah = New System.Windows.Forms.GroupBox()
        Me.cbMekanisme = New System.Windows.Forms.ComboBox()
        Me.txtSumberdata = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSelatan = New System.Windows.Forms.TextBox()
        Me.txtTimur = New System.Windows.Forms.TextBox()
        Me.txtBarat = New System.Windows.Forms.TextBox()
        Me.txtUtara = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.btDelete = New System.Windows.Forms.Button()
        Me.btCancel = New System.Windows.Forms.Button()
        Me.btSave = New System.Windows.Forms.Button()
        Me.btEdit = New System.Windows.Forms.Button()
        Me.btAdd = New System.Windows.Forms.Button()
        Me.btExit = New System.Windows.Forms.Button()
        Me.txtDeskripsi = New System.Windows.Forms.TextBox()
        Me.txtPatahan = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SavePatahan = New System.Windows.Forms.SaveFileDialog()
        Me.PanelDaerah.SuspendLayout()
        Me.gbListDaerah.SuspendLayout()
        Me.gbMenuDaerah.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelDaerah
        '
        Me.PanelDaerah.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelDaerah.Controls.Add(Me.gbListDaerah)
        Me.PanelDaerah.Controls.Add(Me.gbMenuDaerah)
        Me.PanelDaerah.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDaerah.Location = New System.Drawing.Point(0, 0)
        Me.PanelDaerah.Name = "PanelDaerah"
        Me.PanelDaerah.Size = New System.Drawing.Size(759, 478)
        Me.PanelDaerah.TabIndex = 0
        '
        'gbListDaerah
        '
        Me.gbListDaerah.Controls.Add(Me.btExport)
        Me.gbListDaerah.Controls.Add(Me.lvwPatahan)
        Me.gbListDaerah.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbListDaerah.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbListDaerah.Location = New System.Drawing.Point(0, 198)
        Me.gbListDaerah.Name = "gbListDaerah"
        Me.gbListDaerah.Size = New System.Drawing.Size(755, 276)
        Me.gbListDaerah.TabIndex = 0
        Me.gbListDaerah.TabStop = False
        Me.gbListDaerah.Text = "| List Patahan |"
        '
        'btExport
        '
        Me.btExport.Location = New System.Drawing.Point(652, 213)
        Me.btExport.Name = "btExport"
        Me.btExport.Size = New System.Drawing.Size(75, 35)
        Me.btExport.TabIndex = 27
        Me.btExport.Text = "Ex&port"
        Me.btExport.UseVisualStyleBackColor = True
        '
        'lvwPatahan
        '
        Me.lvwPatahan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwPatahan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwPatahan.FullRowSelect = True
        Me.lvwPatahan.GridLines = True
        Me.lvwPatahan.Location = New System.Drawing.Point(3, 17)
        Me.lvwPatahan.Name = "lvwPatahan"
        Me.lvwPatahan.Size = New System.Drawing.Size(749, 256)
        Me.lvwPatahan.TabIndex = 0
        Me.lvwPatahan.UseCompatibleStateImageBehavior = False
        '
        'gbMenuDaerah
        '
        Me.gbMenuDaerah.Controls.Add(Me.cbMekanisme)
        Me.gbMenuDaerah.Controls.Add(Me.txtSumberdata)
        Me.gbMenuDaerah.Controls.Add(Me.Label6)
        Me.gbMenuDaerah.Controls.Add(Me.txtSelatan)
        Me.gbMenuDaerah.Controls.Add(Me.txtTimur)
        Me.gbMenuDaerah.Controls.Add(Me.txtBarat)
        Me.gbMenuDaerah.Controls.Add(Me.txtUtara)
        Me.gbMenuDaerah.Controls.Add(Me.Label5)
        Me.gbMenuDaerah.Controls.Add(Me.lblID)
        Me.gbMenuDaerah.Controls.Add(Me.btDelete)
        Me.gbMenuDaerah.Controls.Add(Me.btCancel)
        Me.gbMenuDaerah.Controls.Add(Me.btSave)
        Me.gbMenuDaerah.Controls.Add(Me.btEdit)
        Me.gbMenuDaerah.Controls.Add(Me.btAdd)
        Me.gbMenuDaerah.Controls.Add(Me.btExit)
        Me.gbMenuDaerah.Controls.Add(Me.txtDeskripsi)
        Me.gbMenuDaerah.Controls.Add(Me.txtPatahan)
        Me.gbMenuDaerah.Controls.Add(Me.Label4)
        Me.gbMenuDaerah.Controls.Add(Me.Label3)
        Me.gbMenuDaerah.Controls.Add(Me.Label2)
        Me.gbMenuDaerah.Controls.Add(Me.Label1)
        Me.gbMenuDaerah.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbMenuDaerah.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMenuDaerah.Location = New System.Drawing.Point(0, 0)
        Me.gbMenuDaerah.Name = "gbMenuDaerah"
        Me.gbMenuDaerah.Size = New System.Drawing.Size(755, 198)
        Me.gbMenuDaerah.TabIndex = 1
        Me.gbMenuDaerah.TabStop = False
        Me.gbMenuDaerah.Text = "| Input Data Patahan/Sesar |"
        '
        'cbMekanisme
        '
        Me.cbMekanisme.FormattingEnabled = True
        Me.cbMekanisme.Items.AddRange(New Object() {"thrust (naik)", "normal (turun)", "oblique (miring)", "strike-slip dekstral (kanan)", "strike-slip sinistral (kiri)"})
        Me.cbMekanisme.Location = New System.Drawing.Point(400, 54)
        Me.cbMekanisme.Name = "cbMekanisme"
        Me.cbMekanisme.Size = New System.Drawing.Size(105, 23)
        Me.cbMekanisme.TabIndex = 3
        Me.cbMekanisme.Text = "-- pilih --"
        '
        'txtSumberdata
        '
        Me.txtSumberdata.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSumberdata.Location = New System.Drawing.Point(400, 83)
        Me.txtSumberdata.Name = "txtSumberdata"
        Me.txtSumberdata.Size = New System.Drawing.Size(105, 21)
        Me.txtSumberdata.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(317, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 15)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Sumber Data"
        '
        'txtSelatan
        '
        Me.txtSelatan.Location = New System.Drawing.Point(584, 115)
        Me.txtSelatan.Name = "txtSelatan"
        Me.txtSelatan.Size = New System.Drawing.Size(66, 21)
        Me.txtSelatan.TabIndex = 8
        '
        'txtTimur
        '
        Me.txtTimur.Location = New System.Drawing.Point(640, 83)
        Me.txtTimur.Name = "txtTimur"
        Me.txtTimur.Size = New System.Drawing.Size(66, 21)
        Me.txtTimur.TabIndex = 6
        '
        'txtBarat
        '
        Me.txtBarat.Location = New System.Drawing.Point(524, 83)
        Me.txtBarat.Name = "txtBarat"
        Me.txtBarat.Size = New System.Drawing.Size(66, 21)
        Me.txtBarat.TabIndex = 5
        '
        'txtUtara
        '
        Me.txtUtara.Location = New System.Drawing.Point(581, 54)
        Me.txtUtara.Name = "txtUtara"
        Me.txtUtara.Size = New System.Drawing.Size(66, 21)
        Me.txtUtara.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(599, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 15)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Area"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.Location = New System.Drawing.Point(117, 28)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(0, 15)
        Me.lblID.TabIndex = 26
        '
        'btDelete
        '
        Me.btDelete.Location = New System.Drawing.Point(389, 147)
        Me.btDelete.Name = "btDelete"
        Me.btDelete.Size = New System.Drawing.Size(75, 35)
        Me.btDelete.TabIndex = 10
        Me.btDelete.Text = "Dele&te"
        Me.btDelete.UseVisualStyleBackColor = True
        '
        'btCancel
        '
        Me.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancel.Location = New System.Drawing.Point(494, 147)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(75, 35)
        Me.btCancel.TabIndex = 11
        Me.btCancel.Text = "&Cancel"
        Me.btCancel.UseVisualStyleBackColor = True
        '
        'btSave
        '
        Me.btSave.Location = New System.Drawing.Point(284, 147)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(75, 35)
        Me.btSave.TabIndex = 9
        Me.btSave.Text = "&Save"
        Me.btSave.UseVisualStyleBackColor = True
        '
        'btEdit
        '
        Me.btEdit.Location = New System.Drawing.Point(179, 147)
        Me.btEdit.Name = "btEdit"
        Me.btEdit.Size = New System.Drawing.Size(75, 35)
        Me.btEdit.TabIndex = 20
        Me.btEdit.Text = "&Edit"
        Me.btEdit.UseVisualStyleBackColor = True
        '
        'btAdd
        '
        Me.btAdd.Location = New System.Drawing.Point(74, 147)
        Me.btAdd.Name = "btAdd"
        Me.btAdd.Size = New System.Drawing.Size(75, 35)
        Me.btAdd.TabIndex = 0
        Me.btAdd.Text = "&Add"
        Me.btAdd.UseVisualStyleBackColor = True
        '
        'btExit
        '
        Me.btExit.Location = New System.Drawing.Point(599, 147)
        Me.btExit.Name = "btExit"
        Me.btExit.Size = New System.Drawing.Size(75, 35)
        Me.btExit.TabIndex = 12
        Me.btExit.Text = "E&xit"
        Me.btExit.UseVisualStyleBackColor = True
        '
        'txtDeskripsi
        '
        Me.txtDeskripsi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeskripsi.Location = New System.Drawing.Point(113, 83)
        Me.txtDeskripsi.Multiline = True
        Me.txtDeskripsi.Name = "txtDeskripsi"
        Me.txtDeskripsi.Size = New System.Drawing.Size(182, 50)
        Me.txtDeskripsi.TabIndex = 2
        '
        'txtPatahan
        '
        Me.txtPatahan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPatahan.Location = New System.Drawing.Point(113, 54)
        Me.txtPatahan.Name = "txtPatahan"
        Me.txtPatahan.Size = New System.Drawing.Size(182, 21)
        Me.txtPatahan.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(317, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 15)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Mekanisme"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 15)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Deskripsi"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 15)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Nama Patahan"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 15)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "ID"
        '
        'SavePatahan
        '
        Me.SavePatahan.Filter = "Text Files(*.txt, *.dat)|*.txt; *.dat"
        '
        'FormPatahan
        '
        Me.AcceptButton = Me.btSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btCancel
        Me.ClientSize = New System.Drawing.Size(759, 478)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelDaerah)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPatahan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelDaerah.ResumeLayout(False)
        Me.gbListDaerah.ResumeLayout(False)
        Me.gbMenuDaerah.ResumeLayout(False)
        Me.gbMenuDaerah.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RegDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LintangDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BujurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PanelDaerah As System.Windows.Forms.Panel
    Friend WithEvents gbListDaerah As System.Windows.Forms.GroupBox
    Friend WithEvents lvwPatahan As System.Windows.Forms.ListView
    Friend WithEvents gbMenuDaerah As System.Windows.Forms.GroupBox
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents btDelete As System.Windows.Forms.Button
    Friend WithEvents btCancel As System.Windows.Forms.Button
    Friend WithEvents btSave As System.Windows.Forms.Button
    Friend WithEvents btEdit As System.Windows.Forms.Button
    Friend WithEvents btAdd As System.Windows.Forms.Button
    Friend WithEvents btExit As System.Windows.Forms.Button
    Friend WithEvents txtDeskripsi As System.Windows.Forms.TextBox
    Friend WithEvents txtPatahan As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btExport As System.Windows.Forms.Button
    Friend WithEvents SavePatahan As System.Windows.Forms.SaveFileDialog
    Friend WithEvents txtSelatan As TextBox
    Friend WithEvents txtTimur As TextBox
    Friend WithEvents txtBarat As TextBox
    Friend WithEvents txtUtara As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSumberdata As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbMekanisme As ComboBox
End Class
