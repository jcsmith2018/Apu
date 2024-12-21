using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApuStoreDb.Models 
{
	[Table("productos", Schema = "dbo")]
	public partial class Productos
	{
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("id")]
		public int Id { get; set; }
		
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("tipo_id")]
		public int TipoId { get; set; }
		
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("marca_id")]
		public int MarcaId { get; set; }
		
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("color_id")]
		public int ColorId { get; set; }
		
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("talla_id")]
		public int TallaId { get; set; }
		
		
		
		[Column("fecha_compra")]
		public DateTime? FechaCompra { get; set; }
		
		[StringLength(100, ErrorMessage = "No se admiten más de {1} caracter(es)")]
		
		[Column("nombre")]
		public string? Nombre { get; set; }
		
		[StringLength(500, ErrorMessage = "No se admiten más de {1} caracter(es)")]
		
		[Column("descripcion")]
		public string? Descripcion { get; set; }
		
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("precio_fabricante")]
		public decimal PrecioFabricante { get; set; }
		
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("precio_compra")]
		public decimal PrecioCompra { get; set; }
		
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("precio_venta")]
		public decimal PrecioVenta { get; set; }
		
		[StringLength(250, ErrorMessage = "No se admiten más de {1} caracter(es)")]
		
		[Column("observaciones")]
		public string? Observaciones { get; set; }


        [Column("orden")]
        public int? Orden { get; set; }


        [Column("estado")]
        public int? Estado { get; set; }


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

