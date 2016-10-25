Imports System.Collections.Generic
Imports System.Xml
Imports System.Net
Imports System.IO
Imports RN.AcessoDados

Namespace Business

    Public Class Mensagem

#Region "Propriedades"
        Private wrkData As Date
        Private wrkTexto As String
        Private wrkEnviadoPor As String
        Private wrkEnviadoPorId As Long
        Private wrkSeguindo As Boolean
        Private wrkId As String

        Public Property Id() As String
            Get
                Return wrkId
            End Get
            Set(ByVal value As String)
                wrkId = value
            End Set
        End Property

        Public Property Data() As Date
            Get
                Return wrkData
            End Get
            Set(ByVal value As Date)
                wrkData = value
            End Set
        End Property

        Public Property Texto() As String
            Get
                Return wrkTexto
            End Get
            Set(ByVal value As String)
                wrkTexto = value
            End Set
        End Property

        Public Property EnviadoPor() As String
            Get
                Return wrkEnviadoPor
            End Get
            Set(ByVal value As String)
                wrkEnviadoPor = value
            End Set
        End Property

        Public Property EnviadoPorId() As Long
            Get
                Return wrkEnviadoPorId
            End Get
            Set(ByVal value As Long)
                wrkEnviadoPorId = value
            End Set
        End Property

        Public Property Seguindo() As Boolean
            Get
                Return wrkSeguindo
            End Get
            Set(ByVal value As Boolean)
                wrkSeguindo = value
            End Set
        End Property
