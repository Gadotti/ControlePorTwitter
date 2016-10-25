Imports RN.AcessoDados
Imports RN.Business

Public Class frmAgendamentos

    Private Sub frmAgendamentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            HabilitaControles(False)

            'Carrega grid dos comandos
            dtgAgendamentos.DataSource = Nothing
            dtgAgendamentos.AutoGenerateColumns = False
            dtgAgendamentos.DataSource = Agendamentos.BuscaAgendamentos()

            CarregaComboComandos()

        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub HabilitaControles(ByVal pHabilitar As Boolean)
        txtDataExecucao.Enabled = pHabilitar
        txtEnviadoPor.Enabled = pHabilitar
        cboComando.Enabled = pHabilitar
        txtHoraDiaria.Enabled = pHabilitar
        chkDomingo.Enabled = pHabilitar
        chkQuarta.Enabled = pHabilitar
        chkQuinta.Enabled = pHabilitar
        chkSabado.Enabled = pHabilitar
        chkSegunda.Enabled = pHabilitar
        chkSexta.Enabled = pHabilitar
        chkTerca.Enabled = pHabilitar

        btnSalvar.Enabled = pHabilitar
        btnCancelar.Enabled = pHabilitar
        optDiaria.Enabled = pHabilitar
        optExecucaoUnica.Enabled = pHabilitar
        optHoraFixa.Enabled = pHabilitar
        optHoraIntervalo.Enabled = pHabilitar

        btnEditar.Enabled = Not pHabilitar
        btnNovo.Enabled = Not pHabilitar
        btnExcluir.Enabled = Not pHabilitar
    End Sub

    Private Sub CarregaComboComandos()
        cboComando.DataSource = Nothing
        cboComando.ValueMember = "Id"
        cboComando.DisplayMember = "Descricao"
        cboComando.DataSource = Comandos.BuscaComandos()
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

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Try
            Dim objAgendamentos As Agendamentos = CType(dtgAgendamentos.SelectedRows(0).DataBoundItem, Agendamentos)

            If objAgendamentos IsNot Nothing Then
                txtId.Text = objAgendamentos.Id.ToString
                cboComando.SelectedValue = objAgendamentos.ComandoId
                txtEnviadoPor.Text = objAgendamentos.EnviadoPor
                If objAgendamentos.DataMensagem <> Date.MinValue Then
                    txtDataMensagem.Text = Format(objAgendamentos.DataMensagem, "dd/MM/yyyy HH:mm:ss")
                Else
                    txtDataMensagem.Text = String.Empty
                End If
                txtDataExecucao.Text = Format(objAgendamentos.DataExecucao, "dd/MM/yyyy HH:mm:ss")
                txtHoraDiaria.Text = Format(objAgendamentos.HoraDiaria, "1/1/1753 HH:mm:ss")
                If objAgendamentos.DiasSemana IsNot Nothing Then
                    For Each wrkItem As DayOfWeek In objAgendamentos.DiasSemana
                        Select Case wrkItem
                            Case DayOfWeek.Sunday
                                chkDomingo.Checked = True
                            Case DayOfWeek.Monday
                                chkSegunda.Checked = True
                            Case DayOfWeek.Tuesday
                                chkTerca.Checked = True
                            Case DayOfWeek.Wednesday
                                chkQuarta.Checked = True
                            Case DayOfWeek.Thursday
                                chkQuinta.Checked = True
                            Case DayOfWeek.Friday
                                chkSexta.Checked = True
                            Case DayOfWeek.Saturday
                                chkSabado.Checked = True
                        End Select
                    Next
                End If

                Select Case objAgendamentos.TipoAgendamento
                    Case Agendamentos.TipoAgendamentoEnum.Diario
                        optDiaria.Checked = True
                        optExecucaoUnica.Checked = False
                    Case Agendamentos.TipoAgendamentoEnum.ExecucaoUnica
                        optDiaria.Checked = False
                        optExecucaoUnica.Checked = True
                End Select

                Select Case objAgendamentos.TipoHora
                    Case Agendamentos.TipoHoraEnum.Fixa
                        optHoraFixa.Checked = True
                        optHoraIntervalo.Checked = False
                    Case Agendamentos.TipoHoraEnum.Intervalo
                        optHoraFixa.Checked = False
                        optHoraIntervalo.Checked = True
                End Select


                HabilitaControles(True)
            Else
                MsgBox("Nenhum comando selecionado!", MsgBoxStyle.Information)
            End If
        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        Try
            If MsgBox("Deseja realmente excluir o Agendamento selecionado?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                'Obtem comando selecionado
                Dim objAgendamento As Agendamentos = CType(dtgAgendamentos.SelectedRows(0).DataBoundItem, Agendamentos)

                'Verifica se encontrou o objeto
                If objAgendamento IsNot Nothing Then
                    objAgendamento.Excluir()

                    dtgAgendamentos.DataSource = Nothing
                    dtgAgendamentos.AutoGenerateColumns = False
                    dtgAgendamentos.DataSource = Agendamentos.BuscaAgendamentos()

                    LimpaCampos()
                    HabilitaControles(False)

                    MsgBox("Operação realizada com suceso!", MsgBoxStyle.OkOnly)
                End If
            End If
        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub LimpaCampos()
        txtId.Text = String.Empty
        txtDataMensagem.Text = String.Empty
        txtEnviadoPor.Text = String.Empty
        txtDataExecucao.Text = Format(Date.Now, "dd/MM/yyyy HH:mm:ss")
        cboComando.SelectedIndex = 0
        txtHoraDiaria.Text = "00:00:00"
        chkDomingo.Checked = False
        chkQuarta.Checked = False
        chkQuinta.Checked = False
        chkSabado.Checked = False
        chkSegunda.Checked = False
        chkSexta.Checked = False
        chkTerca.Checked = False
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Try
            Dim objAgendamento As New Agendamentos
            objAgendamento.Id = CInt(txtId.Text)
            If optExecucaoUnica.Checked Then
                objAgendamento.TipoAgendamento = Agendamentos.TipoAgendamentoEnum.ExecucaoUnica
            ElseIf optDiaria.Checked Then
                objAgendamento.TipoAgendamento = Agendamentos.TipoAgendamentoEnum.Diario
            End If
            objAgendamento.ComandoId = CInt(cboComando.SelectedValue)
            objAgendamento.DataExecucao = CDate(txtDataExecucao.Text)
            objAgendamento.DataMensagem = CDate(IIf(txtDataMensagem.Text = String.Empty, Date.MinValue, txtDataMensagem.Text))
            objAgendamento.EnviadoPor = Funcoes.FormataUsuario(txtEnviadoPor.Text)
            objAgendamento.HoraDiaria = CDate(IIf(txtHoraDiaria.Text = String.Empty, Date.MinValue, txtHoraDiaria.Text))
            objAgendamento.DiasSemana = Agendamentos.MontaListaDiasSemana(chkDomingo.Checked, chkSegunda.Checked, _
                                                                          chkTerca.Checked, chkQuarta.Checked, _
                                                                          chkQuinta.Checked, chkSexta.Checked, _
                                                                          chkSabado.Checked)
            If optHoraFixa.Checked Then
                objAgendamento.TipoHora = Agendamentos.TipoHoraEnum.Fixa
            ElseIf optHoraIntervalo.Checked Then
                objAgendamento.TipoHora = Agendamentos.TipoHoraEnum.Intervalo
            End If

            'Validação
            If optDiaria.Checked AndAlso objAgendamento.DiasSemana.Count = 0 Then
                MsgBox("Em execução Diária, deve haver ao menos um dia da semana selecionado!", MsgBoxStyle.Critical)
                Return
            End If
            objAgendamento.Gravar()

            dtgAgendamentos.DataSource = Nothing
            dtgAgendamentos.AutoGenerateColumns = False
            dtgAgendamentos.DataSource = Agendamentos.BuscaAgendamentos()

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

    Private Sub ControlaVisibilidade()
        If optExecucaoUnica.Checked Then
            lblDataExecucao.Visible = True
            txtDataExecucao.Visible = True
            optHoraFixa.Visible = False
            optHoraIntervalo.Visible = False
            grbHora.Visible = False
            txtHoraDiaria.Visible = False
            chkDomingo.Visible = False
            chkQuarta.Visible = False
            chkQuinta.Visible = False
            chkSabado.Visible = False
            chkSegunda.Visible = False
            chkSexta.Visible = False
            chkTerca.Visible = False
        ElseIf optDiaria.Checked Then
            lblDataExecucao.Visible = False
            txtDataExecucao.Visible = False
            optHoraFixa.Visible = True
            optHoraIntervalo.Visible = True
            grbHora.Visible = True
            txtHoraDiaria.Visible = True
            chkDomingo.Visible = True
            chkQuarta.Visible = True
            chkQuinta.Visible = True
            chkSabado.Visible = True
            chkSegunda.Visible = True
            chkSexta.Visible = True
            chkTerca.Visible = True
        End If
    End Sub

    Private Sub optExecucaoUnica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optExecucaoUnica.CheckedChanged
        ControlaVisibilidade()
    End Sub

    Private Sub optDiaria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDiaria.CheckedChanged
        ControlaVisibilidade()
    End Sub

    Private Sub frmAgendamentos_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Principal.Visible Then
            Principal.Focus()
        End If
    End Sub

End Class