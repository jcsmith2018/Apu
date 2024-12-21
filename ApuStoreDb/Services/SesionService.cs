using Microsoft.EntityFrameworkCore;
using ApuStoreDb;
using ApuStoreDb.Models;


namespace ApuStoreDb.Services
{
    public class SesionService
    {
        private ApuDbContext db;
        public SesionService(ApuDbContext context) 
        { 
            db = context;
        }

        public IniciosSesion? ByUsername(string username)
        {
            return db.IniciosSesion.FirstOrDefault(u => u.Usuario == username);
        }

        public async Task<IList<IniciosSesion>> Buscar(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return await db.IniciosSesion.ToListAsync();
            }

            return await db.IniciosSesion.
                Where(u =>
                    (u.Usuario != null && u.Usuario.Contains(valor))
                    || (u.Nombre != null && u.Nombre.Contains(valor))
                    || (u.Apellidos != null && u.Apellidos.Contains(valor))
            ).ToListAsync();
        }

        
        public IniciosSesion? ById(int id)
        {
            return db.IniciosSesion.FirstOrDefault(u => u.Id == id);
        }

        public void BorrarAcceso(int sesionId, IniciosSesion acceso) 
        {
            acceso.Borrar(sesionId);
            db.Entry(acceso).State = EntityState.Modified;
            db.SaveChanges();
        }
        public IEnumerable<Roles> GetRolesMulti(IniciosSesion sesion)
        {
            List<Roles> result = new List<Roles>();

            var rolesId = sesion.RolesId?.Split(',').Select(int.Parse);

            foreach (int rolid in rolesId!)
            {
                var rol = db.Roles.FirstOrDefault(u => u.Id == rolid);
                result.Add(rol!);
            }

            return result;
        }

        public IEnumerable<Roles> GetRoles(IniciosSesion sesion)
        {
            List<Roles> result = new List<Roles>();

            result.Add(db.Roles.FirstOrDefault(r => r.Id == sesion.RolId) ?? db.Roles.First(r => r.Id == 2)); //por defecto es INVITADO

            return result;
        }

        public IQueryable<ProductosTipo> GetProductosTipo()
        {
            return db.ProductosTipo
            .Include(p => p.GrabadoPor)
            .Include(p => p.EditadoPor);
        }
    }
}
