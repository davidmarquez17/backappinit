using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal interface IGestorBerenice
    {
        Task<Empresa?> GetDetalleEmpresa(int? id);
        Task<bool> CreateEmpresa(Empresa empresa);
        Task<List<Empresa>> GetEmpresas();
        Task<bool> EditEmpresa(Empresa empresa);
        Task<bool> DeleteEmpresa(int id);
        Task<List<Cliente>> GetClientes();
    }
}
