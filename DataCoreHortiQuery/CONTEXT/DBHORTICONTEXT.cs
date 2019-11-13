using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataCoreHortiQuery.CONTEXT
{
    public partial class DBHORTICONTEXT : DbContext
    {
        public DBHORTICONTEXT(DbContextOptions<DBHORTICONTEXT> options) : base(options) { }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Producer> Producer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Unity> Unity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IdCity);

                entity.ToTable("CITY");

                entity.Property(e => e.IdCity)
                    .HasColumnName("ID_CITY")
                    .ValueGeneratedNever();

                entity.Property(e => e.CdCity)
                    .HasColumnName("CD_CITY")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DsCity)
                    .HasColumnName("DS_CITY")
                    .HasMaxLength(200);

                entity.Property(e => e.IdCountry)
                    .IsRequired()
                    .HasColumnName("ID_COUNTRY")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IdState).HasColumnName("ID_STATE");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => new { d.IdCountry, d.IdState })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CITY_STATE");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.IdCountry);

                entity.ToTable("COUNTRY");

                entity.Property(e => e.IdCountry)
                    .HasColumnName("ID_COUNTRY")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DsCountry)
                    .HasColumnName("DS_COUNTRY")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.IdDistrict);

                entity.ToTable("DISTRICT");

                entity.Property(e => e.IdDistrict)
                    .HasColumnName("ID_DISTRICT")
                    .ValueGeneratedNever();

                entity.Property(e => e.BoActive)
                    .IsRequired()
                    .HasColumnName("BO_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DsName)
                    .HasColumnName("DS_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DtAtualization)
                    .HasColumnName("DT_ATUALIZATION")
                    .HasColumnType("datetime2(3)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtCreation)
                    .HasColumnName("DT_CREATION")
                    .HasColumnType("datetime2(3)")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.HasKey(e => e.IdProducer);

                entity.ToTable("PRODUCER");

                entity.Property(e => e.IdProducer)
                    .HasColumnName("ID_PRODUCER")
                    .ValueGeneratedNever();

                entity.Property(e => e.BoActive)
                    .IsRequired()
                    .HasColumnName("BO_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CdCity).HasColumnName("CD_CITY");

                entity.Property(e => e.CdDistrict).HasColumnName("CD_DISTRICT");

                entity.Property(e => e.DsAdress)
                    .HasColumnName("DS_ADRESS")
                    .HasMaxLength(50);

                entity.Property(e => e.DsComplement)
                    .HasColumnName("DS_COMPLEMENT")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DsDescription).HasColumnName("DS_DESCRIPTION");

                entity.Property(e => e.DsEmail)
                    .HasColumnName("DS_EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DsFantasyname)
                    .HasColumnName("DS_FANTASYNAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DsFederalinscription)
                    .HasColumnName("DS_FEDERALINSCRIPTION")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.DsMunicipalinscription)
                    .HasColumnName("DS_MUNICIPALINSCRIPTION")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DsName)
                    .IsRequired()
                    .HasColumnName("DS_NAME")
                    .HasMaxLength(100);

                entity.Property(e => e.DsNumber)
                    .HasColumnName("DS_NUMBER")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DsPhone)
                    .HasColumnName("DS_PHONE")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DsStateinscription)
                    .HasColumnName("DS_STATEINSCRIPTION")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.DsZip)
                    .HasColumnName("DS_ZIP")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DtAtualization)
                    .HasColumnName("DT_ATUALIZATION")
                    .HasColumnType("datetime2(3)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtBirth)
                    .HasColumnName("DT_BIRTH")
                    .HasColumnType("date");

                entity.Property(e => e.DtCreation)
                    .HasColumnName("DT_CREATION")
                    .HasColumnType("datetime2(3)")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CdCityNavigation)
                    .WithMany(p => p.Producer)
                    .HasForeignKey(d => d.CdCity)
                    .HasConstraintName("FK_PRODUCER_CITY");

                entity.HasOne(d => d.CdDistrictNavigation)
                    .WithMany(p => p.Producer)
                    .HasForeignKey(d => d.CdDistrict)
                    .HasConstraintName("FK_PRODUCER_DISTRICT");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.ToTable("PRODUCT");

                entity.Property(e => e.IdProduct)
                    .HasColumnName("ID_PRODUCT")
                    .ValueGeneratedNever();

                entity.Property(e => e.BoActive)
                    .IsRequired()
                    .HasColumnName("BO_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BoStock)
                    .IsRequired()
                    .HasColumnName("BO_STOCK")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CdUnity).HasColumnName("CD_UNITY");

                entity.Property(e => e.DsName)
                    .HasColumnName("DS_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DtAtualization)
                    .HasColumnName("DT_ATUALIZATION")
                    .HasColumnType("datetime2(3)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtCreation)
                    .HasColumnName("DT_CREATION")
                    .HasColumnType("datetime2(3)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtDiscount)
                    .HasColumnName("DT_DISCOUNT")
                    .HasColumnType("date");

                entity.Property(e => e.NmDiscount).HasColumnName("NM_DISCOUNT");

                entity.Property(e => e.NmValue)
                    .HasColumnName("NM_VALUE")
                    .HasColumnType("decimal(12, 2)");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => new { e.IdCountry, e.IdState });

                entity.ToTable("STATE");

                entity.Property(e => e.IdCountry)
                    .HasColumnName("ID_COUNTRY")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IdState).HasColumnName("ID_STATE");

                entity.Property(e => e.DsState)
                    .HasColumnName("DS_STATE")
                    .HasMaxLength(200);

                entity.Property(e => e.DsUf)
                    .HasColumnName("DS_UF")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Unity>(entity =>
            {
                entity.HasKey(e => e.IdUnity);

                entity.ToTable("UNITY");

                entity.Property(e => e.IdUnity)
                    .HasColumnName("ID_UNITY")
                    .ValueGeneratedNever();

                entity.Property(e => e.BoActive)
                    .IsRequired()
                    .HasColumnName("BO_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DsName)
                    .HasColumnName("DS_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.DsUnity)
                    .HasColumnName("DS_UNITY")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.DtAtualization)
                    .HasColumnName("DT_ATUALIZATION")
                    .HasColumnType("datetime2(3)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtCreation)
                    .HasColumnName("DT_CREATION")
                    .HasColumnType("datetime2(3)")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
