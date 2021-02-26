using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using AccesoDato;

namespace LogicaNegocio
{
    public class lnViajeros
    {
        adViajeros _AD = new adViajeros();
        public List<Viajero> ObtenerViajeros()
        {
            try
            {
                return _AD.ObtenerViajeros();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Viajero ObtenerViajero(int pId)
        {
            try
            {
                return _AD.ObtenerViajero(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool InsertarViajero(Viajero pViajero)
        {
            try
            {
                return _AD.InsertarViajero(pViajero);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool ModificarViajero(Viajero pViajero)
        {
            try
            {
                _AD.ModificarViajero(pViajero);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool EliminarViajero(int pId)
        {
            try
            {
                _AD.EliminarViajero(pId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
