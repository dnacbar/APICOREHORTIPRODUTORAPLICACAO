using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Z_DATAHORTI.EF_SCAFOLD
{
    public partial class HORTICONTEXT : DbContext
    {
        public HORTICONTEXT()
        {
        }

        public HORTICONTEXT(DbContextOptions<HORTICONTEXT> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Producer> Producer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<Userhorti> Userhorti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => new { e.IdClient, e.DsEmail });

                entity.ToTable("CLIENT");

                entity.Property(e => e.IdClient).HasColumnName("ID_CLIENT");

                entity.Property(e => e.DsEmail)
                    .HasColumnName("DS_EMAIL")
                    .HasMaxLength(40);

                entity.Property(e => e.BoActive)
                    .IsRequired()
                    .HasColumnName("BO_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DsClient)
                    .IsRequired()
                    .HasColumnName("DS_CLIENT")
                    .HasMaxLength(100);

                entity.Property(e => e.DsFederalinscription)
                    .HasColumnName("DS_FEDERALINSCRIPTION")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.DsPhone)
                    .HasColumnName("DS_PHONE")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DtAtualization)
                    .HasColumnName("DT_ATUALIZATION")
                    .HasColumnType("datetime2(3)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtCreation)
                    .HasColumnName("DT_CREATION")
                    .HasColumnType("datetime2(3)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCity).HasColumnName("ID_CITY");

                entity.Property(e => e.IdDistrict).HasColumnName("ID_DISTRICT");

                entity.HasOne(d => d.DsEmailNavigation)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.DsEmail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENT_USERHORTI");

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.IdCity)
                    .HasConstraintName("FK_CLIENT_CITY");

                entity.HasOne(d => d.IdDistrictNavigation)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.IdDistrict)
                    .HasConstraintName("FK_CLIENT_DISTRICT");
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

                entity.Property(e => e.DsDistrict)
                    .HasColumnName("DS_DISTRICT")
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

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.IdLog);

                entity.ToTable("LOG");

                entity.Property(e => e.IdLog)
                    .HasColumnName("ID_LOG")
                    .ValueGeneratedNever();

                entity.Property(e => e.CdLevellog)
                    .IsRequired()
                    .HasColumnName("CD_LEVELLOG")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DsInfolog)
                    .IsRequired()
                    .HasColumnName("DS_INFOLOG")
                    .IsUnicode(false);

                entity.Property(e => e.DsUserlog)
                    .IsRequired()
                    .HasColumnName("DS_USERLOG")
                    .HasMaxLength(50);

                entity.Property(e => e.DtCreation)
                    .HasColumnName("DT_CREATION")
                    .HasColumnType("datetime2(3)")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.HasKey(e => new { e.IdProducer, e.DsEmail });

                entity.ToTable("PRODUCER");

                entity.Property(e => e.IdProducer).HasColumnName("ID_PRODUCER");

                entity.Property(e => e.DsEmail)
                    .HasColumnName("DS_EMAIL")
                    .HasMaxLength(40);

                entity.Property(e => e.BoActive)
                    .IsRequired()
                    .HasColumnName("BO_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DsAddress)
                    .HasColumnName("DS_ADDRESS")
                    .HasMaxLength(50);

                entity.Property(e => e.DsComplement)
                    .HasColumnName("DS_COMPLEMENT")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DsDescription).HasColumnName("DS_DESCRIPTION");

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

                entity.Property(e => e.DsNumber)
                    .HasColumnName("DS_NUMBER")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DsPhone)
                    .HasColumnName("DS_PHONE")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DsProducer)
                    .IsRequired()
                    .HasColumnName("DS_PRODUCER")
                    .HasMaxLength(100);

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

                entity.Property(e => e.DtCreation)
                    .HasColumnName("DT_CREATION")
                    .HasColumnType("datetime2(3)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCity).HasColumnName("ID_CITY");

                entity.Property(e => e.IdDistrict).HasColumnName("ID_DISTRICT");

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.Producer)
                    .HasForeignKey(d => d.IdCity)
                    .HasConstraintName("FK_PRODUCER_CITY");
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

                entity.Property(e => e.DsProduct)
                    .HasColumnName("DS_PRODUCT")
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

                entity.Property(e => e.IdUnit).HasColumnName("ID_UNIT");

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

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasKey(e => e.IdUnit);

                entity.ToTable("UNIT");

                entity.Property(e => e.IdUnit)
                    .HasColumnName("ID_UNIT")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DsAbreviation)
                    .HasColumnName("DS_ABREVIATION")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.DsUnit)
                    .HasColumnName("DS_UNIT")
                    .HasMaxLength(50);

                entity.Property(e => e.DtAtualization)
                    .HasColumnName("DT_ATUALIZATION")
                    .HasColumnType("datetime2(3)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtCreation)
                    .HasColumnName("DT_CREATION")
                    .HasColumnType("datetime2(3)")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Userhorti>(entity =>
            {
                entity.HasKey(e => e.DsLogin);

                entity.ToTable("USERHORTI");

                entity.Property(e => e.DsLogin)
                    .HasColumnName("DS_LOGIN")
                    .HasMaxLength(40);

                entity.Property(e => e.BoActive)
                    .IsRequired()
                    .HasColumnName("BO_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DsPassword)
                    .IsRequired()
                    .HasColumnName("DS_PASSWORD")
                    .HasMaxLength(100);

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
