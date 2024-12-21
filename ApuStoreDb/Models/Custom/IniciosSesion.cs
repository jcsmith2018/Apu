using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuStoreDb.Models
{
    public partial class IniciosSesion
    {

        public IniciosSesion Audit(int sesionId)
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

        public IniciosSesion Borrar(int sesionId)
        {
            Borrado = true;
            BorradoFecha = DateTime.Now;
            BorradoSesionId = sesionId;

            return this;
        }

        public bool Activo => Nivel > -1 && !Borrado;

        public string NombreApellidos => $"{Nombre} {Apellidos}".Trim();
                

        [NotMapped]
        public IEnumerable<Roles>? Roles { get; set; } = default!;       
        public Roles? Rol { get; set; } = default!;

        public IEnumerable<ProductosTipo> Registrador { get; set;} = default!;

        public IEnumerable<ProductosTipo> Editor { get; set; } = default!;
    }
}
