using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<GroupNewse> GroupNewses { get; set; }
        public DbSet<GroupProfile> GroupProfiles { get; set; }
        public DbSet<RequestGG> RequestGGs { get; set; }
        public DbSet<RequestGU> RequestGUs { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupType> GroupTypes { get; set; }
        public DbSet<MemberRole> MemberRoles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<WallOfUser> WallOfUsers { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserProfile>().HasRequired(x => x.User).WithOptional(x => x.UserProfile);

            modelBuilder.Entity<Group>().HasRequired(x => x.Administrator).WithOptional();
            modelBuilder.Entity<Group>().HasMany(x => x.Users).WithOptional().WillCascadeOnDelete(false);

            modelBuilder.Entity<GroupProfile>().HasRequired(x => x.Group).WithOptional(x => x.GroupProfile);

            
            modelBuilder.Entity<Country>().HasMany(x => x.GroupProfiles).WithOptional(x => x.Country).WillCascadeOnDelete(false);
            
            modelBuilder.Entity<Region>().HasMany(x => x.GroupProfiles).WithOptional(x => x.Region).WillCascadeOnDelete(false);
            
            modelBuilder.Entity<City>().HasMany(x => x.GroupProfiles).WithOptional(x => x.City).WillCascadeOnDelete(false);

            modelBuilder.Entity<RequestGG>().HasRequired(x => x.GroupFrom).WithMany(x => x.RequestGGs).WillCascadeOnDelete(false);

            modelBuilder.Entity<City>().HasRequired(x => x.Country).WithMany(x => x.Cities).HasForeignKey(x => x.CountryId).WillCascadeOnDelete(false);
            modelBuilder.Entity<City>().HasRequired(x => x.Region).WithMany(x => x.Cities).HasForeignKey(x => x.RegionId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Region>().HasRequired(x => x.Country).WithMany(x => x.Regions).HasForeignKey(x => x.CountryId).WillCascadeOnDelete(false);



        }
    }
}