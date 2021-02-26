using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Modelo;

namespace SolucionesEtech.Controllers
{
    public class ViajesController : ApiController
    {
        lnViajes _lnViajes = new lnViajes();
        // GET: api/Viajes
        [HttpGet]
        [Route("api/Viajes/ObtenerViajes")]
        public IHttpActionResult ObtenerViajes()
        {
            return Json(new { Result = true, data = _lnViajes.ObtenerViajes() });
        }

        [HttpGet]
        [Route("api/Viajes/ObtenerViajesExcluyendoViajero")]
        public IHttpActionResult ObtenerViajesExcluyendoViajero(int pIdViajero)
        {
            return Json(new { Result = true, data = _lnViajes.ObtenerViajesExcluyendoViajero(pIdViajero) });
        }

        public Viaje ObtenerViaje(int pId)
        {
            return _lnViajes.ObtenerViaje(pId);
        }

        // POST: api/Viajes
        [HttpPost]
        [Route("api/Viajes/InsertarViaje")]
        public IHttpActionResult InsertarViaje(Viaje pViaje)
        {
            return Json(new { Result = _lnViajes.InsertarViaje(pViaje) });
        }

        [Route("api/Viajes/ModificarViaje")]
        [HttpPut]
        // PUT: api/Viajes/5
        public IHttpActionResult ModificarViaje(Viaje pViaje)
        {
            return Json(new { Result = _lnViajes.ModificarViaje(pViaje) });
        }

        [Route("api/Viajes/EliminarViaje")]
        [HttpDelete]
        // DELETE: api/Viajes/5
        public IHttpActionResult EliminarViaje(Viaje pViaje)
        {
            return Json(new { Result = _lnViajes.EliminarViaje(pViaje.Id) });
        }
    }
}
