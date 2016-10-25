Imports System.IO
Imports RN.Business

Public Class Principal

    Public gNomeServico As String = "Twitter Monitor"
    Public gRodando As Boolean
    Public gIconeAzul As New Drawing.Icon(System.AppDomain.CurrentDomain.BaseDirectory & "\TwitterBlue.ico")
    Public gIconeVermelho As New Drawing.Icon(System.AppDomain.CurrentDomain.BaseDirectory & "\TwitterRed.ico")

    'Thread que aponta para a Sub TimerControle
    Dim wrkThread As New System.Threading.Thread(AddressOf TimerControle)
    Dim aTimer As System.Timers.Timer

    Private Sub TimerControle()
        'Com a Thread rodando iniciamos o timer que aponta para outro 
        'procedimento, algo próximo do que foi feito com a thread 
        'Setamos o "Tempo" do timer para 30000 milisegundos (30 segundos)
        aTimer = New System.Timers.Timer(15 * 1000)

        'Precisamos apontar o timer para algum procedimento, isso é feito 'com o uso do AddHandler
        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent

        aTimer.AutoReset = True
        aTimer.Enabled = True
    End Sub

    Private Sub OnTimedEvent(ByVal obj As Object, ByVal e As System.Timers.ElapsedEventArgs)
        'Dentro do procedimento do Timer fazemos a nossa tarefa, que será 
        'executada a cada N milisegundos.

        MonitoraServico()
    End Sub

    Private Sub MonitoraServico()
        Dim wrkMudarStatus As Boolean = False

        'Obtem status do Serviço de Monitoramento do Twitter
        Dim wrkIcone As Drawing.Icon = Nothing
        Dim wrkServido As New ServiceProcess.ServiceController(gNomeServico)
        If wrkServido.Status = ServiceProcess.ServiceControllerStatus.Running AndAlso Not gRodando Then
            gRodando = True
            wrkIcone = gIconeAzul
            wrkMudarStatus = True
            lblStatus.Text = "Ativo"
        ElseIf wrkServido.Status <> ServiceProcess.ServiceControllerStatus.Running AndAlso gRodando Then
            gRodando = False
            wrkIcone = gIconeVermelho
            wrkMudarStatus = True
            lblStatus.Text = "Inativo"
        End If
        '===================================================

        'Verifica se é para mostra mensagem de alerta
        If wrkMudarStatus Then
            NotifyIconTwitter.Icon = wrkIcone

            If gRodando Then
                NotifyIconTwitter.ShowBalloonTip(3000, gNomeServico, _
                                                 "Twitter Monitor esta Ativo!", ToolTipIcon.Info)
            Else
                NotifyIconTwitter.ShowBalloonTip(3000, gNomeServico, _
                                                 "Twitter Monitor esta Inativo!", ToolTipIcon.Warning)
            End If
        End If
    End Sub

    Private Sub SairToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SairToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub ParâmetrosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParâmetrosToolStripMenuItem.Click
        frmParametros.Show()
    End Sub

    Private Sub ComandosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComandosToolStripMenuItem.Click
        frmComandos.Show()
    End Sub

    Private Sub VisualizarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VisualizarToolStripMenuItem.Click
        frmMensagens.Show()
    End Sub

    Private Sub Principal_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If WindowState = FormWindowState.Minimized Then
            Hide()
        End If
    End Sub

    Private Sub NotifyIconTwitter_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIconTwitter.DoubleClick
        If WindowState = FormWindowState.Minimized Then
            Show()
            WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim tcpClient As New System.Net.Sockets.TcpClient()
            Console.WriteLine("Estabelecendo conexão.")
            tcpClient.Connect("174.123.78.178", 80)

            'Esconde formulario
            Hide()

            'Valida os parametros inciais para funcionar a aplicação
            If Not ValidaIniciacaoSistema() Then
                Application.Exit()
            End If

            'Obtem status do Serviço de Monitoramento do Twitter
            Dim wrkIcone As Drawing.Icon
            Dim wrkServido As New ServiceProcess.ServiceController(gNomeServico)
            Dim wrkStatus As String
            If wrkServido.Status = ServiceProcess.ServiceControllerStatus.Running Then
                wrkStatus = "Ativo"
                wrkIcone = gIconeAzul
                gRodando = True
                btnIniciar.Enabled = False
                btnParar.Enabled = True
            Else
                wrkStatus = "Inativo"
                wrkIcone = gIconeVermelho
                gRodando = False
                btnIniciar.Enabled = True
                btnParar.Enabled = False
            End If
            '===================================================

            lblStatus.Text = wrkStatus

            NotifyIconTwitter.Icon = wrkIcone
            NotifyIconTwitter.ShowBalloonTip(3000, gNomeServico, "Seja bem Vindo ao Twitter Monitor." & Environment.NewLine & _
                                             "Clique aqui para mais configurações." & Environment.NewLine & _
                                             "Neste momento o serviço está " & wrkStatus & ".", ToolTipIcon.Info)

            'Inicia serviço de monitoramento
            If Not wrkThread.IsAlive Then
                wrkThread = New System.Threading.Thread(AddressOf TimerControle)
            End If
            wrkThread.Start()
            '===============================
        Catch wrkErro As Exception
            Show()
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        End Try
        
    End Sub

    Private Sub SairToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SairToolStripMenuItem1.Click
        Application.Exit()
    End Sub

    Private Sub NotifyIconTwitter_BalloonTipClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIconTwitter.BalloonTipClicked
        If WindowState = FormWindowState.Minimized Then
            Show()
            WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Principal_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            WindowState = FormWindowState.Minimized
            Hide()
            Me.OnClosing(e)
        End If
    End Sub

    Private Sub btnIniciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIniciar.Click
        Try
            btnIniciar.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            Dim wrkServido As New ServiceProcess.ServiceController(gNomeServico)
            wrkServido.Start()

            MonitoraServico()

        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        Finally
            btnParar.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnParar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParar.Click
        Try
            btnParar.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            Dim wrkServido As New ServiceProcess.ServiceController(gNomeServico)
            wrkServido.Stop()

            MonitoraServico()

        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
        Finally
            btnIniciar.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnForcarMensagens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForcarMensagens.Click
        Try
            btnForcarMensagens.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            Mensagem.MonitoraMensagens()

            MsgBox("Mensagens verificadas com sucesso")
        Catch wrkErroWeb As System.Net.WebException
            MsgBox("Erro de comunicação. Verifique sua conexão com internet ou sua senha de usuário.", MsgBoxStyle.Critical)
            Funcoes.EscreverLog("Erro de comunicação. Verifique sua conexão com internet: " & wrkErroWeb.ToString, 1)
        Catch wrkErro As Exception
            MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
            Funcoes.EscreverLog("Erro: " & wrkErro.ToString, 1)
        Finally
            Funcoes.EscreverLog("Fim verificação", 0)
            btnForcarMensagens.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub AgendamentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgendamentosToolStripMenuItem.Click
        frmAgendamentos.Show()
    End Sub

    Private Sub UsuáriosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsuáriosToolStripMenuItem.Click
        frmUsuarios.Show()
    End Sub

    Private Function ValidaIniciacaoSistema() As Boolean
        If Not File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\ControlePorTwitter.cfg") Then
            MsgBox("Arquivo ControlePorTwitter.cfg inexistente", MsgBoxStyle.Critical)
            Return False
        End If

        Dim wrkTexto As String = File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory & "\ControlePorTwitter.cfg")
        wrkTexto = wrkTexto.Replace("DiretorioArquivoConfiguracao=", "")

        If wrkTexto = String.Empty Then
            MsgBox("Configure o diretório de arquivos de configuração em ControlePorTwitter.cfg", MsgBoxStyle.Critical)
            Return False
        End If

        Try
            Dim wrkServido As New ServiceProcess.ServiceController(gNomeServico)
        Catch
            MsgBox("Serviço '" & gNomeServico & "' não instalado", MsgBoxStyle.Critical)
            Return False
        End Try

        Return True
    End Function
End Class

'Private Sub btnParaServico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParaServico.Click
'    Try
'        wrkThread.Abort()
'        wrkThread.Join()

'        aTimer.Close()
'        aTimer.Dispose()
'        aTimer = Nothing

'        btnIniciaServico.Enabled = True
'        btnParaServico.Enabled = False
'    Catch wrkErro As Exception
'        MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
'    End Try
'End Sub

'Private Sub btnTesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
'    Try
'        Mensagem.MonitoraMensagens()

'    Catch wrkErro As Exception
'        MsgBox(wrkErro.Message, MsgBoxStyle.Critical)
'    End Try
'End Sub
