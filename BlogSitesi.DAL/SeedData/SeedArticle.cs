using BlogSitesi.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitesi.DAL.SeedData
{
    public class SeedArticle : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(

                new Article { Id = 1, MVCBlogSitesiProjesiUserId= "8ab919e4-833e-4989-ae76-752ddd541cf6", CategoryId=1, Title= "Mantık Konusu", Content= "Terim\r\nBir bilim dahnda, gunluk konuşmaların dışında ozel bir anlama sahip olan kelimelerin her birine o bilim dalına ait bir terim denir.\r\n\r\nÖnerme\r\nDogru ya da yanlış, kesin bir hukum bildiren ifadelere onerme denir.\r\n\r\nDenk Önerme\r\nÖrnek:\r\n\r\np:\"Bir hafta yedi gündür\"\r\n\r\nq: \"6: 3 = 2\" önermeleri denk önermeler midir? Neden?", PublishDate=DateTime.Now },
               new Article { Id = 2, MVCBlogSitesiProjesiUserId = "8ab919e4-833e-4989-ae76-752ddd541cf6", CategoryId = 2, Title = "Temel Kavramlar", Content = "A. Rakam\r\nSayıları ifade etmeye yarayan sembollere, rakam denir. Onluk sayma sisteminde kullanılan rakamlar: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 dur.\r\n\r\nB. Sayı\r\nBir çokluk belirtecek şeklide, rakamların bir araya getirilmesiyle oluşan ifadelere, sayı denir.", PublishDate = DateTime.Now },
              new Article { Id = 3, MVCBlogSitesiProjesiUserId = "8ab919e4-833e-4989-ae76-752ddd541cf6", CategoryId = 3, Title = "Sayı Basamakları", Content = "Sayı Basamakları Konusu\r\nSayı Basamakları\r\nBir doğal sayının tabanına göre aldığı değere basamak değeri ve o sayının her basamağını oluşturan rakamlara da basamak denir.\r\n\r\n(abcde)n  sayısında \"n\" değeri sayı tabanı ve a, b, c, d, e sayı basamakları olmak üzere;\r\n\r\na, b, c, d, e basamaklarının n sayısına göre aldığı değerlere basamak değeri denir", PublishDate = DateTime.Now } 
                );
        }
    }
}
