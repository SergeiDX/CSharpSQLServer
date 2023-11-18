using System;
using System.Collections.Generic;

namespace VideojuegosCRUD.Models;

public partial class Contrato
{
    public int IdContrato { get; set; }

    public string? DescripcionContrato { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaLimite { get; set; }

    public int? IdDesarrollador { get; set; }

    public int? IdEmpresa { get; set; }

    public virtual Desarrollador? IdDesarrolladorNavigation { get; set; }

    public virtual Empresa? IdEmpresaNavigation { get; set; }
}
