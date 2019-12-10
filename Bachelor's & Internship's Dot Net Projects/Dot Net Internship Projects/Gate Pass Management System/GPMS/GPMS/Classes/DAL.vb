Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace DAL
    Public Class DAL        
        Public Enum DataMode
            SavedRecord = 1
            NewRecord = 2
            EditRecord = 3
        End Enum

        Private m_ConStr As String
        Private m_ServerName As String
        Private m_DBName As String
        Private m_UserName As String
        Private m_Password As String

        Public Sub New()

            m_ServerName = My.Settings.Server
            m_DBName = My.Settings.Database
            m_UserName = My.Settings.UserName
            m_Password = My.Settings.Password
            m_ConStr =
                      "Server=" & m_ServerName & ";" & _
                      "Database=" & m_DBName & ";" & _
                      "UID=" & m_UserName & ";" & _
                      "Pwd=" & m_Password & ";" & _
                      "Persist Security Info=True;"
            'Debug.Print(m_ConStr)

        End Sub
        Public ReadOnly Property ConStr() As String
            Get
                Return m_ConStr
            End Get
        End Property
        Public ReadOnly Property ServerName() As String
            Get
                Return m_ServerName
            End Get
        End Property
        Public ReadOnly Property DBName() As String
            Get
                Return m_DBName
            End Get
        End Property
        Public ReadOnly Property UserName() As String
            Get
                Return m_UserName
            End Get
        End Property
        Public ReadOnly Property Password() As String
            Get
                Return m_Password
            End Get
        End Property
        Private Sub OpenConnection(ByRef objSqlConnection As SqlConnection)
            Try
                objSqlConnection.ConnectionString = Me.ConStr
                objSqlConnection.Open()
            Catch ex As Exception
                MsgBox("Error" & vbCrLf & ex.Message & vbCrLf & ex.Source, MsgBoxStyle.Critical, CName)
                End
            End Try

        End Sub
        Public Function GetDataTable(ByVal strSql As String) As DataTable
            Dim objSqlConnection As New SqlConnection
            Dim objSqlCommand As SqlCommand
            Dim objDataTable As New DataTable
            Dim objSqlDataAdapter As SqlDataAdapter

            Try
                Me.OpenConnection(objSqlConnection)
                objSqlCommand = New SqlCommand(strSql, objSqlConnection)
                objSqlDataAdapter = New SqlDataAdapter(objSqlCommand)
                objSqlDataAdapter.Fill(objDataTable)
                Return objDataTable
            Catch ex As Exception
                Throw ex
            Finally
                objSqlCommand.Dispose()
                objSqlDataAdapter.Dispose()
                objSqlConnection.Close()
            End Try

        End Function
        Public Function GetDataTableWithName(ByVal strSql As String, ByVal tName As String) As DataTable
            Dim objSqlConnection As New SqlConnection
            Dim objSqlCommand As SqlCommand
            Dim objDataTable As New DataTable
            Dim objSqlDataAdapter As SqlDataAdapter
            objDataTable.TableName = tName
            Try
                Me.OpenConnection(objSqlConnection)
                objSqlCommand = New SqlCommand(strSql, objSqlConnection)
                objSqlDataAdapter = New SqlDataAdapter(objSqlCommand)
                objSqlDataAdapter.Fill(objDataTable)
                Return objDataTable
            Catch ex As Exception
                Throw ex
            Finally
                objSqlCommand.Dispose()
                objSqlDataAdapter.Dispose()
                objSqlConnection.Close()
            End Try

        End Function
        Protected Function GetDataReader(ByVal strSql As String) As SqlDataReader
            Dim objSqlConnection As New SqlConnection
            Dim objSqlCommand As SqlCommand
            Dim objSqlDataReader As SqlDataReader
            Try
                Me.OpenConnection(objSqlConnection)
                objSqlCommand = New SqlCommand(strSql, objSqlConnection)
                objSqlDataReader = objSqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
                Return objSqlDataReader
            Catch ex As Exception
                Throw ex
            Finally
                objSqlCommand.Dispose()

                objSqlConnection.Close()
            End Try


        End Function

        Public Function GetScaler(ByVal strSql As String) As String
            Dim objSqlConnection As New SqlConnection
            Dim objSqlCommand As SqlCommand
            Dim strReturned

            Try
                Me.OpenConnection(objSqlConnection)
                objSqlCommand = New SqlCommand(strSql, objSqlConnection)
                strReturned = objSqlCommand.ExecuteScalar()
                If IsDBNull(strReturned) Then
                    Return ""
                Else
                    Return strReturned
                End If


            Catch ex As Exception
                'Throw ex
                MsgBox(ex.ToString, MsgBoxStyle.Critical, CName)
            Finally
                objSqlCommand.Dispose()
                objSqlConnection.Close()
            End Try

        End Function

        Public Overloads Function IsRecordExists(ByVal TableName As String, ByVal FieldName As String, ByVal ValueToCompare As Integer) As Boolean
            Dim strSql As String
            Dim objDataTable As New DataTable

            Try
                strSql = "Select * from " & TableName & " where " & FieldName & " = " & ValueToCompare
                objDataTable = GetDataTable(strSql)
                If objDataTable.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            End Try

        End Function
        Public Overloads Function IsRecordExists(ByVal TableName As String, ByVal FieldName As String, ByVal ValueToCompare As String) As Boolean
            Dim strSql As String
            Dim objDataTable As New DataTable

            Try
                strSql = "Select * from " & TableName & " where " & FieldName & " = '" & ValueToCompare & "'"
                objDataTable = GetDataTable(strSql)
                If objDataTable.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            End Try

        End Function
        Public Overloads Function IsRecordExists(ByVal TableName As String, ByVal FieldName As String, ByVal ValueToCompare As Date) As Boolean
            Dim strSql As String
            Dim objDataTable As New DataTable

            Try
                strSql = "Select * from " & TableName & " where " & FieldName & " = '" & ValueToCompare & "'"
                objDataTable = GetDataTable(strSql)
                If objDataTable.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            End Try

        End Function
        Public Overloads Function IsRecordExists(ByVal strSql As String) As Boolean
            Dim objDataTable As New DataTable
            Try
                objDataTable = GetDataTable(strSql)
                If objDataTable.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            End Try

        End Function
        Public Function GetCurrentId(ByVal TableName As String) As Long
            Dim objDataTable As New DataTable
            Dim strSql As String

            Try

                ' Define the query for getting newly added Id
                strSql = "Select IDENT_CURRENT('" & TableName & "') "
                objDataTable = GetDataTable(strSql)
                If objDataTable.Rows.Count > 0 Then
                    Return objDataTable.Rows(0).Item(0)
                Else
                    Return 0
                End If
            Catch ex As Exception
                Throw ex
            End Try

        End Function
        Public Sub ExecuteNonQuery(ByVal strSql As String)
            Dim objSqlConnection As New SqlConnection
            Dim objSqlCommand As SqlCommand

            Try
                Me.OpenConnection(objSqlConnection)
                objSqlCommand = New SqlCommand(strSql, objSqlConnection)
                objSqlCommand.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
                ' Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            Finally
                objSqlCommand.Dispose()
                objSqlConnection.Close()
            End Try

        End Sub

        'Public ReadOnly Property GetReportLoginInfo() As CrystalDecisions.Shared.TableLogOnInfo
        '    Get
        '        Dim L As New CrystalDecisions.Shared.TableLogOnInfo
        '        Dim C As New CrystalDecisions.Shared.ConnectionInfo
        '        C.ServerName = Me.ServerName
        '        C.DatabaseName = Me.DBName
        '        C.UserID = Me.UserName
        '        C.Password = Me.Password
        '        L.ConnectionInfo = C
        '        Return (L)
        '    End Get

        'End Property

    End Class

End Namespace

