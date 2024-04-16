using Duende.IdentityServer.EntityFramework.Options;
using FinanceApp.Server.Models;
using FinanceApp.Server.Models.DailyOpenClose;
using FinanceApp.Server.Models.Logo;
using FinanceApp.Server.Models.News;
using FinanceApp.Server.Models.StockChartData;
using FinanceApp.Server.Models.TickerDetails;
using FinanceApp.Server.Models.Tickers;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FinanceApp.Server.Data;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public ApplicationDbContext(
        DbContextOptions options,
        IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
    {
    }

    public DbSet<TickerResults> Results => Set<TickerResults>();
    public DbSet<TickerListItem> TickerListItems => Set<TickerListItem>();
    public DbSet<Logo> Logos => Set<Logo>();
    public DbSet<DailyOpenClose> DailyOpenCloses => Set<DailyOpenClose>();
    public DbSet<StockChartData> StockChartData => Set<StockChartData>();
    public DbSet<NewsResult> NewsResults => Set<NewsResult>();
    public DbSet<NewsImage> NewsImages => Set<NewsImage>();
    public DbSet<Publisher> Publishers => Set<Publisher>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Address>(e => { e.HasKey(a => a.Address1); });

        builder.Entity<Branding>(e => { e.HasKey(b => b.LogoUrl); });

        builder.Entity<TickerResults>(e =>
        {
            e.HasKey(tr => tr.Ticker);
            e.Property(tr => tr.Ticker).HasMaxLength(4);
            e.ToTable("TickerResults");

            e.HasMany(td => td.ApplicationUsers)
                .WithMany(td => td.TickerWatchlist)
                .UsingEntity(j => j.ToTable("ApplicationUserTickerResults"));

            e.HasOne(tr => tr.Logo)
                .WithOne(l => l.TickerResults)
                .HasForeignKey<Logo>(l => l.Ticker);

            e.HasMany(tr => tr.DailyOpenCloses)
                .WithOne(doc => doc.TickerResults)
                .HasForeignKey(doc => doc.Ticker);

            e.HasMany(tr => tr.StockChartData)
                .WithOne(scd => scd.TickerResults)
                .HasForeignKey(scd => scd.Ticker);

            e.HasMany(tr => tr.NewsResults)
                .WithMany(nr => nr.TickerResults)
                .UsingEntity(j => j.ToTable("NewsResultTickerResults"));
        });

        builder.Entity<TickerListItem>(e =>
        {
            e.HasKey(tli => tli.Ticker);
            e.ToTable("TickerListItem");
        });

        builder.Entity<Logo>(e =>
        {
            e.HasKey(l => l.Ticker);
            e.ToTable("Logo");
        });

        builder.Entity<DailyOpenClose>(e =>
        {
            e.HasKey(doc => new { doc.Ticker, doc.From });
            e.Property(doc => doc.Ticker).HasMaxLength(4);
            e.ToTable("DailyOpenClose");
        });

        builder.Entity<StockChartData>(e =>
        {
            e.HasKey(scd => new { scd.Ticker, scd.Timespan, scd.Multiplier, scd.QueryDate, scd.Date });
            e.Property(scd => scd.Timespan).HasMaxLength(15);
            e.Property(scd => scd.Volume).HasPrecision(20, 0);
            e.ToTable("StockChartData");
        });

        builder.Entity<NewsResult>(e =>
        {
            e.HasKey(nr => nr.IdNews);
            e.HasOne(nr => nr.NewsImage)
                .WithOne(ni => ni.NewsResult)
                .HasForeignKey<NewsImage>(ni => ni.IdNews);
            e.ToTable("NewsResult");
        });

        builder.Entity<NewsImage>(e =>
        {
            e.HasKey(ni => ni.IdNews);
            e.ToTable("NewsImage");
        });

        builder.Entity<Publisher>(e =>
        {
            e.HasKey(p => p.Name);
            e.HasMany(p => p.NewsResults)
                .WithOne(nr => nr.Publisher)
                .HasForeignKey(nr => nr.PublisherName);
            e.ToTable("Publisher");
        });
    }
}