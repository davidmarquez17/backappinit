using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Negocio
{
    public class GestorBerenice : IGestorBerenice
    {
        private readonly BereniceContext _context;

        public GestorBerenice(BereniceContext context)
        {
            _context = context;
        }

        public async Task<Empresa?> GetDetalleEmpresa(int? id)
        {
            if (id == null || _context.Empresas == null)
            {
                return null;
            }

            var empresa = await _context.Empresas
                .FirstOrDefaultAsync(m => m.IdEmpresa == id);

            if (empresa == null)
            {
                return null;
            }

            return empresa;
        }

        public async Task<bool> CreateEmpresa(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Empresa>> GetEmpresas()
        {
            return await _context.Empresas.ToListAsync();
        }

        public async Task<bool> EditEmpresa(Empresa empresa)
        {

            try
            {
                _context.Empresas.Update(empresa);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
        public async Task<bool> DeleteEmpresa(int id)
        {
            if (_context.Empresas == null)
            {
                return false;
            }
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Cliente>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> GetDetalleCliente(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return null;
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ClienteId == id);

            if (cliente == null)
            {
                return null;
            }

            return cliente;
        }

        public async Task<bool> CreateCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditCliente(Cliente cliente)
        {

            try
            {
                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
        public async Task<bool> DeleteCliente(int id)
        {
            if (_context.Clientes == null)
            {
                return false;
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}