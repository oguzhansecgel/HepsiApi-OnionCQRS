using HepsiApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Persistence.Configurations
{
    public class ProductCategoryConfigration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => new { x.ProductID, x.CategoryID });
            builder.HasOne(p => p.Product).WithMany(pc => pc.ProductCategories).HasForeignKey(x => x.ProductID).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Category).WithMany(pc => pc.ProductCategories).HasForeignKey(c => c.CategoryID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
