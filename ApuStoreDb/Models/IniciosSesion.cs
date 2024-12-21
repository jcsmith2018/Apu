using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApuStoreDb.Models 
{
	[Table("inicios_sesion", Schema = "dbo")]
	public partial class IniciosSesion
	{
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("id")]
		public int Id { get; set; }
		
		[StringLength(25, ErrorMessage = "No se admiten más de {1} caracter(es)")]
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("usuario")]
		public string? Usuario { get; set; }
		
		[StringLength(50, ErrorMessage = "No se admiten más de {1} caracter(es)")]
		
		[Column("clave")]
		public string? Clave { get; set; }
		
		[StringLength(50, ErrorMessage = "No se admiten más de {1} caracter(es)")]
		
		[Column("nombre")]
		public string? Nombre { get; set; }
		
		[StringLength(100, ErrorMessage = "No se admiten más de {1} caracter(es)")]
		
		[Column("apellidos")]
		public string? Apellidos { get; set; }
		
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("perfil_id")]
		public int PerfilId { get; set; }
		
		[StringLength(150, ErrorMessage = "No se admiten más de {1} caracter(es)")]
		
		[Column("roles_id")]
		public string? RolesId { get; set; }
		
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("nivel")]
		public int Nivel { get; set; }
		
		[StringLength(15, ErrorMessage = "No se admiten más de {1} caracter(es)")]
		
		[Column("telefono")]
		public string? Telefono { get; set; }
		
		[StringLength(250, ErrorMessage = "No se admiten más de {1} caracter(es)")]
		
		[Column("email")]
		public string? Email { get; set; }
		
		[StringLength(250, ErrorMessage = "No se admiten más de {1} caracter(es)")]
		
		[Column("observaciones")]
		public string? Observaciones { get; set; }

        [Column("rol_id")]
        public int? RolId { get; set; }


        [Column("registro_sesion_id")]
		public int? RegistroSesionId { get; set; }
		
		
		
		[Column("registro_fecha")]
		public DateTime? RegistroFecha { get; set; }
		
		
		
		[Column("edicion_sesion_id")]
		public int? EdicionSesionId { get; set; }
		
		
		
		[Column("edicion_fecha")]
		public DateTime? EdicionFecha { get; set; }
		
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Column("borrado")]
		public bool Borrado { get; set; }
		
		
		
		[Column("borrado_sesion_id")]
		public int? BorradoSesionId { get; set; }
		
		
		
		[Column("borrado_fecha")]
		public DateTime? BorradoFecha { get; set; }
		
	}
}

