<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSettings
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
        Me.PanelSettings = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btExit = New System.Windows.Forms.Button()
        Me.btConnect = New System.Windows.Forms.Button()
        Me.btSave = New System.Windows.Forms.Button()
        Me.btEdit = New System.Windows.Forms.Button()
        Me.gbHost = New System.Windows.Forms.GroupBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.lblPass = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lblHost = New System.Windows.Forms.Label()
        Me.txtDB = New System.Windows.Forms.TextBox()
        Me.lblDB = New System.Windows.Forms.Label()
        Me.PanelSettings.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbHost.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelSettings
        '
        Me.PanelSettings.Controls.Add(Me.GroupBox2)
        Me.PanelSettings.Controls.Add(Me.gbHost)
        Me.PanelSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelSettings.Location = New System.Drawing.Point(0, 0)
        Me.PanelSettings.Name = "PanelSettings"
        Me.PanelSettings.Size = New System.Drawing.Size(469, 286)
        Me.PanelSettings.TabIndex = 9
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btExit)
        Me.GroupBox2.Controls.Add(Me.btConnect)
        Me.GroupBox2.Controls.Add(Me.btSave)
        Me.GroupBox2.Controls.Add(Me.btEdit)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 201)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(469, 85)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'btExit
        '
        Me.btExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btExit.Location = New System.Drawing.Point(368, 34)
        Me.btExit.Name = "btExit"
        Me.btExit.Size = New System.Drawing.Size(75, 23)
        Me.btExit.TabIndex = 4
        Me.btExit.Text = "E&xit"
        Me.btExit.UseVisualStyleBackColor = True
        '
        'btConnect
        '
        Me.btConnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btConnect.Location = New System.Drawing.Point(259, 34)
        Me.btConnect.Name = "btConnect"
        Me.btConnect.Size = New System.Drawing.Size(75, 23)
        Me.btConnect.TabIndex = 3
        Me.btConnect.Text = "Test &Conn"
        Me.btConnect.UseVisualStyleBackColor = True
        '
        'btSave
        '
        Me.btSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSave.Location = New System.Drawing.Point(150, 34)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(75, 23)
        Me.btSave.TabIndex = 2
        Me.btSave.Text = "&Save"
        Me.btSave.UseVisualStyleBackColor = True
        '
        'btEdit
        '
        Me.btEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btEdit.Location = New System.Drawing.Point(41, 34)
        Me.btEdit.Name = "btEdit"
        Me.btEdit.Size = New System.Drawing.Size(75, 23)
        Me.btEdit.TabIndex = 1
        Me.btEdit.Text = "&Edit"
        Me.btEdit.UseVisualStyleBackColor = True
        '
        'gbHost
        '
        Me.gbHost.Controls.Add(Me.txtDB)
        Me.gbHost.Controls.Add(Me.lblDB)
        Me.gbHost.Controls.Add(Me.lblStatus)
        Me.gbHost.Controls.Add(Me.txtPass)
        Me.gbHost.Controls.Add(Me.txtUser)
        Me.gbHost.Controls.Add(Me.txtHost)
        Me.gbHost.Controls.Add(Me.lblPass)
        Me.gbHost.Controls.Add(Me.lblUser)
        Me.gbHost.Controls.Add(Me.lblHost)
        Me.gbHost.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbHost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbHost.Location = New System.Drawing.Point(0, 0)
        Me.gbHost.Name = "gbHost"
        Me.gbHost.Size = New System.Drawing.Size(469, 201)
        Me.gbHost.TabIndex = 0
        Me.gbHost.TabStop = False
        Me.gbHost.Text = "| Koneksi ke Seiscomp3|"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.Color.Red
        Me.lblStatus.Location = New System.Drawing.Point(168, 24)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 15)
        Me.lblStatus.TabIndex = 21
        '
        'txtPass
        '
        Me.txtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass.Location = New System.Drawing.Point(202, 132)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(174, 21)
        Me.txtPass.TabIndex = 3
        '
        'txtUser
        '
        Me.txtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUser.Location = New System.Drawing.Point(202, 97)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(174, 21)
        Me.txtUser.TabIndex = 2
        '
        'txtHost
        '
        Me.txtHost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHost.Location = New System.Drawing.Point(202, 62)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(174, 21)
        Me.txtHost.TabIndex = 1
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPass.Location = New System.Drawing.Point(89, 135)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(61, 15)
        Me.lblPass.TabIndex = 17
        Me.lblPass.Text = "Password"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.Location = New System.Drawing.Point(89, 100)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(65, 15)
        Me.lblUser.TabIndex = 16
        Me.lblUser.Text = "Username"
        '
        'lblHost
        '
        Me.lblHost.AutoSize = True
        Me.lblHost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHost.Location = New System.Drawing.Point(89, 65)
        Me.lblHost.Name = "lblHost"
        Me.lblHost.Size = New System.Drawing.Size(108, 15)
        Me.lblHost.TabIndex = 15
        Me.lblHost.Text = "SeiscomP3 Server"
        '
        'txtDB
        '
        Me.txtDB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDB.Location = New System.Drawing.Point(202, 167)
        Me.txtDB.Name = "txtDB"
        Me.txtDB.Size = New System.Drawing.Size(174, 21)
        Me.txtDB.TabIndex = 4
        '
        'lblDB
        '
        Me.lblDB.AutoSize = True
        Me.lblDB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDB.Location = New System.Drawing.Point(89, 170)
        Me.lblDB.Name = "lblDB"
        Me.lblDB.Size = New System.Drawing.Size(61, 15)
        Me.lblDB.TabIndex = 22
        Me.lblDB.Text = "DB Name"
        '
        'FormSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 286)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelSettings)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelSettings.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.gbHost.ResumeLayout(False)
        Me.gbHost.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelSettings As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btConnect As System.Windows.Forms.Button
    Friend WithEvents btSave As System.Windows.Forms.Button
    Friend WithEvents btEdit As System.Windows.Forms.Button
    Friend WithEvents gbHost As System.Windows.Forms.GroupBox
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents txtHost As System.Windows.Forms.TextBox
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblHost As System.Windows.Forms.Label
    Friend WithEvents btExit As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtDB As TextBox
    Friend WithEvents lblDB As Label
End Class
