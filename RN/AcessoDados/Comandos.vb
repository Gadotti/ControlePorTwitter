Imports System.Collections.Generic
Imports System.Xml
Imports System.IO
Imports System.Text

Namespace AcessoDados

    Public Class Comandos

        Public Const gArquivoXML As String = "\Comandos.xml"

        Private wrkDiretorio As String
        Private Property Diretorio() As String
            Get
                If wrkDiretorio = String.Empty Then
                    Return BuscaDiretorio()
                Else
                    Return wrkDiretorio
                End If
            End Get
            Set(ByVal value As String)
                wrkDiretorio = value
            End Set
        End Property

#Region "Propriedades"
        Public Enum TipoComandoEnum
            LinhaComando = 0
            MonitoraServico = 1
            EncadeamentoComandos = 2
        End Enum

        Private wrkId As Integer
        Private wrkComando As String
        Private wrkDescricao As String
        Private wrkAtivo As Boolean
        Private wrkDataCadastro As Date
        Private wrkEnviaRetorno As Boolean
        Private wrkLinhaComando As String
        Private wrkTipoComando As TipoComandoEnum
        Private wrkNomeServico As String
        Private wrkLinhaComandoParametro As String
        Private wrkListaComandos As List(Of Comandos)
        Private wrkRestricaoUsuarios As List(Of Usuarios)

        Public Property RestricaoUsuarios() As List(Of Usuarios)
            Get
                Return wrkRestricaoUsuarios
            End Get
            Set(ByVal value As List(Of Usuarios))
                wrkRestricaoUsuarios = value
            End Set
        End Property

        Public ReadOnly Property RestricaoUsuariosString() As String
            Get
                If RestricaoUsuarios Is Nothing Then
                    Return String.Empty
                ElseIf RestricaoUsuarios.Count = 0 Then
                    Return String.Empty
                Else
                    Dim wrkLista As New StringBuilder
                    For Each wrkItem As Usuarios In RestricaoUsuarios
                        wrkLista.Append(wrkItem.Id.ToString & ";")
                    Next
                    Dim wrkListaString As String = wrkLista.ToString
                    Return wrkListaString.Substring(0, wrkListaString.Length - 1)
                End If
            End Get
        End Property

        Public ReadOnly Property RestricaoUsuariosPorNomeString() As String
            Get
                If RestricaoUsuarios Is Nothing Then
                    Return String.Empty
                ElseIf RestricaoUsuarios.Count = 0 Then
                    Return String.Empty
                Else
                    Dim wrkLista As New StringBuilder
                    For Each wrkItem As Usuarios In RestricaoUsuarios
                        wrkLista.Append(wrkItem.UsuarioTwitter.ToString & ";")
                    Next
                    Dim wrkListaString As String = wrkLista.ToString
                    Return wrkListaString.Substring(0, wrkListaString.Length - 1)
                End If
            End Get
        End Property

        Private Shared Function PreencheRestricaoUsuariosProperty(ByVal pUsuarios As String) As List(Of Usuarios)
            Dim wrkListaUsuarios As List(Of Usuarios)
            If pUsuarios.Trim <> String.Empty Then
                wrkListaUsuarios = New List(Of Usuarios)
                Dim wrkListaString As String() = pUsuarios.Split(CChar(";"))
                For Each wrkItem As String In wrkListaString
                    wrkListaUsuarios.Add(Usuarios.Busca(CInt(wrkItem)))
                Next
            Else
                wrkListaUsuarios = Nothing
            End If

            Return wrkListaUsuarios
        End Function

        Private ReadOnly Property ListaComandosString() As String
            Get
                If ListaComandos Is Nothing Then
                    Return String.Empty
                ElseIf ListaComandos.Count = 0 Then
                    Return String.Empty
                Else
                    Dim wrkLista As New StringBuilder
                    For Each wrkItem As Comandos In ListaComandos
                        wrkLista.Append(wrkItem.Id.ToString & ";")
                    Next
                    Dim wrkListaString As String = wrkLista.ToString
                    Return wrkListaString.Substring(0, wrkListaString.Length - 1)
                End If
            End Get
        End Property

        Private Shared Function PreencheListaComandoProperty(ByVal pComandos As String) As List(Of Comandos)
            Dim wrkListaComandos As List(Of Comandos)
            If pComandos.Trim <> String.Empty Then
                wrkListaComandos = New List(Of Comandos)
                Dim wrkListaString As String() = pComandos.Split(CChar(";"))
                For Each wrkItem As String In wrkListaString
                    wrkListaComandos.Add(Comandos.Busca(CInt(wrkItem)))
                Next
            Else
                wrkListaComandos = Nothing
            End If

            Return wrkListaComandos
        End Function

        Public Property ListaComandos() As List(Of Comandos)
            Get
                Return wrkListaComandos
            End Get
            Set(ByVal value As List(Of Comandos))
                wrkListaComandos = value
            End Set
        End Property

        Public Property LinhaComandoParametro() As String
            Get
                Return wrkLinhaComandoParametro
            End Get
            Set(ByVal value As String)
                wrkLinhaComandoParametro = value
            End Set
        End Property

        Public Property NomeServico() As String
            Get
                Return wrkNomeServico
            End Get
            Set(ByVal value As String)
                wrkNomeServico = value
            End Set
        End Property

        Public Property Id() As Integer
            Get
                Return wrkId
            End Get
            Set(ByVal value As Integer)
                wrkId = value
            End Set
        End Property

        Public Property Comando() As String
            Get
                Return wrkComando
            End Get
            Set(ByVal value As String)
                wrkComando = value
            End Set
        End Property

        Public Property Descricao() As String
            Get
                Return wrkDescricao
            End Get
            Set(ByVal value As String)
                wrkDescricao = value
            End Set
        End Property

        Public Property Ativo() As Boolean
            Get
                Return wrkAtivo
            End Get
            Set(ByVal value As Boolean)
                wrkAtivo = value
            End Set
        End Property

        Public ReadOnly Property AtivoString() As String
            Get
                Return IIf(wrkAtivo, "Sim", "Não").ToString
            End Get
        End Property

        Public Property DataCadastro() As Date
            Get
                Return wrkDataCadastro
            End Get
            Set(ByVal value As Date)
                wrkDataCadastro = value
            End Set
        End Property

        Public Property EnviaRetorno() As Boolean
            Get
                Return wrkEnviaRetorno
            End Get
            Set(ByVal value As Boolean)
                wrkEnviaRetorno = value
            End Set
        End Property

        Public Property LinhaComando() As String
            Get
                Return wrkLinhaComando
            End Get
            Set(ByVal value As String)
                wrkLinhaComando = value
            End Set
        End Property

        Public Property TipoComando() As TipoComandoEnum
            Get
                Return wrkTipoComando
            End Get
            Set(ByVal value As TipoComandoEnum)
                wrkTipoComando = value
            End Set
        End Property
