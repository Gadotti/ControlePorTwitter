Imports System.Xml
Imports System.IO
Imports System.Text

Namespace AcessoDados

    Public Class Agendamentos
        Public Const gArquivoXML As String = "\Agendamentos.xml"

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
        Public Enum TipoAgendamentoEnum
            ExecucaoUnica = 0
            Diario = 1
        End Enum

        Public Enum TipoHoraEnum
            Fixa
            Intervalo
        End Enum

        Private wrkId As Integer
        Private wrkComandoId As Integer
        Private wrkComandoDescricao As String
        Private wrkDataExecucao As Date
        Private wrkDataMensagem As Date
        Private wrkEnviadoPor As String
        Private wrkTipoAgendamento As TipoAgendamentoEnum
        Private wrkHoraDiaria As Date
        Private wrkDiasSemana As List(Of DayOfWeek)
        Private wrkTipoHora As TipoHoraEnum

        Private wrkDataExecucaoString As String
        Private wrkTipoAgendamentoDescricao As String

        Public Property TipoHora() As TipoHoraEnum
            Get
                Return wrkTipoHora
            End Get
            Set(ByVal value As TipoHoraEnum)
                wrkTipoHora = value
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

        Public Property ComandoId() As Integer
            Get
                Return wrkComandoId
            End Get
            Set(ByVal value As Integer)
                wrkComandoId = value
            End Set
        End Property

        Public Property ComandoDescricao() As String
            Get
                Return wrkComandoDescricao
            End Get
            Set(ByVal value As String)
                wrkComandoDescricao = value
            End Set
        End Property

        Public Property DataExecucao() As Date
            Get
                Return wrkDataExecucao
            End Get
            Set(ByVal value As Date)
                wrkDataExecucao = value
            End Set
        End Property

        Public Property DataMensagem() As Date
            Get
                Return wrkDataMensagem
            End Get
            Set(ByVal value As Date)
                wrkDataMensagem = value
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

        Public Property TipoAgendamento() As TipoAgendamentoEnum
            Get
                Return wrkTipoAgendamento
            End Get
            Set(ByVal value As TipoAgendamentoEnum)
                wrkTipoAgendamento = value
            End Set
        End Property

        Public Property HoraDiaria() As Date
            Get
                Return wrkHoraDiaria
            End Get
            Set(ByVal value As Date)
                wrkHoraDiaria = value
            End Set
        End Property

        Public Property DiasSemana() As List(Of DayOfWeek)
            Get
                Return wrkDiasSemana
            End Get
            Set(ByVal value As List(Of DayOfWeek))
                wrkDiasSemana = value
            End Set
        End Property

        Public ReadOnly Property DataExecucaoString() As String
            Get
                If Me.DataExecucao = Date.MinValue Then
                    Return String.Empty
                Else
                    Return Format(Me.DataExecucao, "dd/MM/yyyy HH:mm:ss")
                End If
            End Get
        End Property

        Public ReadOnly Property TipoAgendamentoDescricao() As String
            Get
                Select Case Me.TipoAgendamento
                    Case TipoAgendamentoEnum.Diario
                        Return "Diário"
                    Case TipoAgendamentoEnum.ExecucaoUnica
                        Return "Execução única"
                    Case Else
                        Return String.Empty
                End Select
            End Get
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

        Public Shared Function BuscaAgendamentos() As List(Of Agendamentos)

            Dim wrkXmlDocument As New XmlDocument
            wrkXmlDocument.LoadXml(File.ReadAllText(BuscaDiretorio() & gArquivoXML))
            Dim wrkLista As XmlNodeList
            wrkLista = wrkXmlDocument.SelectNodes("//agendamentos//agendamento")

            Dim wrkRetorno As New List(Of Agendamentos)
            Dim wrkNode As XmlNode

            For Each wrkNode In wrkLista
                Dim wrkItem As New Agendamentos
                wrkItem.Id = CInt(wrkNode.SelectSingleNode("id").InnerText.ToString())
                wrkItem.ComandoId = CInt(wrkNode.SelectSingleNode("comandoId").InnerText)
                wrkItem.ComandoDescricao = Comandos.Busca(wrkItem.ComandoId).Descricao
                wrkItem.DataExecucao = CDate(wrkNode.SelectSingleNode("dataExecucao").InnerText)
                If wrkNode.SelectSingleNode("dataMensagem").InnerText.Trim <> String.Empty Then
                    wrkItem.DataMensagem = CDate(wrkNode.SelectSingleNode("dataMensagem").InnerText)
                Else
                    wrkItem.DataMensagem = Date.MinValue
                End If
                wrkItem.EnviadoPor = wrkNode.SelectSingleNode("enviadoPor").InnerText.ToString()
                wrkItem.TipoAgendamento = CType(CInt(wrkNode.SelectSingleNode("tipoAgendamento").InnerText), TipoAgendamentoEnum)
                If wrkNode.SelectSingleNode("horaDiaria").InnerText.Trim <> String.Empty Then
                    wrkItem.HoraDiaria = CDate(wrkNode.SelectSingleNode("horaDiaria").InnerText)
                Else
                    wrkItem.HoraDiaria = Date.MinValue
                End If
                wrkItem.DiasSemana = RetornaListaDiasSemana(wrkNode.SelectSingleNode("diasSemana").InnerText)
                wrkItem.TipoHora = CType(CInt(wrkNode.SelectSingleNode("tipoHora").InnerText), TipoHoraEnum)

                wrkRetorno.Add(wrkItem)
            Next

            Return wrkRetorno

        End Function

        Public Sub Gravar()
            'Obtem arquivo XML
            Dim wrkXmlDocument As New XmlDocument
            wrkXmlDocument.Load(Diretorio & gArquivoXML)

            Dim wrkLista As XmlNodeList = wrkXmlDocument.SelectNodes("//agendamentos//agendamento")

            Dim wrkNode As XmlNode

            If Me.Id > 0 Then
                For Each wrkNode In wrkLista
                    If Me.Id = CInt(wrkNode.SelectSingleNode("id").InnerText.ToString()) Then
                        wrkNode.SelectSingleNode("comandoId").InnerText = Me.ComandoId.ToString
                        wrkNode.SelectSingleNode("dataExecucao").InnerText = IIf(Me.DataExecucao = Date.MinValue, String.Empty, Format(Me.DataExecucao, "dd/MM/yyyy HH:mm:ss")).ToString
                        wrkNode.SelectSingleNode("dataMensagem").InnerText = IIf(Me.DataMensagem = Date.MinValue, String.Empty, Format(Me.DataMensagem, "dd/MM/yyyy HH:mm:ss")).ToString
                        wrkNode.SelectSingleNode("enviadoPor").InnerText = Me.EnviadoPor.ToString
                        wrkNode.SelectSingleNode("tipoAgendamento").InnerText = CInt(Me.TipoAgendamento).ToString
                        wrkNode.SelectSingleNode("horaDiaria").InnerText = IIf(Me.HoraDiaria = Date.MinValue, String.Empty, Format(Me.HoraDiaria, "dd/MM/yyyy HH:mm:ss")).ToString
                        wrkNode.SelectSingleNode("diasSemana").InnerText = RetornaStringDiasSemana(Me.DiasSemana)
                        wrkNode.SelectSingleNode("tipoHora").InnerText = CInt(Me.TipoHora).ToString
                    End If
                Next
            Else
                'Obtem novo Id
                Dim objParametros As IEnumerable(Of Agendamentos) = BuscaAgendamentos().OrderByDescending(Function(t) t.Id)
                Dim wrkNovoId As Integer = 0
                If objParametros.Count > 0 Then
                    wrkNovoId = CType(objParametros.First(), Agendamentos).Id
                End If
                wrkNovoId += 1
                Me.Id = wrkNovoId

                'Monta a estrutura com as informações
                Dim wrkTexto As New StringBuilder
                wrkTexto.Append(String.Format("<id>{0}</id>", Me.Id))
                wrkTexto.Append(String.Format("<comandoId>{0}</comandoId>", Me.ComandoId))
                wrkTexto.Append(String.Format("<dataExecucao>{0}</dataExecucao>", IIf(Me.DataExecucao = Date.MinValue, String.Empty, Format(Me.DataExecucao, "dd/MM/yyyy HH:mm:ss"))))
                wrkTexto.Append(String.Format("<dataMensagem>{0}</dataMensagem>", IIf(Me.DataMensagem = Date.MinValue, String.Empty, Format(Me.DataMensagem, "dd/MM/yyyy HH:mm:ss"))))
                wrkTexto.Append(String.Format("<enviadoPor>{0}</enviadoPor>", Me.EnviadoPor))
                wrkTexto.Append(String.Format("<tipoAgendamento>{0}</tipoAgendamento>", CInt(Me.TipoAgendamento)))
                wrkTexto.Append(String.Format("<horaDiaria>{0}</horaDiaria>", IIf(Me.HoraDiaria = Date.MinValue, String.Empty, Format(Me.HoraDiaria, "dd/MM/yyyy HH:mm:ss")).ToString))
                wrkTexto.Append(String.Format("<diasSemana>{0}</diasSemana>", RetornaStringDiasSemana(Me.DiasSemana)))
                wrkTexto.Append(String.Format("<tipoHora>{0}</tipoHora>", CInt(Me.TipoHora)))
                '=====================================

                'Seleciona o main
                Dim wrkNewXMLNode As XmlNode = wrkXmlDocument.SelectSingleNode("agendamentos")
                'Cria o nodo filho
                Dim wrkChildNode As XmlNode = wrkXmlDocument.CreateNode(XmlNodeType.Element, "agendamento", "")
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
            Dim wrkLista As XmlNodeList = wrkXmlDocument.SelectNodes("//agendamentos//agendamento")
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

        Public Shared Function MontaListaDiasSemana(ByVal pDomingo As Boolean, ByVal pSegunda As Boolean, _
                                                    ByVal pTerca As Boolean, ByVal pQuarta As Boolean, _
                                                    ByVal pQuinta As Boolean, ByVal pSexta As Boolean, _
                                                    ByVal pSabado As Boolean) As List(Of DayOfWeek)

            Dim wrkListaRetorno As New List(Of DayOfWeek)
            If pDomingo Then
                wrkListaRetorno.Add(DayOfWeek.Sunday)
            End If
            If pSegunda Then
                wrkListaRetorno.Add(DayOfWeek.Monday)
            End If
            If pTerca Then
                wrkListaRetorno.Add(DayOfWeek.Tuesday)
            End If
            If pQuarta Then
                wrkListaRetorno.Add(DayOfWeek.Wednesday)
            End If
            If pQuinta Then
                wrkListaRetorno.Add(DayOfWeek.Thursday)
            End If
            If pSexta Then
                wrkListaRetorno.Add(DayOfWeek.Friday)
            End If
            If pSabado Then
                wrkListaRetorno.Add(DayOfWeek.Saturday)
            End If

            Return wrkListaRetorno

        End Function

        Private Shared Function RetornaStringDiasSemana(ByVal pListaDias As List(Of DayOfWeek)) As String
            If pListaDias Is Nothing Then
                Return String.Empty
            End If

            Dim wrkListaString As New StringBuilder
            For Each wrkItem As DayOfWeek In pListaDias
                wrkListaString.Append(CInt(wrkItem).ToString & ";")
            Next
            Dim wrkRetorno As String = wrkListaString.ToString
            If wrkRetorno <> String.Empty Then
                Return wrkRetorno.Substring(0, wrkRetorno.Length - 1) 'Retira ultimo ";"
            Else
                Return String.Empty
            End If
        End Function

        Private Shared Function RetornaListaDiasSemana(ByVal pListaDias As String) As List(Of DayOfWeek)

            If pListaDias.Trim <> String.Empty Then
                Dim wrkListaDias As String() = pListaDias.Split(CChar(";"))
                Dim wrkRetorno As New List(Of DayOfWeek)

                For Each wrkItem As String In wrkListaDias
                    Dim wrkItemRetorno As DayOfWeek = CType(wrkItem, DayOfWeek)
                    wrkRetorno.Add(wrkItemRetorno)
                Next

                Return wrkRetorno
            Else
                Return Nothing
            End If

        End Function

    End Class
End Namespace