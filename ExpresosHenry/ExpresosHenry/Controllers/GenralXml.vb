Imports System.Reflection
Imports System.Xml
Imports System.IO
Imports System.Configuration
Imports System.Collections.Specialized
Imports System.Linq



Public Class GenralXml

    Private vg_sRaiz As String = "<?xml version=1.0 encoding=UTF-8 ?>"

#Region "Patron Singleton"
    Private Shared _intanciaCSingleton As GenralXml = Nothing

    Public Shared Function getIntancia() As GenralXml
        If _intanciaCSingleton Is Nothing Then
            _intanciaCSingleton = New GenralXml
        End If
        Return _intanciaCSingleton
    End Function

#End Region

#Region "Constructor"
    Private Sub New()

    End Sub
#End Region

#Region "Clientes"
    Public Function AddCliente(ByVal pi_oCliente As CCliente, ByRef po_sMensaje As String) As Boolean
        Dim vl_bRespuesta As Boolean = False
        Dim vl_xNodo As XmlElement = Nothing
        Dim vl_xNodoCliente As XmlElement = Nothing
        Dim vl_xAtributo As XmlAttribute = Nothing
        Dim vl_xNodoInsert As XmlNode = Nothing
        Dim vl_xDocClientes As New XmlDocument
        Try
            If Not pi_oCliente Is Nothing Then

                If File.Exists(mod_General.vg_sPathArchivoClientes) Then
                    vl_xDocClientes.Load(mod_General.vg_sPathArchivoClientes)
                Else
                    Dim vl_xXmldecl As XmlDeclaration
                    vl_xXmldecl = vl_xDocClientes.CreateXmlDeclaration("1.0", Nothing, Nothing)
                    vl_xDocClientes.AppendChild(vl_xXmldecl)
                    vl_xDocClientes.LoadXml("<Clientes></Clientes>")
                    vl_xDocClientes.Save(mod_General.vg_sPathArchivoClientes)
                End If
                If vl_xDocClientes.SelectSingleNode("Clientes") Is Nothing Then
                    vl_xDocClientes.CreateElement("<Clientes></Clientes>")

                End If

                vl_xNodoInsert = vl_xDocClientes.DocumentElement

                ArmaNodoCliente(pi_oCliente, vl_xNodoCliente, vl_xDocClientes, po_sMensaje)

                If Not vl_xNodoCliente Is Nothing Then
                    If vl_xDocClientes.SelectSingleNode("Cliente") Is Nothing Then
                        vl_xNodoInsert.AppendChild(vl_xNodoCliente)
                        vl_xDocClientes.Save(mod_General.vg_sPathArchivoClientes)
                        vl_bRespuesta = True
                    End If
                End If
            End If
        Catch ex As System.Exception
            po_sMensaje = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function
    Public Sub ArmaNodoCliente(ByVal pi_oCliente As CCliente, ByRef po_xNodo As XmlElement, ByRef po_DocXml As XmlDocument,
                        ByRef po_sMensaje As String)
        Dim vl_xNodo As XmlElement = Nothing
        Dim vl_xAtributo As XmlAttribute = Nothing
        Try
            po_xNodo = po_DocXml.CreateElement("Cliente")
            vl_xAtributo = po_DocXml.CreateAttribute("Id")
            vl_xAtributo.Value = pi_oCliente.IdPersona
            po_xNodo.SetAttribute("Id", vl_xAtributo.InnerText)
            po_DocXml.DocumentElement.AppendChild(po_xNodo)
            vl_xAtributo = Nothing

            ArmaNodoPersona(pi_oCliente, po_xNodo, po_DocXml, po_sMensaje)

        Catch ex As Exception
            po_sMensaje = "Error: " + ex.ToString
        End Try
    End Sub


    Public Function ReturnCliente(ByVal pi_sIdCliente As String, ByRef po_sMensajeEx As String) As CCliente
        Dim vl_sPath As String = ""
        Dim vl_xDocClientes As New XmlDocument
        Dim vl_oCliente As New CCliente
        Dim vl_xNodoCliente As XmlNode
        Dim vl_dFechaNacimiento As Date
        Dim vl_oListParametros As New List(Of String)
        Try
            vl_xDocClientes.Load(vg_sPathArchivoClientes)
            If vl_xDocClientes.SelectNodes("//Cliente").Count = 0 Then
                Return Nothing
            Else
                If Not vl_xDocClientes.SelectSingleNode("//Cliente[@Id='" & pi_sIdCliente & "']") Is Nothing Then
                    vl_xNodoCliente = vl_xDocClientes.SelectSingleNode("//Cliente[@Id='" & pi_sIdCliente & "']")
                    vl_oListParametros.Add(vl_xNodoCliente.SelectSingleNode("Identificacion").InnerText.ToString)
                    vl_oListParametros.Add(vl_xNodoCliente.SelectSingleNode("Identificacion").Attributes("Tipo").Value.ToString)
                    vl_oListParametros.Add(vl_xNodoCliente.SelectSingleNode("Nombres").InnerText.ToString)
                    vl_oListParametros.Add(vl_xNodoCliente.SelectSingleNode("Apellidos").InnerText.ToString)
                    vl_oListParametros.Add(vl_xNodoCliente.SelectSingleNode("Sexo").InnerText.ToString)
                    vl_oListParametros.Add(vl_xNodoCliente.SelectSingleNode("Estatura").InnerText.ToString)
                    vl_oListParametros.Add(vl_xNodoCliente.SelectSingleNode("NacionalidadPersona").InnerText.ToString)
                    vl_dFechaNacimiento = CDate(vl_xNodoCliente.SelectSingleNode("FechaNacimiento").InnerText.ToString)
                    vl_oCliente.CCliente(pi_sIdCliente, vl_oListParametros(0), vl_oListParametros(1), vl_oListParametros(2), vl_oListParametros(3),
                                         vl_dFechaNacimiento, vl_oListParametros(4), vl_oListParametros(5), vl_oListParametros(6))
                    Return vl_oCliente
                Else
                    Return Nothing
                End If
            End If
        Catch ex As System.Exception
            po_sMensajeEx = "Error: " + ex.ToString
            Return Nothing
        End Try
    End Function

    Public Function ReturnListClientes(ByRef po_sMensajeEx As String) As LinkedList(Of CCliente)
        Dim vl_sPath As String = ""
        Dim vl_xDocClientes As New XmlDocument
        Dim vl_oListaClientes As New LinkedList(Of CCliente)
        Dim vl_oCliente As CCliente
        Dim vl_xNodoCliente As XmlNode
        Dim vl_dFechaNacimiento As Date
        Dim vl_oListParametros As New List(Of String)

        Try
            If File.Exists(mod_General.vg_sPathArchivoClientes) Then
                vl_xDocClientes.Load(mod_General.vg_sPathArchivoClientes)
                If Not vl_xDocClientes.SelectNodes("//Cliente") Is Nothing Then

                    For Each vl_xNodoCliente In vl_xDocClientes.SelectNodes("//Cliente")
                        vl_oCliente = New CCliente
                        vl_oListParametros.Add(vl_xNodoCliente.Attributes("Id").Value.ToString)
                        vl_oListParametros.Add(vl_xNodoCliente.SelectSingleNode("Identificacion").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoCliente.SelectSingleNode("Identificacion").Attributes("Tipo").Value.ToString)
                        vl_oListParametros.Add(vl_xNodoCliente.SelectSingleNode("Nombres").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoCliente.SelectSingleNode("Apellidos").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoCliente.SelectSingleNode("Sexo").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoCliente.SelectSingleNode("Estatura").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoCliente.SelectSingleNode("NacionalidadPersona").InnerText.ToString)
                        vl_dFechaNacimiento = CDate(vl_xNodoCliente.SelectSingleNode("FechaNacimiento").InnerText.ToString)
                        vl_oCliente.CCliente(vl_oListParametros(0), vl_oListParametros(1), vl_oListParametros(2), vl_oListParametros(3), vl_oListParametros(4),
                                 vl_dFechaNacimiento, vl_oListParametros(5), vl_oListParametros(6), vl_oListParametros(7))
                        vl_oListaClientes.AddLast(vl_oCliente)
                        vl_oListParametros.Clear()
                        vl_oCliente = Nothing
                    Next
                End If
            End If
            Return vl_oListaClientes
        Catch ex As System.Exception
            po_sMensajeEx = "Error: " + ex.ToString
            Return Nothing
        End Try
    End Function

    Public Function ValidarCliente(ByVal pi_sIdCliente As String, ByRef po_sMensajeEx As String) As Boolean
        Dim vl_sPath As String = ""
        Dim vl_bRespuesta As Boolean = False
        Dim vl_xDocClientes As New XmlDocument
        Try
            vl_xDocClientes.Load(vg_sPathArchivoClientes)
            If Not vl_xDocClientes.SelectNodes("//Cliente").Count = 0 Then
                If Not vl_xDocClientes.SelectSingleNode("//Cliente[@Id='" & pi_sIdCliente & "']") Is Nothing Then
                    vl_bRespuesta = True
                Else
                    vl_bRespuesta = False
                End If
            Else
                vl_bRespuesta = False
            End If
        Catch ex As System.Exception
            po_sMensajeEx = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

    Public Function DeleteCliente(ByVal pi_sIdCliente As String, ByRef po_sMensajeEx As String) As Boolean
        Dim vl_sPath As String = ""
        Dim vl_xDocClientes As New XmlDocument
        Dim vl_oCliente As New CCliente
        Dim vl_xNodoCliente As XmlNode
        Dim vl_xPadre As XmlNode
        Dim vl_bRespuesta As Boolean = False
        Try
            vl_xDocClientes.Load(vg_sPathArchivoClientes)
            If Not vl_xDocClientes.SelectNodes("//Cliente") Is Nothing Then
                vl_xPadre = vl_xDocClientes.SelectSingleNode("/Clientes")
                If Not vl_xDocClientes.SelectSingleNode("//Cliente[@Id='" & pi_sIdCliente & "']") Is Nothing Then
                    vl_xNodoCliente = vl_xDocClientes.SelectSingleNode("//Cliente[@Id='" & pi_sIdCliente & "']")
                    vl_xPadre.RemoveChild(vl_xNodoCliente)
                    vl_xDocClientes.Save(vg_sPathArchivoClientes)
                    vl_bRespuesta = True
                Else
                    vl_bRespuesta = False
                End If
            Else
                vl_bRespuesta = False
            End If
        Catch ex As Exception
            po_sMensajeEx = "Error: " + ex.ToString
        End Try
        Return vl_bRespuesta
    End Function


    Public Function UpDateCliente(pi_sIdPersona As String, ByVal pi_sIdentificacion As String, pi_sTipoIdentificacion As String, ByVal pi_sNombre As String,
                              ByVal pi_sApellido As String, ByVal pi_dFechaNacimiento As Date, ByVal pi_sSexo As String, ByVal pi_sEstatura As String,
                              ByVal pi_sNacionalidad As String, ByRef po_sMensajeEx As String) As Boolean
        Dim vl_sPath As String = ""
        Dim vl_xDocClientes As New XmlDocument
        Dim vl_oCliente As New CCliente
        Dim vl_xNodoCliente As XmlNode
        Dim vl_bRespuesta As Boolean = False
        Try
            vl_xDocClientes.Load(vg_sPathArchivoClientes)
            If Not vl_xDocClientes.SelectNodes("//Cliente") Is Nothing Then
                If Not vl_xDocClientes.SelectSingleNode("//Cliente[@Id='" & pi_sIdPersona & "']") Is Nothing Then
                    vl_xNodoCliente = vl_xDocClientes.SelectSingleNode("//Cliente[@Id='" & pi_sIdPersona & "']")
                    If Not pi_sTipoIdentificacion = String.Empty Then
                        vl_xNodoCliente.SelectSingleNode("Identificacion").Attributes("Tipo").Value = pi_sTipoIdentificacion
                    End If
                    If Not pi_sIdentificacion = String.Empty Then
                        vl_xNodoCliente.SelectSingleNode("Identificacion").InnerText = pi_sIdentificacion
                    End If
                    If Not pi_sNombre = String.Empty Then
                        vl_xNodoCliente.SelectSingleNode("Nombres").InnerText = pi_sNombre
                    End If
                    If Not pi_sApellido = String.Empty Then
                        vl_xNodoCliente.SelectSingleNode("Apellidos").InnerText = pi_sApellido
                    End If
                    If Not Format(pi_dFechaNacimiento.Date, "yyyy/MM/dd").ToString() = String.Empty Then
                        vl_xNodoCliente.SelectSingleNode("FechaNacimiento").InnerText = Format(pi_dFechaNacimiento.Date, "yyyy/MM/dd").ToString()
                    End If
                    If Not pi_sSexo = String.Empty Then
                        vl_xNodoCliente.SelectSingleNode("Sexo").InnerText = pi_sSexo
                    End If
                    If Not pi_sEstatura = String.Empty Then
                        vl_xNodoCliente.SelectSingleNode("Estatura").InnerText = pi_sEstatura
                    End If
                    If Not pi_sNacionalidad = String.Empty Then
                        vl_xNodoCliente.SelectSingleNode("NacionalidadPersona").InnerText = pi_sNacionalidad
                    End If
                    vl_xDocClientes.Save(vg_sPathArchivoClientes)
                    vl_bRespuesta = True
                Else
                    vl_bRespuesta = False
                End If
            Else
                vl_bRespuesta = False
            End If
        Catch ex As Exception
            po_sMensajeEx = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

