using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace CRUD.Controllers
{
    public class EmpresasController : Controller
    {

        private readonly GestorBerenice _gestorBerenice;

        public EmpresasController(GestorBerenice gestorBerenice)
        {
            _gestorBerenice = gestorBerenice;
        }

        // GET: Empresas
        public async Task<IActionResult> Index()
        {
            return Ok(await _gestorBerenice.GetEmpresas());
        }

        // GET: Empresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                var empresa = await _gestorBerenice.GetDetalleEmpresa(id);
                if(empresa != null) return Ok(empresa);
                else return BadRequest();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: Empresas/Create
        [HttpPost]
        public async Task<ActionResult> Create([FromBodyAttribute] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                await _gestorBerenice.CreateEmpresa(empresa);
            }
            return Ok();
        }

        // POST: Empresas/Edit/5
        [HttpPut]
        public async Task<ActionResult> Edit(int id, [FromBodyAttribute] Empresa empresa)
        {
            if (id != empresa.IdEmpresa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await _gestorBerenice.EditEmpresa(empresa)) return Ok();
                else return BadRequest();
            }
            return BadRequest();
        }

        // POST: Empresas/Delete/5
        [HttpDelete, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _gestorBerenice.DeleteEmpresa(id)) return Ok();
            else return BadRequest();
        }
    }
}
