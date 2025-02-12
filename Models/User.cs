using System;
using System.Collections.Generic;

namespace pizza_shop_MVC.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public int RoleId { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string Username { get; set; } = null!;

    public long? Phone { get; set; }

    public string? Profileimage { get; set; }

    public string? Zipcode { get; set; }

    public string? Address { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public bool? IsActive { get; set; }

    public int CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public int CountryId { get; set; }

    public int StateId { get; set; }

    public int CityId { get; set; }

    public virtual ICollection<Account> AccountCreatedByNavigations { get; } = new List<Account>();

    public virtual ICollection<Account> AccountModifiedByNavigations { get; } = new List<Account>();

    public virtual City City { get; set; } = null!;

    public virtual ICollection<City> CityCreatedByNavigations { get; } = new List<City>();

    public virtual ICollection<City> CityModifiedByNavigations { get; } = new List<City>();

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Country> CountryCreatedByNavigations { get; } = new List<Country>();

    public virtual ICollection<Country> CountryModifiedByNavigations { get; } = new List<Country>();

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Customer> CustomerCreatedByNavigations { get; } = new List<Customer>();

    public virtual ICollection<Customer> CustomerModifiedByNavigations { get; } = new List<Customer>();

    public virtual ICollection<Feedback> FeedbackCreatedByNavigations { get; } = new List<Feedback>();

    public virtual ICollection<Feedback> FeedbackModifiedByNavigations { get; } = new List<Feedback>();

    public virtual ICollection<User> InverseCreatedByNavigation { get; } = new List<User>();

    public virtual ICollection<User> InverseModifiedByNavigation { get; } = new List<User>();

    public virtual ICollection<Invoice> InvoiceCreatedByNavigations { get; } = new List<Invoice>();

    public virtual ICollection<Invoice> InvoiceModifiedByNavigations { get; } = new List<Invoice>();

    public virtual ICollection<MappingMenuItemWithModifier> MappingMenuItemWithModifierCreatedByNavigations { get; } = new List<MappingMenuItemWithModifier>();

    public virtual ICollection<MappingMenuItemWithModifier> MappingMenuItemWithModifierModifiedByNavigations { get; } = new List<MappingMenuItemWithModifier>();

    public virtual ICollection<MenuCategory> MenuCategoryCreatedByNavigations { get; } = new List<MenuCategory>();

    public virtual ICollection<MenuCategory> MenuCategoryModifiedByNavigations { get; } = new List<MenuCategory>();

    public virtual ICollection<MenuItem> MenuItemCreatedByNavigations { get; } = new List<MenuItem>();

    public virtual ICollection<MenuItem> MenuItemModifiedByNavigations { get; } = new List<MenuItem>();

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<Modifier> ModifierCreatedByNavigations { get; } = new List<Modifier>();

    public virtual ICollection<ModifierGroup> ModifierGroupCreatedByNavigations { get; } = new List<ModifierGroup>();

    public virtual ICollection<ModifierGroup> ModifierGroupModifiedByNavigations { get; } = new List<ModifierGroup>();

    public virtual ICollection<Modifier> ModifierModifiedByNavigations { get; } = new List<Modifier>();

    public virtual ICollection<Order> OrderCreatedByNavigations { get; } = new List<Order>();

    public virtual ICollection<Order> OrderModifiedByNavigations { get; } = new List<Order>();

    public virtual ICollection<OrderTaxMapping> OrderTaxMappingCreatedByNavigations { get; } = new List<OrderTaxMapping>();

    public virtual ICollection<OrderTaxMapping> OrderTaxMappingModifiedByNavigations { get; } = new List<OrderTaxMapping>();

    public virtual ICollection<OrderedItem> OrderedItemCreatedByNavigations { get; } = new List<OrderedItem>();

    public virtual ICollection<OrderedItem> OrderedItemModifiedByNavigations { get; } = new List<OrderedItem>();

    public virtual ICollection<OrderedItemModifierMapping> OrderedItemModifierMappingCreatedByNavigations { get; } = new List<OrderedItemModifierMapping>();

    public virtual ICollection<OrderedItemModifierMapping> OrderedItemModifierMappingModifiedByNavigations { get; } = new List<OrderedItemModifierMapping>();

    public virtual ICollection<Payment> PaymentCreatedByNavigations { get; } = new List<Payment>();

    public virtual ICollection<Payment> PaymentModifiedByNavigations { get; } = new List<Payment>();

    public virtual ICollection<Permission> PermissionCreatedByNavigations { get; } = new List<Permission>();

    public virtual ICollection<Permission> PermissionModifiedByNavigations { get; } = new List<Permission>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Role> RoleCreatedByNavigations { get; } = new List<Role>();

    public virtual ICollection<Role> RoleModifiedByNavigations { get; } = new List<Role>();

    public virtual ICollection<RolePermission> RolePermissionCreatedByNavigations { get; } = new List<RolePermission>();

    public virtual ICollection<RolePermission> RolePermissionModifiedByNavigations { get; } = new List<RolePermission>();

    public virtual ICollection<RolePermission> RolePermissionPermissions { get; } = new List<RolePermission>();

    public virtual ICollection<RolePermission> RolePermissionRoles { get; } = new List<RolePermission>();

    public virtual ICollection<Section> SectionCreatedByNavigations { get; } = new List<Section>();

    public virtual ICollection<Section> SectionModifiedByNavigations { get; } = new List<Section>();

    public virtual State State { get; set; } = null!;

    public virtual ICollection<State> StateCreatedByNavigations { get; } = new List<State>();

    public virtual ICollection<State> StateModifiedByNavigations { get; } = new List<State>();

    public virtual ICollection<Table> TableCreatedByNavigations { get; } = new List<Table>();

    public virtual ICollection<Table> TableModifiedByNavigations { get; } = new List<Table>();

    public virtual ICollection<TaxesAndFee> TaxesAndFeeCreatedByNavigations { get; } = new List<TaxesAndFee>();

    public virtual ICollection<TaxesAndFee> TaxesAndFeeModifiedByNavigations { get; } = new List<TaxesAndFee>();

    public virtual ICollection<Unit> Units { get; } = new List<Unit>();

    public virtual ICollection<WaitingToken> WaitingTokenCreatedByNavigations { get; } = new List<WaitingToken>();

    public virtual ICollection<WaitingToken> WaitingTokenModifiedByNavigations { get; } = new List<WaitingToken>();
}