#End Region

#Region "Vehiculo"


    Public Function AddVehiculo(ByVal pi_oVehiculo As CVehiculo, ByRef po_sMensaje As String) As Boolean
        Dim vl_bRespuesta As Boolean = False
        Dim vl_sPath As String = ""
        Dim vl_xNodo As XmlElement = Nothing
        Dim vl_xNodoVehiculo As XmlElement = Nothing
        Dim vl_xAtributo As XmlAttribute = Nothing
        Dim vl_xNodoInsert As XmlNode = Nothing
        Dim vl_xDocVehiculos As New XmlDocument

        Try
            If Not pi_oVehiculo Is Nothing Then

                If File.Exists(mod_General.vg_sPathArchivoVehiculos) Then
                    vl_xDocVehiculos.Load(mod_General.vg_sPathArchivoVehiculos)
                Else
                    Dim vl_xXmldecl As XmlDeclaration
                    vl_xXmldecl = vl_xDocVehiculos.CreateXmlDeclaration("1.0", Nothing, Nothing)
                    vl_xDocVehiculos.AppendChild(vl_xXmldecl)
                    vl_xDocVehiculos.LoadXml("<Vehiculos></Vehiculos>")
                    vl_xDocVehiculos.Save(mod_General.vg_sPathArchivoVehiculos)
                End If
                If vl_xDocVehiculos.SelectSingleNode("Vehiculos") Is Nothing Then
                    vl_xDocVehiculos.CreateElement("<Vehiculos></Vehiculos>")

                End If
                vl_xNodoInsert = vl_xDocVehiculos.DocumentElement
                ArmaNodoVehiculo(pi_oVehiculo, vl_xNodoVehiculo, vl_xDocVehiculos, po_sMensaje)
                If Not vl_xNodoVehiculo Is Nothing Then
                    If vl_xDocVehiculos.SelectSingleNode("Vehiculo") Is Nothing Then
                        vl_xNodoInsert.AppendChild(vl_xNodoVehiculo)
                        vl_xDocVehiculos.Save(mod_General.vg_sPathArchivoVehiculos)
                        vl_bRespuesta = True
                    End If
                End If
            End If
        Catch ex As System.Exception
            po_sMensaje = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

    Public Sub ArmaNodoVehiculo(ByVal pi_oVehiculo As CVehiculo, ByRef po_xNodo As XmlElement, ByRef po_DocXml As XmlDocument,
                        ByRef po_sMensaje As String)
        Dim vl_xNodo As XmlElement = Nothing
        Dim vl_xAtributo As XmlAttribute = Nothing

        Try
            po_xNodo = po_DocXml.CreateElement("Vehiculo")
            vl_xAtributo = po_DocXml.CreateAttribute("Id")
            vl_xAtributo.Value = pi_oVehiculo.IdVehiculo
            po_xNodo.SetAttribute("Id", vl_xAtributo.InnerText)
            po_DocXml.DocumentElement.AppendChild(po_xNodo)
            vl_xAtributo = Nothing

            If Not po_xNodo Is Nothing Then

                vl_xNodo = po_DocXml.CreateElement("Placa")
                vl_xNodo.InnerText = pi_oVehiculo.PlacaVehiculo
                po_xNodo.AppendChild(vl_xNodo)
                vl_xNodo = Nothing
                If Not pi_oVehiculo.ColorVehiculo.Equals("") Then
                    vl_xNodo = po_DocXml.CreateElement("Color")
                    vl_xNodo.InnerText = pi_oVehiculo.ColorVehiculo
                    po_xNodo.AppendChild(vl_xNodo)
                    vl_xNodo = Nothing
                End If
                If Not pi_oVehiculo.CantidadRuedas.Equals("") Then
                    vl_xNodo = po_DocXml.CreateElement("CantidadRuedas")
                    vl_xNodo.InnerText = pi_oVehiculo.CantidadRuedas
                    po_xNodo.AppendChild(vl_xNodo)
                    vl_xNodo = Nothing
                End If
                If Not pi_oVehiculo.CantPasajerosVeh.Equals("") Then
                    vl_xNodo = po_DocXml.CreateElement("CantidadPasajeros")
                    vl_xNodo.InnerText = pi_oVehiculo.CantPasajerosVeh
                    po_xNodo.AppendChild(vl_xNodo)
                    vl_xNodo = Nothing
                End If
                If Not pi_oVehiculo.ModeloVeh.Equals("") Then
                    vl_xNodo = po_DocXml.CreateElement("Modelo")
                    vl_xNodo.InnerText = pi_oVehiculo.ModeloVeh
                    po_xNodo.AppendChild(vl_xNodo)
                    vl_xNodo = Nothing
                End If
            End If

        Catch ex As Exception
            po_sMensaje = "Error: " + ex.ToString
        End Try


    End Sub


    Public Function ReturnVehiculo(ByVal pi_sIdVehiculo As String, ByRef po_sMensajeEx As String) As CVehiculo
        Dim vl_sPath As String = ""
        Dim vl_xDocVehiculos As New XmlDocument
        Dim vl_oVehiculo As New CVehiculo
        Dim vl_xNodoVehiculo As XmlNode
        Dim vl_oListParametros As New List(Of String)
        Try
            vl_xDocVehiculos.Load(vg_sPathArchivoVehiculos)
            If vl_xDocVehiculos.SelectNodes("//Vehiculo").Count = 0 Then
                Return Nothing
            Else
                If Not vl_xDocVehiculos.SelectSingleNode("//Vehiculo[@Id='" & pi_sIdVehiculo & "']") Is Nothing Then
                    vl_xNodoVehiculo = vl_xDocVehiculos.SelectSingleNode("//Vehiculo[@Id='" & pi_sIdVehiculo & "']")
                    vl_oListParametros.Add(vl_xNodoVehiculo.SelectSingleNode("Placa").InnerText.ToString)
                    vl_oListParametros.Add(vl_xNodoVehiculo.SelectSingleNode("Color").InnerText.ToString)
                    vl_oListParametros.Add(vl_xNodoVehiculo.SelectSingleNode("CantidadRuedas").InnerText.ToString)
                    vl_oListParametros.Add(vl_xNodoVehiculo.SelectSingleNode("CantidadPasajeros").InnerText.ToString)
                    vl_oListParametros.Add(vl_xNodoVehiculo.SelectSingleNode("Modelo").InnerText.ToString)
                    vl_oVehiculo.CVehiculo(pi_sIdVehiculo, vl_oListParametros(0), vl_oListParametros(1), vl_oListParametros(2), vl_oListParametros(3),
                                          vl_oListParametros(4))
                    Return vl_oVehiculo
                Else
                    Return Nothing
                End If
            End If
        Catch ex As System.Exception
            po_sMensajeEx = "Error: " + ex.ToString
            Return Nothing
        End Try
    End Function

    Public Function ReturnListVehiculos(ByRef po_sMensajeEx As String) As LinkedList(Of CVehiculo)
        Dim vl_sPath As String = ""
        Dim vl_xDocVehiculos As New XmlDocument
        Dim vl_oListaVehiculos As New LinkedList(Of CVehiculo)
        Dim vl_oVehiculo As CVehiculo
        Dim vl_xNodoVehiculo As XmlNode
        Dim vl_oListParametros As New List(Of String)
        'Dim vl_oListParametros As New Dictionary(Of String, String)
        Try
            If File.Exists(mod_General.vg_sPathArchivoVehiculos) Then
                vl_xDocVehiculos.Load(mod_General.vg_sPathArchivoVehiculos)
                If Not vl_xDocVehiculos.SelectNodes("//Vehiculo") Is Nothing Then

                    For Each vl_xNodoVehiculo In vl_xDocVehiculos.SelectNodes("//Vehiculo")
                        vl_oVehiculo = New CVehiculo
                        vl_oListParametros.Add(vl_xNodoVehiculo.Attributes("Id").Value.ToString)
                        vl_oListParametros.Add(vl_xNodoVehiculo.SelectSingleNode("Placa").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoVehiculo.SelectSingleNode("Color").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoVehiculo.SelectSingleNode("CantidadRuedas").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoVehiculo.SelectSingleNode("CantidadPasajeros").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoVehiculo.SelectSingleNode("Modelo").InnerText.ToString)
                        vl_oVehiculo.CVehiculo(vl_oListParametros(0), vl_oListParametros(1), vl_oListParametros(2), vl_oListParametros(3), vl_oListParametros(4),
                                  vl_oListParametros(5))
                        vl_oListaVehiculos.AddLast(vl_oVehiculo)
                        vl_oListParametros.Clear()
                        vl_oVehiculo = Nothing
                    Next
                End If
            End If
            Return vl_oListaVehiculos
        Catch ex As System.Exception
            po_sMensajeEx = "Error: " + ex.ToString
            Return Nothing
        End Try
    End Function

    Public Function ValidarVehiculo(ByVal pi_sIdVehiculo As String, ByRef po_sMensajeEx As String) As Boolean
        Dim vl_sPath As String = ""
        Dim vl_bRespuesta As Boolean = False
        Dim vl_xDocVehiculos As New XmlDocument
        Try
            vl_xDocVehiculos.Load(vg_sPathArchivoVehiculos)
            If Not vl_xDocVehiculos.SelectNodes("//Vehiculo").Count = 0 Then
                If Not vl_xDocVehiculos.SelectSingleNode("//Vehiculo[@Id='" & pi_sIdVehiculo & "']") Is Nothing Then
                    vl_bRespuesta = True
                Else
                    vl_bRespuesta = False
                End If
            Else
                vl_bRespuesta = False
            End If
        Catch ex As System.Exception
            po_sMensajeEx = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

    Public Function DeleteVehiculo(ByVal pi_sIdVehiculo As String, ByRef po_sMensajeEx As String) As Boolean
        Dim vl_sPath As String = ""
        Dim vl_xDocVehiculos As New XmlDocument
        Dim vl_oVehiculo As New CVehiculo
        Dim vl_xNodoVehiculo As XmlNode
        Dim vl_xPadre As XmlNode
        Dim vl_bRespuesta As Boolean = False
        Try
            vl_xDocVehiculos.Load(vg_sPathArchivoVehiculos)
            If Not vl_xDocVehiculos.SelectNodes("//Vehiculo") Is Nothing Then
                vl_xPadre = vl_xDocVehiculos.SelectSingleNode("/Vehiculos")
                If Not vl_xDocVehiculos.SelectSingleNode("//Vehiculo[@Id='" & pi_sIdVehiculo & "']") Is Nothing Then
                    vl_xNodoVehiculo = vl_xDocVehiculos.SelectSingleNode("//Vehiculo[@Id='" & pi_sIdVehiculo & "']")
                    vl_xPadre.RemoveChild(vl_xNodoVehiculo)
                    vl_xDocVehiculos.Save(vg_sPathArchivoVehiculos)
                    vl_bRespuesta = True
                Else
                    vl_bRespuesta = False
                End If
            Else
                vl_bRespuesta = False
            End If
        Catch ex As Exception
            po_sMensajeEx = "Error: " + ex.ToString
        End Try
        Return vl_bRespuesta
    End Function


    Public Function UpDateVehiculo(ByVal pi_oVehiculo As CVehiculo, ByRef po_sMensaje As String) As Boolean
        Dim vl_sPath As String = ""
        Dim vl_xDocVehiculos As New XmlDocument
        Dim vl_oVehiculo As New CVehiculo
        Dim vl_xNodoVehiculo As XmlNode
        Dim vl_bRespuesta As Boolean = False
        Try
            vl_xDocVehiculos.Load(vg_sPathArchivoVehiculos)
            If Not vl_xDocVehiculos.SelectNodes("//Vehiculo") Is Nothing Then
                If Not vl_xDocVehiculos.SelectSingleNode("//Vehiculo[@Id='" & pi_oVehiculo.IdVehiculo & "']") Is Nothing Then
                    vl_xNodoVehiculo = vl_xDocVehiculos.SelectSingleNode("//Vehiculo[@Id='" & pi_oVehiculo.IdVehiculo & "']")
                    If Not pi_oVehiculo.PlacaVehiculo = String.Empty Then
                        vl_xNodoVehiculo.SelectSingleNode("Placa").InnerText = pi_oVehiculo.PlacaVehiculo
                    End If
                    If Not pi_oVehiculo.ColorVehiculo = String.Empty Then
                        vl_xNodoVehiculo.SelectSingleNode("Color").InnerText = pi_oVehiculo.ColorVehiculo
                    End If
                    If Not pi_oVehiculo.CantidadRuedas = 0 Then
                        vl_xNodoVehiculo.SelectSingleNode("CantidadRuedas").InnerText = pi_oVehiculo.CantidadRuedas
                    End If
                    If Not pi_oVehiculo.CantPasajerosVeh = 0 Then
                        vl_xNodoVehiculo.SelectSingleNode("CantidadPasajeros").InnerText = pi_oVehiculo.CantPasajerosVeh
                    End If
                    If Not pi_oVehiculo.ModeloVeh = 0 Then
                        vl_xNodoVehiculo.SelectSingleNode("Modelo").InnerText = pi_oVehiculo.ModeloVeh
                    End If
                    vl_xDocVehiculos.Save(vg_sPathArchivoVehiculos)
                    vl_bRespuesta = True
                Else
                    vl_bRespuesta = False
                End If
            Else
                vl_bRespuesta = False
            End If
        Catch ex As Exception
            po_sMensaje = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

