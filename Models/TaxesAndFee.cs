using System;
using System.Collections.Generic;

namespace pizza_shop_MVC.Models;

public partial class TaxesAndFee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal? FlatAmount { get; set; }

    public decimal? Percentage { get; set; }

    public bool? Isactive { get; set; }

    public bool? Isdefault { get; set; }

    public decimal? Taxvalue { get; set; }

    public bool? IsDeleted { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<OrderTaxMapping> OrderTaxMappings { get; } = new List<OrderTaxMapping>();
}
