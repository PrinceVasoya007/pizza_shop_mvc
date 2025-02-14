using System;
using System.Collections.Generic;

namespace pizza_shop_MVC.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public int? CreatedBy { get; set; }

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
