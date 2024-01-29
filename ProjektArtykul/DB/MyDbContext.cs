using Microsoft.EntityFrameworkCore;
using DB.Entities;

namespace DB;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
       : base(options)
    {

    }
    public DbSet<Article> Articles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Coments> Coments { get; set; }
    public DbSet<Marks> Marks { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ArticleTags> ArticleTags { get; set; }
    public DbSet<ArticleSections> ArticleSections { get; set; }
    public DbSet<ArticleParagraph> ArticleParagraphs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Article>()
            .ToTable("Articles");
        modelBuilder.Entity<Article>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Article>()
            .Property(p => p.Id)
            .UseIdentityColumn(seed: 1, increment: 1);

        modelBuilder.Entity<User>()
           .ToTable("Users");
        modelBuilder.Entity<User>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<User>()
            .Property(p => p.Id)
            .UseIdentityColumn(seed: 1, increment: 1);

        modelBuilder.Entity<Coments>()
          .ToTable("Coments");
        modelBuilder.Entity<Coments>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Coments>()
            .Property(p => p.Id)
            .UseIdentityColumn(seed: 1, increment: 1);

        modelBuilder.Entity<Marks>()
          .ToTable("Marks");
        modelBuilder.Entity<Marks>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Marks>()
            .Property(p => p.Id)
            .UseIdentityColumn(seed: 1, increment: 1);

        modelBuilder.Entity<Tag>()
          .ToTable("Tags");
        modelBuilder.Entity<Tag>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Tag>()
            .Property(p => p.Id)
            .UseIdentityColumn(seed: 1, increment: 1);

        modelBuilder.Entity<ArticleTags>()
          .ToTable("ArticleTags");
        modelBuilder.Entity<ArticleTags>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<ArticleTags>()
            .Property(p => p.Id)
            .UseIdentityColumn(seed: 1, increment: 1);

        modelBuilder.Entity<ArticleParagraph>()
          .ToTable("ArticleParagraphs");
        modelBuilder.Entity<ArticleParagraph>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<ArticleParagraph>()
            .Property(p => p.Id)
            .UseIdentityColumn(seed: 1, increment: 1);

        modelBuilder.Entity<ArticleSections>()
          .ToTable("ArticleSections");
        modelBuilder.Entity<ArticleSections>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<ArticleSections>()
            .Property(p => p.Id)
            .UseIdentityColumn(seed: 1, increment: 1);
    }


}