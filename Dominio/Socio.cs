using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Socio
    {
        public int PK_IS_Cod { get; set; }
        public int IS_Dni { get; set; }
        public string VS_Nombre_Completo { get; set; }
        public string VS_Apellido_Paterno { get; set; }
        public string VS_Apellido_Materno { get; set; }
        public DateTime DS_Fecha_Nacimiento { get; set; }

        public DateTime DS_Fecha_Registro { get; set; }

        public int FK_ISol_Cod { get; set; }
        public int FK_IESocio_Cod { get; set; }
        public int Fk_IOcu_Cod { get; set; }
        public int Fk_IEc_Cod { get; set; }
        public int Fk_IDi_Cod { get; set; }


        public int estado { get; set; }
    

    }
}
