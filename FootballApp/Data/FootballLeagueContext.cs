using Microsoft.EntityFrameworkCore;
using FootballApp.Models;

public class FootballLeagueContext : DbContext
{
    public FootballLeagueContext(DbContextOptions<FootballLeagueContext> options) : base(options) { }

    public DbSet<Druzyna> Druzyny { get; set; }
    public DbSet<Zawodnik> Zawodnicy { get; set; }
    public DbSet<Mecz> Mecze { get; set; }
    public DbSet<StatystykiZawodnika> StatystykiZawodnikow { get; set; }
    public DbSet<User> Users { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 

      
        modelBuilder.Entity<Mecz>()
            .HasOne(m => m.DruzynaDomowa)
            .WithMany(d => d.MeczeDomowe)
            .HasForeignKey(m => m.DruzynaDomowaId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Mecz>()
            .HasOne(m => m.DruzynaGości)
            .WithMany(d => d.MeczeGości)
            .HasForeignKey(m => m.DruzynaGościId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Zawodnik>()
            .HasOne(z => z.Druzyna)
            .WithMany(d => d.Zawodnicy)
            .HasForeignKey(z => z.DruzynaId)
            .OnDelete(DeleteBehavior.SetNull); 

        modelBuilder.Entity<StatystykiZawodnika>()
            .HasOne(s => s.Zawodnik)
            .WithOne(z => z.Statystyki)
            .HasForeignKey<StatystykiZawodnika>(s => s.ZawodnikId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}