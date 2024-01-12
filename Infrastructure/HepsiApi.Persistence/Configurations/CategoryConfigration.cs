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
    public class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category category1 = new()
            {
                ID=1,
                Name="Elektrik",
                Priorty=1,
                ParentID=0,
                IsDeleted=false,
                CreatedDate=DateTime.Now,
                
            };
            Category category2 = new()
            {
                ID = 2,
                Name = "Moda",
                Priorty = 2,
                ParentID = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now,

            };

            Category parent1 = new()
            {
                ID = 3,
                Name = "Bilgisayar",
                Priorty = 1,
                ParentID = 1,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };
            Category parent2 = new()
            {
                ID = 4,
                Name = "Kadın",
                Priorty = 1,
                ParentID = 2,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };
            builder.HasData(category1, category2, parent1, parent2);
        }
    }
}
