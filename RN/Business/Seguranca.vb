Imports System
Imports System.Text
Imports System.IO
Imports System.Security.Cryptography

Namespace Business

    Public Class Seguranca
        Public Enum enumCriptoProvider
            Rijndael = 1
            RC2 = 2
            DES = 3
            TripleDES = 4
        End Enum

        Private wrkKey As String = String.Empty
        Private wrkCriptoProvider As enumCriptoProvider
        Private wrkAlgoritmo As SymmetricAlgorithm

        'Cria Vetor de Inicialização
        Private Sub SetIV()
            Select Case wrkCriptoProvider
                Case enumCriptoProvider.Rijndael
                    wrkAlgoritmo.IV = New Byte() {&HCC, &H73, &H4B, &HA8, &HEA, &H9C, &H46, &H5, _
                                                  &HF9, &HCD, &HC2, &H35, &H2E, &H13, &H6F, &HF}
                Case Else
                    wrkAlgoritmo.IV = New Byte() {&HF9, &HCD, &HC2, &H35, &H2E, &H13, &H6F, &HF}
            End Select
        End Sub

        'Chave de Criptografia
        Public Property Key() As String
            Get
                Return wrkKey
            End Get
            Set(ByVal Value As String)
                wrkKey = Value
            End Set
        End Property

        'Inicializa a Classe
        Public Sub New()
            'Como não foi passado nenhum Algoritmo
            wrkAlgoritmo = New RijndaelManaged
            wrkAlgoritmo.Mode = CipherMode.CBC
            wrkCriptoProvider = enumCriptoProvider.Rijndael
        End Sub

        'Inicializa a Classe passando o Tipo de Provedor da Criptografia
        Public Sub New(ByVal pCriptoProvider As enumCriptoProvider)
            Select Case pCriptoProvider
                Case enumCriptoProvider.Rijndael
                    wrkAlgoritmo = New RijndaelManaged
                    wrkCriptoProvider = enumCriptoProvider.Rijndael
                Case enumCriptoProvider.RC2
                    wrkAlgoritmo = New RC2CryptoServiceProvider
                    wrkCriptoProvider = enumCriptoProvider.RC2
                Case enumCriptoProvider.DES
                    wrkAlgoritmo = New DESCryptoServiceProvider
                    wrkCriptoProvider = enumCriptoProvider.DES
                Case enumCriptoProvider.TripleDES
                    wrkAlgoritmo = New TripleDESCryptoServiceProvider
                    wrkCriptoProvider = enumCriptoProvider.TripleDES
            End Select
            wrkAlgoritmo.Mode = CipherMode.CBC
        End Sub

        'Gera uma Chave Aleatória para ser usada na Criptografia
        Private Function GerarKey() As String
            Dim wrkIndice As Integer
            Dim wrkRetorno As String = String.Empty
            Dim wrkNumero As Integer
            Dim wrkRandom As New System.Random

            For wrkIndice = 0 To 32
                wrkNumero = wrkRandom.Next(0, 99)
                wrkRetorno = wrkRetorno + wrkNumero.ToString()
                If wrkRetorno.Length >= 32 Then
                    If wrkRetorno.Length > 32 Then
                        wrkRetorno = wrkRetorno.Substring(0, 32)
                    End If
                    Exit For
                End If
            Next
            Return wrkRetorno
        End Function

        'Pega a Chave gerada
        Public Function GetKey() As Byte()

            Dim wrkSalt As String = String.Empty

            If wrkAlgoritmo.LegalKeySizes.Length > 0 Then
                Dim wrkKeySize As Integer = wrkKey.Length * 8
                Dim wrkMinSize As Integer = wrkAlgoritmo.LegalKeySizes(0).MinSize
                Dim wrkMaxSize As Integer = wrkAlgoritmo.LegalKeySizes(0).MaxSize
                Dim wrkSkipSize As Integer = wrkAlgoritmo.LegalKeySizes(0).SkipSize

                If wrkKeySize > wrkMaxSize Then
                    wrkKey = wrkKey.Substring(0, Convert.ToInt32(wrkMaxSize / 8))
                ElseIf wrkKeySize < wrkMaxSize Then
                    Dim wrkSizeValido As Integer
                    If wrkKeySize <= wrkMinSize Then
                        wrkSizeValido = wrkMinSize
                    Else
                        wrkSizeValido = (wrkKeySize - wrkKeySize Mod wrkSkipSize) + wrkSkipSize
                        If wrkKeySize < wrkSizeValido Then
                            wrkKey = wrkKey.PadRight(Convert.ToInt32(wrkSizeValido / 8), Convert.ToChar("*"))
                        End If
                    End If
                End If
            End If

            If wrkKey.Length = 0 Then
                wrkKey = GerarKey()
            End If

            Dim wrkKeyRetorno As PasswordDeriveBytes = New PasswordDeriveBytes(wrkKey, ASCIIEncoding.ASCII.GetBytes(wrkSalt))
            Return wrkKeyRetorno.GetBytes(wrkKey.Length)
        End Function

        'Encripta a String passada por Parâmetro
        Public Function Encripta(ByVal pString As String) As String
            Dim wrkByte As Byte() = ASCIIEncoding.ASCII.GetBytes(pString)
            Dim wrkKeyByte As Byte() = GetKey()

            wrkAlgoritmo.Key = wrkKeyByte
            SetIV()

            Dim wrkCriptoTransform As ICryptoTransform = wrkAlgoritmo.CreateEncryptor()

            Dim wrkMemoryStream As New MemoryStream
            Dim wrkCriptoStream As New CryptoStream(wrkMemoryStream, wrkCriptoTransform, CryptoStreamMode.Write)

            wrkCriptoStream.Write(wrkByte, 0, wrkByte.Length)
            wrkCriptoStream.FlushFinalBlock()

            Dim wrkCriptoByte As Byte() = wrkMemoryStream.ToArray()

            Return Convert.ToBase64String(wrkCriptoByte, 0, wrkCriptoByte.GetLength(0))
        End Function

        'Decripta a String passada por Parâmetro
        Public Function Decripta(ByVal pString As String) As String
            Dim wrkByte As Byte() = Convert.FromBase64String(pString)
            Dim wrkKeyByte As Byte() = GetKey()

            wrkAlgoritmo.Key = wrkKeyByte
            SetIV()

            Dim wrkCriptoTransform As ICryptoTransform = wrkAlgoritmo.CreateDecryptor()
            Try
                Dim wrkMemoryStream As New MemoryStream(wrkByte, 0, wrkByte.Length)
                Dim wrkCriptoStream As New CryptoStream(wrkMemoryStream, wrkCriptoTransform, CryptoStreamMode.Read)

                Dim wrkStreamReader As New StreamReader(wrkCriptoStream)
                Return wrkStreamReader.ReadToEnd()
            Catch
                Return Nothing
            End Try
        End Function
    End Class
End Namespace