using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogSitesi.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlogSitesi.DAL.Data;

// Add profile data for application users by adding properties to the MVCBlogSitesiProjesiUser class
public class MVCBlogSitesiPLUser : IdentityUser
{
    public string? NameSurname { get; set; }
    public string? Bio { get; set; }
    
    public string? PhotoUrl { get; set; }
    public virtual List<Article> Articles { get; set; }
}

