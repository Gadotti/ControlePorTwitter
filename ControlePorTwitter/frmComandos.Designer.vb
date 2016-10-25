<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComandos
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
        Me.dtgComandos = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblLinhaComando = New System.Windows.Forms.Label
        Me.btnSalvar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtComando = New System.Windows.Forms.TextBox
        Me.txtDescricao = New System.Windows.Forms.TextBox
        Me.txtLinhaComando = New System.Windows.Forms.TextBox
        Me.chkAtivo = New System.Windows.Forms.CheckBox
        Me.chkEnviaRetorno = New System.Windows.Forms.CheckBox
        Me.btnNovo = New System.Windows.Forms.Button
        Me.btnEditar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtId = New System.Windows.Forms.TextBox
        Me.btnExlcuir = New System.Windows.Forms.Button
        Me.optLinhaComando = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.optStatusServico = New System.Windows.Forms.RadioButton
        Me.lblNomeServico = New System.Windows.Forms.Label
        Me.txtNomeServico = New System.Windows.Forms.TextBox
        Me.lblParametros = New System.Windows.Forms.Label
        Me.txtParametros = New System.Windows.Forms.TextBox
        Me.lstRestricaoUsuarios = New System.Windows.Forms.ListBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnAdicionarUsuario = New System.Windows.Forms.Button
        Me.btnRetirarUsuario = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.optEncadeamentoComandos = New System.Windows.Forms.RadioButton
        Me.lstComandos = New System.Windows.Forms.ListBox
        Me.lblListaComandos = New System.Windows.Forms.Label
        Me.cboComandos = New System.Windows.Forms.ComboBox
        Me.btnAdicionarComando = New System.Windows.Forms.Button
        Me.btnRetirarComando = New System.Windows.Forms.Button
        Me.cboUsuarios = New System.Windows.Forms.ComboBox
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Comando = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descricao = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RestricaoUsuariosString = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AtivoString = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dtgComandos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgComandos
        '
        Me.dtgComandos.AllowUserToAddRows = False
        Me.dtgComandos.AllowUserToDeleteRows = False
        Me.dtgComandos.AllowUserToResizeRows = False
        Me.dtgComandos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgComandos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Comando, Me.Descricao, Me.RestricaoUsuariosString, Me.AtivoString})
        Me.dtgComandos.Location = New System.Drawing.Point(12, 12)
        Me.dtgComandos.MultiSelect = False
        Me.dtgComandos.Name = "dtgComandos"
        Me.dtgComandos.ReadOnly = True
        Me.dtgComandos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgComandos.Size = New System.Drawing.Size(701, 231)
        Me.dtgComandos.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(58, 359)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Comando:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(55, 385)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descrição:"
        '
        'lblLinhaComando
        '
        Me.lblLinhaComando.AutoSize = True
        Me.lblLinhaComando.Location = New System.Drawing.Point(15, 411)
        Me.lblLinhaComando.Name = "lblLinhaComando"
        Me.lblLinhaComando.Size = New System.Drawing.Size(98, 13)
        Me.lblLinhaComando.TabIndex = 6
        Me.lblLinhaComando.Text = "Linha de comando:"
        '
        'btnSalvar
        '
        Me.btnSalvar.Location = New System.Drawing.Point(278, 525)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(75, 23)
        Me.btnSalvar.TabIndex = 7
        Me.btnSalvar.Text = "Salvar"
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(359, 525)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtComando
        '
        Me.txtComando.Location = New System.Drawing.Point(119, 356)
        Me.txtComando.Name = "txtComando"
        Me.txtComando.Size = New System.Drawing.Size(204, 20)
        Me.txtComando.TabIndex = 9
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(119, 382)
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(204, 20)
        Me.txtDescricao.TabIndex = 10
        '
        'txtLinhaComando
        '
        Me.txtLinhaComando.Location = New System.Drawing.Point(119, 408)
        Me.txtLinhaComando.Name = "txtLinhaComando"
        Me.txtLinhaComando.Size = New System.Drawing.Size(204, 20)
        Me.txtLinhaComando.TabIndex = 13
        '
        'chkAtivo
        '
        Me.chkAtivo.AutoSize = True
        Me.chkAtivo.Location = New System.Drawing.Point(118, 488)
        Me.chkAtivo.Name = "chkAtivo"
        Me.chkAtivo.Size = New System.Drawing.Size(56, 17)
        Me.chkAtivo.TabIndex = 14
        Me.chkAtivo.Text = "Ativo?"
        Me.chkAtivo.UseVisualStyleBackColor = True
        '
        'chkEnviaRetorno
        '
        Me.chkEnviaRetorno.AutoSize = True
        Me.chkEnviaRetorno.Location = New System.Drawing.Point(180, 488)
        Me.chkEnviaRetorno.Name = "chkEnviaRetorno"
        Me.chkEnviaRetorno.Size = New System.Drawing.Size(100, 17)
        Me.chkEnviaRetorno.TabIndex = 15
        Me.chkEnviaRetorno.Text = "Envia Retorno?"
        Me.chkEnviaRetorno.UseVisualStyleBackColor = True
        '
        'btnNovo
        '
        Me.btnNovo.Location = New System.Drawing.Point(12, 249)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(75, 23)
        Me.btnNovo.TabIndex = 16
        Me.btnNovo.Text = "Novo"
        Me.btnNovo.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Location = New System.Drawing.Point(93, 249)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(75, 23)
        Me.btnEditar.TabIndex = 17
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(94, 335)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Id:"
        '
        'txtId
        '
        Me.txtId.Enabled = False
        Me.txtId.Location = New System.Drawing.Point(119, 332)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(100, 20)
        Me.txtId.TabIndex = 19
        '
        'btnExlcuir
        '
        Me.btnExlcuir.Location = New System.Drawing.Point(173, 249)
        Me.btnExlcuir.Name = "btnExlcuir"
        Me.btnExlcuir.Size = New System.Drawing.Size(75, 23)
        Me.btnExlcuir.TabIndex = 20
        Me.btnExlcuir.Text = "Excluir"
        Me.btnExlcuir.UseVisualStyleBackColor = True
        '
        'optLinhaComando
        '
        Me.optLinhaComando.AutoSize = True
        Me.optLinhaComando.Checked = True
        Me.optLinhaComando.Location = New System.Drawing.Point(120, 287)
        Me.optLinhaComando.Name = "optLinhaComando"
        Me.optLinhaComando.Size = New System.Drawing.Size(114, 17)
        Me.optLinhaComando.TabIndex = 21
        Me.optLinhaComando.TabStop = True
        Me.optLinhaComando.Text = "Linha de Comando"
        Me.optLinhaComando.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 289)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Tipo de Comando:"
        '
        'optStatusServico
        '
        Me.optStatusServico.AutoSize = True
        Me.optStatusServico.Location = New System.Drawing.Point(240, 287)
        Me.optStatusServico.Name = "optStatusServico"
        Me.optStatusServico.Size = New System.Drawing.Size(114, 17)
        Me.optStatusServico.TabIndex = 23
        Me.optStatusServico.Text = "Status de Serviços"
        Me.optStatusServico.UseVisualStyleBackColor = True
        '
        'lblNomeServico
        '
        Me.lblNomeServico.AutoSize = True
        Me.lblNomeServico.Location = New System.Drawing.Point(36, 465)
        Me.lblNomeServico.Name = "lblNomeServico"
        Me.lblNomeServico.Size = New System.Drawing.Size(77, 13)
        Me.lblNomeServico.TabIndex = 24
        Me.lblNomeServico.Text = "Nome Serviço:"
        '
        'txtNomeServico
        '
        Me.txtNomeServico.Location = New System.Drawing.Point(118, 462)
        Me.txtNomeServico.Name = "txtNomeServico"
        Me.txtNomeServico.Size = New System.Drawing.Size(205, 20)
        Me.txtNomeServico.TabIndex = 25
        '
        'lblParametros
        '
        Me.lblParametros.AutoSize = True
        Me.lblParametros.Location = New System.Drawing.Point(116, 437)
        Me.lblParametros.Name = "lblParametros"
        Me.lblParametros.Size = New System.Drawing.Size(63, 13)
        Me.lblParametros.TabIndex = 27
        Me.lblParametros.Text = "Parametros:"
        '
        'txtParametros
        '
        Me.txtParametros.Location = New System.Drawing.Point(180, 434)
        Me.txtParametros.Name = "txtParametros"
        Me.txtParametros.Size = New System.Drawing.Size(143, 20)
        Me.txtParametros.TabIndex = 28
        '
        'lstRestricaoUsuarios
        '
        Me.lstRestricaoUsuarios.FormattingEnabled = True
        Me.lstRestricaoUsuarios.Location = New System.Drawing.Point(359, 307)
        Me.lstRestricaoUsuarios.Name = "lstRestricaoUsuarios"
        Me.lstRestricaoUsuarios.Size = New System.Drawing.Size(162, 147)
        Me.lstRestricaoUsuarios.TabIndex = 29
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(356, 276)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Permitido aos usuários:"
        '
        'btnAdicionarUsuario
        '
        Me.btnAdicionarUsuario.Location = New System.Drawing.Point(359, 486)
        Me.btnAdicionarUsuario.Name = "btnAdicionarUsuario"
        Me.btnAdicionarUsuario.Size = New System.Drawing.Size(87, 23)
        Me.btnAdicionarUsuario.TabIndex = 33
        Me.btnAdicionarUsuario.Text = "Adicionar"
        Me.btnAdicionarUsuario.UseVisualStyleBackColor = True
        '
        'btnRetirarUsuario
        '
        Me.btnRetirarUsuario.Location = New System.Drawing.Point(452, 486)
        Me.btnRetirarUsuario.Name = "btnRetirarUsuario"
        Me.btnRetirarUsuario.Size = New System.Drawing.Size(69, 23)
        Me.btnRetirarUsuario.TabIndex = 34
        Me.btnRetirarUsuario.Text = "Retirar"
        Me.btnRetirarUsuario.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(356, 291)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(154, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "(Em branco para não restringir.)"
        '
        'optEncadeamentoComandos
        '
        Me.optEncadeamentoComandos.AutoSize = True
        Me.optEncadeamentoComandos.Location = New System.Drawing.Point(120, 309)
        Me.optEncadeamentoComandos.Name = "optEncadeamentoComandos"
        Me.optEncadeamentoComandos.Size = New System.Drawing.Size(165, 17)
        Me.optEncadeamentoComandos.TabIndex = 36
        Me.optEncadeamentoComandos.TabStop = True
        Me.optEncadeamentoComandos.Text = "Encadeamento de Comandos"
        Me.optEncadeamentoComandos.UseVisualStyleBackColor = True
        '
        'lstComandos
        '
        Me.lstComandos.FormattingEnabled = True
        Me.lstComandos.Location = New System.Drawing.Point(527, 307)
        Me.lstComandos.Name = "lstComandos"
        Me.lstComandos.Size = New System.Drawing.Size(186, 147)
        Me.lstComandos.TabIndex = 37
        '
        'lblListaComandos
        '
        Me.lblListaComandos.AutoSize = True
        Me.lblListaComandos.Location = New System.Drawing.Point(524, 291)
        Me.lblListaComandos.Name = "lblListaComandos"
        Me.lblListaComandos.Size = New System.Drawing.Size(100, 13)
        Me.lblListaComandos.TabIndex = 38
        Me.lblListaComandos.Text = "Lista de Comandos:"
        '
        'cboComandos
        '
        Me.cboComandos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboComandos.FormattingEnabled = True
        Me.cboComandos.Location = New System.Drawing.Point(527, 459)
        Me.cboComandos.Name = "cboComandos"
        Me.cboComandos.Size = New System.Drawing.Size(186, 21)
        Me.cboComandos.TabIndex = 39
        '
        'btnAdicionarComando
        '
        Me.btnAdicionarComando.Location = New System.Drawing.Point(527, 486)
        Me.btnAdicionarComando.Name = "btnAdicionarComando"
        Me.btnAdicionarComando.Size = New System.Drawing.Size(97, 23)
        Me.btnAdicionarComando.TabIndex = 40
        Me.btnAdicionarComando.Text = "Adicionar"
        Me.btnAdicionarComando.UseVisualStyleBackColor = True
        '
        'btnRetirarComando
        '
        Me.btnRetirarComando.Location = New System.Drawing.Point(630, 486)
        Me.btnRetirarComando.Name = "btnRetirarComando"
        Me.btnRetirarComando.Size = New System.Drawing.Size(83, 23)
        Me.btnRetirarComando.TabIndex = 41
        Me.btnRetirarComando.Text = "Retirar"
        Me.btnRetirarComando.UseVisualStyleBackColor = True
        '
        'cboUsuarios
        '
        Me.cboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUsuarios.FormattingEnabled = True
        Me.cboUsuarios.Location = New System.Drawing.Point(359, 459)
        Me.cboUsuarios.Name = "cboUsuarios"
        Me.cboUsuarios.Size = New System.Drawing.Size(162, 21)
        Me.cboUsuarios.TabIndex = 42
        '
        'Id
        '
        Me.Id.DataPropertyName = "Id"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Width = 50
        '
        'Comando
        '
        Me.Comando.DataPropertyName = "Comando"
        Me.Comando.HeaderText = "Comando"
        Me.Comando.Name = "Comando"
        Me.Comando.ReadOnly = True
        '
        'Descricao
        '
        Me.Descricao.DataPropertyName = "Descricao"
        Me.Descricao.HeaderText = "Descrição"
        Me.Descricao.Name = "Descricao"
        Me.Descricao.ReadOnly = True
        Me.Descricao.Width = 300
        '
        'RestricaoUsuariosString
        '
        Me.RestricaoUsuariosString.DataPropertyName = "RestricaoUsuariosPorNomeString"
        Me.RestricaoUsuariosString.HeaderText = "Restrito ao Usuários"
        Me.RestricaoUsuariosString.Name = "RestricaoUsuariosString"
        Me.RestricaoUsuariosString.ReadOnly = True
        '
        'AtivoString
        '
        Me.AtivoString.DataPropertyName = "AtivoString"
        Me.AtivoString.HeaderText = "Ativo"
        Me.AtivoString.Name = "AtivoString"
        Me.AtivoString.ReadOnly = True
        '
        'frmComandos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 557)
        Me.Controls.Add(Me.cboUsuarios)
        Me.Controls.Add(Me.btnRetirarComando)
        Me.Controls.Add(Me.btnAdicionarComando)
        Me.Controls.Add(Me.cboComandos)
        Me.Controls.Add(Me.lblListaComandos)
        Me.Controls.Add(Me.lstComandos)
        Me.Controls.Add(Me.optEncadeamentoComandos)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnRetirarUsuario)
        Me.Controls.Add(Me.btnAdicionarUsuario)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lstRestricaoUsuarios)
        Me.Controls.Add(Me.txtParametros)
        Me.Controls.Add(Me.lblParametros)
        Me.Controls.Add(Me.txtNomeServico)
        Me.Controls.Add(Me.lblNomeServico)
        Me.Controls.Add(Me.optStatusServico)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.optLinhaComando)
        Me.Controls.Add(Me.btnExlcuir)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnNovo)
        Me.Controls.Add(Me.chkEnviaRetorno)
        Me.Controls.Add(Me.chkAtivo)
        Me.Controls.Add(Me.txtLinhaComando)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.txtComando)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.lblLinhaComando)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtgComandos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "frmComandos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comandos"
        CType(Me.dtgComandos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgComandos As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblLinhaComando As System.Windows.Forms.Label
    Friend WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtComando As System.Windows.Forms.TextBox
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents txtLinhaComando As System.Windows.Forms.TextBox
    Friend WithEvents chkAtivo As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnviaRetorno As System.Windows.Forms.CheckBox
    Friend WithEvents btnNovo As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents btnExlcuir As System.Windows.Forms.Button
    Friend WithEvents optLinhaComando As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents optStatusServico As System.Windows.Forms.RadioButton
    Friend WithEvents lblNomeServico As System.Windows.Forms.Label
    Friend WithEvents txtNomeServico As System.Windows.Forms.TextBox
    Friend WithEvents lblParametros As System.Windows.Forms.Label
    Friend WithEvents txtParametros As System.Windows.Forms.TextBox
    Friend WithEvents lstRestricaoUsuarios As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnAdicionarUsuario As System.Windows.Forms.Button
    Friend WithEvents btnRetirarUsuario As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents optEncadeamentoComandos As System.Windows.Forms.RadioButton
    Friend WithEvents lstComandos As System.Windows.Forms.ListBox
    Friend WithEvents lblListaComandos As System.Windows.Forms.Label
    Friend WithEvents cboComandos As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdicionarComando As System.Windows.Forms.Button
    Friend WithEvents btnRetirarComando As System.Windows.Forms.Button
    Friend WithEvents cboUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comando As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RestricaoUsuariosString As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AtivoString As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
