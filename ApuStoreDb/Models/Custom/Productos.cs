using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuStoreDb.Models
{
    public partial class Productos

    {
        public Productos Audit(int sesionId)
        {            
            if (Id == 0)
            {
                RegistroFecha = DateTime.Now;
                RegistroSesionId = sesionId;
                Estado = 1;
                return this;
            }
            EdicionFecha = DateTime.Now;
            EdicionSesionId = sesionId;
            return this;
        }

        public Productos Borrar(int sesionId)
        {
            Borrado = true;
            BorradoFecha = DateTime.Now;
            BorradoSesionId = sesionId;
            return this;
        }

        public ProductosTipo? Tipo { get; set; } = default!;
        public ProductosTallas? Talla { get; set; } = default!;
        public ProductosColores? Color { get; set; } = default!;
        public ProductosMarcas? Marca {  get; set; } = default!;
        public IEnumerable<ProductosFotos>? Fotos { get; set; } = default!;
        //public ProductosFotos? Foto { get; set; } = default!;

    }

}
