using Dominio;
using GestionDatos;
using System.Data;

namespace Negocio
{
    public class N_Frecuencia
    {

        GD_Frecuencia objFrecuencia;

        public N_Frecuencia()
        {
            objFrecuencia = new GD_Frecuencia();
        }

        public DataTable listarFrecuencia()
        {
            return objFrecuencia.listar_Frecuencia();
        }
    }
}
