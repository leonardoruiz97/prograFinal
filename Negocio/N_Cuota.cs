using Dominio;
using GestionDatos;
using System.Data;

namespace Negocio
{
    public class N_Cuota
    {
        GD_Cuota objCuota;

        public N_Cuota()
        {

            objCuota = new GD_Cuota();
        }

        public int RegistrarCuota(Cuota cu)
        {
            return objCuota.registrarCuota(cu);
        }
    }
}
