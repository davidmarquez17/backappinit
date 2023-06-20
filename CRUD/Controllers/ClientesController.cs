using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace CRUD.Controllers
{
    public class ClientesController : Controller
    {
        private readonly GestorBerenice _gestorBerenice;

        public ClientesController(GestorBerenice gestorBerenice)
        {
            _gestorBerenice = gestorBerenice;
        }

        // GET: Empresas
        public async Task<IActionResult> Index()
        {
            return Ok(await _gestorBerenice.GetClientes());
        }

        // GET: Empresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                var cliente = await _gestorBerenice.GetDetalleCliente(id);
                if (cliente != null) return Ok(cliente);
                else return BadRequest();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: Cliente/Create
        [HttpPost]
        public async Task<ActionResult> Create([FromBodyAttribute] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                await _gestorBerenice.CreateCliente(cliente);
            }
            return Ok();
        }

        // POST: Empresas/Edit/5
        [HttpPut]
        public async Task<ActionResult> Edit(int id, [FromBodyAttribute] Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await _gestorBerenice.EditCliente(cliente)) return Ok();
                else return BadRequest();
            }
            return BadRequest();
        }

        // POST: Empresas/Delete/5
        [HttpDelete, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _gestorBerenice.DeleteCliente(id)) return Ok();
            else return BadRequest();
        }
    }
}
