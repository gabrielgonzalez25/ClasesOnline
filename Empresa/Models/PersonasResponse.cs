using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa.Models
{
    public class PersonasResponse
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public List<T_Empleado> Data { get; set; }

    }
}
