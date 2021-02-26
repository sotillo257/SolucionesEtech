using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Modelo;
using LogicaNegocio;

namespace SolucionesEtech.Controllers
{
    public class ViajerosxViajesController : ApiController
    {
        lnViajerosxViajes _lnViajerosxViajes = new lnViajerosxViajes();
        // GET: api/ViajerosxViajes
        [HttpGet]
        [Route("api/ViajerosxViajes/ObtenerViajesxViajeros")]
        public IHttpActionResult ObtenerViajesxViajeros(int pIdViajero)
        {
            return Json(new { Result = true, data = _lnViajerosxViajes.ObtenerViajesxViajero(pIdViajero) });
        }

        [HttpGet]
        [Route("api/ViajerosxViajes/ObtenerViajerosxViaje")]
        public IHttpActionResult ObtenerViajerosxViaje(int pIdViaje)
        {
            return Json(new { Result = true, data = _lnViajerosxViajes.ObtenerViajerosxViaje(pIdViaje) });
        }


        // GET: api/ViajerosxViajes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ViajerosxViajes
        [HttpPost]
        [Route("api/ViajerosxViajes/InsertarViajerosxViajes")]
        public IHttpActionResult InsertarViajerosxViajes(ViajerosxViajes pViajerosxViajes)
        {
            try
            {
                return Json(new { Result = _lnViajerosxViajes.InsertarViajeroxViaje(pViajerosxViajes) });
            }
            catch (Exception ex)
            {
            return Json(new { Result =false, Mensaje = ex.Message });
        }
            }
            

        // DELETE: api/ViajerosxViajes/5
        [HttpDelete]
        [Route("api/ViajerosxViajes/EliminarViajeRealizado")]
        public IHttpActionResult EliminarViajeRealizado(ViajerosxViajes pViajerosxViajes)
        {
            return Json(new { Result = true, data = _lnViajerosxViajes.EliminarViajeroxViaje(pViajerosxViajes) });
        }
    }
}
