using EncuestasApi_Domain.DTO;
using EncuestasApi_Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EncuestasApi.Controllers
{
    [RoutePrefix("api/Encuesta")]
    public class EncuestaController : ApiController
    {
        [Route("GetAll")]
        [HttpGet]
        [AllowAnonymous]
        public List<UniEncuestaDTO> GetAll()
        {
            return UniEncuestaService.GetAll();
        }

        [Route("GetByNameOrId")]
        [HttpGet]
        [AllowAnonymous]
        public UniEncuestaDTO GetByNameOrId(string idName)
        {
            return UniEncuestaService.GetByNameOrId(idName);
        }

        [Route("CreateRespuesta")]
        [HttpPost]
        [AllowAnonymous]
        public bool CreateRespuesta([FromBody]AlumnoRespuestaRequestDTO alumnoRespuestaRequestDTO)
        {
            return UniEncuestaService.CreateRespuesta(alumnoRespuestaRequestDTO);
        }

        [Route("AlumnoRespuestaExists")]
        [HttpGet]
        [AllowAnonymous]
        public bool AlumnoRespuestaExists(string username)
        {
            return UniEncuestaService.AlumnoRespuestaExists(username);
        }

        [Route("SendEmail")]
        [HttpGet]
        [AllowAnonymous]
        public void AlumnoRespuestaExists(string username)
        {
            /*
            DataSet dataSet = UniEncuestaService.GetEncuestaDataSet();
            string htmlString = getHtml(dataSet);
            SendAutomatedEmail(htmlString, "email@domain.com");
            */
        }
    }
}