using System;
using System.Collections.Generic;

namespace VideojuegosCRUD.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Username { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<Plataforma> Plataformas { get; } = new List<Plataforma>();
}
