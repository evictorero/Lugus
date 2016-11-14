
'CUALQUIER OBJETO QUE PUEDA PERTENECER A UNA COLECCION
'EN UNA RELACION DE AGREGACION DEBERA IMPLEMENTAR ESTA INTERFAZ
Public Interface IColeccionable

    'ESTADOS POSIBLES QUE UN OBJETO PUEDE ADOPTAR DENTRO DE UNA COLECCION
    Enum EstadosColeccion
        SinCambio = 0
        Agregado = 1
        Borrado = 2
        Quitado = 3
        Modificado = 4
    End Enum

    'PROPIEDADES QUE DEBEN IMPLEMENTARSE
    Property EstadoColeccion() As EstadosColeccion
    Property IndiceColeccion() As Integer

End Interface
