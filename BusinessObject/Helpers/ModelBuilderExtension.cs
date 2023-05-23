using BusinessObject.Object;
using Microsoft.EntityFrameworkCore;
using System;

namespace BusinessObject.Helpers
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Seed Customer
            modelBuilder.Entity<Customer>().HasData(
                    new Customer
                    {
                        Id = "1",
                        Fullname = "Kaiz Nguyen",
                        Birthday = DateTime.Parse("04/02/2001").ToString("dd/MM/yyyy"),
                        Male = true,
                        PhoneNumber = "0396384095",
                        Email = "kaizph@gmail.com",
                        Points = 8,
                        TypeId = "1",
                    },
                    new Customer
                    {
                        Id = "2",
                        Fullname = "Chau NT",
                        Birthday = DateTime.Parse("08/02/1997").ToString("dd/MM/yyyy"),
                        Male = false,
                        PhoneNumber = "0793786216",
                        Email = "chaunt@gmail.com",
                        Points = 9,
                        TypeId = "2"
                    }
                );
            #endregion

            #region Seed Type of Customer
            modelBuilder.Entity<TypeCustomer>().HasData(
                    new TypeCustomer
                    {
                        Id = "1",
                        Name = "VIP"
                    },
                    new TypeCustomer
                    {
                        Id = "2",
                        Name = "Gold"
                    },
                    new TypeCustomer
                    {
                        Id = "3",
                        Name = "Diamond"
                    },
                    new TypeCustomer
                    {
                        Id = "4",
                        Name = "Newbie"
                    }
                );
            #endregion
        }

        public static void SetUp(this ModelBuilder modelBuilder)
        {
            // set table
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<TypeCustomer>().ToTable("TypeCustomers");

            // set key with fluentAPI
            modelBuilder.Entity<Customer>().HasKey(c => new { c.Id });
            modelBuilder.Entity<TypeCustomer>().HasKey(t => new { t.Id });

            #region Configuration to props
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(10)
                    .IsRequired();

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasMaxLength(10)
                    .IsRequired();

                entity.Property(e => e.Male)
                    .HasColumnName("male")
                    .IsRequired();

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(150)
                    .IsRequired();

                entity.Property(e => e.Points)
                    .HasColumnName("points")
                    .IsRequired();
            });

            // Type of Customer
            modelBuilder.Entity<TypeCustomer>(e =>
            {
                e.Property(e => e.Name).IsRequired().HasMaxLength(50);
            });
            #endregion
        }
    }
}
