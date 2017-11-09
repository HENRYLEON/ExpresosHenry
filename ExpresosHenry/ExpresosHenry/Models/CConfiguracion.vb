Imports System.Reflection
Imports System.Xml
''' <summary>
''' Config de la aplicación
''' </summary>
Public Class CConfiguracion

#Region "Patron Singleton"
  Private Shared _intanciaCSingleton As CConfiguracion = Nothing

  Public Shared Function getIntancia() As CConfiguracion
    If _intanciaCSingleton Is Nothing Then
      _intanciaCSingleton = New CConfiguracion
    End If
    Return _intanciaCSingleton
  End Function

#End Region


#Region "Atributos"
  Private vg_sOpcionAlmacenamiento As Integer
  Private vg_sPathArchivoClientes As String
  Private vg_sPathArchivoUsuarios As String
  Private vg_sPathArchivoTickes As String
  Private vg_sPathArchivoVehiculos As String
  Private vg_sCadenaConexionSQL As String
  Private vg_xDocConfiguracion As New XmlDocument
  Private vg_sPathArchivoTrace As String
#End Region

#Region "Constructor"
  Public Sub CConfiguracion(ByVal pi_iTipoAlmacenamiento As Integer, ByRef po_sMensaje As String)
    vg_sOpcionAlmacenamiento = pi_iTipoAlmacenamiento
    InicializarConfiguracionXML(po_sMensaje)
  End Sub
#End Region

#Region "Propiedades"
  Public ReadOnly Property OpcionAlmacenamiento() As Integer
    Get
      Return vg_sOpcionAlmacenamiento
    End Get
  End Property

  Public ReadOnly Property PathArchivoClientes() As String
    Get
      Return vg_sPathArchivoClientes
    End Get
  End Property

  Public ReadOnly Property PathArchivoUsuarios() As String
    Get
      Return vg_sPathArchivoUsuarios
    End Get
  End Property

  Public ReadOnly Property PathArchivoTickes() As String
    Get
      Return vg_sPathArchivoTickes
    End Get
  End Property

  Public ReadOnly Property CadenaConexionSQL() As String
    Get
      Return vg_sCadenaConexionSQL
    End Get
  End Property

  Public ReadOnly Property PathArchivoVehiculos() As String
    Get
      Return vg_sPathArchivoVehiculos
    End Get
  End Property

  Public ReadOnly Property PathArchivoTrace() As String
    Get
      Return vg_sPathArchivoTrace
    End Get
  End Property
#End Region

#Region "Inicializar variables"
  Public Function InicializarConfiguracionXML(ByRef po_sMensaje As String) As Boolean
    Dim vl_bRespuesta As Boolean = False
    Dim vl_sPath As String = ""
    Dim vl_xNodo As XmlNode

    Try
      vl_sPath = AssemblyDirectory()
      vl_sPath = vl_sPath.Substring(0, vl_sPath.LastIndexOf("\"))
      vg_xDocConfiguracion.Load(vl_sPath & "\Xmlconfiguration.xml")
      If Not vg_xDocConfiguracion Is Nothing Then
        If vg_xDocConfiguracion.InnerXml.Trim <> "" Then

          vl_xNodo = vg_xDocConfiguracion.SelectSingleNode("//CADENACONEXION")
          If Not vl_xNodo Is Nothing AndAlso vl_xNodo.InnerText <> "" Then
            vg_sCadenaConexionSQL = vl_xNodo.InnerText
            vl_bRespuesta = True
          Else
            po_sMensaje = "No se encontró la configuracion para el archivo de clientes"
            vl_bRespuesta = False
          End If
          vl_xNodo = Nothing

          vl_xNodo = vg_xDocConfiguracion.SelectSingleNode("//PATHCLIENTES")
          If Not vl_xNodo Is Nothing AndAlso vl_xNodo.InnerText <> "" Then
            vg_sPathArchivoClientes = vl_xNodo.InnerText
            vl_bRespuesta = True
          Else
            po_sMensaje = "No se encontró la configuracion para el archivo de clientes"
            vl_bRespuesta = False
          End If
          vl_xNodo = Nothing
          vl_xNodo = vg_xDocConfiguracion.SelectSingleNode("//PATHUSUARIOS")
          If Not vl_xNodo Is Nothing AndAlso vl_xNodo.InnerText <> "" Then
            vg_sPathArchivoUsuarios = vl_xNodo.InnerText
            vl_bRespuesta = True
          Else
            po_sMensaje = "No se encontró la configuracion para el archivo de usuarios"
            vl_bRespuesta = False
          End If
          vl_xNodo = Nothing
          vl_xNodo = vg_xDocConfiguracion.SelectSingleNode("//PATHTICKES")
          If Not vl_xNodo Is Nothing AndAlso vl_xNodo.InnerText <> "" Then
            vg_sPathArchivoTickes = vl_xNodo.InnerText
            vl_bRespuesta = True
          Else
            po_sMensaje = "No se encontró la configuracion para el archivo de tickes"
            vl_bRespuesta = False
          End If
          vl_xNodo = Nothing
          vl_xNodo = vg_xDocConfiguracion.SelectSingleNode("//PATHVEHICULOS")
          If Not vl_xNodo Is Nothing AndAlso vl_xNodo.InnerText <> "" Then
            vg_sPathArchivoVehiculos = vl_xNodo.InnerText
            vl_bRespuesta = True
          Else
            po_sMensaje = "No se encontró la configuracion para el archivo de vehiculos"
            vl_bRespuesta = False
          End If
        Else
          po_sMensaje = "Erro en el archivo de configuración"
          vl_bRespuesta = False
        End If
      Else
        po_sMensaje = "No se encontró en el archivo de configuración"
        vl_bRespuesta = False
      End If
    Catch ex As System.Exception
      po_sMensaje = "Error: " + ex.ToString
      vl_bRespuesta = False
    End Try
    Return vl_bRespuesta
  End Function


  Public Function InicializarConfiguracionSQL(ByRef po_sMensaje As String) As Boolean
    Dim vl_bRespuesta As Boolean = False
    Dim vl_sPath As String = ""
    Dim vl_xNodo As XmlNode
    Try
      vl_sPath = AssemblyDirectory()
      vl_sPath = vl_sPath.Substring(0, vl_sPath.LastIndexOf("\"))
      vg_xDocConfiguracion.Load(vl_sPath & "\Xmlconfiguration.xml")
      If Not vg_xDocConfiguracion Is Nothing Then
        If vg_xDocConfiguracion.InnerXml.Trim <> "" Then

          vl_xNodo = vg_xDocConfiguracion.SelectSingleNode("//CADENACONEXION")
          If Not vl_xNodo Is Nothing AndAlso vl_xNodo.InnerText <> "" Then
            vg_sCadenaConexionSQL = vl_xNodo.InnerText
            vl_bRespuesta = True
          Else
            po_sMensaje = "No se encontró la configuracion para el para la cadena de conexion."
            vl_bRespuesta = False
          End If
        Else
          po_sMensaje = "Erro en el archivo de configuración"
          vl_bRespuesta = False
        End If
      Else
        po_sMensaje = "No se encontró en el archivo de configuración"
        vl_bRespuesta = False
      End If
    Catch ex As System.Exception
      po_sMensaje = "Error: " + ex.ToString
      vl_bRespuesta = False
    End Try
    Return vl_bRespuesta
  End Function
#End Region

#Region "Funciones generales"




  Public Function AssemblyDirectory() As String
    Dim codeBase As String = Assembly.GetExecutingAssembly().CodeBase
    Dim uri__1 As New UriBuilder(codeBase)
    Dim path__2 As String = Uri.UnescapeDataString(uri__1.Path)
    Return path__2.Replace("/", "\")
  End Function
#End Region

End Class
