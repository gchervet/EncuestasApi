using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasApi_Domain.DTO
{
    public class UniEncuestaPreguntaDTO
    {
        public int IdEncuesta { get; set; }
        public int IdPregunta { get; set; }
        public int IdTipoPregunta { get; set; }
        public string TipoPreguntaNombre { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
    public class UniEncuestaDTO
    {
        public int IdEncuesta { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public List<UniEncuestaPreguntaDTO> PreguntaList { get; set; }
    }
    public class RespuestaRequestDTO
    {
        public int IdPregunta { get; set; }
        public int Value { get; set; }
        public int IdEncuesta { get; set; }
    }
    public class AlumnoRespuestaRequestDTO
    {
        public string Username { get; set; }
        public List<RespuestaRequestDTO> RespuestaList { get; set; }
    }
}
