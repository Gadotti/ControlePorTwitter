<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgendamentos
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
        Me.dtgAgendamentos = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComandoDescricao = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataExecucao = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TipoAgendamento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnNovo = New System.Windows.Forms.Button
        Me.btnEditar = New System.Windows.Forms.Button
        Me.btnExcluir = New System.Windows.Forms.Button
        Me.lblId = New System.Windows.Forms.Label
        Me.lblComando = New System.Windows.Forms.Label
        Me.lblTipoAgendamento = New System.Windows.Forms.Label
        Me.lblDataExecucao = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtId = New System.Windows.Forms.TextBox
        Me.optExecucaoUnica = New System.Windows.Forms.RadioButton
        Me.optDiaria = New System.Windows.Forms.RadioButton
        Me.cboComando = New System.Windows.Forms.ComboBox
        Me.txtDataExecucao = New System.Windows.Forms.DateTimePicker
        Me.txtEnviadoPor = New System.Windows.Forms.TextBox
        Me.txtDataMensagem = New System.Windows.Forms.TextBox
        Me.btnSalvar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.chkDomingo = New System.Windows.Forms.CheckBox
        Me.chkSegunda = New System.Windows.Forms.CheckBox
        Me.chkTerca = New System.Windows.Forms.CheckBox
        Me.chkQuarta = New System.Windows.Forms.CheckBox
        Me.chkQuinta = New System.Windows.Forms.CheckBox
        Me.chkSexta = New System.Windows.Forms.CheckBox
        Me.chkSabado = New System.Windows.Forms.CheckBox
        Me.txtHoraDiaria = New System.Windows.Forms.DateTimePicker
        Me.optHoraFixa = New System.Windows.Forms.RadioButton
        Me.optHoraIntervalo = New System.Windows.Forms.RadioButton
        Me.grbHora = New System.Windows.Forms.GroupBox
        CType(Me.dtgAgendamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbHora.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtgAgendamentos
        '
        Me.dtgAgendamentos.AllowUserToAddRows = False
        Me.dtgAgendamentos.AllowUserToDeleteRows = False
        Me.dtgAgendamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAgendamentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.ComandoDescricao, Me.DataExecucao, Me.TipoAgendamento})
        Me.dtgAgendamentos.Location = New System.Drawing.Point(12, 12)
        Me.dtgAgendamentos.MultiSelect = False
        Me.dtgAgendamentos.Name = "dtgAgendamentos"
        Me.dtgAgendamentos.ReadOnly = True
        Me.dtgAgendamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAgendamentos.Size = New System.Drawing.Size(443, 150)
        Me.dtgAgendamentos.TabIndex = 0
        '
        'Id
        '
        Me.Id.DataPropertyName = "Id"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        '
        'ComandoDescricao
        '
        Me.ComandoDescricao.DataPropertyName = "ComandoDescricao"
        Me.ComandoDescricao.HeaderText = "Comando"
        Me.ComandoDescricao.Name = "ComandoDescricao"
        Me.ComandoDescricao.ReadOnly = True
        '
        'DataExecucao
        '
        Me.DataExecucao.DataPropertyName = "DataExecucaoString"
        Me.DataExecucao.HeaderText = "Data Execução"
        Me.DataExecucao.Name = "DataExecucao"
        Me.DataExecucao.ReadOnly = True
        '
        'TipoAgendamento
        '
        Me.TipoAgendamento.DataPropertyName = "TipoAgendamentoDescricao"
        Me.TipoAgendamento.HeaderText = "Tipo Agendamento"
        Me.TipoAgendamento.Name = "TipoAgendamento"
        Me.TipoAgendamento.ReadOnly = True
        '
        'btnNovo
        '
        Me.btnNovo.Location = New System.Drawing.Point(12, 168)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(75, 23)
        Me.btnNovo.TabIndex = 1
        Me.btnNovo.Text = "Novo"
        Me.btnNovo.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Location = New System.Drawing.Point(93, 168)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(75, 23)
        Me.btnEditar.TabIndex = 2
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnExcluir
        '
        Me.btnExcluir.Location = New System.Drawing.Point(174, 168)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(75, 23)
        Me.btnExcluir.TabIndex = 3
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.UseVisualStyleBackColor = True
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(45, 234)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(19, 13)
        Me.lblId.TabIndex = 4
        Me.lblId.Text = "Id:"
        '
        'lblComando
        '
        Me.lblComando.AutoSize = True
        Me.lblComando.Location = New System.Drawing.Point(9, 258)
        Me.lblComando.Name = "lblComando"
        Me.lblComando.Size = New System.Drawing.Size(55, 13)
        Me.lblComando.TabIndex = 5
        Me.lblComando.Text = "Comando:"
        '
        'lblTipoAgendamento
        '
        Me.lblTipoAgendamento.AutoSize = True
        Me.lblTipoAgendamento.Location = New System.Drawing.Point(13, 204)
        Me.lblTipoAgendamento.Name = "lblTipoAgendamento"
        Me.lblTipoAgendamento.Size = New System.Drawing.Size(100, 13)
        Me.lblTipoAgendamento.TabIndex = 6
        Me.lblTipoAgendamento.Text = "Tipo Agendamento:"
        '
        'lblDataExecucao
        '
        Me.lblDataExecucao.AutoSize = True
        Me.lblDataExecucao.Location = New System.Drawing.Point(9, 291)
        Me.lblDataExecucao.Name = "lblDataExecucao"
        Me.lblDataExecucao.Size = New System.Drawing.Size(107, 13)
        Me.lblDataExecucao.TabIndex = 7
        Me.lblDataExecucao.Text = "Data para execução:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(230, 234)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Enviado por:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(195, 258)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Data da mensagem:"
        '
        'txtId
        '
        Me.txtId.Enabled = False
        Me.txtId.Location = New System.Drawing.Point(68, 231)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(121, 20)
        Me.txtId.TabIndex = 10
        '
        'optExecucaoUnica
        '
        Me.optExecucaoUnica.AutoSize = True
        Me.optExecucaoUnica.Checked = True
        Me.optExecucaoUnica.Location = New System.Drawing.Point(116, 202)
        Me.optExecucaoUnica.Name = "optExecucaoUnica"
        Me.optExecucaoUnica.Size = New System.Drawing.Size(104, 17)
        Me.optExecucaoUnica.TabIndex = 11
        Me.optExecucaoUnica.TabStop = True
        Me.optExecucaoUnica.Text = "Execução Única"
        Me.optExecucaoUnica.UseVisualStyleBackColor = True
        '
        'optDiaria
        '
        Me.optDiaria.AutoSize = True
        Me.optDiaria.Location = New System.Drawing.Point(226, 202)
        Me.optDiaria.Name = "optDiaria"
        Me.optDiaria.Size = New System.Drawing.Size(52, 17)
        Me.optDiaria.TabIndex = 12
        Me.optDiaria.TabStop = True
        Me.optDiaria.Text = "Diária"
        Me.optDiaria.UseVisualStyleBackColor = True
        '
        'cboComando
        '
        Me.cboComando.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboComando.FormattingEnabled = True
        Me.cboComando.Location = New System.Drawing.Point(68, 255)
        Me.cboComando.Name = "cboComando"
        Me.cboComando.Size = New System.Drawing.Size(121, 21)
        Me.cboComando.TabIndex = 13
        '
        'txtDataExecucao
        '
        Me.txtDataExecucao.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.txtDataExecucao.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtDataExecucao.Location = New System.Drawing.Point(119, 287)
        Me.txtDataExecucao.Name = "txtDataExecucao"
        Me.txtDataExecucao.Size = New System.Drawing.Size(130, 20)
        Me.txtDataExecucao.TabIndex = 14
        Me.txtDataExecucao.Value = New Date(2010, 4, 11, 0, 0, 0, 0)
        '
        'txtEnviadoPor
        '
        Me.txtEnviadoPor.Enabled = False
        Me.txtEnviadoPor.Location = New System.Drawing.Point(296, 229)
        Me.txtEnviadoPor.Name = "txtEnviadoPor"
        Me.txtEnviadoPor.Size = New System.Drawing.Size(157, 20)
        Me.txtEnviadoPor.TabIndex = 15
        '
        'txtDataMensagem
        '
        Me.txtDataMensagem.Enabled = False
        Me.txtDataMensagem.Location = New System.Drawing.Point(296, 255)
        Me.txtDataMensagem.Name = "txtDataMensagem"
        Me.txtDataMensagem.Size = New System.Drawing.Size(157, 20)
        Me.txtDataMensagem.TabIndex = 16
        '
        'btnSalvar
        '
        Me.btnSalvar.Location = New System.Drawing.Point(162, 375)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(75, 23)
        Me.btnSalvar.TabIndex = 17
        Me.btnSalvar.Text = "Salvar"
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(243, 375)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'chkDomingo
        '
        Me.chkDomingo.AutoSize = True
        Me.chkDomingo.Location = New System.Drawing.Point(187, 323)
        Me.chkDomingo.Name = "chkDomingo"
        Me.chkDomingo.Size = New System.Drawing.Size(68, 17)
        Me.chkDomingo.TabIndex = 19
        Me.chkDomingo.Text = "Domingo"
        Me.chkDomingo.UseVisualStyleBackColor = True
        '
        'chkSegunda
        '
        Me.chkSegunda.AutoSize = True
        Me.chkSegunda.Location = New System.Drawing.Point(187, 346)
        Me.chkSegunda.Name = "chkSegunda"
        Me.chkSegunda.Size = New System.Drawing.Size(69, 17)
        Me.chkSegunda.TabIndex = 20
        Me.chkSegunda.Text = "Segunda"
        Me.chkSegunda.UseVisualStyleBackColor = True
        '
        'chkTerca
        '
        Me.chkTerca.AutoSize = True
        Me.chkTerca.Location = New System.Drawing.Point(262, 323)
        Me.chkTerca.Name = "chkTerca"
        Me.chkTerca.Size = New System.Drawing.Size(54, 17)
        Me.chkTerca.TabIndex = 21
        Me.chkTerca.Text = "Terça"
        Me.chkTerca.UseVisualStyleBackColor = True
        '
        'chkQuarta
        '
        Me.chkQuarta.AutoSize = True
        Me.chkQuarta.Location = New System.Drawing.Point(262, 346)
        Me.chkQuarta.Name = "chkQuarta"
        Me.chkQuarta.Size = New System.Drawing.Size(58, 17)
        Me.chkQuarta.TabIndex = 22
        Me.chkQuarta.Text = "Quarta"
        Me.chkQuarta.UseVisualStyleBackColor = True
        '
        'chkQuinta
        '
        Me.chkQuinta.AutoSize = True
        Me.chkQuinta.Location = New System.Drawing.Point(322, 323)
        Me.chkQuinta.Name = "chkQuinta"
        Me.chkQuinta.Size = New System.Drawing.Size(57, 17)
        Me.chkQuinta.TabIndex = 23
        Me.chkQuinta.Text = "Quinta"
        Me.chkQuinta.UseVisualStyleBackColor = True
        '
        'chkSexta
        '
        Me.chkSexta.AutoSize = True
        Me.chkSexta.Location = New System.Drawing.Point(322, 346)
        Me.chkSexta.Name = "chkSexta"
        Me.chkSexta.Size = New System.Drawing.Size(53, 17)
        Me.chkSexta.TabIndex = 24
        Me.chkSexta.Text = "Sexta"
        Me.chkSexta.UseVisualStyleBackColor = True
        '
        'chkSabado
        '
        Me.chkSabado.AutoSize = True
        Me.chkSabado.Location = New System.Drawing.Point(385, 323)
        Me.chkSabado.Name = "chkSabado"
        Me.chkSabado.Size = New System.Drawing.Size(63, 17)
        Me.chkSabado.TabIndex = 25
        Me.chkSabado.Text = "Sábado"
        Me.chkSabado.UseVisualStyleBackColor = True
        '
        'txtHoraDiaria
        '
        Me.txtHoraDiaria.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.txtHoraDiaria.Location = New System.Drawing.Point(26, 36)
        Me.txtHoraDiaria.Name = "txtHoraDiaria"
        Me.txtHoraDiaria.Size = New System.Drawing.Size(78, 20)
        Me.txtHoraDiaria.TabIndex = 26
        Me.txtHoraDiaria.Value = New Date(2010, 4, 12, 0, 0, 0, 0)
        '
        'optHoraFixa
        '
        Me.optHoraFixa.AutoSize = True
        Me.optHoraFixa.Location = New System.Drawing.Point(8, 13)
        Me.optHoraFixa.Name = "optHoraFixa"
        Me.optHoraFixa.Size = New System.Drawing.Size(44, 17)
        Me.optHoraFixa.TabIndex = 28
        Me.optHoraFixa.TabStop = True
        Me.optHoraFixa.Text = "Fixo"
        Me.optHoraFixa.UseVisualStyleBackColor = True
        '
        'optHoraIntervalo
        '
        Me.optHoraIntervalo.AutoSize = True
        Me.optHoraIntervalo.Location = New System.Drawing.Point(63, 13)
        Me.optHoraIntervalo.Name = "optHoraIntervalo"
        Me.optHoraIntervalo.Size = New System.Drawing.Size(66, 17)
        Me.optHoraIntervalo.TabIndex = 29
        Me.optHoraIntervalo.TabStop = True
        Me.optHoraIntervalo.Text = "Intervalo"
        Me.optHoraIntervalo.UseVisualStyleBackColor = True
        '
        'grbHora
        '
        Me.grbHora.Controls.Add(Me.optHoraFixa)
        Me.grbHora.Controls.Add(Me.txtHoraDiaria)
        Me.grbHora.Controls.Add(Me.optHoraIntervalo)
        Me.grbHora.Location = New System.Drawing.Point(12, 323)
        Me.grbHora.Name = "grbHora"
        Me.grbHora.Size = New System.Drawing.Size(135, 66)
        Me.grbHora.TabIndex = 30
        Me.grbHora.TabStop = False
        Me.grbHora.Text = "Tipo de Hora"
        '
        'frmAgendamentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 410)
        Me.Controls.Add(Me.grbHora)
        Me.Controls.Add(Me.chkSabado)
        Me.Controls.Add(Me.chkSexta)
        Me.Controls.Add(Me.chkQuinta)
        Me.Controls.Add(Me.chkQuarta)
        Me.Controls.Add(Me.chkTerca)
        Me.Controls.Add(Me.chkSegunda)
        Me.Controls.Add(Me.chkDomingo)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.txtDataMensagem)
        Me.Controls.Add(Me.txtEnviadoPor)
        Me.Controls.Add(Me.txtDataExecucao)
        Me.Controls.Add(Me.cboComando)
        Me.Controls.Add(Me.optDiaria)
        Me.Controls.Add(Me.optExecucaoUnica)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblDataExecucao)
        Me.Controls.Add(Me.lblTipoAgendamento)
        Me.Controls.Add(Me.lblComando)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnNovo)
        Me.Controls.Add(Me.dtgAgendamentos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAgendamentos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agendamentos"
        CType(Me.dtgAgendamentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbHora.ResumeLayout(False)
        Me.grbHora.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgAgendamentos As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComandoDescricao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataExecucao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoAgendamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnNovo As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnExcluir As System.Windows.Forms.Button
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents lblComando As System.Windows.Forms.Label
    Friend WithEvents lblTipoAgendamento As System.Windows.Forms.Label
    Friend WithEvents lblDataExecucao As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents optExecucaoUnica As System.Windows.Forms.RadioButton
    Friend WithEvents optDiaria As System.Windows.Forms.RadioButton
    Friend WithEvents cboComando As System.Windows.Forms.ComboBox
    Friend WithEvents txtDataExecucao As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtEnviadoPor As System.Windows.Forms.TextBox
    Friend WithEvents txtDataMensagem As System.Windows.Forms.TextBox
    Friend WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents chkDomingo As System.Windows.Forms.CheckBox
    Friend WithEvents chkSegunda As System.Windows.Forms.CheckBox
    Friend WithEvents chkTerca As System.Windows.Forms.CheckBox
    Friend WithEvents chkQuarta As System.Windows.Forms.CheckBox
    Friend WithEvents chkQuinta As System.Windows.Forms.CheckBox
    Friend WithEvents chkSexta As System.Windows.Forms.CheckBox
    Friend WithEvents chkSabado As System.Windows.Forms.CheckBox
    Friend WithEvents txtHoraDiaria As System.Windows.Forms.DateTimePicker
    Friend WithEvents optHoraFixa As System.Windows.Forms.RadioButton
    Friend WithEvents optHoraIntervalo As System.Windows.Forms.RadioButton
    Friend WithEvents grbHora As System.Windows.Forms.GroupBox
End Class
