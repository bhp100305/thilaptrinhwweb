using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BuiHuyPhu_231230867_de02.Models;

public partial class BuiiHuyPhu231230867De02Context : DbContext
{
    public BuiiHuyPhu231230867De02Context()
    {
    }

    public BuiiHuyPhu231230867De02Context(DbContextOptions<BuiiHuyPhu231230867De02Context> options)
        : base(options)
    {
    }

    public virtual DbSet<BhpCatalog> BhpCatalogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=BuiiHuyPhu_231230867_de02;uid=sa;pwd=HuyPhu@999; MultipleActiveResultSets=True; TrustServerCertificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BhpCatalog>(entity =>
        {
            entity.HasKey(e => e.HvtId).HasName("PK__BhpCatal__65251A3A3F2E4FDA");

            entity.ToTable("BhpCatalog");

            entity.Property(e => e.HvtId).HasColumnName("hvtId");
            entity.Property(e => e.HvtCateActive).HasColumnName("hvtCateActive");
            entity.Property(e => e.HvtCateName)
                .HasMaxLength(100)
                .HasColumnName("hvtCateName");
            entity.Property(e => e.HvtCatePrice).HasColumnName("hvtCatePrice");
            entity.Property(e => e.HvtCateQty).HasColumnName("hvtCateQty");
            entity.Property(e => e.HvtPicture)
                .HasMaxLength(255)
                .HasColumnName("hvtPicture");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
