Public Class ComboValuePair
    'http://mattly.me/snippet/2009/06/24/vb-net-implement-keyvalue-pairs-in-combobox/
    'This class will enable a key/value relationship with items in a ComboBox.

    'Example: ComboBox1.Items.Add(New DataItem("Key", "Value"))
    'Key is available with ComboBox1.Items.Item(ComboBox1.SelectedIndex).ID
    'Value is available with ComboBox1.Items.Item(ComboBox1.SelectedIndex).Value


    Private _id As String
    Private _value As String

    Public Sub New(ByVal id As String, ByVal value As String)
        _id = id
        _value = value
    End Sub

    Public ReadOnly Property ID() As String
        Get
            Return _id
        End Get
    End Property

    Public ReadOnly Property Value() As String
        Get
            Return _value
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return Value
    End Function
End Class

