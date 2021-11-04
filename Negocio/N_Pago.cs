using Dominio;
using GestionDatos;
using System.Data;
namespace Negocio
{
    public class N_Pago
    {
        GD_Pago objAmor;

        public N_Pago()
        {

            objAmor = new GD_Pago();
        }

        public int RegistrarAmortizacion(Pago amor)
        {
            return objAmor.registrarAmortizacion(amor);
        }
    }
}
