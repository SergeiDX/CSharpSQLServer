using System;
using System.Collections.Generic;

namespace VideojuegosCRUD.Models;

public partial class Videojuego
{
    public int IdVideojuego { get; set; }

    public string? TituloVideojuego { get; set; }

    public DateTime? Lanzamiento { get; set; }

    public int? IdDesarrollador { get; set; }

    public virtual ICollection<Genero> Generos { get; } = new List<Genero>();

    public virtual Desarrollador? IdDesarrolladorNavigation { get; set; }

    public virtual ICollection<Plataforma> Plataformas { get; } = new List<Plataforma>();

    public virtual ICollection<Tienda> Tienda { get; } = new List<Tienda>();
}
