Imports RN.AcessoDados
Imports RN.Business

Public Class frmUsuarios

    Private Sub frmUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            HabilitaControles(False)

            dtgUsuarios.DataSource = Nothing
            dtgUsuarios.AutoGenerateColumns = False
            dtgUsuarios.DataSource = Usuarios.BuscaUsuarios

        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNovo.Click
        Try
            LimpaCampos()
            HabilitaControles(True)
            txtId.Text = "0"
            txtUsuarioTwitter.Focus()
        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Try
            Dim objUsuario As Usuarios = CType(dtgUsuarios.SelectedRows(0).DataBoundItem, Usuarios)

            If objUsuario IsNot Nothing Then
                txtId.Text = objUsuario.Id.ToString
                txtNome.Text = objUsuario.Nome
                txtEmail.Text = objUsuario.Email
                txtUsuarioTwitter.Text = objUsuario.UsuarioTwitter

                HabilitaControles(True)

                txtUsuarioTwitter.Enabled = False
            Else
                MsgBox("Nenhum comando selecionado!", MsgBoxStyle.Information)
            End If
        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        Try
            If MsgBox("Deseja realmente excluir o Usuário selecionado?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                'Obtem comando selecionado
                Dim objUsuario As Usuarios = CType(dtgUsuarios.SelectedRows(0).DataBoundItem, Usuarios)

                'Verifica se encontrou o objeto
                If dtgUsuarios IsNot Nothing Then
                    If objUsuario.ValidaExclusao() Then
                        objUsuario.Excluir()

                        dtgUsuarios.DataSource = Nothing
                        dtgUsuarios.AutoGenerateColumns = False
                        dtgUsuarios.DataSource = Usuarios.BuscaUsuarios()

                        LimpaCampos()
                        HabilitaControles(False)

                        MsgBox("Operação realizada com suceso!", MsgBoxStyle.OkOnly)
                    Else
                        MsgBox("Este usuário está sendo utilizado no Cadastro de Comandos." & _
                               Environment.NewLine & "Retire sua referência para excluí-lo.", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            'Campos Obrigatórios
            If txtUsuarioTwitter.Text.Trim = String.Empty Then
                MsgBox("Campo Usuário Twitter obrigatório", MsgBoxStyle.Critical)
                Return
            End If

            'Verifica se usuário já existe
            If txtUsuarioTwitter.Enabled AndAlso _
              Usuarios.BuscaUsuarios().FindAll(Function(u) u.UsuarioTwitter = Funcoes.FormataUsuario(txtUsuarioTwitter.Text)).Count > 0 Then
                MsgBox("Usuário Twitter já cadastrado!", MsgBoxStyle.Critical)
                Return
            End If

            Dim objUsuarios As New Usuarios
            objUsuarios.Id = CInt(txtId.Text)
            objUsuarios.Nome = txtNome.Text
            objUsuarios.UsuarioTwitter = Funcoes.FormataUsuario(txtUsuarioTwitter.Text)
            objUsuarios.Email = txtEmail.Text
            objUsuarios.Gravar()

            dtgUsuarios.DataSource = Nothing
            dtgUsuarios.AutoGenerateColumns = False
            dtgUsuarios.DataSource = Usuarios.BuscaUsuarios()

            LimpaCampos()
            HabilitaControles(False)

            MsgBox("Operação realizada com suceso!", MsgBoxStyle.OkOnly)
        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            LimpaCampos()
            HabilitaControles(False)
        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub LimpaCampos()
        txtEmail.Text = String.Empty
        txtId.Text = String.Empty
        txtNome.Text = String.Empty
        txtUsuarioTwitter.Text = String.Empty
    End Sub

    Private Sub HabilitaControles(ByVal pHabilitar As Boolean)
        txtEmail.Enabled = pHabilitar
        txtNome.Enabled = pHabilitar
        txtUsuarioTwitter.Enabled = pHabilitar

        btnSalvar.Enabled = pHabilitar
        btnCancelar.Enabled = pHabilitar

        btnEditar.Enabled = Not pHabilitar
        btnNovo.Enabled = Not pHabilitar
        btnExcluir.Enabled = Not pHabilitar
    End Sub

    Private Sub frmUsuarios_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Principal.Visible Then
            Principal.Focus()
        End If
    End Sub
End Class