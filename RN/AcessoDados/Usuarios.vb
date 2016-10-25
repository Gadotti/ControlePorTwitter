Imports System.Xml
Imports System.IO
Imports System.Text

Namespace AcessoDados

    Public Class Usuarios
        Public Const gArquivoXML As String = "\Usuarios.xml"

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
        Private wrkId As Integer
        Private wrkNome As String
        Private wrkUsuarioTwitter As String
        Private wrkEmail As String

        Public Property Email() As String
            Get
                Return wrkEmail
            End Get
            Set(ByVal value As String)
                wrkEmail = value
            End Set
        End Property

        Public Property UsuarioTwitter() As String
            Get
                Return wrkUsuarioTwitter
            End Get
            Set(ByVal value As String)
                wrkUsuarioTwitter = value
            End Set
        End Property

        Public Property Nome() As String
            Get
                Return wrkNome
            End Get
            Set(ByVal value As String)
                wrkNome = value
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


#End Region

        Private Shared Function BuscaDiretorio() As String
            Dim wrkTexto As String = File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory & "\ControlePorTwitter.cfg")
            wrkTexto = wrkTexto.Replace("DiretorioArquivoConfiguracao=", "")
            Return wrkTexto
        End Function

        Public Sub New()
            Diretorio = BuscaDiretorio()
        End Sub

        Public Shared Function BuscaUsuarios() As List(Of Usuarios)
            Dim wrkXmlDocument As New XmlDocument
            wrkXmlDocument.LoadXml(File.ReadAllText(BuscaDiretorio() & gArquivoXML))

            Dim wrkLista As XmlNodeList
            wrkLista = wrkXmlDocument.SelectNodes("//usuarios//usuario")

            Dim wrkRetorno As New List(Of Usuarios)
            Dim wrkNode As XmlNode

            For Each wrkNode In wrkLista
                Dim wrkItem As New Usuarios
                wrkItem.Id = CInt(wrkNode.SelectSingleNode("id").InnerText.ToString())
                wrkItem.Nome = wrkNode.SelectSingleNode("nome").InnerText
                wrkItem.UsuarioTwitter = wrkNode.SelectSingleNode("usuarioTwitter").InnerText
                wrkItem.Email = wrkNode.SelectSingleNode("email").InnerText

                wrkRetorno.Add(wrkItem)
            Next

            Return wrkRetorno
        End Function

        Public Shared Function Busca(ByVal pUsuarioId As Integer) As Usuarios
            Dim wrkXmlDocument As New XmlDocument
            wrkXmlDocument.LoadXml(File.ReadAllText(BuscaDiretorio() & gArquivoXML))

            Dim wrkLista As XmlNodeList
            wrkLista = wrkXmlDocument.SelectNodes("//usuarios//usuario")

            Dim wrkRetorno As Usuarios = Nothing
            Dim wrkNode As XmlNode

            For Each wrkNode In wrkLista
                Dim wrkItem As New Usuarios
                wrkItem.Id = CInt(wrkNode.SelectSingleNode("id").InnerText.ToString())
                If wrkItem.Id = pUsuarioId Then
                    wrkItem.Id = CInt(wrkNode.SelectSingleNode("id").InnerText.ToString())
                    wrkItem.Nome = wrkNode.SelectSingleNode("nome").InnerText
                    wrkItem.UsuarioTwitter = wrkNode.SelectSingleNode("usuarioTwitter").InnerText
                    wrkItem.Email = wrkNode.SelectSingleNode("email").InnerText
                    wrkRetorno = wrkItem
                End If
            Next

            Return wrkRetorno
        End Function

        Public Sub Gravar()
            'Obtem arquivo XML
            Dim wrkXmlDocument As New XmlDocument
            wrkXmlDocument.Load(Diretorio & gArquivoXML)

            Dim wrkLista As XmlNodeList = wrkXmlDocument.SelectNodes("//usuarios//usuario")

            Dim wrkNode As XmlNode

            If Me.Id > 0 Then
                For Each wrkNode In wrkLista
                    If Me.Id = CInt(wrkNode.SelectSingleNode("id").InnerText.ToString()) Then
                        wrkNode.SelectSingleNode("nome").InnerText = Me.Nome
                        wrkNode.SelectSingleNode("usuarioTwitter").InnerText = Me.UsuarioTwitter
                        wrkNode.SelectSingleNode("email").InnerText = Me.Email
                    End If
                Next
            Else
                'Obtem novo Id
                Dim objParametros As IEnumerable(Of Usuarios) = BuscaUsuarios().OrderByDescending(Function(t) t.Id)
                Dim wrkNovoId As Integer = 0
                If objParametros.Count > 0 Then
                    wrkNovoId = CType(objParametros.First(), Usuarios).Id
                End If
                wrkNovoId += 1
                Me.Id = wrkNovoId

                'Monta a estrutura com as informações
                Dim wrkTexto As New StringBuilder
                wrkTexto.Append(String.Format("<id>{0}</id>", Me.Id))
                wrkTexto.Append(String.Format("<nome>{0}</nome>", Me.Nome))
                wrkTexto.Append(String.Format("<usuarioTwitter>{0}</usuarioTwitter>", Me.UsuarioTwitter))
                wrkTexto.Append(String.Format("<email>{0}</email>", Me.Email))
                '=====================================

                'Seleciona o main
                Dim wrkNewXMLNode As XmlNode = wrkXmlDocument.SelectSingleNode("usuarios")
                'Cria o nodo filho
                Dim wrkChildNode As XmlNode = wrkXmlDocument.CreateNode(XmlNodeType.Element, "usuario", "")
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
            Dim wrkLista As XmlNodeList = wrkXmlDocument.SelectNodes("//usuarios//usuario")
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

        Public Function ValidaExclusao() As Boolean
            'Percorre comandos para verifica ser usuário não está informado em algum comando
            For Each wrkComando In Comandos.BuscaComandos()
                If wrkComando.RestricaoUsuarios IsNot Nothing Then
                    For Each wrkUsuario In wrkComando.RestricaoUsuarios
                        If wrkUsuario.UsuarioTwitter = UsuarioTwitter Then
                            Return False
                        End If
                    Next
                End If
            Next

            Return True
        End Function

        Public Overrides Function ToString() As String
            Return UsuarioTwitter
        End Function

    End Class
End Namespace