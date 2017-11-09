Public Class CCarpeta

#Region "Atributos"
  Private vl_sPath As String
  Private vl_sName As String
#End Region

#Region "Constructor"
  Public Sub CCarpeta(ByVal pi_sPath As String, pi_sName As String)
    vl_sPath = pi_sPath
    vl_sName = pi_sName
  End Sub
#End Region


  Public Property Path() As String
    Get
      Return vl_sPath
    End Get
    Set(value As String)
      vl_sPath = value
    End Set
  End Property


End Class
