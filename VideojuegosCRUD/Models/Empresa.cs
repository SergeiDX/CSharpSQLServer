using System;
using System.Collections.Generic;

namespace VideojuegosCRUD.Models;

public partial class Empresa
{
    public int IdEmpresa { get; set; }

    public string? NombreEmpresa { get; set; }

    public DateTime? Fundacion { get; set; }

    public string? SitioWeb { get; set; }

    public string? PaisOrigen { get; set; }

    public virtual ICollection<Contrato> Contratos { get; } = new List<Contrato>();
}
