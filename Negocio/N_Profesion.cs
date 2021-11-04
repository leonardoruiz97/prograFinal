using Dominio;
using GestionDatos;
using System.Data;

namespace Negocio
{
  public class N_Profesion
    {
        GD_Profesion objProfesion;

        public N_Profesion()
        {
            objProfesion = new GD_Profesion();
        }


        public DataTable listarProfesion()
        {
            return objProfesion.listar_Profesion();
        }
    }
}
