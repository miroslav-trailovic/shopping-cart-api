using Microsoft.EntityFrameworkCore;
using ShoppingCart.DataModel;
using System;

namespace ShoppingCart.Repositories
{
    public class ShoppingCartContext : DbContext
    {
        public DbSet<PromotionCode> PromotionCode { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<CartItem> CartItem { get; set; }

        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PromotionCode>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.UserName)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price)
                    .IsRequired();

                entity.HasOne(d => d.PromotionCode)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.PromotionCodeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Article_PromotionCode");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.Property(e => e.Quantity).IsRequired();

                entity.Property(e => e.DateCreated)
                    .IsRequired()
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CartItem_Article");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CartItem_Customer");
            });
        }
    }
}
