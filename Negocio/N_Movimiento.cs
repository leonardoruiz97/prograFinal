<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GestionDatos;
using Dominio;
=======
﻿using Dominio;
using GestionDatos;
using System.Data;
>>>>>>> 2e117e603b0885bcbfe2e51c888694f135425927

namespace Negocio
{
    public class N_Movimiento
    {
<<<<<<< HEAD
        GD_Movimiento objMov;

        public N_Movimiento() 
        {
            objMov = new GD_Movimiento();
        }

        public int RegistrarMovimientoxCuotaPagada(Movimiento mov)
        {
            return objMov.registrarMovimientoxCuotaPagada(mov);
=======
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
>>>>>>> 2e117e603b0885bcbfe2e51c888694f135425927
        }
    }
}
