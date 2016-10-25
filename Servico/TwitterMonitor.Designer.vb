Imports RN.AcessoDados
Imports RN
Imports System.ServiceProcess

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TwitterMonitor
    Inherits ServiceBase

    'UserService overrides dispose to clean up the component list.
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

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        'Setamos o "Tempo" do timer para 10000 milisegundos (10 segundos)
        aTimer = New System.Timers.Timer(CInt(Parametros.BuscaParametros().Intervalo) * 1000)

        'Precisamos apontar o timer para algum procedimento, isso é feito 'com o uso do AddHandler
        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent
        aTimer.AutoReset = True
        'aTimer.Enabled = True

        'Nome do Servico
        Me.ServiceName = "Twitter Monitor"

        DirectCast((Me.aTimer), System.ComponentModel.ISupportInitialize).EndInit()
    End Sub

End Class
