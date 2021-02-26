using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Viaje
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int NumeroPlazas { get; set; }
        public decimal Precio { get; set; }
        public AereoPuerto Destino { get; set; }
        public AereoPuerto Origen { get; set; }
        public List<Viajero> listViajeros { get; set; }

    }
}
