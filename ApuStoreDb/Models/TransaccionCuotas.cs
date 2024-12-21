using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApuStoreDb.Models 
{
	[Table("transaccion_cuotas", Schema = "dbo")]
	public partial class TransaccionCuotas
	{
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("id")]
		public int Id { get; set; }
		
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("id_transaccion")]
		public int IdTransaccion { get; set; }
		
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("numero_cuota")]
		public int NumeroCuota { get; set; }
		
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("monto_cuota")]
		public double MontoCuota { get; set; }
		
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("fecha_vencimiento")]
		public DateTime FechaVencimiento { get; set; }
		
		
		
		[Column("fecha_pago")]
		public DateTime? FechaPago { get; set; }
		
		[StringLength(30, ErrorMessage = "No se admiten más de {1} caracter(es)")]
		
		[Column("estado_pago")]
		public string? EstadoPago { get; set; }
		
	}
}

