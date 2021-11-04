using Dominio;
using GestionDatos;
using System.Data;

namespace Negocio
{
    public class N_Usuario
    {
        GD_Usuario objusu;

        public N_Usuario()
        {
            objusu = new GD_Usuario();
        }
        public void IniciarSesion(Usuario ojb)
        {
            objusu.IniciarSesion(ojb);
        }


        public int RegistrarUsuario(Usuario usu)
        {
            return objusu.registrarUsuario(usu);
        }


        public void buscarUsuarioDni(Usuario ojb)
        {
            objusu.buscarUsuarioDni(ojb);
        }
    }
}
