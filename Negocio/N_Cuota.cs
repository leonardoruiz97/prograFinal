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


        public DataTable ListarCuotaMoroso(Cuota cu)
        {
            return objCuota.listarCuotaMoroso(cu);
        }

        public void ActualizarEstadoCuota(Cuota cuo)
        {
            objCuota.ActualizarEstadoCuota(cuo);
        }

        public void ConsultarImporteAPagarxCuota(Cuota cuo)
        {
            objCuota.ConsultarImporteAPagarxCuota(cuo);
        }

        public DataTable ListarCuotasxPrestamo(Cuota cu)
        {
            return objCuota.listarCuotasxPrestamo(cu);
        }
    }
}
