using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasApi_Domain.DTO
{
    public class UniEncuestaPopupRespuestaAlumnoDTO
    {
        public int IdEncuesta { get; set; }
        public int IdPregunta { get; set; }
        public int Legajo { get; set; }
        public Nullable<int> RespuestaNumerica { get; set; }
        public string RespuestaTexto { get; set; }
        public System.DateTime Fecha { get; set; }
    }
}
