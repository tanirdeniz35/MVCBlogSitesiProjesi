 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlogSitesi.DAL.Entities;
using BlogSitesi.DAL.Enums;
using BlogSitesi.DAL.StaticMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCBlogSitesiProjesi.Data;
using BlogSitesi.DAL.Data;
namespace BlogSitesi.DAL.SeedData
{
    public class SeedAdminKullanici : IEntityTypeConfiguration<MVCBlogSitesiPLUser>
    {
        public void Configure(EntityTypeBuilder<MVCBlogSitesiPLUser> builder)
        {
            builder.HasData(
                new MVCBlogSitesiPLUser() { Id= "8ab919e4-833e-4989-ae76-752ddd541cf6", Email="admin@matematik.com", ConcurrencyStamp = "8ab919e4-833e-4989-ae76-752ddd541cf6", EmailConfirmed=true, UserName= "admin@matematik.com", NameSurname="Deneme Kullanıcı", Bio="Deneme Bio" }
         
                
                );
           
        }
    }
}
