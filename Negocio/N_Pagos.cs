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
    public class N_Pagos

    {
        GD_Pagos objpa;

        public N_Pagos()
        {
            objpa = new GD_Pagos();
        }
        

        public DataTable ListarPagos(Prestamo pa)
        {
            return objpa.ListarPagos(pa);
        }

        public int RegistrarPagoxCuota(Pago pag, Cuota cuo)
        {
            return objpa.registrarPagoxCuota(pag, cuo);
        }
    }
}
