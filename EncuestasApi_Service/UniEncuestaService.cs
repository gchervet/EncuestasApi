using EncuestasApi_Domain.DTO;
using EncuestasApi_DATA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncuestasApi_DATA;

namespace EncuestasApi_Service
{
    public class UniEncuestaService
    {
        public static List<UniEncuestaDTO> GetAll()
        {
            List<UniEncuestaDTO> rtn = new List<UniEncuestaDTO>();
            List<uniEncuestaPopup> uniEncuestaPopupList = UniEncuestasDAL.GetAll();

            foreach (uniEncuestaPopup uniEncuestaPopup in uniEncuestaPopupList)
            {
                UniEncuestaDTO uniEncuestaDTO = new UniEncuestaDTO();
                uniEncuestaDTO.Descripcion = uniEncuestaPopup.Descripcion;
                uniEncuestaDTO.IdEncuesta = uniEncuestaPopup.IdEncuesta;
                uniEncuestaDTO.Nombre = uniEncuestaPopup.Nombre;

                rtn.Add(uniEncuestaDTO);
            }
            return rtn;
        }

        public static UniEncuestaDTO GetByNameOrId(string idName)
        {
            if (idName != null)
            {
                int id = 0;
                uniEncuestaPopup uniEncuestaPopup = null;

                if (Int32.TryParse(idName, out id))
                {
                    uniEncuestaPopup = UniEncuestasDAL.GetById(id);
                }
                else
                {
                    string name = idName;
                    uniEncuestaPopup = UniEncuestasDAL.GetByName(name);
                }
                if (uniEncuestaPopup != null)
                {
                    UniEncuestaDTO rtn = new UniEncuestaDTO();
                    rtn.Descripcion = uniEncuestaPopup.Descripcion;
                    rtn.IdEncuesta = uniEncuestaPopup.IdEncuesta;
                    rtn.Nombre = uniEncuestaPopup.Nombre;
                    rtn.PreguntaList = new List<UniEncuestaPreguntaDTO>();

                    List<uniEncuestaPopupPregunta> uniEncuestaPopupPreguntaList = UniEncuestasDAL.GetEncuestaPreguntaList(rtn.IdEncuesta);

                    foreach (uniEncuestaPopupPregunta uniEncuestaPopupPregunta in uniEncuestaPopupPreguntaList)
                    {
                        UniEncuestaPreguntaDTO uniEncuestaPreguntaDTO = new UniEncuestaPreguntaDTO();
                        uniEncuestaPreguntaDTO.Descripcion = uniEncuestaPopupPregunta.Descripcion;
                        uniEncuestaPreguntaDTO.IdEncuesta = uniEncuestaPopupPregunta.IdEncuesta;
                        uniEncuestaPreguntaDTO.IdPregunta = uniEncuestaPopupPregunta.IdPregunta;
                        uniEncuestaPreguntaDTO.IdTipoPregunta = uniEncuestaPopupPregunta.IdTipoPregunta;
                        uniEncuestaPreguntaDTO.Nombre = uniEncuestaPopupPregunta.Nombre;

                        // Tipo Pregunta
                        uniEncuestaPreguntaTipo uniEncuestaPreguntaTipo = UniEncuestasDAL.GetTipoPreguntaById(uniEncuestaPreguntaDTO.IdTipoPregunta);
                        if (uniEncuestaPreguntaTipo != null)
                        {
                            uniEncuestaPreguntaDTO.TipoPreguntaNombre = uniEncuestaPreguntaTipo.Nombre;
                        }

                        rtn.PreguntaList.Add(uniEncuestaPreguntaDTO);
                    }
                    return rtn;
                }
            }
            return null;
        }

        public static bool CreateRespuesta(AlumnoRespuestaRequestDTO alumnoRespuestaRequestDTO)
        {
            if(alumnoRespuestaRequestDTO != null)
            {
                // 1. Buscar el legajo del alumno
                string legajo = UniEncuestasDAL.GetLegajoByUsername(alumnoRespuestaRequestDTO.Username);
                if(legajo != null)
                {
                    List<uniEncuestaPopupRespuestaAlumno> uniEncuestaPopupRespuestaAlumnoModelList = new List<uniEncuestaPopupRespuestaAlumno>();
                    foreach (RespuestaRequestDTO respuesta in alumnoRespuestaRequestDTO.RespuestaList)
                    {
                        uniEncuestaPopupRespuestaAlumno uniEncuestaPopupRespuestaAlumnoModel = new uniEncuestaPopupRespuestaAlumno();

                        uniEncuestaPopupRespuestaAlumnoModel.Fecha = DateTime.Now;
                        uniEncuestaPopupRespuestaAlumnoModel.IdEncuesta = respuesta.IdEncuesta;
                        uniEncuestaPopupRespuestaAlumnoModel.IdPregunta = respuesta.IdPregunta;
                        uniEncuestaPopupRespuestaAlumnoModel.Legajo = Int32.Parse(legajo);
                        uniEncuestaPopupRespuestaAlumnoModel.RespuestaNumerica = respuesta.Value;
                        uniEncuestaPopupRespuestaAlumnoModel.RespuestaTexto = null;

                        uniEncuestaPopupRespuestaAlumnoModelList.Add(uniEncuestaPopupRespuestaAlumnoModel);
                    }
                    if (uniEncuestaPopupRespuestaAlumnoModelList.Count > 0)
                    {
                        return UniEncuestasDAL.CreateRespuesta(uniEncuestaPopupRespuestaAlumnoModelList);
                    }
                }

            }
            
            
            return false;
        }

        public static bool AlumnoRespuestaExists(string username)
        {
            string legajoStr = UniEncuestasDAL.GetLegajoByUsername(username);
            int legajo = 0;

            if (legajoStr != null)
            {
                if (Int32.TryParse(legajoStr, out legajo))
                {
                    return UniEncuestasDAL.AlumnoRespuestaExists(legajo);
                }
            }
            return true;
        }
    }
}
