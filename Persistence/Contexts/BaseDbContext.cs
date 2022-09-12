using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<LanguageTechnology> LanguageTechnologies { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(
                    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("KodlamaIoDevConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(e =>
            {
                e.ToTable("ProgrammingLanguages").HasKey(l => l.Id);
                e.Property(l => l.Id).HasColumnName("Id");
                e.Property(l => l.Name).HasColumnName("Name");
                e.HasMany(l => l.LanguageTechnologies);
            });

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("Users").HasKey(u => u.Id);
                e.Property(u => u.Id).HasColumnName("Id");
                e.Property(u => u.FirstName).HasColumnName("FirstName");
                e.Property(u => u.LastName).HasColumnName("LastName");
                e.Property(u => u.Email).HasColumnName("Email");
                e.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt");
                e.Property(u => u.PasswordHash).HasColumnName("PasswordHash");
                e.Property(u => u.Status).HasColumnName("Status");
                e.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType");
                e.HasMany(u => u.UserOperationClaims);
                e.HasMany(u => u.RefreshTokens);

            });

            modelBuilder.Entity<OperationClaim>(e =>
            {
                e.ToTable("OperationClaims").HasKey(c => c.Id);
                e.Property(c => c.Id).HasColumnName("Id");
                e.Property(c => c.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(e =>
            {
                e.ToTable("UserOperationClaims").HasKey(c => c.Id);
                e.Property(c => c.Id).HasColumnName("Id");
                e.Property(c => c.UserId).HasColumnName("UserId");
                e.Property(c => c.OperationClaimId).HasColumnName("OperationClaimId");
                e.HasOne(c => c.User);
                e.HasOne(c => c.OperationClaim);
            });

            modelBuilder.Entity<RefreshToken>(e =>
            {
                e.ToTable("RefreshTokens").HasKey(t => t.Id);
                e.Property(t => t.Id).HasColumnName("Id");
                e.Property(t => t.UserId).HasColumnName("UserId");
                e.Property(t => t.Expires).HasColumnName("Expires");
                e.Property(t => t.Created).HasColumnName("Created");
                e.Property(t => t.Revoked).HasColumnName("Revoked");
                e.Property(t => t.RevokedByIp).HasColumnName("RevokedByIp");
                e.Property(t => t.ReplacedByToken).HasColumnName("ReplacedByToken");
                e.Property(t => t.ReasonRevoked).HasColumnName("ReasonRevoked");
                e.HasOne(t => t.User); 
            });

            modelBuilder.Entity<LanguageTechnology>(e =>
            {
                e.ToTable("LanguageTechnologies").HasKey(t => t.Id);
                e.Property(t => t.Id).HasColumnName("Id");
                e.Property(t => t.Name).HasColumnName("Name");
                e.Property(t => t.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                e.HasOne(t => t.ProgrammingLanguage);
            });

            modelBuilder.Entity<UserInformation>(e =>
            {
                e.ToTable("UserInformations").HasKey(t => t.Id);
                e.Property(t => t.Id).HasColumnName("Id");
                e.Property(t => t.UserId).HasColumnName("UserId");
                e.Property(t => t.GithubAddress).HasColumnName("GithubAddress");
            });
        }
    }
}
