Imports RN.AcessoDados

Public Class frmComandos

    Private Sub frmComandos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            HabilitaControles(False)

            'Carrega grid dos comandos
            dtgComandos.DataSource = Nothing
            dtgComandos.AutoGenerateColumns = False
            dtgComandos.DataSource = Comandos.BuscaComandos()

            'Carrega combo de comandos
            CarregaComboComandos()

        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CarregaComboComandos(Optional ByVal pRetirarId As Integer = 0)
        cboComandos.DataSource = Nothing
        If pRetirarId = 0 Then
            cboComandos.DataSource = Comandos.BuscaComandos()
        Else
            cboComandos.DataSource = Comandos.BuscaComandos().FindAll(Function(c) c.Id <> pRetirarId)
        End If

        cboUsuarios.DataSource = Nothing
        cboUsuarios.DataSource = Usuarios.BuscaUsuarios
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Try
            Dim objComando As Comandos = CType(dtgComandos.SelectedRows(0).DataBoundItem, Comandos)

            If objComando IsNot Nothing Then
                txtComando.Text = objComando.Comando
                txtDescricao.Text = objComando.Descricao
                txtId.Text = objComando.Id.ToString
                txtLinhaComando.Text = objComando.LinhaComando
                txtParametros.Text = objComando.LinhaComandoParametro
                lstRestricaoUsuarios.DataSource = Nothing
                If objComando.RestricaoUsuariosString.Trim <> String.Empty Then
                    lstRestricaoUsuarios.DataSource = objComando.RestricaoUsuarios
                End If
                txtNomeServico.Text = objComando.NomeServico

                If objComando.TipoComando = Comandos.TipoComandoEnum.LinhaComando Then
                    optLinhaComando.Checked = True
                    optStatusServico.Checked = False
                    optEncadeamentoComandos.Checked = False
                ElseIf objComando.TipoComando = Comandos.TipoComandoEnum.MonitoraServico Then
                    optLinhaComando.Checked = False
                    optStatusServico.Checked = True
                    optEncadeamentoComandos.Checked = False
                ElseIf objComando.TipoComando = Comandos.TipoComandoEnum.EncadeamentoComandos Then
                    optLinhaComando.Checked = False
                    optStatusServico.Checked = False
                    optEncadeamentoComandos.Checked = True
                End If

                'Carrega lista de comandos
                lstComandos.DataSource = objComando.ListaComandos

                chkAtivo.Checked = objComando.Ativo
                chkEnviaRetorno.Checked = objComando.EnviaRetorno

                HabilitaControles(True)
                CarregaComboComandos(objComando.Id)
            Else
                MsgBox("Nenhum comando selecionado!", MsgBoxStyle.Information)
            End If
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

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            Dim objComando As New Comandos
            objComando.Id = CInt(txtId.Text)
            objComando.Comando = txtComando.Text
            objComando.Descricao = txtDescricao.Text
            objComando.LinhaComando = txtLinhaComando.Text
            objComando.LinhaComandoParametro = txtParametros.Text
            objComando.Ativo = chkAtivo.Checked
            objComando.EnviaRetorno = chkEnviaRetorno.Checked
            objComando.NomeServico = txtNomeServico.Text

            'Salva Usuarios
            objComando.RestricaoUsuarios = Nothing
            If lstRestricaoUsuarios.DataSource IsNot Nothing Then
                objComando.RestricaoUsuarios = CType(lstRestricaoUsuarios.DataSource, List(Of Usuarios))
            End If
            '==============

            objComando.ListaComandos = Nothing

            'Verifica tipo do comando
            If optLinhaComando.Checked Then
                objComando.TipoComando = Comandos.TipoComandoEnum.LinhaComando
            ElseIf optStatusServico.Checked Then
                objComando.TipoComando = Comandos.TipoComandoEnum.MonitoraServico
            ElseIf optEncadeamentoComandos.Checked Then
                objComando.TipoComando = Comandos.TipoComandoEnum.EncadeamentoComandos

                If lstComandos.DataSource Is Nothing OrElse CType(lstComandos.DataSource, List(Of Comandos)).Count < 2 Then
                    MsgBox("Deve haver no mínimo 2 comandos para um encademanto de comandos!", MsgBoxStyle.Critical)
                    Return
                End If

                'Preenche lista de comandos
                If lstComandos.DataSource IsNot Nothing Then
                    objComando.ListaComandos = CType(lstComandos.DataSource, List(Of Comandos))
                End If
            End If

            objComando.Gravar()

            dtgComandos.DataSource = Nothing
            dtgComandos.AutoGenerateColumns = False
            dtgComandos.DataSource = Comandos.BuscaComandos()

            LimpaCampos()
            HabilitaControles(False)
            CarregaComboComandos()

            MsgBox("Operação realizada com suceso!", MsgBoxStyle.OkOnly)

        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub HabilitaControles(ByVal pHabilitar As Boolean)
        txtComando.Enabled = pHabilitar
        txtDescricao.Enabled = pHabilitar
        txtLinhaComando.Enabled = pHabilitar
        txtParametros.Enabled = pHabilitar
        lstRestricaoUsuarios.Enabled = pHabilitar
        cboUsuarios.Enabled = pHabilitar
        btnAdicionarUsuario.Enabled = pHabilitar
        btnRetirarUsuario.Enabled = pHabilitar
        chkAtivo.Enabled = pHabilitar
        chkEnviaRetorno.Enabled = pHabilitar
        optLinhaComando.Enabled = pHabilitar
        optStatusServico.Enabled = pHabilitar
        optEncadeamentoComandos.Enabled = pHabilitar
        txtNomeServico.Enabled = pHabilitar
        lstComandos.Enabled = pHabilitar
        btnAdicionarComando.Enabled = pHabilitar
        btnRetirarComando.Enabled = pHabilitar
        cboComandos.Enabled = pHabilitar

        btnSalvar.Enabled = pHabilitar
        btnCancelar.Enabled = pHabilitar

        btnEditar.Enabled = Not pHabilitar
        btnNovo.Enabled = Not pHabilitar
        btnExlcuir.Enabled = Not pHabilitar
    End Sub

    Private Sub LimpaCampos()
        txtComando.Text = String.Empty
        txtDescricao.Text = String.Empty
        txtId.Text = String.Empty
        txtLinhaComando.Text = String.Empty
        txtParametros.Text = String.Empty
        lstRestricaoUsuarios.DataSource = Nothing
        chkAtivo.Checked = False
        chkEnviaRetorno.Checked = False
        txtNomeServico.Text = String.Empty
        optLinhaComando.Checked = True
        optStatusServico.Checked = False
        optEncadeamentoComandos.Checked = False

        If cboComandos.DataSource IsNot Nothing Then
            cboComandos.SelectedIndex = 0
        End If

        If cboUsuarios.DataSource IsNot Nothing Then
            cboUsuarios.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNovo.Click
        Try
            LimpaCampos()
            HabilitaControles(True)
            txtId.Text = "0"

        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnExlcuir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExlcuir.Click
        Try
            If MsgBox("Deseja realmente excluir o Comando selecionado?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                'Obtem comando selecionado
                Dim objComando As Comandos = CType(dtgComandos.SelectedRows(0).DataBoundItem, Comandos)

                'Verifica se encontrou o objeto
                If objComando IsNot Nothing Then
                    objComando.Excluir()

                    dtgComandos.DataSource = Nothing
                    dtgComandos.AutoGenerateColumns = False
                    dtgComandos.DataSource = Comandos.BuscaComandos()

                    LimpaCampos()
                    HabilitaControles(False)

                    MsgBox("Operação realizada com suceso!", MsgBoxStyle.OkOnly)
                End If
            End If
        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub optLinhaComando_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optLinhaComando.CheckedChanged
        ControlaVisibilidades()
    End Sub

    Private Sub ControlaVisibilidades()
        Try
            If optLinhaComando.Checked Then
                lblLinhaComando.Visible = True
                txtLinhaComando.Visible = True
                txtParametros.Visible = True
                lblParametros.Visible = True
                lblNomeServico.Visible = False
                txtNomeServico.Visible = False
                chkEnviaRetorno.Enabled = True
                lstComandos.Visible = False
                cboComandos.Visible = False
                btnAdicionarComando.Visible = False
                btnRetirarComando.Visible = False
                lblListaComandos.Visible = False
            ElseIf optStatusServico.Checked Then
                lblLinhaComando.Visible = False
                txtLinhaComando.Visible = False
                txtParametros.Visible = False
                lblParametros.Visible = False
                lblNomeServico.Visible = True
                txtNomeServico.Visible = True
                chkEnviaRetorno.Enabled = False
                chkEnviaRetorno.Checked = True
                lstComandos.Visible = False
                cboComandos.Visible = False
                btnAdicionarComando.Visible = False
                btnRetirarComando.Visible = False
                lblListaComandos.Visible = False
            ElseIf optEncadeamentoComandos.Checked Then
                lblLinhaComando.Visible = False
                txtLinhaComando.Visible = False
                txtParametros.Visible = False
                lblParametros.Visible = False
                lblNomeServico.Visible = False
                txtNomeServico.Visible = False
                chkEnviaRetorno.Enabled = True
                lstComandos.Visible = True
                cboComandos.Visible = True
                btnAdicionarComando.Visible = True
                btnRetirarComando.Visible = True
                lblListaComandos.Visible = True
            End If
        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnRetirarUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetirarUsuario.Click
        Try
            If lstRestricaoUsuarios.DataSource IsNot Nothing Then
                Dim wrkListaNova As New List(Of Usuarios)
                Dim wrkIndex As Integer = 0
                For Each wrkItem As Usuarios In CType(lstRestricaoUsuarios.DataSource, List(Of Usuarios))
                    If wrkIndex <> lstRestricaoUsuarios.SelectedIndex Then
                        wrkListaNova.Add(wrkItem)
                    End If
                    wrkIndex += 1
                Next

                lstRestricaoUsuarios.DataSource = wrkListaNova
            End If
        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnAdicionarUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionarUsuario.Click
        Try
            Dim wrkListaNova As New List(Of Usuarios)
            wrkListaNova.Add(CType(cboUsuarios.SelectedValue, Usuarios))

            If lstRestricaoUsuarios.DataSource Is Nothing Then
                lstRestricaoUsuarios.DataSource = wrkListaNova
            Else
                Dim wrkListaAtual As New List(Of Usuarios)
                For Each wrkItem As Usuarios In CType(lstRestricaoUsuarios.DataSource, List(Of Usuarios))
                    wrkListaAtual.Add(wrkItem)
                Next
                wrkListaAtual.AddRange(wrkListaNova)
                lstRestricaoUsuarios.DataSource = wrkListaAtual
            End If
        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnAdicionarComando_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionarComando.Click
        Try
            Dim wrkListaNova As New List(Of Comandos)
            wrkListaNova.Add(CType(cboComandos.SelectedValue, Comandos))

            If lstComandos.DataSource Is Nothing Then
                lstComandos.DataSource = wrkListaNova
            Else
                Dim wrkListaAtual As New List(Of Comandos)
                For Each wrkItem As Comandos In CType(lstComandos.DataSource, List(Of Comandos))
                    wrkListaAtual.Add(wrkItem)
                Next
                wrkListaAtual.AddRange(wrkListaNova)
                lstComandos.DataSource = wrkListaAtual
            End If

        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnRetirarComando_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetirarComando.Click
        Try
            If lstComandos.DataSource IsNot Nothing Then
                Dim wrkListaNova As New List(Of Comandos)
                Dim wrkIndex As Integer = 0
                For Each wrkItem As Comandos In CType(lstComandos.DataSource, List(Of Comandos))
                    If wrkIndex <> lstComandos.SelectedIndex Then
                        wrkListaNova.Add(wrkItem)
                    End If
                    wrkIndex += 1
                Next

                lstComandos.DataSource = wrkListaNova
            End If

        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub optStatusServico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optStatusServico.CheckedChanged
        ControlaVisibilidades()
    End Sub

    Private Sub optEncadeamentoComandos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optEncadeamentoComandos.CheckedChanged
        ControlaVisibilidades()
    End Sub

    Private Sub frmComandos_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Principal.Visible Then
            Principal.Focus()
        End If
    End Sub
End Class