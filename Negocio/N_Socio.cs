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
  public  class N_Socio
    {
        GD_Socio objso;

        public N_Socio()
        {
            objso = new GD_Socio();
        }


        public int RegistrarSocio(Socio so)
        {
            return objso.registrarSocio(so);
        }


        public void BuscarSocioxdni(Socio so)
        {
            objso.buscarSocio(so);
        }

        public void BuscarSocio(Socio so)
        {
            objso.buscarsociodni(so);
        }


        public void consultarSocioPrestamoxdni(Socio socio, Sexo sex,Estado_Civil ec,Distrito dis ,Ocupacion ocu)
        {
            objso.buscarSocioPrestamoxDni(socio,sex,ec,dis,ocu);
        }



        public DataTable listarPrestamoPendientexsocio(Socio soci)
        {
            return objso.listaPrestamoPendienteSocio(soci);
        }

        public DataTable listarPrestamoAceptadoxsocio(Socio soci)
        {
            return objso.listaPrestamoAceptadoSocio(soci);
        }

        public DataTable listarSociosHabilitados(Socio soci)
        {
            return objso.listaSociosHabilitados(soci);
        }

        public DataTable listarSociosSuspendidos(Socio soci)
        {
            return objso.listaSociosSuspendidos(soci);
        }


        public void ActualizarEstadoSocio(Socio soci)
        {
            objso.actualizarEstadoSocio(soci);
        }

        public void consultarSocio(Socio soc, Solicitud sol, Estado_Civil ec, Distrito di, Ocupacion ocu, Provincia pro, Estado_Socio es)
        {
            objso.ConsultarSociopk(soc, sol, ec, di, ocu, pro, es);
        }

        public void BuscarSocioAfiPatro(Socio so, Afiliacion afi)
        {
            objso.buscarSocioAfiPatro(so, afi);
        }

        public void BuscarSocioDatosPatro(Patrocinador patro)
        {
            objso.buscarSocioDatosPatro(patro);
        }
   

        public void ActualizarDatosSocio(Solicitud sol)
        {
            objso.ActualizarDatoSocios(sol);
        }
    }
}
