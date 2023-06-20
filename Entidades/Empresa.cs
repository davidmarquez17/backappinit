using System;
using System.Collections.Generic;

namespace CRUD.Models;

public partial class Empresa
{
    public int IdEmpresa { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
