using Dominio;
using GestionDatos;
using System.Data;
namespace Negocio
{
   public class N_Ocupacion
    {
        GD_Ocupacion objOcupa;

        public N_Ocupacion()
        {
            objOcupa = new GD_Ocupacion();

        }

        public DataTable listarOcupacion()
        {
            return objOcupa.listar_Ocupacion();
        }
    }
}
