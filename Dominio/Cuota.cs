﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cuota
    {
        public int PK_IC_Cod { get; set; }

        public int IC_NumeroCuota { get; set; }

        public DateTime DC_FechaPago { get; set; }

        public double FC_MontoCuota { get; set; }

        public DateTime DC_FechaInicio { get; set; }

        public DateTime DC_FechaFin { get; set; }

        public int FK_IPre_Cod { get; set; }

        public int FK_IECU_Cod { get; set; }

    }
}
