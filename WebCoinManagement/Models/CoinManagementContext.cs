namespace WebCoinManagement.Models {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CoinManagementContext : DbContext {
        public CoinManagementContext()
            : base("name=CoinManagementContext") {
        }

        public virtual DbSet<Coins> Coins { get; set; }
        public virtual DbSet<CoinsCategory> CoinsCategory { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Coins>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Coins>()
                .Property(e => e.CoinType)
                .IsUnicode(false);

            modelBuilder.Entity<Coins>()
                .Property(e => e.FacialValue)
                .IsUnicode(false);

            modelBuilder.Entity<Coins>()
                .Property(e => e.MarketValue)
                .IsUnicode(false);

            modelBuilder.Entity<Coins>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Coins>()
                .Property(e => e.CoinDate)
                .IsUnicode(false);

            modelBuilder.Entity<CoinsCategory>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<CoinsCategory>()
                .HasMany(e => e.Coins)
                .WithOptional(e => e.CoinsCategory)
                .HasForeignKey(e => e.CategoryID);

            modelBuilder.Entity<Users>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.UserRole)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Coins)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.CoinsCategory)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);
        }
    }
}
