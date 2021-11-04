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
   public class N_Tipo_Prestamo
    {
        GD_Tipo_Prestamo objTPrestamo;
        public N_Tipo_Prestamo()
        {
            objTPrestamo = new GD_Tipo_Prestamo();
        }


        public DataTable listarTipoPrestamo()
        {
            return objTPrestamo.listar_Tipo_Prestamo();
        }

    }
}
