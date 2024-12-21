using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuStoreDb.Models
{
    public partial class ProductosColores
    {
        public ProductosColores Audit(int sesionId)
        {

            if (Id == 0)
            {
                Orden = 0;
                RegistroFecha = DateTime.Now;
                RegistroSesionId = sesionId;
                return this;
            }
            EdicionFecha = DateTime.Now;
            EdicionSesionId = sesionId;
            return this;
        }

        public ProductosColores Borrar(int sesionId)
        {
            Borrado = true;
            BorradoFecha = DateTime.Now;
            BorradoSesionId = sesionId;
            return this;
        }

        public IEnumerable<Productos>? Productos;
    }
}
