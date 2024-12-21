using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApuStoreDb.Models 
{
	[Table("transacciones_formaspago", Schema = "dbo")]
	public partial class TransaccionesFormaspago
	{
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("id")]
		public int Id { get; set; }
		
		[StringLength(50, ErrorMessage = "No se admiten más de {1} caracter(es)")]
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("metodo_pago")]
		public string? MetodoPago { get; set; }
		
	}
}

