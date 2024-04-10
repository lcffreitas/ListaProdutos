using ListaProdutos.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaProdutos.Infra.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .IsRequired();
            builder.Property(p => p.Price)
                .IsRequired();
            builder.Property(p => p.Stock)
                .IsRequired();
            builder.Property(p => p.ExpirationDate)
                .IsRequired();
            builder.Property(p => p.Category)
                .IsRequired();
        }
    }
}
