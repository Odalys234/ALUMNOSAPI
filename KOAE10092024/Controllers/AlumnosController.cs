using KOAE10092024.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KOAE10092024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        // Declaración de una lista estática de objetos "Alumno" para almacenar alumnos.
        static List<Alumno> alumnos = new List<Alumno>();

        // Definición de un método HTTP GET que devuelve una colección de alumnos.
        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            return alumnos;
        }

        // Definición de un método HTTP GET que recibe un Id como parámetro y devuelve un alumno específico.
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var alumno = alumnos.FirstOrDefault(a => a.Id == id);
            if (alumno != null)
            {
                return Ok(alumno);
            }
            return NotFound(); // Devuelve 404 si no encuentra el alumno
        }

        // Definición de un método HTTP POST para agregar un nuevo alumno a la lista.
        [HttpPost]
        public IActionResult Post([FromBody] Alumno alumno)
        {
            alumnos.Add(alumno);
            return Ok(); // Devuelve 200 OK cuando se agrega el alumno
        }

        // Definición de un método HTTP PUT para actualizar un alumno existente en la lista por su Id.
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Alumno alumno)
        {
            var existingAlumno = alumnos.FirstOrDefault(a => a.Id == id);
            if (existingAlumno != null)
            {
                // Actualiza los datos del alumno existente con los datos proporcionados
                existingAlumno.Nombre = alumno.Nombre;
                existingAlumno.Apellido = alumno.Apellido;
                existingAlumno.Edad = alumno.Edad;
                return Ok(); // Devuelve 200 OK si la actualización es exitosa
            }
            else
            {
                return NotFound(); // Devuelve 404 si no encuentra el alumno
            }
        }

        // Definición de un método HTTP DELETE para eliminar un alumno por su Id.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingAlumno = alumnos.FirstOrDefault(a => a.Id == id);
            if (existingAlumno != null)
            {
                alumnos.Remove(existingAlumno);
                return Ok(); // Devuelve 200 OK cuando se elimina el alumno
            }
            else
            {
                return NotFound(); // Devuelve 404 si no encuentra el alumno
            }
        }
    }
}
