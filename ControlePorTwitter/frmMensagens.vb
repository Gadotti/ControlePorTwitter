Imports RN.Business
Imports RN.AcessoDados

Public Class frmMensagens

    Private Sub btnObterMensagem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObterMensagem.Click
        Try
            btnObterMensagem.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            dtgMensagens.DataSource = Nothing
            dtgMensagens.AutoGenerateColumns = False
            dtgMensagens.DataSource = Mensagem.BuscaMensagens()

        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        Finally
            btnObterMensagem.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnObterDirectMessages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObterDirectMessages.Click
        Try
            btnObterDirectMessages.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            Dim objParametros As Parametros = Parametros.BuscaParametros

            dtgMensagens.DataSource = Nothing
            dtgMensagens.AutoGenerateColumns = False
            dtgMensagens.DataSource = Mensagem.BuscaMensagensDiretas(objParametros.Usuario, objParametros.Senha, "0")

        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        Finally
            btnObterDirectMessages.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnVoltar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            btnObterMensagem.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            dtgMensagens.DataSource = Nothing
            dtgMensagens.AutoGenerateColumns = False
            dtgMensagens.DataSource = Mensagem.BuscaMensagens()

        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        Finally
            btnObterMensagem.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub frmMensagens_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Principal.Visible Then
            Principal.Focus()
        End If
    End Sub
End Class