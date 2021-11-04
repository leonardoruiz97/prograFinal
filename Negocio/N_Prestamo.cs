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
   public class N_Prestamo
    {
        GD_Prestamo objpre;

          public N_Prestamo()
            {
                objpre = new GD_Prestamo();
            }


            public int RegistrarPrestamo(Prestamo pre)
            {
                return objpre.registrarPrestamo(pre);
            }

        public DataTable listarPrestamoPendiente(Prestamo pre)
        {
            return objpre.listaPrestamodPendiente(pre);
        }

        public DataTable listarPrestamoDenegada(Prestamo pre)
        {
            return objpre.listaPrestamoRechazado(pre);
        }

        public DataTable listarPrestamoAceptada(Prestamo pre)
        {
            return objpre.listaPrestamoAceptada(pre);
        }

        public void ActualizarEstadoPrestamo(Prestamo pre)
        {
            objpre.actualizarEstadoPrestamo(pre);
        }

        public void consultarPrestamo(Prestamo pre, Tipo_Prestamo tpre, Socio soc, Tipo_Vivienda tv, Profesion pro, Rubro ru, Situacion_Laboral sl, Frecuencia fre, Solicitud sol, Sexo sex, Estado_Civil ec, Distrito di, Ocupacion ocu, Estado_Prestamo epre)
        {
            objpre.ConsultarPrestamopk(pre, tpre, soc, tv, pro, ru, sl, fre,sol,sex,ec,di,ocu,epre);
        }

        public void consultarPrestamoSocio(Prestamo pre,Socio soc)
        {
            objpre.ConsultarPrestamoSocio(pre , soc);
        }

        public DataTable listarPrestamos(Prestamo pre)
        {
            return objpre.listaPrestamos(pre);
        }

        public DataTable listarPrestamosDesembolsado(Prestamo pre)
        {
            return objpre.listaPrestamosDesembolsado(pre);
        }

    }

}
