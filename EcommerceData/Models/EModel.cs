using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceData.Models
{
    public class EModel:IdentityDbContext
    {

        /*
         to be added: size,Model,trigger for stock
             */
        public EModel(DbContextOptions<EModel>options) : base(options)
        {

        }
        public virtual DbSet<Category> Categories { get; set; }
        //public virtual DbSet<ChallanDetail? ChallanDetails { get; set; }
        //public virtual DbSet<ChallanMaster? ChallanMasters { get; set; }
        //public virtual DbSet<DeliveryInfo? DeliveryInfoes { get; set; }
        public virtual DbSet<CompanyInfo> CompanyInfoes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<PayMethod> PayMethods { get; set; }
        public virtual DbSet<PrdImage> PrdImages { get; set; }
        public virtual DbSet<Product>Products { get; set; }
        public virtual DbSet<ProductsOffer>  ProductsOffers { get; set; }
        public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual DbSet<PurchaseMaster> PurchaseMasters { get; set; }
        public virtual DbSet<SalesDetail> SalesDetails { get; set; }
        public virtual DbSet<SalesMaster> SalesMasters { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<StockDetail> StockDetails { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        //public virtual DbSet<sysdiagram? sysdiagrams { get; set; }
        public virtual DbSet<Thana> Thanas { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        //public virtual DbSet<User? Users { get; set; }
      //  public virtual DbSet<View_Purchase? View_Purchase { get; set; }
    }
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentID { get; set; }
        [ForeignKey("CompanyInfo")]
        [DefaultValue(1)]
        public int ComID { get; set; }
        public virtual CompanyInfo CompanyInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
        
    }
    public partial class CompanyInfo
    {
        public int Id { get; set; }
        public string companyName { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string cell { get; set; }
        public string EMail { get; set; }
        public string webaddress { get; set; }
        public string Telephone { get; set; }
        public byte[] logo { get; set; }
        public int ThanaID { get; set; }
        public int DisId { get; set; }
    }
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
          //  this.DeliveryInfoes = new HashSet<DeliveryInfo?();
            this.Orders = new HashSet<Order>();
            this.SalesMasters = new HashSet<SalesMaster>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string ContactPerson { get; set; }
        public string Mobile { get; set; }
        public string EntryBy { get; set; }
        public   System.DateTime? EntryDate { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string CompanyContact { get; set; }
        public string CompanyWebsite { get; set; }
        public   int? ThanaID { get; set; }
        public   int? DistId { get; set; }

        public virtual District District { get; set; }
        public virtual Thana Thana { get; set; }
        [ForeignKey("CompanyInfo")]
        public int ComID { get; set; }
        public virtual CompanyInfo CompanyInfo { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        // public virtual ICollection<DeliveryInfo? DeliveryInfoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesMaster> SalesMasters { get; set; }
    }
    public partial class District
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public District()
        {
            this.Customers = new HashSet<Customer>();
          //  this.DeliveryInfoes = new HashSet<DeliveryInfo?();
            this.Orders = new HashSet<Order>();
            this.Shippers = new HashSet<Shipper>();
            this.Suppliers = new HashSet<Supplier>();
            this.Thanas = new HashSet<Thana>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<DeliveryInfo? DeliveryInfoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipper> Shippers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplier> Suppliers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Thana> Thanas { get; set; }
    }

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string ShippingAdress { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public   int? ThanaId { get; set; }
        public   int? DistID { get; set; }
        public   int? PayMethodID { get; set; }
        public   int? ShipperID { get; set; }
        public string VoucherNo { get; set; }
        public   int? BillNo { get; set; }
        public string Types { get; set; }
        public string PaymentStatus { get; set; }
        public int DeliveryStatus { get; set; }
        public   int? CustomerID { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal Deliveryfee { get; set; }
        public   System.DateTime? DeliveryDate { get; set; }
        public   System.DateTime? ActualDel_date { get; set; }
        public string TransactionID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual District District { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual PayMethod PayMethod { get; set; }
        public virtual Shipper Shipper { get; set; }

        [ForeignKey("CompanyInfo")]
        [DefaultValue(1)]
        public int ComID { get; set; }
        public virtual CompanyInfo CompanyInfo { get; set; }
        public virtual Thana Thana { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int? Discountrate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Discountamount { get; set; }
        public   int? Vatrate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? Vatamount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? NetAmount { get; set; }
        public   int? OrderID { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? UnitPrice { get; set; }
        public   int? UnitQty { get; set; }
        public int PrdId { get; set; }
        [DefaultValue(1)]
        public int ComID { get; set; }
        public virtual Order Order { get; set; }
    }
    public partial class OrderStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderStatus()
        {
            this.Orders = new HashSet<Order>();
        }

        public int ID { get; set; }
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
    public partial class PayMethod
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PayMethod()
        {
           // this.DeliveryInfoes = new HashSet<DeliveryInfo?();
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string PayMethodName { get; set; }
        public string Desccription { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<DeliveryInfo? DeliveryInfoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }

    public partial class PrdImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string OriginalImagePath { get; set; }
        public string ThumbImagePath { get; set; }

        public virtual Product Product { get; set; }
    }

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.SalesDetails = new HashSet<SalesDetail>();
            this.PurchaseDetails = new HashSet<PurchaseDetail>();
        }

        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
        public string EntryBy { get; set; }
        public System.DateTime EntryDate { get; set; }
        public int Reorderlevel { get; set; }
        public string UnitName { get; set; }
        public int CatID { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [DisplayName("SalesPrice")]
        public decimal SalesPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DisRate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DisAmount { get; set; }
        public   int? FreeId { get; set; }
        public int UnitId { get; set; }
        public string ProductDescription { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? VatRate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? VatAmount { get; set; }
        public   int? Qtyinbox { get; set; }
        public string Boxunit { get; set; }
        //[0=Inactive,1=Active]
        //public int Status { get; set; }
        public virtual Category Category { get; set; }
        public virtual PrdImage PrdImage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }













        [ForeignKey("CompanyInfo")]
        public int ComID { get; set; }
        public virtual CompanyInfo CompanyInfo { get; set; }
    }
    public partial class ProductsOffer
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public   int? FreeOn { get; set; }
        public   int? FreQty { get; set; }
        public   System.DateTime? StartDate { get; set; }
        public   System.DateTime? EndDate { get; set; }
    }
    public partial class PurchaseDetail
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? Discountrate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? Discountamount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? Vatrate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? Vatamount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? NetAmount { get; set; }

        public   int? MasteriD { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? UnitPrice { get; set; }
        public   int? UnitQty { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? TotalPrice { get; set; }
        public   int? PrdId { get; set; }

        public virtual Product Product { get; set; }
        public virtual PurchaseMaster PurchaseMaster { get; set; }
    }

    public partial class PurchaseMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseMaster()
        {
            this.PurchaseDetails = new HashSet<PurchaseDetail>();
        }

        public int ID { get; set; }
        public   System.DateTime? PurchaseDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? TotalQuantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? TotalPrice { get; set; }
        public string VoucherNo { get; set; }
        public string BillNo { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? TDiscountrate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? TVatrate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? TDiscountamount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? TVatamount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? Paidamount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? Due { get; set; }
       
        public   int? SupplierId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? Convence { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? Packing { get; set; }
        public   string EntryBy { get; set; }
        public   System.DateTime? EntryDate { get; set; }
        public string Note { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? LaborCost { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? Netamount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        [ForeignKey("CompanyInfo")]
        public int ComID { get; set; }
        public virtual CompanyInfo CompanyInfo { get; set; }
    }

    public partial class SalesDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesDetail()
        {
          //  this.DeliveryInfoes = new HashSet<DeliveryInfo?();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public   int? Discountrate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? Discountamount { get; set; }
        public   int? Vatrate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? Vatamount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? NetAmount { get; set; }
        public   int? MasteriD { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? UnitPrice { get; set; }
        public   int? UnitQty { get; set; }
        public   int? PrdId { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<DeliveryInfo? DeliveryInfoes { get; set; }
        public virtual Product Product { get; set; }
        public virtual SalesMaster SalesMaster { get; set; }
    }

    public partial class SalesMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesMaster()
        {
            this.SalesDetails = new HashSet<SalesDetail>();
        }

        public int ID { get; set; }
        public   System.DateTime? SalesDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? TotalQuantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? TotalPrice { get; set; }
        public string VoucherNo { get; set; }
        public long BillNo { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? TDiscountrate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? TVatrate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? TDiscountamount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? TVatamount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? Paidamount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? Due { get; set; }
        public   int? CustomerId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? Convence { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? Packing { get; set; }
        public   string EntryBy { get; set; }
        public   System.DateTime? EntryDate { get; set; }
        public string Note { get; set; }

        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("CompanyInfo")]
        public int ComID { get; set; }
        public virtual CompanyInfo CompanyInfo { get; set; }
    }

    public partial class Shipper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shipper()
        {
           // this.DeliveryInfoes = new HashSet<DeliveryInfo?();
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Tnt { get; set; }
        public string website { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public   int? ThanaId { get; set; }
        public   int? DistID { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<DeliveryInfo? DeliveryInfoes { get; set; }
        public virtual District District { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        public virtual Thana Thana { get; set; }
        [ForeignKey("CompanyInfo")]
        public int ComID { get; set; }
        public virtual CompanyInfo CompanyInfo { get; set; }
    }
    public partial class Stock
    {
        public int ID { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? Price { get; set; }
        public string ProductCode { get; set; }
        public string UnitName { get; set; }
        [ForeignKey("CompanyInfo")]
        public int ComID { get; set; }
        public virtual CompanyInfo CompanyInfo { get; set; }
    }
    public partial class StockDetail
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public   System.DateTime? StockDate { get; set; }
        public   int? InQty { get; set; }
        public   int? Outqty { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public   decimal? StockPrice { get; set; }
        public   string EntryBy { get; set; }
        public   System.DateTime? EntryDate { get; set; }
        public   int? Balancedqty { get; set; }
        public string UnitName { get; set; }
        [ForeignKey("CompanyInfo")]
        public int ComID { get; set; }
        public virtual CompanyInfo CompanyInfo { get; set; }
    }
    public partial class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string ContactPerson { get; set; }
        public string Mobile { get; set; }
        public   string EntryBy { get; set; }
        public   System.DateTime? EntryDate { get; set; }
        public   int? ThanaId { get; set; }
        public   int? DistID { get; set; }

        public virtual District District { get; set; }
        public virtual Thana Thana { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("CompanyInfo")]
        public int ComID { get; set; }
        public virtual CompanyInfo CompanyInfo { get; set; }
    }
    public partial class Thana
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thana()
        {
            this.Customers = new HashSet<Customer>();
        //    this.DeliveryInfoes = new HashSet<DeliveryInfo?();
            this.Orders = new HashSet<Order>();
            this.Shippers = new HashSet<Shipper>();
            this.Suppliers = new HashSet<Supplier>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public   int? DistId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<DeliveryInfo? DeliveryInfoes { get; set; }
        public virtual District District { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipper> Shippers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }

    public partial class Unit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Unit()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Products = new HashSet<Product>();
            this.SalesMasters = new HashSet<SalesMaster>();
            this.Suppliers = new HashSet<Supplier>();
        }

        public int ID { get; set; }
        public string Username { get; set; }
        public string UPassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesMaster> SalesMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
    public partial class View_Purchase
    {
        public string Code { get; set; }
      
        public   decimal? Discountrate { get; set; }
       
        public   decimal? Discountamount { get; set; }
        public   decimal? Vatrate { get; set; }
        public   decimal? TDiscountrate { get; set; }
        public   decimal? Vatamount { get; set; }
        public   decimal? NetAmount { get; set; }
        public   decimal? UnitPrice { get; set; }
        public   int? UnitQty { get; set; }
        public   System.DateTime? PurchaseDate { get; set; }
        public   decimal? TotalQuantity { get; set; }
        public   decimal? TotalPrice { get; set; }
        public string VoucherNo { get; set; }
        public string BillNo { get; set; }
        public   decimal? TVatrate { get; set; }
        public   decimal? TDiscountamount { get; set; }
        public   decimal? TVatamount { get; set; }
        public   decimal? Paidamount { get; set; }
        public   decimal? Due { get; set; }
        public   int? SupplierId { get; set; }
        public   decimal? Convence { get; set; }
        public   decimal? Packing { get; set; }
        public  string EntryBy { get; set; }
        public   System.DateTime? EntryDate { get; set; }
        public string Note { get; set; }
        public   int? MasteriD { get; set; }
        public   decimal? LaborCost { get; set; }
        public   decimal? Expr1 { get; set; }
        public   decimal? Expr2 { get; set; }
    }
}
