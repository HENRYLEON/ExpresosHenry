Public Class CUsuario
    Inherits CPersona
    Public Sub CUsuario()
    End Sub

    Public Sub CUsuario(ByVal pi_sIdPersona As String, ByVal pi_sIdentificacionPersona As String, ByVal pi_sTipoIdentifiPersona As String,
                        ByVal pi_sNombrePersona As String, ByVal pi_sApellidoPersona As String, ByVal pi_dFechaNaciPersona As Date, ByVal pi_sSexoPersona As String,
                        ByVal pi_sEstaturaPersona As String, ByVal pi_sNacionalidadPersona As String)
        Me.CPersona(pi_sIdPersona, pi_sIdentificacionPersona, pi_sTipoIdentifiPersona, pi_sNombrePersona, pi_sApellidoPersona,
                    pi_dFechaNaciPersona, pi_sSexoPersona, pi_sEstaturaPersona, pi_sNacionalidadPersona)
    End Sub
End Class
