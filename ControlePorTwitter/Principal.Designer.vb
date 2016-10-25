<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ArquivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConfiguraçõesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AgendamentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ComandosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ParâmetrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UsuáriosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MensagensToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VisualizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NotifyIconTwitter = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SairToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.Status = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnForcarMensagens = New System.Windows.Forms.Button
        Me.btnParar = New System.Windows.Forms.Button
        Me.btnIniciar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Status.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArquivoToolStripMenuItem, Me.ConfiguraçõesToolStripMenuItem, Me.MensagensToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(330, 24)
        Me.MenuStrip1.TabIndex = 12
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArquivoToolStripMenuItem
        '
        Me.ArquivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SairToolStripMenuItem})
        Me.ArquivoToolStripMenuItem.Name = "ArquivoToolStripMenuItem"
        Me.ArquivoToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.ArquivoToolStripMenuItem.Text = "Arquivo"
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        Me.SairToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.SairToolStripMenuItem.Text = "Sair"
        '
        'ConfiguraçõesToolStripMenuItem
        '
        Me.ConfiguraçõesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgendamentosToolStripMenuItem, Me.ComandosToolStripMenuItem, Me.ParâmetrosToolStripMenuItem, Me.UsuáriosToolStripMenuItem})
        Me.ConfiguraçõesToolStripMenuItem.Name = "ConfiguraçõesToolStripMenuItem"
        Me.ConfiguraçõesToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.ConfiguraçõesToolStripMenuItem.Text = "Configurações"
        '
        'AgendamentosToolStripMenuItem
        '
        Me.AgendamentosToolStripMenuItem.Name = "AgendamentosToolStripMenuItem"
        Me.AgendamentosToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.AgendamentosToolStripMenuItem.Text = "Agendamentos"
        '
        'ComandosToolStripMenuItem
        '
        Me.ComandosToolStripMenuItem.Name = "ComandosToolStripMenuItem"
        Me.ComandosToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ComandosToolStripMenuItem.Text = "Comandos"
        '
        'ParâmetrosToolStripMenuItem
        '
        Me.ParâmetrosToolStripMenuItem.Name = "ParâmetrosToolStripMenuItem"
        Me.ParâmetrosToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ParâmetrosToolStripMenuItem.Text = "Parâmetros"
        '
        'UsuáriosToolStripMenuItem
        '
        Me.UsuáriosToolStripMenuItem.Name = "UsuáriosToolStripMenuItem"
        Me.UsuáriosToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.UsuáriosToolStripMenuItem.Text = "Usuários"
        '
        'MensagensToolStripMenuItem
        '
        Me.MensagensToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VisualizarToolStripMenuItem})
        Me.MensagensToolStripMenuItem.Name = "MensagensToolStripMenuItem"
        Me.MensagensToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.MensagensToolStripMenuItem.Text = "Mensagens"
        '
        'VisualizarToolStripMenuItem
        '
        Me.VisualizarToolStripMenuItem.Name = "VisualizarToolStripMenuItem"
        Me.VisualizarToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.VisualizarToolStripMenuItem.Text = "Visualizar"
        '
        'NotifyIconTwitter
        '
        Me.NotifyIconTwitter.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIconTwitter.Icon = CType(resources.GetObject("NotifyIconTwitter.Icon"), System.Drawing.Icon)
        Me.NotifyIconTwitter.Text = "TwitterMonitorNotifyIcon"
        Me.NotifyIconTwitter.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SairToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(104, 26)
        '
        'SairToolStripMenuItem1
        '
        Me.SairToolStripMenuItem1.Name = "SairToolStripMenuItem1"
        Me.SairToolStripMenuItem1.Size = New System.Drawing.Size(103, 22)
        Me.SairToolStripMenuItem1.Text = "Sair"
        '
        'Status
        '
        Me.Status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblStatus})
        Me.Status.Location = New System.Drawing.Point(0, 209)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(330, 22)
        Me.Status.SizingGrip = False
        Me.Status.TabIndex = 13
        Me.Status.Text = "Status"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(42, 17)
        Me.ToolStripStatusLabel1.Text = "Status:"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(84, 17)
        Me.lblStatus.Text = "Ativo ou Inativo"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnForcarMensagens)
        Me.GroupBox1.Controls.Add(Me.btnParar)
        Me.GroupBox1.Controls.Add(Me.btnIniciar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(125, 179)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Administração"
        '
        'btnForcarMensagens
        '
        Me.btnForcarMensagens.Location = New System.Drawing.Point(6, 77)
        Me.btnForcarMensagens.Name = "btnForcarMensagens"
        Me.btnForcarMensagens.Size = New System.Drawing.Size(113, 36)
        Me.btnForcarMensagens.TabIndex = 2
        Me.btnForcarMensagens.Text = "Forçar Verificação de Mensagens"
        Me.btnForcarMensagens.UseVisualStyleBackColor = True
        '
        'btnParar
        '
        Me.btnParar.Location = New System.Drawing.Point(6, 48)
        Me.btnParar.Name = "btnParar"
        Me.btnParar.Size = New System.Drawing.Size(113, 23)
        Me.btnParar.TabIndex = 1
        Me.btnParar.Text = "Parar Monitor"
        Me.btnParar.UseVisualStyleBackColor = True
        '
        'btnIniciar
        '
        Me.btnIniciar.Location = New System.Drawing.Point(6, 19)
        Me.btnIniciar.Name = "btnIniciar"
        Me.btnIniciar.Size = New System.Drawing.Size(113, 23)
        Me.btnIniciar.TabIndex = 0
        Me.btnIniciar.Text = "Iniciar Monitor"
        Me.btnIniciar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(161, 167)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Atenção: Esta é uma versão Beta."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(167, 180)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Erros podem ser reportados para:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(184, 193)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "controleportwitter@gmail.com"
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(330, 231)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Principal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Status.ResumeLayout(False)
        Me.Status.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArquivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfiguraçõesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SairToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParâmetrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComandosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MensagensToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VisualizarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyIconTwitter As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SairToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Status As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnParar As System.Windows.Forms.Button
    Friend WithEvents btnIniciar As System.Windows.Forms.Button
    Friend WithEvents btnForcarMensagens As System.Windows.Forms.Button
    Friend WithEvents AgendamentosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuáriosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
