Imports System.Xml
Imports System.IO
Imports RN.Business

Namespace AcessoDados

    Public Class Parametros

        Private Const gArquivoXML As String = "\Parametros.xml"

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
        Public Enum TipoLeituraMsg
            Publicas
            Diretas
        End Enum

        Private wrkUltimaMsgId As String
        Private wrkSenha As String
        Private wrkIntervalo As Integer
        Private wrkMensagens As TipoLeituraMsg
        Private wrkUsuario As String

        Public Property Usuario() As String
            Get
                Return wrkUsuario
            End Get
            Set(ByVal value As String)
                wrkUsuario = value
            End Set
        End Property

        Public Property Mensagens() As TipoLeituraMsg
            Get
                Return wrkMensagens
            End Get
            Set(ByVal value As TipoLeituraMsg)
                wrkMensagens = value
            End Set
        End Property

        Public Property Intervalo() As Integer
            Get
                Return wrkIntervalo
            End Get
            Set(ByVal value As Integer)
                wrkIntervalo = value
            End Set
        End Property

        Public Property Senha() As String
            Get
                Return wrkSenha
            End Get
            Set(ByVal value As String)
                wrkSenha = value
            End Set
        End Property

        Public Property UltimaMsgId() As String
            Get
                Return wrkUltimaMsgId
            End Get
            Set(ByVal value As String)
                'Grava no arquivo XML o valor também
                Dim wrkXmlDocument As New XmlDocument
                wrkXmlDocument.Load(Diretorio & gArquivoXML)
                wrkXmlDocument.SelectSingleNode("//parametros//UltimaMsgId").InnerText = value
                wrkXmlDocument.Save(Diretorio & gArquivoXML)
                wrkXmlDocument = Nothing

                wrkUltimaMsgId = value
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

        Public Shared Function BuscaParametros() As Parametros

            Dim wrkXmlDocument As New XmlDocument
            wrkXmlDocument.LoadXml(File.ReadAllText(BuscaDiretorio() & gArquivoXML))

            Dim wrkRetorno As New Parametros
            wrkRetorno.Usuario = Funcoes.FormataUsuario(wrkXmlDocument.SelectSingleNode("//parametros//Usuario").InnerText)
            wrkRetorno.wrkUltimaMsgId = wrkXmlDocument.SelectSingleNode("//parametros//UltimaMsgId").InnerText
            wrkRetorno.Intervalo = CInt(wrkXmlDocument.SelectSingleNode("//parametros//Intervalo").InnerText)
            wrkRetorno.Mensagens = CType(wrkXmlDocument.SelectSingleNode("//parametros//Mensagens").InnerText, TipoLeituraMsg)
            wrkRetorno.Senha = Funcoes.Decripta(wrkXmlDocument.SelectSingleNode("//parametros//Senha").InnerText)

            Return wrkRetorno

        End Function

        Public Sub Gravar()
            Dim wrkXmlDocument As New XmlDocument
            wrkXmlDocument.LoadXml(File.ReadAllText(Diretorio & gArquivoXML))

            Dim wrkRetorno As New Parametros
            wrkXmlDocument.SelectSingleNode("//parametros//Usuario").InnerText = Funcoes.FormataUsuario(Usuario.ToString)
            wrkXmlDocument.SelectSingleNode("//parametros//Intervalo").InnerText = Intervalo.ToString
            wrkXmlDocument.SelectSingleNode("//parametros//Mensagens").InnerText = CInt(Mensagens).ToString
            wrkXmlDocument.SelectSingleNode("//parametros//Senha").InnerText = Funcoes.Encripta(Senha)

            'Salva alterações do XML
            wrkXmlDocument.Save(Diretorio & gArquivoXML)
            'Libera objeto
            wrkXmlDocument = Nothing

        End Sub


    End Class
End Namespace