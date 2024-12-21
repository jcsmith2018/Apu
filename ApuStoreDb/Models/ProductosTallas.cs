using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApuStoreDb.Models 
{
	[Table("productos_tallas", Schema = "dbo")]
	public partial class ProductosTallas
	{
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("id")]
		public int Id { get; set; }
		
		[StringLength(150, ErrorMessage = "No se admiten más de {1} caracter(es)")]
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("nombre")]
		public string? Nombre { get; set; }
		
		[StringLength(3, ErrorMessage = "No se admiten más de {1} caracter(es)")]
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("nombre_corto")]
		public string? NombreCorto { get; set; }



        [Column("orden")]
        public int? Orden { get; set; }



        [Column("registro_sesion_id")]
        public int? RegistroSesionId { get; set; }



        [Column("registro_fecha")]
        public DateTime? RegistroFecha { get; set; }



        [Column("edicion_sesion_id")]
        public int? EdicionSesionId { get; set; }



        [Column("edicion_fecha")]
        public DateTime? EdicionFecha { get; set; }



        [Column("borrado")]
        public bool Borrado { get; set; }



        [Column("borrado_sesion_id")]
        public int? BorradoSesionId { get; set; }



        [Column("borrado_fecha")]
        public DateTime? BorradoFecha { get; set; }

    }
}

