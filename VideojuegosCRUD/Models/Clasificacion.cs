using System;
using System.Collections.Generic;

namespace VideojuegosCRUD.Models;

public partial class Clasificacion
{
    public int IdClasificacion { get; set; }

    public string? Clasificacion1 { get; set; }

    public string? TipoClasificacion { get; set; }

    public virtual ICollection<Genero> Generos { get; } = new List<Genero>();
}
