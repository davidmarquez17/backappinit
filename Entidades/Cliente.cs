using System;
using System.Collections.Generic;

namespace CRUD.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public int Empresa { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public virtual Empresa? EmpresaNavigation { get; set; } = null!;
}
