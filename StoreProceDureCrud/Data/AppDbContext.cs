using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreProceDureCrud.Areas.ProfileArea.Models;
using StoreProceDureCrud.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace StoreProceDureCrud.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        internal object tblName;

        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor _httpContextAccessor) : base(options)
        {
            this._httpContextAccessor = _httpContextAccessor;
        }

     
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Hobby> Hobbies { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<FavouriteHobby> FavouriteHobbies { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<ProfileViewModel> ProfileViewModels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<ProfileViewModel>();
        }
    }
}
