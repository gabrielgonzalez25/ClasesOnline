using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Empresa.Data;
using Empresa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Empresa.Controllers
{

    [ApiController]
    public class Personascontroller : ControllerBase
    {
        private PersonasContext _context;
        public Personascontroller(PersonasContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("api/Personas/ListaEmpleados")]
        public PersonasResponse ListaEmpleados()
        {
            PersonasResponse result = new PersonasResponse();
            try
            {
                List<T_Empleado> empleados = new List<T_Empleado>();
                empleados = _context.T_Empleado.ToList();

                result.Codigo = "01";
                result.Descripcion = "Exitoso";
                result.Data = empleados;

            }
            catch (Exception ex)
            {
                result = new PersonasResponse()
                {
                    Codigo = "02",
                    Descripcion = "Error: " + ex.Message,
                    Data = null
                };
                
            }
            
            
            return result;
        }

        [HttpPost]
        [Route("api/Personas/NuevosEmpleados")]
        public PersonasResponse CrearEmpleados([FromBody] JObject data)
        {
            PersonasResponse result = new PersonasResponse();

            
            try
            {
                string Nombre = data.GetValue("Nombre").Value<string>();
                string Apellido = data.GetValue("Apellido").Value<string>();

                T_Empleado nuevoEmpleado = new T_Empleado()
                {
                    Nombre = Nombre,
                    Apellido = Apellido

                };

                _context.T_Empleado.Add(nuevoEmpleado);
                _context.SaveChanges();
                
                List<T_Empleado> empleados = new List<T_Empleado>();
                empleados = _context.T_Empleado.Where(a => a.Apellido.Equals(Apellido) && a.Nombre.Equals(Nombre)).ToList();

                result.Codigo = "01";
                result.Descripcion = "Exitoso";
                result.Data = empleados;

            }
            catch (Exception ex)
            {
                result = new PersonasResponse()
                {
                    Codigo = "02",
                    Descripcion = "Error: " + ex.Message,
                    Data = null
                };

            }


            return result;
        }

    }
}
