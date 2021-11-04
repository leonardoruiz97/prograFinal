using Dominio;
using GestionDatos;
using System.Data;

namespace Negocio
{
    public class N_Vivienda
    {
        GD_Vivienda objVivienda;

        public N_Vivienda()
        {
            objVivienda = new GD_Vivienda();
        }

        public DataTable listarVivienda()
        {
            return objVivienda.listar_Vivienda();
        }
    }
}
