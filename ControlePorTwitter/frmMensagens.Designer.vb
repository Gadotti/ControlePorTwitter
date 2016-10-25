<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMensagens
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
        Me.dtgMensagens = New System.Windows.Forms.DataGridView
        Me.btnVoltar = New System.Windows.Forms.Button
        Me.btnObterDirectMessages = New System.Windows.Forms.Button
        Me.btnObterMensagem = New System.Windows.Forms.Button
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Texto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EnviadoPor = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dtgMensagens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgMensagens
        '
        Me.dtgMensagens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgMensagens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Data, Me.Texto, Me.EnviadoPor})
        Me.dtgMensagens.Location = New System.Drawing.Point(12, 41)
        Me.dtgMensagens.Name = "dtgMensagens"
        Me.dtgMensagens.Size = New System.Drawing.Size(760, 307)
        Me.dtgMensagens.TabIndex = 6
        '
        'btnVoltar
        '
        Me.btnVoltar.Location = New System.Drawing.Point(12, 354)
        Me.btnVoltar.Name = "btnVoltar"
        Me.btnVoltar.Size = New System.Drawing.Size(75, 23)
        Me.btnVoltar.TabIndex = 7
        Me.btnVoltar.Text = "<< Voltar"
        Me.btnVoltar.UseVisualStyleBackColor = True
        '
        'btnObterDirectMessages
        '
        Me.btnObterDirectMessages.Location = New System.Drawing.Point(192, 12)
        Me.btnObterDirectMessages.Name = "btnObterDirectMessages"
        Me.btnObterDirectMessages.Size = New System.Drawing.Size(174, 23)
        Me.btnObterDirectMessages.TabIndex = 9
        Me.btnObterDirectMessages.Text = "Mensagens Diretas Recebidas"
        Me.btnObterDirectMessages.UseVisualStyleBackColor = True
        '
        'btnObterMensagem
        '
        Me.btnObterMensagem.Location = New System.Drawing.Point(12, 12)
        Me.btnObterMensagem.Name = "btnObterMensagem"
        Me.btnObterMensagem.Size = New System.Drawing.Size(174, 23)
        Me.btnObterMensagem.TabIndex = 8
        Me.btnObterMensagem.Text = "Mensagens Públicas Enviadas"
        Me.btnObterMensagem.UseVisualStyleBackColor = True
        '
        'Id
        '
        Me.Id.DataPropertyName = "Id"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        '
        'Data
        '
        Me.Data.DataPropertyName = "Data"
        Me.Data.HeaderText = "Data"
        Me.Data.Name = "Data"
        Me.Data.ReadOnly = True
        '
        'Texto
        '
        Me.Texto.DataPropertyName = "Texto"
        Me.Texto.HeaderText = "Mensagem"
        Me.Texto.Name = "Texto"
        Me.Texto.ReadOnly = True
        Me.Texto.Width = 300
        '
        'EnviadoPor
        '
        Me.EnviadoPor.DataPropertyName = "EnviadoPor"
        Me.EnviadoPor.HeaderText = "Enviado Por"
        Me.EnviadoPor.Name = "EnviadoPor"
        Me.EnviadoPor.ReadOnly = True
        '
        'frmMensagens
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 383)
        Me.Controls.Add(Me.btnObterDirectMessages)
        Me.Controls.Add(Me.btnObterMensagem)
        Me.Controls.Add(Me.btnVoltar)
        Me.Controls.Add(Me.dtgMensagens)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmMensagens"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visualizar Mensagens"
        CType(Me.dtgMensagens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtgMensagens As System.Windows.Forms.DataGridView
    Friend WithEvents btnVoltar As System.Windows.Forms.Button
    Friend WithEvents btnObterDirectMessages As System.Windows.Forms.Button
    Friend WithEvents btnObterMensagem As System.Windows.Forms.Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Texto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EnviadoPor As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
