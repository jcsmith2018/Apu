using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApuStoreDb.Models 
{
	[Table("productos_stocks", Schema = "dbo")]
	public partial class ProductosStocks
	{
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("id")]
		public int Id { get; set; }
		
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("id_producto")]
		public int IdProducto { get; set; }
		
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("cantidad")]
		public int Cantidad { get; set; }
		
	}
}

