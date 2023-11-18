using System;
using System.Collections.Generic;

namespace VideojuegosCRUD.Models;

public partial class Tienda
{
    public int IdTienda { get; set; }

    public string? NombreTienda { get; set; }

    public int? IdVideojuego { get; set; }

    public int? IdVenta { get; set; }

    public virtual Venta? IdVentaNavigation { get; set; }

    public virtual Videojuego? IdVideojuegoNavigation { get; set; }
}
