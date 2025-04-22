using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlogSitesi.DAL.Entities;
using BlogSitesi.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitesi.DAL.SeedData
{
    public class SeedCategory : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(

                new Category { Id = 1, Name = "Mantık" },
                  new Category { Id = 2, Name = "Temel Kavramlar" },
                  new Category { Id = 3, Name = "Sayı Basamakları" },
                  new Category { Id = 4, Name = "Kümeler" },
                 new Category { Id = 5, Name = "Bölme Bölünebilme" },
           new Category { Id = 6, Name = "Basit Eşitsizlikler" },
        new Category { Id = 7, Name = "Rasyonel Sayılar" }
                ); 
        }
    }
}
