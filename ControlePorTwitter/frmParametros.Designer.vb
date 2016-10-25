<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParametros
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSenha = New System.Windows.Forms.TextBox
        Me.chkAlteraSenha = New System.Windows.Forms.CheckBox
        Me.lblDataUltimaMensagemLida = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtIntervalo = New System.Windows.Forms.NumericUpDown
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.rbtPublicas = New System.Windows.Forms.RadioButton
        Me.rbtPrivadas = New System.Windows.Forms.RadioButton
        Me.btnSalvar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtUsuario = New System.Windows.Forms.TextBox
        CType(Me.txtIntervalo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Data/Hora última mensagem lida:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(130, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Usuário:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(135, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Senha:"
        '
        'txtSenha
        '
        Me.txtSenha.Enabled = False
        Me.txtSenha.Location = New System.Drawing.Point(182, 52)
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSenha.Size = New System.Drawing.Size(100, 20)
        Me.txtSenha.TabIndex = 3
        '
        'chkAlteraSenha
        '
        Me.chkAlteraSenha.AutoSize = True
        Me.chkAlteraSenha.Location = New System.Drawing.Point(288, 54)
        Me.chkAlteraSenha.Name = "chkAlteraSenha"
        Me.chkAlteraSenha.Size = New System.Drawing.Size(96, 17)
        Me.chkAlteraSenha.TabIndex = 4
        Me.chkAlteraSenha.Text = "Alterar Senha?"
        Me.chkAlteraSenha.UseVisualStyleBackColor = True
        '
        'lblDataUltimaMensagemLida
        '
        Me.lblDataUltimaMensagemLida.AutoSize = True
        Me.lblDataUltimaMensagemLida.Location = New System.Drawing.Point(179, 30)
        Me.lblDataUltimaMensagemLida.Name = "lblDataUltimaMensagemLida"
        Me.lblDataUltimaMensagemLida.Size = New System.Drawing.Size(137, 13)
        Me.lblDataUltimaMensagemLida.TabIndex = 6
        Me.lblDataUltimaMensagemLida.Text = "[DataUltimaMensagemLida]"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(58, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Ler mensagens a cada:"
        '
        'txtIntervalo
        '
        Me.txtIntervalo.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.txtIntervalo.Location = New System.Drawing.Point(182, 78)
        Me.txtIntervalo.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.txtIntervalo.Name = "txtIntervalo"
        Me.txtIntervalo.Size = New System.Drawing.Size(46, 20)
        Me.txtIntervalo.TabIndex = 8
        Me.txtIntervalo.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(229, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "segundos"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(149, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Ler comandos de mensagens:"
        '
        'rbtPublicas
        '
        Me.rbtPublicas.AutoSize = True
        Me.rbtPublicas.Location = New System.Drawing.Point(182, 108)
        Me.rbtPublicas.Name = "rbtPublicas"
        Me.rbtPublicas.Size = New System.Drawing.Size(118, 17)
        Me.rbtPublicas.TabIndex = 11
        Me.rbtPublicas.TabStop = True
        Me.rbtPublicas.Text = "Públicas (Enviadas)"
        Me.rbtPublicas.UseVisualStyleBackColor = True
        '
        'rbtPrivadas
        '
        Me.rbtPrivadas.AutoSize = True
        Me.rbtPrivadas.Location = New System.Drawing.Point(182, 131)
        Me.rbtPrivadas.Name = "rbtPrivadas"
        Me.rbtPrivadas.Size = New System.Drawing.Size(157, 17)
        Me.rbtPrivadas.TabIndex = 12
        Me.rbtPrivadas.TabStop = True
        Me.rbtPrivadas.Text = "Diretas (Privadas recebidas)"
        Me.rbtPrivadas.UseVisualStyleBackColor = True
        '
        'btnSalvar
        '
        Me.btnSalvar.Location = New System.Drawing.Point(153, 160)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(75, 23)
        Me.btnSalvar.TabIndex = 13
        Me.btnSalvar.Text = "Salvar"
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(234, 160)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 14
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(182, 6)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(134, 20)
        Me.txtUsuario.TabIndex = 15
        '
        'frmParametros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 195)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.rbtPrivadas)
        Me.Controls.Add(Me.rbtPublicas)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtIntervalo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblDataUltimaMensagemLida)
        Me.Controls.Add(Me.chkAlteraSenha)
        Me.Controls.Add(Me.txtSenha)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmParametros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parametros"
        CType(Me.txtIntervalo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSenha As System.Windows.Forms.TextBox
    Friend WithEvents chkAlteraSenha As System.Windows.Forms.CheckBox
    Friend WithEvents lblDataUltimaMensagemLida As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtIntervalo As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rbtPublicas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtPrivadas As System.Windows.Forms.RadioButton
    Friend WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
End Class
