using System;
using System.Collections.Generic;

namespace VideojuegosCRUD.Models;

public partial class Plataforma
{
    public int IdPlataforma { get; set; }

    public string? NombrePlataforma { get; set; }

    public string? Fabricante { get; set; }

    public int? IdVideojuego { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual Videojuego? IdVideojuegoNavigation { get; set; }
}
