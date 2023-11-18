using System;
using System.Collections.Generic;

namespace VideojuegosCRUD.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public decimal? Precio { get; set; }

    public DateTime? FechaVenta { get; set; }

    public virtual ICollection<Tienda> Tienda { get; } = new List<Tienda>();
}