#End Region

#Region "Usuarios"
    Public Function AddUsuario(ByVal pi_oUsuario As CUsuario, ByRef po_sMensaje As String) As Boolean
        Dim vl_bRespuesta As Boolean = False
        Dim vl_sPath As String = ""
        Dim vl_xNodo As XmlElement = Nothing
        Dim vl_xNodoUsuario As XmlElement = Nothing
        Dim vl_xAtributo As XmlAttribute = Nothing
        Dim vl_xNodoInsert As XmlNode = Nothing
        Dim vl_xDocUsuarios As New XmlDocument

        Try
            If Not pi_oUsuario Is Nothing Then

                If File.Exists(mod_General.vg_sPathArchivoUsuarios) Then
                    vl_xDocUsuarios.Load(mod_General.vg_sPathArchivoUsuarios)
                Else
                    Dim vl_xXmldecl As XmlDeclaration
                    vl_xXmldecl = vl_xDocUsuarios.CreateXmlDeclaration("1.0", Nothing, Nothing)
                    vl_xDocUsuarios.AppendChild(vl_xXmldecl)
                    vl_xDocUsuarios.LoadXml("<Usuarios></Usuarios>")
                    vl_xDocUsuarios.Save(mod_General.vg_sPathArchivoUsuarios)
                End If
                If vl_xDocUsuarios.SelectSingleNode("Usuarios") Is Nothing Then
                    vl_xDocUsuarios.CreateElement("<Usuarios></Usuarios>")

                End If

                vl_xNodoInsert = vl_xDocUsuarios.DocumentElement
                ArmaNodoUsuario(pi_oUsuario, vl_xNodoUsuario, vl_xDocUsuarios, po_sMensaje)
                If Not vl_xNodoUsuario Is Nothing Then
                    If vl_xDocUsuarios.SelectSingleNode("Usuario") Is Nothing Then
                        vl_xNodoInsert.AppendChild(vl_xNodoUsuario)
                        vl_xDocUsuarios.Save(mod_General.vg_sPathArchivoUsuarios)
                        vl_bRespuesta = True
                    End If
                End If
            End If
        Catch ex As System.Exception
            po_sMensaje = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

    Public Sub ArmaNodoUsuario(ByVal pi_oUsuario As CUsuario, ByRef po_xNodo As XmlElement, ByRef po_DocXml As XmlDocument,
                    ByRef po_sMensaje As String)
        Dim vl_xNodo As XmlElement = Nothing
        Dim vl_xAtributo As XmlAttribute = Nothing
        Try

            po_xNodo = po_DocXml.CreateElement("Usuario")
            vl_xAtributo = po_DocXml.CreateAttribute("Id")
            vl_xAtributo.Value = pi_oUsuario.IdPersona
            po_xNodo.SetAttribute("Id", vl_xAtributo.InnerText)
            po_DocXml.DocumentElement.AppendChild(po_xNodo)
            vl_xAtributo = Nothing

            ArmaNodoPersona(pi_oUsuario, po_xNodo, po_DocXml, po_sMensaje)

        Catch ex As Exception
            po_sMensaje = "Error: " + ex.ToString
        End Try
    End Sub
    Private Sub ArmaNodoPersona(ByVal pi_oPersona As CPersona, ByRef po_xNodo As XmlElement, ByRef po_DocXml As XmlDocument,
                    ByRef po_sMensaje As String)

        Dim vl_xNodo As XmlElement = Nothing
        Dim vl_xAtributo As XmlAttribute = Nothing
        Dim vl_sFecha As String

        Try

            If Not po_xNodo Is Nothing Then

                vl_xNodo = po_DocXml.CreateElement("Identificacion")
                vl_xAtributo = po_DocXml.CreateAttribute("Tipo")
                vl_xAtributo.Value = pi_oPersona.TipoIdentifiPersona
                vl_xNodo.SetAttribute("Tipo", vl_xAtributo.InnerText)
                vl_xNodo.InnerText = pi_oPersona.IdentificacionPersona
                po_xNodo.AppendChild(vl_xNodo)


                vl_xNodo = po_DocXml.CreateElement("Nombres")
                vl_xNodo.InnerText = pi_oPersona.NombrePersona
                po_xNodo.AppendChild(vl_xNodo)
                vl_xNodo = Nothing
                vl_xNodo = po_DocXml.CreateElement("Apellidos")
                vl_xNodo.InnerText = pi_oPersona.ApellidoPersona
                po_xNodo.AppendChild(vl_xNodo)
                vl_xNodo = Nothing

                If Not pi_oPersona.FechaNaciPersona.Equals("") Then
                    vl_sFecha = Format(pi_oPersona.FechaNaciPersona.Date, "yyyy/MM/dd").ToString()

                    vl_xNodo = po_DocXml.CreateElement("FechaNacimiento")
                    vl_xNodo.InnerText = vl_sFecha
                    po_xNodo.AppendChild(vl_xNodo)
                    vl_xNodo = Nothing
                End If
                If Not pi_oPersona.SexoPersona.Equals("") Then
                    vl_xNodo = po_DocXml.CreateElement("Sexo")
                    vl_xNodo.InnerText = pi_oPersona.SexoPersona
                    po_xNodo.AppendChild(vl_xNodo)
                    vl_xNodo = Nothing
                End If
                If Not pi_oPersona.EstaturaPersona.Equals("") Then
                    vl_xNodo = po_DocXml.CreateElement("Estatura")
                    vl_xNodo.InnerText = pi_oPersona.EstaturaPersona
                    po_xNodo.AppendChild(vl_xNodo)
                    vl_xNodo = Nothing
                End If
                If Not pi_oPersona.NacionalidadPersona.Equals("") Then
                    vl_xNodo = po_DocXml.CreateElement("NacionalidadPersona")
                    vl_xNodo.InnerText = pi_oPersona.NacionalidadPersona
                    po_xNodo.AppendChild(vl_xNodo)
                    vl_xNodo = Nothing
                End If
                vl_xNodo = po_DocXml.CreateElement("FechaRegistro")
                vl_xNodo.InnerText = pi_oPersona.FechaRegistro.ToString
                po_xNodo.AppendChild(vl_xNodo)
            End If
        Catch ex As Exception
            po_sMensaje = "Error: " + ex.ToString
        End Try
    End Sub

    Public Function ReturnUsuario(ByVal pi_sIdUsuario As String, ByRef po_sMensajeEx As String) As CUsuario
        Dim vl_sPath As String = ""
        Dim vl_xDocUsuarios As New XmlDocument
        Dim vl_oUsuario As New CUsuario
        Dim vl_xNodoUsuario As XmlNode
        Dim vl_dFechaNacimiento As Date
        Dim vl_oListParametros As New List(Of String)
        Try
            vl_xDocUsuarios.Load(vg_sPathArchivoUsuarios)
            If vl_xDocUsuarios.SelectNodes("//Usuario").Count = 0 Then
                Return Nothing
            Else
                If Not vl_xDocUsuarios.SelectSingleNode("//Usuario[@Id='" & pi_sIdUsuario & "']") Is Nothing Then
                    vl_xNodoUsuario = vl_xDocUsuarios.SelectSingleNode("//Usuario[@Id='" & pi_sIdUsuario & "']")
                    vl_oListParametros.Add(vl_xNodoUsuario.SelectSingleNode("Identificacion").InnerText.ToString)
                    vl_oListParametros.Add(vl_xNodoUsuario.SelectSingleNode("Identificacion").Attributes("Tipo").Value.ToString)
                    vl_oListParametros.Add(vl_xNodoUsuario.SelectSingleNode("Nombres").InnerText.ToString)
                    vl_oListParametros.Add(vl_xNodoUsuario.SelectSingleNode("Apellidos").InnerText.ToString)
                    vl_oListParametros.Add(vl_xNodoUsuario.SelectSingleNode("Sexo").InnerText.ToString)
                    vl_oListParametros.Add(vl_xNodoUsuario.SelectSingleNode("Estatura").InnerText.ToString)
                    vl_oListParametros.Add(vl_xNodoUsuario.SelectSingleNode("NacionalidadPersona").InnerText.ToString)
                    vl_dFechaNacimiento = CDate(vl_xNodoUsuario.SelectSingleNode("FechaNacimiento").InnerText.ToString)
                    'vl_oUsuario.CUsuario(pi_sIdUsuario)
                    vl_oUsuario.CUsuario(pi_sIdUsuario, vl_oListParametros(0), vl_oListParametros(1), vl_oListParametros(2), vl_oListParametros(3),
                                         vl_dFechaNacimiento, vl_oListParametros(4), vl_oListParametros(5), vl_oListParametros(6))
                    Return vl_oUsuario
                Else
                    Return Nothing
                End If
            End If
        Catch ex As System.Exception
            po_sMensajeEx = "Error: " + ex.ToString
            Return Nothing
        End Try
    End Function

    Public Function ReturnListUsuarios(ByRef po_sMensajeEx As String) As LinkedList(Of CUsuario)
        Dim vl_sPath As String = ""
        Dim vl_xDocUsuarios As New XmlDocument
        Dim vl_oListaUsuarios As New LinkedList(Of CUsuario)
        Dim vl_oUsuario As CUsuario
        Dim vl_xNodoUsuario As XmlNode
        Dim vl_dFechaNacimiento As Date
        Dim vl_oListParametros As New List(Of String)
        'Dim vl_oListParametros As New Dictionary(Of String, String)
        Try
            If File.Exists(mod_General.vg_sPathArchivoUsuarios) Then
                vl_xDocUsuarios.Load(mod_General.vg_sPathArchivoUsuarios)
                If Not vl_xDocUsuarios.SelectNodes("//Usuario") Is Nothing Then

                    For Each vl_xNodoUsuario In vl_xDocUsuarios.SelectNodes("//Usuario")
                        vl_oUsuario = New CUsuario
                        vl_oListParametros.Add(vl_xNodoUsuario.Attributes("Id").Value.ToString)
                        vl_oListParametros.Add(vl_xNodoUsuario.SelectSingleNode("Identificacion").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoUsuario.SelectSingleNode("Identificacion").Attributes("Tipo").Value.ToString)
                        vl_oListParametros.Add(vl_xNodoUsuario.SelectSingleNode("Nombres").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoUsuario.SelectSingleNode("Apellidos").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoUsuario.SelectSingleNode("Sexo").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoUsuario.SelectSingleNode("Estatura").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoUsuario.SelectSingleNode("NacionalidadPersona").InnerText.ToString)
                        vl_dFechaNacimiento = CDate(vl_xNodoUsuario.SelectSingleNode("FechaNacimiento").InnerText.ToString)
                        vl_oUsuario.CUsuario(vl_oListParametros(0), vl_oListParametros(1), vl_oListParametros(2), vl_oListParametros(3), vl_oListParametros(4),
                                 vl_dFechaNacimiento, vl_oListParametros(5), vl_oListParametros(6), vl_oListParametros(7))
                        vl_oListaUsuarios.AddLast(vl_oUsuario)
                        vl_oListParametros.Clear()
                        vl_oUsuario = Nothing
                    Next
                End If
            End If
            Return vl_oListaUsuarios
        Catch ex As System.Exception
            po_sMensajeEx = "Error: " + ex.ToString
            Return Nothing
        End Try
    End Function

    Public Function ValidarUsuario(ByVal pi_sIdUsuario As String, ByRef po_sMensajeEx As String) As Boolean
        Dim vl_sPath As String = ""
        Dim vl_bRespuesta As Boolean = False
        Dim vl_xDocUsuarios As New XmlDocument
        Try
            vl_xDocUsuarios.Load(vg_sPathArchivoUsuarios)
            If Not vl_xDocUsuarios.SelectNodes("//Usuario").Count = 0 Then
                If Not vl_xDocUsuarios.SelectSingleNode("//Usuario[@Id='" & pi_sIdUsuario & "']") Is Nothing Then
                    vl_bRespuesta = True
                Else
                    vl_bRespuesta = False
                End If
            Else
                vl_bRespuesta = False
            End If
        Catch ex As System.Exception
            po_sMensajeEx = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

    Public Function DeleteUsuario(ByVal pi_sIdUsuario As String, ByRef po_sMensajeEx As String) As Boolean
        Dim vl_sPath As String = ""
        Dim vl_xDocUsuarios As New XmlDocument
        Dim vl_oUsuario As New CUsuario
        Dim vl_xNodoUsuario As XmlNode
        Dim vl_xPadre As XmlNode
        Dim vl_bRespuesta As Boolean = False
        Try
            vl_xDocUsuarios.Load(vg_sPathArchivoUsuarios)
            If Not vl_xDocUsuarios.SelectNodes("//Usuario") Is Nothing Then
                vl_xPadre = vl_xDocUsuarios.SelectSingleNode("/Usuarios")
                If Not vl_xDocUsuarios.SelectSingleNode("//Usuario[@Id='" & pi_sIdUsuario & "']") Is Nothing Then
                    vl_xNodoUsuario = vl_xDocUsuarios.SelectSingleNode("//Usuario[@Id='" & pi_sIdUsuario & "']")
                    vl_xPadre.RemoveChild(vl_xNodoUsuario)
                    vl_xDocUsuarios.Save(vg_sPathArchivoUsuarios)
                    vl_bRespuesta = True
                Else
                    vl_bRespuesta = False
                End If
            Else
                vl_bRespuesta = False
            End If
        Catch ex As Exception
            po_sMensajeEx = "Error: " + ex.ToString
        End Try
        Return vl_bRespuesta
    End Function


  Public Function UpDateUsuario(pi_oPersona As CUsuario, ByRef po_sMensajeEx As String) As Boolean
    Dim vl_sPath As String = ""
    Dim vl_xDocUsuarios As New XmlDocument
    Dim vl_oUsuario As New CUsuario
    Dim vl_xNodoUsuario As XmlNode
    Dim vl_bRespuesta As Boolean = False
    Try
      vl_xDocUsuarios.Load(vg_sPathArchivoUsuarios)
      If Not vl_xDocUsuarios.SelectNodes("//Usuario") Is Nothing Then
        If Not vl_xDocUsuarios.SelectSingleNode("//Usuario[@Id='" & pi_oPersona.IdPersona & "']") Is Nothing Then
          vl_xNodoUsuario = vl_xDocUsuarios.SelectSingleNode("//Usuario[@Id='" & pi_oPersona.IdPersona & "']")
          If Not pi_oPersona.TipoIdentifiPersona = String.Empty Then
            vl_xNodoUsuario.SelectSingleNode("Identificacion").Attributes("Tipo").Value = pi_oPersona.TipoIdentifiPersona
          End If
          If Not pi_oPersona.IdentificacionPersona = String.Empty Then
            vl_xNodoUsuario.SelectSingleNode("Identificacion").InnerText = pi_oPersona.IdentificacionPersona
          End If
          If Not pi_oPersona.NombrePersona = String.Empty Then
            vl_xNodoUsuario.SelectSingleNode("Nombres").InnerText = pi_oPersona.NombrePersona
          End If
          If Not pi_oPersona.ApellidoPersona = String.Empty Then
            vl_xNodoUsuario.SelectSingleNode("Apellidos").InnerText = pi_oPersona.ApellidoPersona
          End If
          If Not Format(pi_oPersona.FechaNaciPersona.Date, "yyyy/MM/dd").ToString() = String.Empty Then
            vl_xNodoUsuario.SelectSingleNode("FechaNacimiento").InnerText = Format(pi_oPersona.FechaNaciPersona.Date, "yyyy/MM/dd").ToString()
          End If
          If Not pi_oPersona.SexoPersona = String.Empty Then
            vl_xNodoUsuario.SelectSingleNode("Sexo").InnerText = pi_oPersona.SexoPersona
          End If
          If Not pi_oPersona.EstaturaPersona = String.Empty Then
            vl_xNodoUsuario.SelectSingleNode("Estatura").InnerText = pi_oPersona.EstaturaPersona
          End If
          If Not pi_oPersona.NacionalidadPersona = String.Empty Then
            vl_xNodoUsuario.SelectSingleNode("NacionalidadPersona").InnerText = pi_oPersona.NacionalidadPersona
          End If
          vl_xDocUsuarios.Save(vg_sPathArchivoUsuarios)
          vl_bRespuesta = True
        Else
          vl_bRespuesta = False
        End If
      Else
        vl_bRespuesta = False
      End If
    Catch ex As Exception
      po_sMensajeEx = "Error: " + ex.ToString
      vl_bRespuesta = False
    End Try
    Return vl_bRespuesta
  End Function

