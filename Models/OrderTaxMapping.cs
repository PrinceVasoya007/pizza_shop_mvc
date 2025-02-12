using System;
using System.Collections.Generic;

namespace pizza_shop_MVC.Models;

public partial class OrderTaxMapping
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int TaxId { get; set; }

    public int Noofperson { get; set; }

    public bool? IsDeleted { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual TaxesAndFee Tax { get; set; } = null!;
}
