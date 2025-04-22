using BlogSitesi.DAL.Data;
using BlogSitesi.DAL.Entities;
using BlogSitesi.DAL.Entities.Common;
using BlogSitesi.DAL.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
 
using System.Reflection.Emit;

namespace MVCBlogSitesiProjesi.Data;

public class MVCBlogSitesiPLContext : IdentityDbContext<MVCBlogSitesiPLUser>
{
    public DbSet<Article> Articles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public MVCBlogSitesiPLContext(DbContextOptions<MVCBlogSitesiPLContext> options)
      : base(options)
    {
    }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new SeedAdminKullanici());
        builder.ApplyConfiguration(new SeedCategory());
        builder.ApplyConfiguration(new SeedArticle());
    }

    public override int SaveChanges()
    {

        var datas = ChangeTracker
           .Entries<BaseEntity>();
        foreach (var data in datas)
        {
            var entity = data.Entity;
            var entityType = entity.GetType();
            switch (data.State)
            {
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Deleted:
                    data.State = EntityState.Modified;
                    entity.SilmeTarihi = DateTime.Now;
                    entity.SilindiMi = true;
                    break;

                case EntityState.Modified:
                    entity.GuncellemeTarihi = DateTime.Now;
                    break;
                case EntityState.Added:
                    entity.KayitTarihi = DateTime.Now;
                    break;
                default:
                    break;
            }

        }

        return base.SaveChanges();
    }
}