#End Region

        Public Shared Function BuscaMensagens() As List(Of Mensagem)
            Dim wrkUsuario As String = Parametros.BuscaParametros().Usuario
            Dim wrkUrl As String

            'Monta url de conexão e realiza comunicação
            wrkUrl = String.Format("http://twitter.com/statuses/user_timeline.xml?screen_name={0}", wrkUsuario)
            Dim wrkClient As New WebClient
            Dim wrkStream As Stream = wrkClient.OpenRead(wrkUrl)
            wrkStream.Flush()
            Dim wrkReader As New StreamReader(wrkStream)

            Dim wrkXmlDocument As New XmlDocument
            wrkXmlDocument.LoadXml(wrkReader.ReadToEnd)

            Dim wrkLista As XmlNodeList
            wrkLista = wrkXmlDocument.SelectNodes("//status")

            Dim wrkRetorno As New List(Of Mensagem)
            Dim wrkNode As XmlNode

            For Each wrkNode In wrkLista
                Dim wrkItem As New Mensagem
                wrkItem.Texto = wrkNode.SelectSingleNode("text").InnerText.ToString()
                wrkItem.Data = Funcoes.FromTwitterDate(wrkNode.SelectSingleNode("created_at").InnerText.ToString())
                wrkItem.EnviadoPor = Funcoes.FormataUsuario(wrkNode.SelectSingleNode("user//screen_name").InnerText.ToString())
                wrkItem.EnviadoPorId = CType(wrkNode.SelectSingleNode("user//id").InnerText.ToString(), Long)
                wrkItem.Seguindo = True

                wrkRetorno.Add(wrkItem)
            Next

            Return wrkRetorno
        End Function

        Public Shared Function BuscaMensagensDiretas(ByVal pLogin As String, ByVal pSenha As String, ByVal pUltimaMsgId As String) As List(Of Mensagem)

            'Obtem XML =======================================================
            Dim wrkUsuario As String = pLogin
            Dim wrkSenha As String = pSenha
            Dim wrkUrl As String

            'Monta url de conexão e realiza comunicação
            wrkUrl = String.Format("http://api.twitter.com/1/direct_messages.xml?since_id={0}", pUltimaMsgId)
            Dim wrkClient As New WebClient

            'Informa login e senha
            wrkClient.Credentials = New NetworkCredential(wrkUsuario, wrkSenha)

            'Solicita http
            Dim wrkStream As Stream = wrkClient.OpenRead(wrkUrl)
            wrkStream.Flush()
            Dim wrkReader As New StreamReader(wrkStream)

            '=================================================================

            'Trata XML =========================================================================================
            Dim wrkXmlDocument As New XmlDocument
            wrkXmlDocument.LoadXml(wrkReader.ReadToEnd())

            Dim wrkLista As XmlNodeList
            wrkLista = wrkXmlDocument.SelectNodes("//direct_message")

            Dim wrkRetorno As New List(Of Mensagem)
            Dim wrkNode As XmlNode

            For Each wrkNode In wrkLista
                Dim wrkItem As New Mensagem
                wrkItem.Texto = wrkNode.SelectSingleNode("text").InnerText.ToString()
                wrkItem.Data = Funcoes.FromTwitterDate(wrkNode.SelectSingleNode("created_at").InnerText.ToString())
                wrkItem.EnviadoPor = Funcoes.FormataUsuario(wrkNode.SelectSingleNode("sender_screen_name").InnerText.ToString())
                wrkItem.EnviadoPorId = CType(wrkNode.SelectSingleNode("sender//id").InnerText.ToString(), Long)
                wrkItem.Seguindo = CBool(wrkNode.SelectSingleNode("sender//following").InnerText.ToString())

                wrkRetorno.Add(wrkItem)
            Next
            '====================================================================================================

            Return wrkRetorno
        End Function

        Public Shared Sub EnviaMensagemDireta(ByVal pMensagemTexto As String, ByVal pEnviadoPor As String)
            Dim objParametros As Parametros = Parametros.BuscaParametros()
            Dim wrkRequest As HttpWebRequest = CType(WebRequest.Create(String.Format("http://twitter.com/direct_messages/new.xml?user={0}&text={1}", pEnviadoPor, pMensagemTexto)), HttpWebRequest)
            wrkRequest.Method = "POST"
            wrkRequest.Credentials = New NetworkCredential(objParametros.Usuario, objParametros.Senha)
            wrkRequest.ContentLength = 0
            wrkRequest.ContentType = "application/x-www-form-urlencoded"

            Dim wrkRespone As WebResponse = wrkRequest.GetResponse()

        End Sub

        Public Shared Sub MonitoraMensagens()
            Dim objListaComandos As List(Of Comandos) = Comandos.BuscaComandos()
            Dim objParametros As Parametros = Parametros.BuscaParametros()
            Dim objMensagens As List(Of Mensagem)
            Dim wrkEncontrouComandos As Boolean = False

            Funcoes.EscreverLog("Verificando Mensagens", 0, True)

            'Verifica se foi configurado senha para o usuário
            If objParametros.Senha = String.Empty Then
                Funcoes.EscreverLog("Senha não definida para usuário", 1)
                Return
            End If

            'Verifica qual fonte de mensagens buscar
            If objParametros.Mensagens = Parametros.TipoLeituraMsg.Diretas Then
                objMensagens = Mensagem.BuscaMensagensDiretas(objParametros.Usuario, objParametros.Senha, objParametros.UltimaMsgId)
            Else 'If objParametros.Mensagens = Parametros.TipoLeituraMsg.Publicas Then
                objMensagens = Mensagem.BuscaMensagens()
            End If

            'Verifica se encontra alguma mensagem
            If objMensagens.Count > 0 Then
                'Obtem somente as mensagens não lidas
                'objMensagens = objMensagens.FindAll(Function(t) t.Data > objParametros.DataUltimaMensagemLida)

                'Orderna por mensagens mais antigas
                Dim wrkMensagensOrdenadas As IEnumerable(Of Mensagem) = objMensagens.OrderBy(Function(t) t.Data)

                'Passa por cada mensgem verificando comando a executar
                Dim wrkItemMensagem As Mensagem
                For Each wrkItemMensagem In wrkMensagensOrdenadas
                    'Seta e grava ultima mensagem lida.
                    objParametros.UltimaMsgId = wrkItemMensagem.ID

                    'Obtem comando:
                    Dim objComando As Comandos = Comandos.ObtemComando(wrkItemMensagem.Texto, objListaComandos, wrkItemMensagem.EnviadoPor)

                    'Verifica se encontrou o comando
                    If objComando IsNot Nothing Then
                        Funcoes.EscreverLog("Executando comando '" & objComando.Comando & "'", 1)

                        wrkEncontrouComandos = True
                        Dim wrkRetorno As String = objComando.Executa(wrkItemMensagem.EnviadoPor)

                        'Envia retorno caso solicitado para o usuário em enviou o comando
                        If (objComando.EnviaRetorno AndAlso Not wrkRetorno = String.Empty) Then
                            EnviaMensagemDireta(wrkRetorno, wrkItemMensagem.EnviadoPor)
                            Funcoes.EscreverLog("Retorno enviado com sucesso.", 1)
                        End If

                    End If
                Next
            End If

            If Not wrkEncontrouComandos Then
                Funcoes.EscreverLog("Nenhum comando encontrado", 1)
            End If

            Funcoes.EscreverLog("Verificando Agendamentos", 1)
            'Verifica agendamentos
            ExecutaAgendamentos()

        End Sub

        Public Shared Sub ExecutaAgendamentos()
            Dim wrkEncontrouAgendamento As Boolean = False
            Dim objAgendamento As List(Of Agendamentos) = Agendamentos.BuscaAgendamentos

            'Obtem agendamentos de execuções unicas
            Dim objExecucoesUnicas As List(Of Agendamentos) = objAgendamento.FindAll(Function(a) a.TipoAgendamento = Agendamentos.TipoAgendamentoEnum.ExecucaoUnica AndAlso a.DataExecucao <= Date.Now)
            For Each wrkItem As Agendamentos In objExecucoesUnicas
                wrkEncontrouAgendamento = True
                Dim objComando As Comandos = Comandos.Busca(wrkItem.Id)
                Dim wrkRetorno As String = objComando.Executa(wrkItem.EnviadoPor, True)

                'Envia retorno caso solicitado para o usuário em enviou o comando
                If (objComando.EnviaRetorno AndAlso wrkRetorno <> String.Empty AndAlso wrkItem.EnviadoPor <> String.Empty) Then
                    EnviaMensagemDireta(wrkRetorno, wrkItem.EnviadoPor)
                End If

                Funcoes.EscreverLog("Agendamento '" & wrkItem.ComandoDescricao & "' execuado com sucesso. ", 1)

                'Exclui agendamento após execução
                wrkItem.Excluir()
            Next
            '=======================================

            'Obtem agendamentos de execuções diárias
            Dim wrkAgendamentosDiarias As List(Of Agendamentos) = objAgendamento.FindAll(Function(a) a.TipoAgendamento = Agendamentos.TipoAgendamentoEnum.Diario AndAlso _
                                                                                                     a.HoraDiaria <= a.HoraDiaria.AddHours(Date.Now.Hour).AddMinutes(Date.Now.Minute).AddSeconds(Date.Now.Second))
            For Each wrkItem As Agendamentos In wrkAgendamentosDiarias
                'Verifica se é o dia da semana solicitado
                Dim wrkConfirma As Boolean = False
                For Each wrkDia In wrkItem.DiasSemana
                    If wrkDia = Date.Now.DayOfWeek Then
                        wrkConfirma = True
                    End If
                Next
                '========================================

                'Se está convirmado executa comando
                If wrkConfirma Then
                    'Verifica se este comando já não foi executado hoje
                    Select Case wrkItem.TipoHora
                        Case Agendamentos.TipoHoraEnum.Fixa
                            If wrkItem.DataExecucao.Date < Date.Now.Date Then
                                wrkConfirma = True
                            Else
                                wrkConfirma = False
                            End If
                        Case Agendamentos.TipoHoraEnum.Intervalo
                            'Calcula o intervalo
                            Dim wrkHoraCalculada As Date = wrkItem.DataExecucao
                            wrkHoraCalculada = wrkHoraCalculada.AddHours(wrkItem.HoraDiaria.Hour).AddMinutes(wrkItem.HoraDiaria.Minute).AddSeconds(wrkItem.HoraDiaria.Second)
                            If wrkHoraCalculada <= Date.Now Then
                                wrkConfirma = True
                            Else
                                wrkConfirma = False
                            End If
                            '===================
                        Case Else
                            wrkConfirma = False
                    End Select

                    If wrkConfirma Then
                        'Executa Comando do agendamento
                        wrkEncontrouAgendamento = True
                        Dim objComando As Comandos = Comandos.Busca(wrkItem.ComandoId)
                        Dim wrkRetorno As String = objComando.Executa(wrkItem.EnviadoPor, True)

                        'Envia retorno caso solicitado para o usuário em enviou o comando
                        If (objComando.EnviaRetorno AndAlso wrkRetorno <> String.Empty AndAlso wrkItem.EnviadoPor <> String.Empty) Then
                            EnviaMensagemDireta(wrkRetorno, wrkItem.EnviadoPor)
                        End If

                        Funcoes.EscreverLog("Agendamento '" & objComando.Descricao & "' execuado com sucesso. ", 1)

                        'Grava data da ultima execução
                        wrkItem.DataExecucao = Date.Now
                        wrkItem.Gravar()
                    End If
                End If
                '==================================
            Next

            If Not wrkEncontrouAgendamento Then
                Funcoes.EscreverLog("Nenhum agendamento.", 1)
            End If
        End Sub

    End Class
End Namespace