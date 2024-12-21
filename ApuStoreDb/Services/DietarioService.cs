using BcnDietarioDb.Models;
using BcnDietarioDb.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BcnDietarioDb.Services
{
    public class DietarioService
    {
        private ApuDbContext _db;
       
        public DietarioService(ApuDbContext context)
        {
            _db = context;            
        }

        public async Task<int> AddAsignacion(int sessionid, TareaOficiales asignacion)
        {
            asignacion.CoordId = sessionid;
            asignacion.Fecha = DateTime.Now;
            _db.TareaOficiales.Add(asignacion.Audit(sessionid));
            await _db.SaveChangesAsync();

            return asignacion.TareaId;
        }

        public async Task<int> AddContacto(int sessionid, TareaContactos contacto)
        {
            _db.TareaContactos.Add(contacto.Audit(sessionid));
            await _db.SaveChangesAsync();

            return contacto.TareaId;
        }

        public async Task CerrarAsignacion(int sessionId, CierreModel cierre)
        {
            var tarea = await _db.Tarea.FirstAsync(t => t.Id == cierre.TareaId);
            if (tarea != null)
            {
                tarea.TerminadaFecha = cierre.Fecha;
                tarea.TerminadaSesionId = sessionId;
                tarea.TerminadaTexto = cierre.Observaciones;
                tarea.TerminalSerie = cierre.SerieTerminal;
                tarea.Ucr1Serie = cierre.SerieDispositivo;
                tarea.TerminalSerieRetirado = cierre.SerieRetirado;
                tarea.Terminada = true;

                tarea.Audit(sessionId);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<int> AsignarDispositivo(int sessionId, TareaDispositivos dispositivo)
        {
            dispositivo.AlmaceneroId = sessionId;
            dispositivo.Fecha = DateTime.Now;
            _db.TareaDispositivos.Add(dispositivo.Audit(sessionId));
            await _db.SaveChangesAsync();

            return dispositivo.TareaId;
        }
        public async Task<int> AsignarLlave(int sessionId, TareaLlaves llaves)
        {            
            llaves.Fecha = DateTime.Now;
            _db.TareaLlaves.Add(llaves.Audit(sessionId));
            await _db.SaveChangesAsync();

            return llaves.TareaId;
        }
    }
}
