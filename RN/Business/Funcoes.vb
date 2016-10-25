
Namespace Business

    Public Class Funcoes

        Public Shared Function FromTwitterDate(ByVal pData As String) As DateTime
            Dim dayOfWeek As String = pData.Substring(0, 3).Trim
            Dim month As String = pData.Substring(4, 3).Trim
            Dim dayInMonth As String = pData.Substring(8, 2).Trim
            Dim time As String = pData.Substring(11, 9).Trim
            Dim offset As String = pData.Substring(20, 5).Trim
            Dim year As String = pData.Substring(25, 5).Trim
            Dim dateTime As String = String.Format("{0}-{1}-{2} {3}", dayInMonth, month, year, time)
            Dim ret As Date = CDate(dateTime)
            Return ret
        End Function

        Public Shared Function SomenteNumeros(ByVal pValor As String) As String
            Dim wrkInd As Integer = 0
            Dim wrkTemp As Integer = 0
            Dim wrkTemp2 As String = String.Empty

            For wrkInd = 1 To Len(pValor)
                wrkTemp = Asc(Mid(pValor, wrkInd, 1))
                If wrkTemp >= 48 And wrkTemp <= 57 Then
                    wrkTemp2 = wrkTemp2 & Mid(pValor, wrkInd, 1)
                End If
            Next

            Return wrkTemp2

        End Function

        Public Shared Function Encripta(ByVal wrkString As String) As String
            Dim wrkCripto As New Seguranca
            Dim wrkChave As String
            Dim wrkStringEncriptada As String
            'Encripta a String
            wrkStringEncriptada = wrkCripto.Encripta(wrkString)
            'Pega a Chave Gerada
            wrkChave = wrkCripto.Key
            'Retorna a Senha Criptografada
            Return wrkStringEncriptada + wrkChave
        End Function

        Public Shared Function Decripta(ByVal wrkString As String) As String
            Dim wrkCripto As New Seguranca
            'Caso a senha tenha 56 caracteres, significa que pode ter sido criptografada
            If wrkString.Length >= 56 Then
                'Pega a Chave da String criptografada
                wrkCripto.Key = wrkString.Substring(wrkString.Length - 32)
                'Retorna a String Original
                Return wrkCripto.Decripta(wrkString.Substring(0, wrkString.Length - 32))
            End If
            'Caso a palavra não tenha 56 caracteres, significa que não foi criptografada, retorna ela mesma
            Return wrkString
        End Function

        Public Shared Function FormataUsuario(ByVal pUsuario As String) As String
            Dim wrkUsuario As String = pUsuario
            If wrkUsuario <> String.Empty Then
                If wrkUsuario.Substring(0, 1) <> "@" Then
                    wrkUsuario = "@" & wrkUsuario
                End If
            End If

            Return wrkUsuario
        End Function

        Public Shared Sub EscreverLog(ByVal pLinha As String, ByVal pNrNivel As Integer, _
                                      Optional ByVal pPularLinha As Boolean = False)

            Dim wrkProgramaName As String = "ControlePorTwitter"
            Dim wrkProgramaVersion As String = "1.0.1"

            Dim wrkNmArqvLOG As String = System.AppDomain.CurrentDomain.BaseDirectory & "\" & wrkProgramaName & "Log.log"

            If IO.File.Exists(wrkNmArqvLOG) Then
                'verifica tamanho do arquivo
                If FileLen(wrkNmArqvLOG) > (1000 * 1024) Then
                    'maior que 500 k, limpa
                    IO.File.Delete(wrkNmArqvLOG)
                End If
            End If

            Dim wrkStream As New IO.StreamWriter(wrkNmArqvLOG, True, System.Text.Encoding.Default)
            Try
                wrkStream.WriteLine(CType(IIf(pPularLinha, Environment.NewLine, ""), String) & Now.ToShortDateString + " " + Now.ToLongTimeString + " - " + CStr(IIf(wrkProgramaName <> "", wrkProgramaName & " - ", "")) + wrkProgramaVersion + " - " + Space(pNrNivel) + pLinha)
            Finally
                wrkStream.Close()
            End Try

        End Sub
    End Class
End Namespace