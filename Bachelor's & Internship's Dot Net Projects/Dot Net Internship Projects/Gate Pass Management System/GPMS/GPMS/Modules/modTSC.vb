Module modTSC
    Public Declare Sub openport Lib "tsclib.dll" (ByVal PrinterName As String)
    Public Declare Sub closeport Lib "tsclib.dll" ()
    Public Declare Sub sendcommand Lib "tsclib.dll" (ByVal command_Renamed As String)
    Public Declare Sub setup Lib "tsclib.dll" (ByVal LabelWidth As String, ByVal LabelHeight As String, ByVal Speed As String, ByVal Density As String, ByVal Sensor As String, ByVal Vertical As String, ByVal Offset As String)
    Public Declare Sub downloadpcx Lib "tsclib.dll" (ByVal Filename As String, ByVal ImageName As String)
    Public Declare Sub barcode Lib "tsclib.dll" (ByVal X As String, ByVal Y As String, ByVal CodeType As String, ByVal Height_Renamed As String, ByVal Readable As String, ByVal rotation As String, ByVal Narrow As String, ByVal Wide As String, ByVal Code As String)
    Public Declare Sub printerfont Lib "tsclib.dll" (ByVal X As String, ByVal Y As String, ByVal FontName As String, ByVal rotation As String, ByVal Xmul As String, ByVal Ymul As String, ByVal Content As String)
    Public Declare Sub clearbuffer Lib "tsclib.dll" ()
    Public Declare Sub printlabel Lib "tsclib.dll" (ByVal NumberOfSet As String, ByVal NumberOfCopy As String)
    Public Declare Sub formfeed Lib "tsclib.dll" ()
    Public Declare Sub nobackfeed Lib "tsclib.dll" ()
    Public Declare Sub windowsfont Lib "tsclib.dll" (ByVal X As Short, ByVal Y As Short, ByVal fontheight_Renamed As Short, ByVal rotation As Short, ByVal fontstyle As Short, ByVal fontunderline As Short, ByVal FaceName As String, ByVal TextContent As String)

End Module
