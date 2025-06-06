﻿using Microsoft.EntityFrameworkCore;
using SistemaAdministrativoAPI.Data;
using SistemaAdministrativoAPI.Models.Atencion_Ciudadano;
using System;

namespace SistemaAdministrativoAPI.Servicios.Atencion_Ciudadano
{
    public class AtencionCiudadanoService
    {
        private readonly ApplicationDbContext _context;

        public AtencionCiudadanoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ciudadano>> GetUsuariosAsync()
        {
            return await _context.Ciudadanos.Include(u => u.Atenciones).ToListAsync();
        }

        public async Task<Ciudadano> GetUsuarioByIdAsync(int id)
        {
            return await _context.Ciudadanos.Include(u => u.Atenciones).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Ciudadano> BuscarPorDocumentoAsync(string documento)
        {
            return await _context.Ciudadanos.Include(u => u.Atenciones)
                                          .FirstOrDefaultAsync(u => u.NumeroDocumento == documento);
        }

        public async Task<Ciudadano> CreateUsuarioAsync(Ciudadano ciudadano)
        {
            // Verificar si el ciudadano ya existe por su documento
            var existingCiudadano = await _context.Ciudadanos
                .Include(c => c.Atenciones)
                .FirstOrDefaultAsync(c => c.NumeroDocumento == ciudadano.NumeroDocumento);

            if (existingCiudadano != null)
            {
                // Agregar nuevas atenciones al ciudadano existente
                foreach (var atencion in ciudadano.Atenciones)
                {
                    atencion.CiudadanoId = existingCiudadano.Id;
                    existingCiudadano.Atenciones.Add(atencion);
                }

                await _context.SaveChangesAsync();
                return existingCiudadano;
            }
            else
            {
                // Crear un nuevo ciudadano con sus atenciones
                _context.Ciudadanos.Add(ciudadano);
                await _context.SaveChangesAsync();
                return ciudadano;
            }
        }

        public async Task<bool> UpdateUsuarioAsync(int id, Ciudadano ciudadano)
        {
            if (id != ciudadano.Id) return false;

            _context.Entry(ciudadano).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return _context.Ciudadanos.Any(e => e.Id == id);
            }
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var usuario = await _context.Ciudadanos.FindAsync(id);
            if (usuario == null) return false;

            _context.Ciudadanos.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
