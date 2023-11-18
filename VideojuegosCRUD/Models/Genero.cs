using System;
using System.Collections.Generic;

namespace VideojuegosCRUD.Models;

public partial class Genero
{
    public int IdGenero { get; set; }

    public string? NombreGenero { get; set; }

    public int? IdVideojuego { get; set; }

    public int? IdClasificacion { get; set; }

    public virtual Clasificacion? IdClasificacionNavigation { get; set; }

    public virtual Videojuego? IdVideojuegoNavigation { get; set; }
}
