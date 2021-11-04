using Dominio;
using GestionDatos;
using System.Data;

namespace Negocio
{
    public class N_Patrocinador
    {
        GD_Patrocinador objpatro;

        public N_Patrocinador()
        {
            objpatro = new GD_Patrocinador();
        }
        public void buscarPatrocinadorDni(Patrocinador patro)
        {
            objpatro.buscarpatrocinadordni(patro);
        }

    }
}
