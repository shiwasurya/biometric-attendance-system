Imports System.Data.SqlClient

Public Class DataBaseModel
    Private connectionstring As String
    Public Sub New()
        connectionstring = My.Settings.InterNICDb
    End Sub
    Public Function ExecuteDataTable(ByVal sql As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter(sql, connectionstring)           
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        Return dt
    End Function
End Class