#End Region

#Region "Ticket"
  Public Function AddTicket(ByRef pi_oTicket As CTicket, ByRef po_sMensajeEx As String) As Boolean
        Dim vl_bRespuesta As Boolean = False
        Dim vl_xNodo As XmlElement = Nothing
        Dim vl_xNodoTicket As XmlElement = Nothing
        Dim vl_xNodoCliente As XmlElement = Nothing
        Dim vl_xNodoVehiculo As XmlElement = Nothing
        Dim vl_xNodoConductor As XmlElement = Nothing
        Dim vl_xAtributo As XmlAttribute = Nothing
        Dim vl_xNodoInsert As XmlNode = Nothing
        Dim vl_xDocTickets As New XmlDocument
        Dim vl_sFecha As String
        Try
            If Not pi_oTicket Is Nothing Then
                If File.Exists(mod_General.vg_sPathArchivoTickes) Then
                    vl_xDocTickets.Load(mod_General.vg_sPathArchivoTickes)
                Else
                    Dim vl_xXmldecl As XmlDeclaration
                    vl_xXmldecl = vl_xDocTickets.CreateXmlDeclaration("1.0", Nothing, Nothing)
                    vl_xDocTickets.AppendChild(vl_xXmldecl)
                    vl_xDocTickets.LoadXml("<Tickets></Tickets>")
                    vl_xDocTickets.Save(mod_General.vg_sPathArchivoTickes)
                End If
                If vl_xDocTickets.SelectSingleNode("Tickets") Is Nothing Then
                    vl_xDocTickets.CreateElement("<Tickets></Tickets>")
                End If

                vl_xNodoInsert = vl_xDocTickets.DocumentElement
                vl_xNodoTicket = vl_xDocTickets.CreateElement("Ticket")
                vl_xAtributo = vl_xDocTickets.CreateAttribute("Id")
                vl_xAtributo.Value = pi_oTicket.IdTicket
                vl_xNodoTicket.SetAttribute("Id", vl_xAtributo.InnerText)
                vl_xDocTickets.DocumentElement.AppendChild(vl_xNodoTicket)
                vl_xAtributo = Nothing

                If Not vl_xNodoTicket Is Nothing Then
                    Dim vl_ddt As DateTime = DateTime.Parse(pi_oTicket.FechaVenta)
                    vl_sFecha = vl_ddt.ToString()
                    vl_xNodo = vl_xDocTickets.CreateElement("FechaVenta")
                    vl_xNodo.InnerText = vl_sFecha
                    vl_xNodoTicket.AppendChild(vl_xNodo)
                    vl_xNodo = Nothing

                    vl_ddt = DateTime.Parse(pi_oTicket.FechaIniTic)
                    vl_sFecha = vl_ddt.ToString()
                    vl_xNodo = vl_xDocTickets.CreateElement("FechaSalida")
                    vl_xNodo.InnerText = vl_sFecha
                    vl_xNodoTicket.AppendChild(vl_xNodo)
                    vl_xNodo = Nothing

                    vl_ddt = DateTime.Parse(pi_oTicket.FechaFinTic)
                    vl_sFecha = vl_ddt.ToString()
                    vl_xNodo = vl_xDocTickets.CreateElement("FechaLlegada")
                    vl_xNodo.InnerText = vl_sFecha
                    vl_xNodoTicket.AppendChild(vl_xNodo)
                    vl_xNodo = Nothing

                    vl_xNodo = vl_xDocTickets.CreateElement("Trayecto")
                    vl_xNodo.InnerText = pi_oTicket.Trayecto
                    vl_xNodoTicket.AppendChild(vl_xNodo)
                    vl_xNodo = Nothing


                    vl_xNodo = vl_xDocTickets.CreateElement("LugarSalida")
                    vl_xNodo.InnerText = pi_oTicket.LugarSalida
                    vl_xNodoTicket.AppendChild(vl_xNodo)
                    vl_xNodo = Nothing


                    vl_xNodo = vl_xDocTickets.CreateElement("LugarLlegada")
                    vl_xNodo.InnerText = pi_oTicket.LugarLlegada
                    vl_xNodoTicket.AppendChild(vl_xNodo)
                    vl_xNodo = Nothing

                    vl_xNodo = vl_xDocTickets.CreateElement("Estado")
                    vl_xNodo.InnerText = pi_oTicket.EstadoTicket
                    vl_xNodoTicket.AppendChild(vl_xNodo)
                    vl_xNodo = Nothing

                    vl_xNodo = vl_xDocTickets.CreateElement("Costo")
                    vl_xNodo.InnerText = pi_oTicket.Costo
                    vl_xNodoTicket.AppendChild(vl_xNodo)
                    vl_xNodo = Nothing

                    vl_xNodo = vl_xDocTickets.CreateElement("Impuesto")
                    vl_xNodo.InnerText = pi_oTicket.Impuesto
                    vl_xNodoTicket.AppendChild(vl_xNodo)
                    vl_xNodo = Nothing

                    ArmaNodoCliente(pi_oTicket.Cliente, vl_xNodoCliente, vl_xDocTickets, po_sMensajeEx)
                    vl_xNodoTicket.AppendChild(vl_xNodoCliente)

                    ArmaNodoVehiculo(pi_oTicket.Vehiculo, vl_xNodoVehiculo, vl_xDocTickets, po_sMensajeEx)
                    vl_xNodoTicket.AppendChild(vl_xNodoVehiculo)

                    ArmaNodoUsuario(pi_oTicket.Conductor, vl_xNodoConductor, vl_xDocTickets, po_sMensajeEx)
                    vl_xNodoTicket.AppendChild(vl_xNodoConductor)

                    If Not pi_oTicket.Cliente Is Nothing Then

                    End If

                    If vl_xNodoTicket.SelectSingleNode("Ticket") Is Nothing Then
                        vl_xNodoInsert.AppendChild(vl_xNodoTicket)
                        vl_xDocTickets.Save(mod_General.vg_sPathArchivoTickes)
                        vl_bRespuesta = True
                    End If
                End If
            End If
        Catch ex As System.Exception
            po_sMensajeEx = "Error: " + ex.ToString
            vl_bRespuesta = False
        End Try
        Return vl_bRespuesta
    End Function

    Public Function ReturnListTickets(ByRef po_sMensaje As String) As LinkedList(Of CTicket)
        Dim vl_sPath As String = ""
        Dim vl_xDocTickets As New XmlDocument
        Dim vl_oListaTicket As New LinkedList(Of CTicket)
        Dim vl_oTicket As CTicket
        Dim vl_oUsuario As CUsuario
        Dim vl_oCliente As CCliente
        Dim vl_oVehiculo As CVehiculo
        Dim vl_xNodoTicket As XmlNode
        Dim vl_dFechaVenta As DateTime
        Dim vl_dFechaIni As DateTime
        Dim vl_dFechaFin As DateTime
        Dim vl_oListParametros As New List(Of String)

        Try
            If File.Exists(mod_General.vg_sPathArchivoTickes) Then
                vl_xDocTickets.Load(mod_General.vg_sPathArchivoTickes)
                If Not vl_xDocTickets.SelectNodes("//Ticket") Is Nothing Then

                    For Each vl_xNodoTicket In vl_xDocTickets.SelectNodes("//Ticket")
                        vl_oTicket = New CTicket
                        vl_oCliente = New CCliente
                        vl_oUsuario = New CUsuario
                        vl_oVehiculo = New CVehiculo

                        vl_oListParametros.Add(vl_xNodoTicket.Attributes("Id").Value.ToString)
                        vl_dFechaVenta = DateTime.Parse(vl_xNodoTicket.SelectSingleNode("FechaVenta").InnerText.ToString)
                        vl_dFechaIni = DateTime.Parse(vl_xNodoTicket.SelectSingleNode("FechaSalida").InnerText.ToString)
                        vl_dFechaFin = DateTime.Parse(vl_xNodoTicket.SelectSingleNode("FechaLlegada").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoTicket.SelectSingleNode("Trayecto").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoTicket.SelectSingleNode("LugarSalida").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoTicket.SelectSingleNode("LugarLlegada").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoTicket.SelectSingleNode("Estado").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoTicket.SelectSingleNode("Costo").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoTicket.SelectSingleNode("Impuesto").InnerText.ToString)
                        vl_oCliente = ReturnCliente((vl_xNodoTicket.SelectSingleNode("//Cliente").Attributes("Id").Value.ToString), po_sMensaje)
                        vl_oUsuario = ReturnUsuario((vl_xNodoTicket.SelectSingleNode("//Usuario").Attributes("Id").Value.ToString), po_sMensaje)
                        vl_oVehiculo = ReturnVehiculo((vl_xNodoTicket.SelectSingleNode("//Vehiculo").Attributes("Id").Value.ToString), po_sMensaje)
                        vl_oTicket.CTicket(vl_oListParametros(0), vl_dFechaVenta, vl_dFechaIni, vl_dFechaFin, vl_oCliente, vl_oListParametros(1), vl_oListParametros(2), vl_oListParametros(3),
                                           vl_oVehiculo, vl_oUsuario)
                        vl_oListaTicket.AddLast(vl_oTicket)
                        vl_oListParametros.Clear()
                        vl_oTicket = Nothing
                    Next
                End If
            End If
            Return vl_oListaTicket
        Catch ex As System.Exception
            po_sMensaje = "Error: " + ex.ToString
            Return Nothing
        End Try
    End Function

    Public Function ReturnTicket(ByVal pi_sIdTicket As String, ByRef po_sMensaje As String) As CTicket
        Dim vl_sPath As String = ""
        Dim vl_xDocTickets As New XmlDocument
        Dim vl_oListaTicket As New LinkedList(Of CTicket)
        Dim vl_oTicket As CTicket
        Dim vl_oUsuario As CUsuario
        Dim vl_oCliente As CCliente
        Dim vl_oVehiculo As CVehiculo
        Dim vl_xNodoTicket As XmlNode
        Dim vl_dFechaVenta As DateTime
        Dim vl_dFechaIni As DateTime
        Dim vl_dFechaFin As DateTime
        Dim vl_oListParametros As New List(Of String)

        Try
            If File.Exists(mod_General.vg_sPathArchivoTickes) Then
                vl_xDocTickets.Load(mod_General.vg_sPathArchivoTickes)
                If Not vl_xDocTickets.SelectNodes("//Ticket") Is Nothing Then
                    If Not vl_xDocTickets.SelectSingleNode("//Ticket[@Id='" & pi_sIdTicket & "']") Is Nothing Then
                        vl_xNodoTicket = vl_xDocTickets.SelectSingleNode("//Ticket[@Id='" & pi_sIdTicket & "']")
                        vl_oTicket = New CTicket
                        vl_oCliente = New CCliente
                        vl_oUsuario = New CUsuario
                        vl_oVehiculo = New CVehiculo

                        vl_oListParametros.Add(vl_xNodoTicket.Attributes("Id").Value.ToString)
                        vl_dFechaVenta = DateTime.Parse(vl_xNodoTicket.SelectSingleNode("FechaVenta").InnerText.ToString)
                        vl_dFechaIni = DateTime.Parse(vl_xNodoTicket.SelectSingleNode("FechaSalida").InnerText.ToString)
                        vl_dFechaFin = DateTime.Parse(vl_xNodoTicket.SelectSingleNode("FechaLlegada").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoTicket.SelectSingleNode("Trayecto").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoTicket.SelectSingleNode("LugarSalida").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoTicket.SelectSingleNode("LugarLlegada").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoTicket.SelectSingleNode("Estado").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoTicket.SelectSingleNode("Costo").InnerText.ToString)
                        vl_oListParametros.Add(vl_xNodoTicket.SelectSingleNode("Impuesto").InnerText.ToString)
                        vl_oCliente = ReturnCliente((vl_xNodoTicket.SelectSingleNode("//Cliente").Attributes("Id").Value.ToString), po_sMensaje)
                        vl_oUsuario = ReturnUsuario((vl_xNodoTicket.SelectSingleNode("//Usuario").Attributes("Id").Value.ToString), po_sMensaje)
                        vl_oVehiculo = ReturnVehiculo((vl_xNodoTicket.SelectSingleNode("//Vehiculo").Attributes("Id").Value.ToString), po_sMensaje)
                        vl_oTicket.CTicket(vl_oListParametros(0), vl_dFechaVenta, vl_dFechaIni, vl_dFechaFin, vl_oCliente, vl_oListParametros(1), vl_oListParametros(2), vl_oListParametros(3),
                                       vl_oVehiculo, vl_oUsuario)
                        vl_oListParametros.Clear()
                        Return vl_oTicket
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Catch ex As System.Exception
            po_sMensaje = "Error: " + ex.ToString
            Return Nothing
        End Try
    End Function

    Public Function DeleteTicket(ByVal pi_sTicket As String, ByRef po_sMensajeEx As String) As Boolean
        Dim vl_sPath As String = ""
        Dim vl_xDocTickets As New XmlDocument
        Dim vl_xNodoTicket As XmlNode
        Dim vl_xPadre As XmlNode
        Dim vl_bRespuesta As Boolean = False
        Try
            vl_xDocTickets.Load(vg_sPathArchivoTickes)
            If Not vl_xDocTickets.SelectNodes("//Tickets") Is Nothing Then
                vl_xPadre = vl_xDocTickets.SelectSingleNode("/Tickets")
                If Not vl_xDocTickets.SelectSingleNode("//Ticket[@Id='" & pi_sTicket & "']") Is Nothing Then
                    vl_xNodoTicket = vl_xDocTickets.SelectSingleNode("//Ticket[@Id='" & pi_sTicket & "']")
                    vl_xPadre.RemoveChild(vl_xNodoTicket)
                    vl_xDocTickets.Save(vg_sPathArchivoTickes)
                    vl_bRespuesta = True
                Else
                    vl_bRespuesta = False
                End If
            Else
                vl_bRespuesta = False
            End If
        Catch ex As Exception
            po_sMensajeEx = "Error: " + ex.ToString
        End Try
        Return vl_bRespuesta
    End Function

    Public Function GetNextId(ByRef pi_sMensajeEx As String) As Integer
        Dim vl_xDocTickets As New XmlDocument
        Dim vl_iCount As Integer = 0
        Dim vl_iNextId As Integer
        Dim vl_xNodoTicket As XmlNode
        Dim vl_oListIds As New List(Of String)
        Try
            If File.Exists(mod_General.vg_sPathArchivoTickes) Then
                vl_xDocTickets.Load(mod_General.vg_sPathArchivoTickes)
                If Not vl_xDocTickets.SelectNodes("//Ticket") Is Nothing Then
                    For Each vl_xNodoTicket In vl_xDocTickets.SelectNodes("//Ticket")
                        vl_oListIds.Add(vl_xNodoTicket.Attributes("Id").Value.ToString)
                    Next
                    vl_iNextId = vl_oListIds.Max
                    Return vl_iNextId + 1
                End If
            End If
        Catch ex As Exception
            pi_sMensajeEx = "Error: " + ex.ToString
            Return Nothing
        End Try
        Return vl_iCount
    End Function

#End Region

End Class
