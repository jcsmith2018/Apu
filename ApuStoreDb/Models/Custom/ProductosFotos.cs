using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuStoreDb.Models
{
    public partial class ProductosFotos
    {
        public ProductosFotos Audit(int sesionId)
        {
            if (Id == 0)
            {
                RegistroFecha = DateTime.Now;
                RegistroSesionId = sesionId;
                return this;
            }
            EdicionFecha = DateTime.Now;
            EdicionSesionId = sesionId;
            return this;
        }

        public ProductosFotos Borrar(int sesionId)
        {
            Borrado = true;
            BorradoFecha = DateTime.Now;
            BorradoSesionId = sesionId;
            return this;
        }

        public Productos Producto { get; set; } = default!;

        public IEnumerable<Productos>? Productos;

    }
}
