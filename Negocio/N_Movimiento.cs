using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GestionDatos;
using Dominio;

namespace Negocio
{
    public class N_Movimiento
    {
        GD_Movimiento objMov;

        public N_Movimiento() 
        {
            objMov = new GD_Movimiento();
        }

        public int RegistrarMovimientoxCuotaPagada(Movimiento mov)
        {
            return objMov.registrarMovimientoxCuotaPagada(mov);
        }
    }
}
