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

        public static List<sp_get_uni_encuesta_registro_alumnos_Result> GetRegistroAlumno()
        {
            using (var context = new UniEncuesta_Entities())
            {
                return context.sp_get_uni_encuesta_registro_alumnos().ToList();
            }
        }

        public static void GenerarRegistro(List<sp_get_uni_encuesta_registro_alumnos_Result> sp_get_uni_encuesta_registro_alumnos_Result)
        {
            using (var context = new UniEncuesta_Entities())
            {
                foreach (sp_get_uni_encuesta_registro_alumnos_Result sp_get_uni_encuesta_registro_alumnos in sp_get_uni_encuesta_registro_alumnos_Result)
                {
                    uniEncuestaRegistroAlumnos uniEncuestaRegistroAlumnos = new uniEncuestaRegistroAlumnos();
                    uniEncuestaRegistroAlumnos.Legajo = sp_get_uni_encuesta_registro_alumnos.LegajoDefinitivo.ToString();
                    uniEncuestaRegistroAlumnos.Nombre = sp_get_uni_encuesta_registro_alumnos.Nombre.ToString();
                    uniEncuestaRegistroAlumnos.Apellido = sp_get_uni_encuesta_registro_alumnos.Apellido.ToString();
                    uniEncuestaRegistroAlumnos.Modalidad = sp_get_uni_encuesta_registro_alumnos.Modalidad.ToString();
                    uniEncuestaRegistroAlumnos.Carrera = sp_get_uni_encuesta_registro_alumnos.Carrera.ToString();
                    uniEncuestaRegistroAlumnos.FechaIngreso = DateTime.Now;

                    if (sp_get_uni_encuesta_registro_alumnos.ID.HasValue)
                    {
                        uniEncuestaRegistroAlumnos.AlumnoDNI = sp_get_uni_encuesta_registro_alumnos.ID.Value.ToString();
                    }
                    else
                    {
                        uniEncuestaRegistroAlumnos.AlumnoDNI = string.Empty;
                    }

                    context.uniEncuestaRegistroAlumnos.Add(uniEncuestaRegistroAlumnos);

                    try
                    {
                        context.SaveChanges();
                    }
                    catch(Exception e)
                    {
                        return;
                    }
                }
            }
        }
    }
}
