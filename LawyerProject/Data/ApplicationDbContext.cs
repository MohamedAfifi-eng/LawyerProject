using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace LawyerProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<AdministrativeWork> AdministrativeWorks { get; set; }
        public DbSet<AdministrativeWorkKind> administrativeWorkKinds { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<CaseClient> CaseClients { get; set; }
        public DbSet<CaseEnemy> CaseEnemies { get; set; }
        public DbSet<CaseKind> CaseKinds { get; set; }
        public DbSet<CaseSubKind> CaseSubKinds { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<CourtKind> CourtKinds { get; set; }
        public DbSet<Dayra> Dayras { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<MaktabTawseek> MaktabTawseeks { get; set; }
        public DbSet<Nyaba> Nyabas { get; set; }
        public DbSet<NyabaKind> NyabaKinds { get; set; }
        public DbSet<Tawkeel> Tawkeels { get; set; }
        public DbSet<TawkeelClients> TawkeelClients { get; set; }
        public DbSet<DocumentKind> DocumentKinds { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}