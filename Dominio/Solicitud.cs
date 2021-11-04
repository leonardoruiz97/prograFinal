using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
  public class Solicitud
    {
        public int PK_ISol_Cod { get; set; }
        public int ISol_Dni { get; set; }
        public string VSol_Nombre_Completo { get; set; }
        public string VSol_Apellido_Paterno { get; set; }
        public string VSol_Apellido_Materno { get; set; }
        public DateTime DSol_Fecha_Nacimiento { get; set; }

        public DateTime DSol_Fecha_Registro { get; set; }

        public string VSol_Direccion { get; set; }
        public string VSol_Correo { get; set; }

        public int ISol_Celular { get; set; }
        public int ISol_Telefono_Fijo { get; set; }

        public byte[] IMSol_Recibo_Luz { get; set; }
        public byte[] IMSol_Recibo_agua { get; set; }
        public byte[] IMSol_Imagen_Vivienda { get; set; }
        public byte[] IMSol_Constancia { get; set; }


        public int FK_ID_Cod { get; set; }

        public int FK_IPro_Cod { get; set; }

        public int FK_IEc_Cod { get; set; }

        public int FK_IOcu_Cod { get; set; }




        public int FK_IESol_Cod { get; set; }

        public int FK_IA_Cod { get; set; }

        public string DepartamentoResidencia { get; set; }

        public int FK_ISe_Cod { get; set; }

        public int FK_IDi_Cod { get; set; }


        public int estado { get; set; }

    }
}
