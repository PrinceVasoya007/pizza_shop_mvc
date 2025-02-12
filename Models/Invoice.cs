using System;
using System.Collections.Generic;

namespace pizza_shop_MVC.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ModifierId { get; set; }

    public int? Quantityofmodifier { get; set; }

    public decimal? Rateofmodifier { get; set; }

    public decimal? Totalamount { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual Modifier Modifier { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();
}
