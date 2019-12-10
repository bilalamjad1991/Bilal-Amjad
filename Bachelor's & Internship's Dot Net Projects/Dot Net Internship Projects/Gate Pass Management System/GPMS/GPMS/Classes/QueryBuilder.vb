Public Enum FieldType
    Numeric = 1
    Text = 2
    DateTime = 3

End Enum
'Public Structure dbField
'    Dim fldName As String
'    Dim fldValue As String
'    Dim fldType As FieldType

'End Structure

Public Class QueryBuilder
    Private sTableName As String
    Private pFilterFieldName As String
    Private pFilterFieldValue As String
    Public pFilter As DatabaseField
    Dim colFields As New System.Collections.Generic.List(Of DatabaseField)    'System.Collections.Generic.List(Of DatabaseField)
    Public WriteOnly Property TableName
        Set(ByVal value)
            sTableName = value
        End Set

    End Property

    Public Sub New(ByVal TableName As String)
        Me.TableName = TableName
        pFilter = New DatabaseField
    End Sub
    Public Sub New()
        pFilter = New DatabaseField
    End Sub
    Public Sub ClearFields()
        colFields.Clear()

    End Sub
    Public Sub AddField(ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldTypeOf As FieldType)
        Dim F As DatabaseField = New DatabaseField(FieldName, FieldValue, FieldTypeOf)
        'F.fldName = FieldName
        'F.fldValue = FieldValue
        'F.fldType = FieldTypeOf
        colFields.Add(F)

    End Sub
    Public Overloads Function RemoveField(ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldTypeOf As FieldType)
        Dim F As DatabaseField = New DatabaseField(FieldName, FieldValue, FieldTypeOf)
        Return colFields.Remove(F)

    End Function
    Public Overloads Function RemoveField(ByVal FieldName As String) As Boolean
        Dim N As Integer = 0
        For Each F As DatabaseField In colFields
            If F.fldName = FieldName Then
                colFields.RemoveAt(N)
                Return True
            End If
            N += 1
        Next
        Return False
    End Function
    Public Function GetInsertQuery() As String
        Dim FieldNamesString As String
        Dim FieldValuesString As String
        Dim S As String
        For Each F As DatabaseField In colFields
            FieldNamesString += F.fldName & ", "
            FieldValuesString += IIf(F.fldType = FieldType.Numeric, F.fldValue, "'" & F.fldValue & "'") & ", "

        Next
        FieldNamesString = "(" & Mid(FieldNamesString, 1, Len(FieldNamesString) - 2) & ")"
        FieldValuesString = "(" & Mid(FieldValuesString, 1, Len(FieldValuesString) - 2) & ")"
        S = "INSERT INTO " & sTableName & " " & FieldNamesString & " VALUES " & FieldValuesString
        Return S

    End Function
    Public Overloads Function GetUpdateQuery() As String
        Dim S As String
        Dim S1 As String
        If IsNothing(pFilter) Then
            MsgBox("Please set the InsertDeleteFilter")
            Return ""
        End If
        S = "UPDATE " & sTableName & " SET "
        For Each F As DatabaseField In colFields
            S1 += F.fldName & " = " & IIf(F.fldType = FieldType.Numeric, F.fldValue, "'" & F.fldValue & "'") & ", "

        Next
        S1 = Mid(S1, 1, Len(S1) - 2)
        S1 += " WHERE " & pFilter.fldName & " = " & IIf(pFilter.fldType = FieldType.Numeric, pFilter.fldValue, "'" & pFilter.fldValue & "'")
        Return S & " " & S1
    End Function
    Public Overloads Function GetUpdateQuery(ByVal Criteria As String) As String
        Dim S As String
        Dim S1 As String
        S = "UPDATE " & sTableName & " SET "
        For Each F As DatabaseField In colFields
            S1 += F.fldName & " = " & IIf(F.fldType = FieldType.Numeric, F.fldValue, "'" & F.fldValue & "'") & ", "

        Next
        S1 = Mid(S1, 1, Len(S1) - 2)
        S1 += Criteria
        Return S & " " & S1
    End Function
    Public Sub InsertDeleteFilterField(ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldTypeOf As FieldType)
        pFilter.fldName = FieldName
        pFilter.fldValue = FieldValue
        pFilter.fldType = FieldType.Text

    End Sub
    'Public Property FilterFieldName As String
    '    Get
    '        Return pFilterFieldName
    '    End Get
    '    Set(ByVal value As String)
    '        pFilterFieldName = value
    '    End Set
    'End Property
    'Public Property FilterFieldValue As String
    '    Get
    '        Return pFilterFieldValue
    '    End Get
    '    Set(ByVal value As String)
    '        pFilterFieldValue = value
    '    End Set
    'End Property
End Class

Public Class DatabaseField
    Private pName As String
    Private fValue As String
    Private fType As FieldType
    Public Sub New(ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldType As FieldType)
        Me.fldName = FieldName
        Me.fldValue = FieldValue
        Me.fldType = FieldType
    End Sub
    Public Sub New()

    End Sub
    Public Property fldName As String
        Get
            Return pName
        End Get
        Set(ByVal NewValue As String)
            pName = NewValue
        End Set
    End Property
    Public Property fldValue As String
        Get
            Return fValue
        End Get
        Set(ByVal NewValue As String)
            fValue = NewValue
        End Set
    End Property
    Public Property fldType As FieldType
        Get
            Return fType
        End Get
        Set(ByVal NewValue As FieldType)
            fType = NewValue
        End Set
    End Property
End Class

