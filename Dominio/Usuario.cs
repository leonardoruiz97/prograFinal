using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public class Usuario
    {
        public int PK_IU_Cod { get; set; }
        public string VU_Correo { get; set; }
        public string VU_Contraseña { get; set; }
        public int IU_Dni { get; set; }
     
        public int FK_IRo_Cod { get; set; }

        public int FK_IS_Cod { get; set; }
        public int FK_IPa_Cod { get; set; }

        public int estado { get; set; }
    }
}
