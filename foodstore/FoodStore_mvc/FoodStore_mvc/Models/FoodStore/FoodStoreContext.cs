using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FoodStore_mvc.Models.FoodStore
{
    public partial class FoodStoreContext : DbContext
    {
        public FoodStoreContext()
        {
        }

        public FoodStoreContext(DbContextOptions<FoodStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Building> Building { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductInvoice> ProductInvoice { get; set; }
        public virtual DbSet<ProductInvoiceWithQuantity> ProductInvoiceWithQuantity { get; set; }
        public virtual DbSet<ProductPurchaseOrder> ProductPurchaseOrder { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasKey(e => new { e.BuildingName, e.UnitNum })
                    .HasName("PK__Building__14E071A0CB93A857");

                entity.Property(e => e.BuildingName)
                    .HasColumnName("building_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UnitNum).HasColumnName("unit_num");

                entity.Property(e => e.Capacity).HasColumnName("capacity");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Branch)
                    .HasColumnName("branch")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.BranchNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Branch)
                    .HasConstraintName("FK__Employee__branch__4316F928");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceNum)
                    .HasName("PK__Invoice__F9EE1383938C89D4");

                entity.Property(e => e.InvoiceNum)
                    .HasColumnName("invoiceNum")
                    .ValueGeneratedNever();

                entity.Property(e => e.Branch)
                    .HasColumnName("branch")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.BranchNavigation)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.Branch)
                    .HasConstraintName("FK__Invoice__branch__31EC6D26");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasKey(e => e.Mfg)
                    .HasName("PK__Manufact__DF50190DF6A5C524");

                entity.Property(e => e.Mfg)
                    .HasColumnName("mfg")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.MfgDiscount)
                    .HasColumnName("mfgDiscount")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .HasColumnName("productID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Mfg)
                    .HasColumnName("mfg")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.Vendor)
                    .HasColumnName("vendor")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.MfgNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.Mfg)
                    .HasConstraintName("FK__Product__mfg__286302EC");

                entity.HasOne(d => d.VendorNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.Vendor)
                    .HasConstraintName("FK__Product__vendor__29572725");
            });

            modelBuilder.Entity<ProductInvoice>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.InvoiceNum })
                    .HasName("PK__ProductI__028E3072E4210938");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.InvoiceNum).HasColumnName("invoiceNum");

                entity.HasOne(d => d.InvoiceNumNavigation)
                    .WithMany(p => p.ProductInvoice)
                    .HasForeignKey(d => d.InvoiceNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductIn__invoi__35BCFE0A");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductInvoice)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductIn__produ__34C8D9D1");
            });

            modelBuilder.Entity<ProductInvoiceWithQuantity>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.InvoiceNum })
                    .HasName("PK__ProductI__028E3072658FC761");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.InvoiceNum).HasColumnName("invoiceNum");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.InvoiceNumNavigation)
                    .WithMany(p => p.ProductInvoiceWithQuantity)
                    .HasForeignKey(d => d.InvoiceNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductIn__invoi__398D8EEE");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductInvoiceWithQuantity)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductIn__produ__38996AB5");
            });

            modelBuilder.Entity<ProductPurchaseOrder>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.PoNum })
                    .HasName("PK__ProductP__6DEC0407F891FA0E");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.PoNum).HasColumnName("po_num");

                entity.HasOne(d => d.PoNumNavigation)
                    .WithMany(p => p.ProductPurchaseOrder)
                    .HasForeignKey(d => d.PoNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductPu__po_nu__403A8C7D");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPurchaseOrder)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductPu__produ__3F466844");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.PoNum)
                    .HasName("PK__Purchase__0FCD54D5F13621BE");

                entity.Property(e => e.PoNum)
                    .HasColumnName("po_num")
                    .ValueGeneratedNever();

                entity.Property(e => e.Branch)
                    .HasColumnName("branch")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.BranchNavigation)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.Branch)
                    .HasConstraintName("FK__PurchaseO__branc__3C69FB99");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Branch)
                    .HasName("PK__Store__1F8431240463D376");

                entity.Property(e => e.Branch)
                    .HasColumnName("branch")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BuildingName)
                    .HasColumnName("building_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .HasColumnName("region")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UnitNum).HasColumnName("unit_num");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => new { d.BuildingName, d.UnitNum })
                    .HasConstraintName("FK__Store__2F10007B");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Vendor)
                    .HasName("PK__Supplier__42A1EB1C928D5FA1");

                entity.Property(e => e.Vendor)
                    .HasColumnName("vendor")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.SupplierEmail)
                    .HasColumnName("supplier_email")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }
    }
}
