using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroEstudiante.Models
{
    public class Estudiantes
    {
        [Key]

        public int EstudianteID { get; set; }

        [Required(ErrorMessage = "Es obligarotio introducir el nombre")]
        public string Nombre { get; set; }

        [Range(minimum: 1, maximum: 10, ErrorMessage = " Seleccione un semestre")]
        public int Semestre { get; set; }
    }
}
