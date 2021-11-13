using Dominio;
using GestionDatos;
using System.Data;

namespace Negocio
{
    public class N_Movimiento
    {
        GD_Movimiento objMovimiento;

        public N_Movimiento()
        {
            objMovimiento = new GD_Movimiento();
        }

        public int registrarMovimiento(Movimiento mo)
        {
            return objMovimiento.registrarMovimiento(mo);
        }

        public int registrarAhorro(Movimiento mo)
        {
            return objMovimiento.registrarAhorro(mo);
        }

        public DataTable listarMovimientoxSocio(Socio soci)
        {
            return objMovimiento.listarMovimientoxSocio(soci);
        }
        public DataTable listarMovimiento()
        {
            return objMovimiento.listarMovimiento();
        }
    }
}
