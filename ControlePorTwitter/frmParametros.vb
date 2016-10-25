Imports RN.Business
Imports RN.AcessoDados

Public Class frmParametros
    Dim objParametro As Parametros

    Private Sub frmParametros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CarregaDados()
        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CarregaDados()
        objParametro = Parametros.BuscaParametros

        txtIntervalo.Value = CType(objParametro.Intervalo, Decimal)
        txtUsuario.Text = Funcoes.FormataUsuario(objParametro.Usuario)
        lblDataUltimaMensagemLida.Text = objParametro.UltimaMsgId

        'Verifica qual tipo de mensagem marcar
        Select Case objParametro.Mensagens
            Case Parametros.TipoLeituraMsg.Publicas
                rbtPublicas.Checked = True
                rbtPrivadas.Checked = False
            Case Parametros.TipoLeituraMsg.Diretas
                rbtPublicas.Checked = False
                rbtPrivadas.Checked = True
        End Select
        '=====================================

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub chkAlteraSenha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAlteraSenha.CheckedChanged
        If chkAlteraSenha.Checked Then
            txtSenha.Enabled = True
        Else
            txtSenha.Enabled = False
        End If
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            If objParametro IsNot Nothing Then
                objParametro.Usuario = txtUsuario.Text
                objParametro.Senha = txtSenha.Text
                objParametro.Intervalo = CInt(txtIntervalo.Value)
                If rbtPrivadas.Checked Then
                    objParametro.Mensagens = Parametros.TipoLeituraMsg.Diretas
                ElseIf rbtPublicas.Checked Then
                    objParametro.Mensagens = Parametros.TipoLeituraMsg.Publicas
                End If

                'Grava alterações
                objParametro.Gravar()

                MsgBox("Operação realizada com sucesso!", MsgBoxStyle.OkOnly)

                Me.Close()
            End If
        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmParametros_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Principal.Visible Then
            Principal.Focus()
        End If
    End Sub
End Class