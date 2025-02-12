using System;
using System.Collections.Generic;

namespace pizza_shop_MVC.Models;

public partial class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int OrderNo { get; set; }

    public int[]? Orderstatus { get; set; }

    public decimal? Totalamount { get; set; }

    public decimal? Tax { get; set; }

    public decimal? SubTotal { get; set; }

    public decimal? Discount { get; set; }

    public decimal? PaidAmount { get; set; }

    public string? Notes { get; set; }

    public bool? IsSgstSelected { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<OrderTaxMapping> OrderTaxMappings { get; } = new List<OrderTaxMapping>();

    public virtual ICollection<OrderedItem> OrderedItems { get; } = new List<OrderedItem>();
}
