using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasApi_DATA.DAL
{
    public class UniEncuestasDAL
    {
        public static List<uniEncuestaPopup> GetAll()
        {
            using (var context = new UniEncuesta_Entities())
            {
                return context.uniEncuestaPopup.ToList();
            }
        }

        public static uniEncuestaPopup GetById(int id)
        {
            using (var context = new UniEncuesta_Entities())
            {
                return context.uniEncuestaPopup.Where(x => x.IdEncuesta == id).FirstOrDefault();
            }
        }

        public static uniEncuestaPopup GetByName(string name)
        {
            using (var context = new UniEncuesta_Entities())
            {
                return context.uniEncuestaPopup.Where(x => x.Nombre == name).FirstOrDefault();
            }
        }

        public static bool CreateRespuesta(List<uniEncuestaPopupRespuestaAlumno> uniEncuestaPopupRespuestaAlumnoModelList)
        {
            using (var context = new UniEncuesta_Entities())
            {
                try
                {
                    context.uniEncuestaPopupRespuestaAlumno.AddRange(uniEncuestaPopupRespuestaAlumnoModelList);

                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public static string GetLegajoByUsername(string username)
        {
            using (var context = new UniEncuesta_Entities())
            {
                vUniAlumnosUsername vUniAlumnoUsername = context.vUniAlumnosUsername.Where(x => x.Username == username).FirstOrDefault();
                if (vUniAlumnoUsername != null)
                {
                    return vUniAlumnoUsername.legajo;
                }
                return null;
            }
        }

        public static bool AlumnoRespuestaExists(int legajo)
        {
            using (var context = new UniEncuesta_Entities())
            {
                return context.uniEncuestaPopupRespuestaAlumno.Any(x => x.Legajo == legajo);
            }
        }

        public static List<uniEncuestaPopupPregunta> GetEncuestaPreguntaList(int idEncuesta)
        {
            using (var context = new UniEncuesta_Entities())
            {
                return context.uniEncuestaPopupPregunta.Where(x => x.IdEncuesta == idEncuesta).ToList();
            }
        }

        public static uniEncuestaPreguntaTipo GetTipoPreguntaById(int idTipoPregunta)
        {
            using (var context = new UniEncuesta_Entities())
            {
                return context.uniEncuestaPreguntaTipo.Where(x => x.idTipoEncuestaPregunta == idTipoPregunta).FirstOrDefault();
            }
        }
    }
}
