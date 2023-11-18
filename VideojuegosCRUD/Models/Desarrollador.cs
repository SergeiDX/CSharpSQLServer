using System;
using System.Collections.Generic;

namespace VideojuegosCRUD.Models;

public partial class Desarrollador
{
    public int IdDesarrollador { get; set; }

    public string? NombreDesarrollador { get; set; }

    public DateTime? Fundacion { get; set; }

    public string? PaisOrigen { get; set; }

    public string? SitioWeb { get; set; }

    public virtual ICollection<Contrato> Contratos { get; } = new List<Contrato>();

    public virtual ICollection<Videojuego> Videojuegos { get; } = new List<Videojuego>();
}
