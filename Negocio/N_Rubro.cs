using Dominio;
using GestionDatos;
using System.Data;

namespace Negocio
{
  public class N_Rubro
    {
        GD_Rubro objRubro;

        public N_Rubro()
        {
            objRubro = new GD_Rubro();
        }

        public DataTable listarRubro()
        {
            return objRubro.listar_Rubro();
        }

    }
}
