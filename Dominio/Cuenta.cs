using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cuenta
    {

        public int PK_ICu_Cod { get; set; }
        public double FCu_Primer_Abono { get; set; }
        public double FCu_Incripcion { get; set; }
        public char CHCu_Numero_Cuenta{ get; set; }
        public double FCu_Monto_Total { get; set; }
        public int FK_IS_Cod { get; set; }

    }
}
