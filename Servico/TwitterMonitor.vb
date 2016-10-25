Imports RN.Business
Imports System

Public Class TwitterMonitor
    Inherits System.ServiceProcess.ServiceBase

    Private aTimer As System.Timers.Timer

    Public Sub New()
        ' This call is required by the Windows.Forms
        ' Component Designer.
        InitializeComponent()
    End Sub

    ' The main entry point for the process
    Public Shared Sub Main()
        Dim ServicesToRun As System.ServiceProcess.ServiceBase()

        ServicesToRun = New System.ServiceProcess.ServiceBase() {New TwitterMonitor()}

        System.ServiceProcess.ServiceBase.Run(ServicesToRun)
    End Sub

    ''' <summary>
    ''' Set things in motion so your service can do its work.
    ''' </summary>
    Protected Overloads Overrides Sub OnStart(ByVal args As String())
        Try
            Me.aTimer.Enabled = True
            Me.LogMessage("Twitter Monitor Iniciado")
        Catch wrkErro As Exception
            Me.LogMessage("Twitter Monitor - Erro: " & wrkErro.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' Stop this service.
    ''' </summary>
    Protected Overloads Overrides Sub OnStop()
        Me.aTimer.Enabled = False
        Me.LogMessage("Twitter Monitor Parado")
    End Sub

    Private Sub OnTimedEvent(ByVal obj As Object, ByVal e As System.Timers.ElapsedEventArgs)
        'Dentro do procedimento do Timer fazemos a nossa tarefa, que será 
        'executada a cada N milisegundos.
        Try
            Mensagem.MonitoraMensagens()

        Catch wrkErroWeb As System.Net.WebException
            Funcoes.EscreverLog("Erro de comunicação. Verifique sua conexão com internet: " & wrkErroWeb.ToString, 1)
        Catch wrkErro As Exception
            Me.LogMessage(wrkErro.Message)
            Funcoes.EscreverLog("Erro: " & wrkErro.ToString, 1)
        Finally
            Funcoes.EscreverLog("Fim verificação", 0)
        End Try

    End Sub

    Private Sub LogMessage(ByVal pMessage As String)
        EventLog.WriteEntry(Me.ServiceName, pMessage)
    End Sub

End Class
