using Dominio;
using GestionDatos;
using System.Data;

namespace Negocio
{
    public class N_Situacion_Laboral
    {
        GD_Situacion_Laboral objSituacion;

        public N_Situacion_Laboral()
        {
            objSituacion = new GD_Situacion_Laboral();
        }

        public DataTable listarSituacion()
        {
            return objSituacion.listar_Situacion();
        }
    }
}
