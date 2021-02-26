using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using AccesoDato;

namespace LogicaNegocio
{
    public class lnAereoPuerto
    {
        adAereoPuertos _AD = new adAereoPuertos();
        public List<AereoPuerto> ObtenerAereoPuertos()
        {
            try
            {
                return _AD.ObtenerAereoPuertos();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public AereoPuerto ObtenerAereoPuerto(int pId)
        {
            try
            {
                return _AD.ObtenerAereoPuerto(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