#End Region

        Private Shared Function BuscaDiretorio() As String
            Dim wrkTexto As String = File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory & "\ControlePorTwitter.cfg")
            wrkTexto = wrkTexto.Replace("DiretorioArquivoConfiguracao=", "")
            Return wrkTexto
        End Function

        Public Sub New()
            Diretorio = BuscaDiretorio()
        End Sub

        Public Shared Function Busca(ByVal pComandoId As Integer) As Comandos
            Dim wrkXmlDocument As New XmlDocument
            wrkXmlDocument.LoadXml(File.ReadAllText(BuscaDiretorio() & gArquivoXML))

            Dim wrkLista As XmlNodeList
            wrkLista = wrkXmlDocument.SelectNodes("//comandos//comando")

            Dim wrkRetorno As Comandos = Nothing
            Dim wrkNode As XmlNode

            For Each wrkNode In wrkLista
                Dim wrkItem As New Comandos
                wrkItem.Id = CInt(wrkNode.SelectSingleNode("id").InnerText.ToString())
                If wrkItem.Id = pComandoId Then
                    wrkItem.DataCadastro = CDate(wrkNode.SelectSingleNode("data_cadastro").InnerText.ToString())
                    wrkItem.Comando = wrkNode.SelectSingleNode("nome").InnerText
                    wrkItem.Descricao = wrkNode.SelectSingleNode("descricao").InnerText
                    wrkItem.Ativo = CBool(wrkNode.SelectSingleNode("ativo").InnerText.ToString())
                    wrkItem.EnviaRetorno = CBool(wrkNode.SelectSingleNode("envia_retorno").InnerText.ToString())
                    wrkItem.RestricaoUsuarios = PreencheRestricaoUsuariosProperty(wrkNode.SelectSingleNode("restricao_usuarios").InnerText)
                    wrkItem.LinhaComando = wrkNode.SelectSingleNode("linhacomando").InnerText.ToString()
                    wrkItem.TipoComando = CType(CInt(wrkNode.SelectSingleNode("tipocomando").InnerText), TipoComandoEnum)
                    wrkItem.NomeServico = wrkNode.SelectSingleNode("nomeservico").InnerText
                    wrkItem.LinhaComandoParametro = wrkNode.SelectSingleNode("linhacomandoparametro").InnerText
                    wrkItem.ListaComandos = PreencheListaComandoProperty(wrkNode.SelectSingleNode("listacomandos").InnerText)
                    wrkRetorno = wrkItem
                End If
            Next

            Return wrkRetorno
        End Function

        Public Shared Function BuscaComandos() As List(Of Comandos)

            Dim wrkXmlDocument As New XmlDocument
            wrkXmlDocument.LoadXml(File.ReadAllText(BuscaDiretorio() & gArquivoXML))

            Dim wrkLista As XmlNodeList
            wrkLista = wrkXmlDocument.SelectNodes("//comandos//comando")

            Dim wrkRetorno As New List(Of Comandos)
            Dim wrkNode As XmlNode

            For Each wrkNode In wrkLista
                Dim wrkItem As New Comandos
                wrkItem.Id = CInt(wrkNode.SelectSingleNode("id").InnerText.ToString())
                wrkItem.DataCadastro = CDate(wrkNode.SelectSingleNode("data_cadastro").InnerText.ToString())
                wrkItem.Comando = wrkNode.SelectSingleNode("nome").InnerText
                wrkItem.Descricao = wrkNode.SelectSingleNode("descricao").InnerText
                wrkItem.Ativo = CBool(wrkNode.SelectSingleNode("ativo").InnerText.ToString())
                wrkItem.EnviaRetorno = CBool(wrkNode.SelectSingleNode("envia_retorno").InnerText.ToString())
                wrkItem.RestricaoUsuarios = PreencheRestricaoUsuariosProperty(wrkNode.SelectSingleNode("restricao_usuarios").InnerText)
                wrkItem.LinhaComando = wrkNode.SelectSingleNode("linhacomando").InnerText.ToString()
                wrkItem.TipoComando = CType(CInt(wrkNode.SelectSingleNode("tipocomando").InnerText), TipoComandoEnum)
                wrkItem.NomeServico = wrkNode.SelectSingleNode("nomeservico").InnerText
                wrkItem.LinhaComandoParametro = wrkNode.SelectSingleNode("linhacomandoparametro").InnerText
                wrkItem.ListaComandos = PreencheListaComandoProperty(wrkNode.SelectSingleNode("listacomandos").InnerText)

                wrkRetorno.Add(wrkItem)
            Next

            Return wrkRetorno

        End Function

        Public Shared Function ObtemComando(ByVal pMensagem As String, ByVal pListaComandos As List(Of Comandos), ByVal pEnviadoPor As String) As Comandos

            Dim objComando As Comandos
            For Each objComando In pListaComandos
                'Verifica se o comando esta contido na mensagem
                If pMensagem.ToLower.Contains(objComando.Comando.ToLower) Then

                    'Verifica se é para agendar comando
                    If pMensagem.ToLower.IndexOf("#agendar") > -1 Then
                        'Obtem data e hora do agendamento
                        Dim wrkDataHora As String = pMensagem.Substring(pMensagem.ToLower.IndexOf("#agendar") + 8, 20)
                        Dim wrkDataSplit As String() = wrkDataHora.Substring(0, 11).Split(CChar("/"))
                        Dim wrkDia As Integer = CInt(wrkDataSplit(0))
                        Dim wrkMes As Integer = CInt(wrkDataSplit(1))
                        Dim wrkAno As Integer = CInt(wrkDataSplit(2))
                        Dim wrkHoraSplit As String() = wrkDataHora.Substring(11, 9).Split(CChar(":"))
                        Dim wrkHora As Integer = CInt(wrkHoraSplit(0))
                        Dim wrkMinuto As Integer = CInt(wrkHoraSplit(1))
                        Dim wrkSegundo As Integer = CInt(wrkHoraSplit(2))

                        Dim wrkDataAgendamento As Date = New Date(wrkAno, wrkMes, wrkDia, wrkHora, wrkMinuto, wrkSegundo)
                        '===========================================

                        'Grava Agendamento
                        Dim objAgendamento As New Agendamentos
                        objAgendamento.ComandoDescricao = "Comando agendado remotamente"
                        objAgendamento.ComandoId = objComando.Id
                        objAgendamento.DataExecucao = wrkDataAgendamento
                        objAgendamento.DataMensagem = Date.Now
                        objAgendamento.EnviadoPor = pEnviadoPor
                        objAgendamento.TipoAgendamento = Agendamentos.TipoAgendamentoEnum.ExecucaoUnica
                        objAgendamento.Gravar()
                        '=================

                    Else
                        'Caso encontre retorna o objeto comando
                        Return objComando
                    End If
                End If
            Next

            'Caso nao tenho encontrado o comando não retorna o objeto
            Return Nothing

        End Function

        Public Function Executa(ByVal pEnviadoPor As String, Optional ByVal pComandoAgendado As Boolean = False) As String
            Dim wrkRetorno As String = String.Empty
            Dim wrkUsuarioLiberado As Boolean = True

            'Verifica se o comando esta ativo
            If Ativo = False Then
                Return "Este comando esta como inativo!"
            End If


            'Valida se não for agendamento
            If Not pComandoAgendado Then
                'Verifica se houver restrição se esta sendo informado o remetente
                If RestricaoUsuarios IsNot Nothing AndAlso RestricaoUsuarios.Count > 0 AndAlso pEnviadoPor = String.Empty Then
                    Return "Necessário informar usuário remetente da mensagem!"
                End If

                'Verifica se o usuário esta dentro da restrição
                If RestricaoUsuarios IsNot Nothing AndAlso RestricaoUsuarios.Count > 0 Then
                    wrkUsuarioLiberado = False
                    Dim wrkUsuario As Usuarios

                    'Passa por cada usuário
                    For Each wrkUsuario In RestricaoUsuarios
                        'Verica e o usuário é valido
                        If wrkUsuario.UsuarioTwitter.ToLower.Trim = pEnviadoPor.ToLower.Trim Then
                            wrkUsuarioLiberado = True
                        End If
                    Next
                End If
            End If

            'Caso esteja apto a executar
            If wrkUsuarioLiberado Then
                Select Case Me.TipoComando
                    Case TipoComandoEnum.LinhaComando
                        'Executa comendo por linha de comando
                        Process.Start(Me.LinhaComando, Me.LinhaComandoParametro)

                        wrkRetorno = String.Format("Comando '{0}' executado com sucesso!", Me.Descricao)
                    Case TipoComandoEnum.MonitoraServico
                        Dim wrkServido As New ServiceProcess.ServiceController(Me.NomeServico)
                        Dim wrkStatus As String = String.Empty

                        Select Case wrkServido.Status
                            Case ServiceProcess.ServiceControllerStatus.ContinuePending
                                wrkStatus = "Esperando para continuar"
                            Case ServiceProcess.ServiceControllerStatus.Paused
                                wrkStatus = "Pausado"
                            Case ServiceProcess.ServiceControllerStatus.PausePending
                                wrkStatus = "Esperando para pausar"
                            Case ServiceProcess.ServiceControllerStatus.Running
                                wrkStatus = "Executando"
                            Case ServiceProcess.ServiceControllerStatus.StartPending
                                wrkStatus = "Esperando para executar"
                            Case ServiceProcess.ServiceControllerStatus.Stopped
                                wrkStatus = "Parado"
                            Case ServiceProcess.ServiceControllerStatus.StopPending
                                wrkStatus = "Esperando para parar"
                        End Select

                        'Formata mensagem de retorno
                        wrkRetorno = String.Format("O Serviço {0} está '{1}'", Me.NomeServico, wrkStatus)
                    Case TipoComandoEnum.EncadeamentoComandos
                        For Each wrkItem As Comandos In ListaComandos
                            wrkItem.Executa(pEnviadoPor)
                        Next
                        wrkRetorno = String.Format("Cadeia de comandos '{0}' executado com sucesso!", Me.Descricao)
                End Select
            End If

            Return wrkRetorno
        End Function

        Public Sub Gravar()
            'Obtem arquivo XML
            Dim wrkXmlDocument As New XmlDocument
            wrkXmlDocument.Load(Diretorio & gArquivoXML)

            Dim wrkLista As XmlNodeList = wrkXmlDocument.SelectNodes("//comandos//comando")

            Dim wrkNode As XmlNode

            If Me.Id > 0 Then
                For Each wrkNode In wrkLista
                    If Me.Id = CInt(wrkNode.SelectSingleNode("id").InnerText.ToString()) Then
                        wrkNode.SelectSingleNode("nome").InnerText = Me.Comando
                        wrkNode.SelectSingleNode("descricao").InnerText = Me.Descricao
                        wrkNode.SelectSingleNode("ativo").InnerText = IIf(Me.Ativo, "1", "0").ToString
                        wrkNode.SelectSingleNode("envia_retorno").InnerText = IIf(Me.EnviaRetorno, "1", "0").ToString
                        wrkNode.SelectSingleNode("restricao_usuarios").InnerText = Me.RestricaoUsuariosString
                        wrkNode.SelectSingleNode("linhacomando").InnerText = Me.LinhaComando
                        wrkNode.SelectSingleNode("tipocomando").InnerText = CInt(Me.TipoComando).ToString
                        wrkNode.SelectSingleNode("nomeservico").InnerText = Me.NomeServico
                        wrkNode.SelectSingleNode("linhacomandoparametro").InnerText = Me.LinhaComandoParametro
                        wrkNode.SelectSingleNode("listacomandos").InnerText = Me.ListaComandosString
                    End If
                Next
            Else
                'Obtem novo Id
                Dim objParametros As IEnumerable(Of Comandos) = BuscaComandos().OrderByDescending(Function(t) t.Id)
                Dim wrkNovoId = CType(objParametros.First(), Comandos).Id
                wrkNovoId += 1
                Me.Id = wrkNovoId

                'Monta a estrutura com as informações
                Dim wrkTexto As New StringBuilder
                wrkTexto.Append(String.Format("<id>{0}</id>", Me.Id))
                wrkTexto.Append(String.Format("<nome>{0}</nome>", Me.Comando))
                wrkTexto.Append(String.Format("<descricao>{0}</descricao>", Me.Descricao))
                wrkTexto.Append(String.Format("<ativo>{0}</ativo>", IIf(Me.Ativo, "1", "0")))
                wrkTexto.Append(String.Format("<data_cadastro>{0}</data_cadastro>", Date.Now))
                wrkTexto.Append(String.Format("<restricao_usuarios>{0}</restricao_usuarios>", Me.RestricaoUsuariosString))
                wrkTexto.Append(String.Format("<envia_retorno>{0}</envia_retorno>", IIf(Me.EnviaRetorno, "1", "0")))
                wrkTexto.Append(String.Format("<linhacomando>{0}</linhacomando>", Me.LinhaComando))
                wrkTexto.Append(String.Format("<tipocomando>{0}</tipocomando>", CInt(Me.TipoComando)))
                wrkTexto.Append(String.Format("<nomeservico>{0}</nomeservico>", Me.NomeServico))
                wrkTexto.Append(String.Format("<linhacomandoparametro>{0}</linhacomandoparametro>", Me.LinhaComandoParametro))
                wrkTexto.Append(String.Format("<listacomandos>{0}</listacomandos>", Me.ListaComandosString))
                '=====================================

                'Seleciona o main
                Dim wrkNewXMLNode As XmlNode = wrkXmlDocument.SelectSingleNode("comandos")
                'Cria o nodo filho
                Dim wrkChildNode As XmlNode = wrkXmlDocument.CreateNode(XmlNodeType.Element, "comando", "")
                'Insere a estrutura com as informções
                wrkChildNode.InnerXml = wrkTexto.ToString
                'Insere o nodo filho no xml
                wrkNewXMLNode.AppendChild(wrkChildNode)

            End If

            'Salva alterações do XML
            wrkXmlDocument.Save(Diretorio & gArquivoXML)
            'Libera objeto
            wrkXmlDocument = Nothing
        End Sub

        Public Sub Excluir()
            'Obtem arquivo XML
            Dim wrkXmlDocument As New XmlDocument
            wrkXmlDocument.Load(Diretorio & gArquivoXML)
            Dim wrkLista As XmlNodeList = wrkXmlDocument.SelectNodes("//comandos//comando")
            Dim wrkNode As XmlNode

            For Each wrkNode In wrkLista
                If Me.Id = CInt(wrkNode.SelectSingleNode("id").InnerText.ToString()) Then
                    wrkNode.ParentNode.RemoveChild(wrkNode)
                End If
            Next

            'Salva alterações do XML
            wrkXmlDocument.Save(Diretorio & gArquivoXML)
            'Libera objeto
            wrkXmlDocument = Nothing

        End Sub

        Public Overrides Function ToString() As String
            Return Descricao
        End Function

    End Class
End Namespace