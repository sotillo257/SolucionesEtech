using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using AccesoDato;

namespace LogicaNegocio
{
    public class lnViajerosxViajes
    {
        adViajerosxViajes _AD = new adViajerosxViajes();
        public List<ViajerosxViajes> ObtenerViajerosxViajes()
        {
            try
            {
                return _AD.ObtenerViajerosxViajes();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<ViajerosxViajes> ObtenerViajesxViajero(int pIdViajero)
        {
            try
            {
                return _AD.ObtenerViajerosxViajes().Where(x => x.Viajero.Id == pIdViajero).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<ViajerosxViajes> ObtenerViajerosxViaje(int pIdViaje)
        {
            try
            {
                return _AD.ObtenerViajerosxViajes().Where(x => x.Viaje.Id == pIdViaje).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        

        public ViajerosxViajes ObtenerViajeroxViaje(int pId)
        {
            try
            {
                return _AD.ObtenerViajeroxViaje(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool InsertarViajeroxViaje(ViajerosxViajes pViajerosxViajes)
        {
            try
            {
                adViajes adViajes = new adViajes();
                Viaje viaje = adViajes.ObtenerViaje(pViajerosxViajes.Viaje.Id);
                if (viaje.NumeroPlazas > 0 )
                {
                    if (_AD.InsertarViajeroxViaje(pViajerosxViajes))
                    {
                        viaje.NumeroPlazas = viaje.NumeroPlazas - 1;
                        return adViajes.ModificarViaje(viaje);
                    }
                }
                else
                {
                    throw new Exception("El viaje no tiene plazas disponibles");
                }
                
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool ModificarViajeroxViaje(ViajerosxViajes pViajerosxViajes)
        {
            try
            {
                
                return _AD.ModificarViajeroxViaje(pViajerosxViajes);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool EliminarViajeroxViaje(ViajerosxViajes pViajerosxViajes)
        {
            try
            {
                adViajes adViajes = new adViajes();
                Viaje viaje = adViajes.ObtenerViaje(pViajerosxViajes.Viaje.Id);
                viaje.NumeroPlazas++;
                adViajes.ModificarViaje(viaje);
                _AD.EliminarViajeroxViaje(pViajerosxViajes.Id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
