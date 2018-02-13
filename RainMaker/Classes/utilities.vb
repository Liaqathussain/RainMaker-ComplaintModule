Imports System.Net
Imports System.Text
Imports System.IO

Public Class utilities
    Public Shared roleID As Integer = 0
    Dim objSMS_Service As New SMS_Service.Service1SoapClient

    Public Sub callAPI(ByVal number As String, ByVal message As String)
        Try
            Dim req As HttpWebRequest = HttpWebRequest.Create("http://sms.intellexal.com/api/?username=multinet&password=pakistan123&receiver=" & number & "&msgdata=" & message & "")
            Dim response As WebResponse = req.GetResponse
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Title:="Message Box")
        End Try
    End Sub

    ''' <summary>
    ''' This Function use to send Message by calling api with two argunmets Number and message both in String
    ''' </summary>
    ''' <param name="number"></param>
    ''' <param name="message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 

    Public Function call2api(ByVal Stage As String, ByVal number As String, ByVal message As String, ByVal UserID As Integer) As String

        Try
            Dim client As New System.Net.WebClient()
            client.Headers.Add("content-type", "application/json")
            'set your header here, you can add multiple headers
            Dim result As String = Encoding.ASCII.GetString(client.UploadData("http://sms.intellexal.com/api/?username=multinet&password=pakistan123&receiver=" & number & "&msgdata=" & message & "", "POST", Encoding.[Default].GetBytes("{""receiver"": ""031320"",""msgdata"":""test message""}")))
            Dim reader As New StringReader(result)
            Dim ds As New DataSet
            ds.ReadXml(reader)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Columns(4).ColumnName.Equals("response_Id") Then
                    If ds.Tables(0).Rows(0)("response_Id").Equals(0) Then
                        objSMS_Service.InsertSMSLog(Stage, number, message, "Message Sent", UserID)
                        Return "Message Sent"
                    End If
                Else
                    If ds.Tables(0).Columns(0).ColumnName.Equals("status") Then
                        objSMS_Service.InsertSMSLog(Stage, number, message, ds.Tables(0).Rows(0)("status"), UserID)
                        Return ds.Tables(0).Rows(0)("status")
                    Else
                        objSMS_Service.InsertSMSLog(Stage, number, message, ds.Tables(0).Rows(0)("description"), UserID)
                        Return ds.Tables(0).Rows(0)("description")
                    End If

                End If
            Else
                Return "Message not sent due to some technically problem"
            End If

        Catch ex As Exception
            Return ex.Message


        End Try

    End Function

    Public Function getOFCMessage(ByVal dt As String, ByVal tt As String, ByVal Cname As String, ByVal city As String, ByVal fault As String, ByVal own As String, ByVal esc As String, ByVal Notes As String)
        Dim mesge As String = String.Empty
        Try
            mesge = mesge & "D/T:" & dt & Environment.NewLine
            mesge = mesge & "TT:" & tt & Environment.NewLine
            mesge = mesge & "CName:" & Cname & Environment.NewLine
            mesge = mesge & "City:" & city & Environment.NewLine
            mesge = mesge & "Fault Occ:" & fault & Environment.NewLine
            mesge = mesge & "Own:" & own & Environment.NewLine
            mesge = mesge & "Esc:" & esc & Environment.NewLine
            mesge = mesge & "Notes:" & Notes

        Catch ex As Exception

        End Try
        Return mesge
    End Function

    Public Function GetSessionID() As String
        

    End Function

End Class
