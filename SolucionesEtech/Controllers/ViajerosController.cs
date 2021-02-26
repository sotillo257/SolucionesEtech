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
    [Route("api/Viajeros")]
    public class ViajerosController : ApiController
    {
        lnViajeros _lnViajeros = new lnViajeros();
        // GET: api/Viajeros
        [HttpGet]
        [Route("api/Viajeros/ObtenerViajeros")]
        public IHttpActionResult ObtenerViajeros()
        {
            return Json(new { Result = true, data = _lnViajeros.ObtenerViajeros()  });             
        }

        public Viajero ObtenerViajero(int pId)
        {
            return _lnViajeros.ObtenerViajero(pId);
        }

        // POST: api/Viajeros
        [HttpPost]
        [Route("api/Viajeros/InsertarViajero")]
        public IHttpActionResult InsertarViajero(Viajero pViajero)
        {
            return Json(new { Result = _lnViajeros.InsertarViajero(pViajero)});
        }

        [Route("api/Viajeros/ModificarViajero")]
        [HttpPut]
        // PUT: api/Viajeros/5
        public IHttpActionResult ModificarViajero(Viajero pViajero)
        {
            return Json(new { Result = _lnViajeros.ModificarViajero(pViajero) });
        }

        [Route("api/Viajeros/EliminarViajero")]
        [HttpDelete]
        // DELETE: api/Viajeros/5
        public IHttpActionResult EliminarViajero(Viajero pViajero)
        {
            return Json(new { Result = _lnViajeros.EliminarViajero(pViajero.Id) });
        }
    }
}
