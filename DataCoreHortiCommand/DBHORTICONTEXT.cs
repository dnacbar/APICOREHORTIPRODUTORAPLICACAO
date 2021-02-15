using DOMAINCOREHORTICOMMAND;
using Microsoft.EntityFrameworkCore;

namespace DATACOREHORTICOMMAND
{
    public partial class DBHORTICONTEXT : DbContext
    {
        public DBHORTICONTEXT(DbContextOptions<DBHORTICONTEXT> options) : base(options) { }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Producer> Producer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<Userhorti> Userhorti { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IdCity);

                entity.ToTable("CITY");

                entity.Property(e => e.IdCity)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_CITY");

                entity.Property(e => e.CdCity)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CD_CITY");

                entity.Property(e => e.DsCity)
                    .HasMaxLength(200)
                    .HasColumnName("DS_CITY");

                entity.Property(e => e.IdCountry)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ID_COUNTRY");

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
                    .HasMaxLength(40)
                    .HasColumnName("DS_EMAIL");

                entity.Property(e => e.DsAddress)
                    .HasMaxLength(50)
                    .HasColumnName("DS_ADDRESS");

                entity.Property(e => e.DsClient)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("DS_CLIENT");

                entity.Property(e => e.DsComplement)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("DS_COMPLEMENT");

                entity.Property(e => e.DsFederalInscription)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("DS_FEDERALINSCRIPTION");

                entity.Property(e => e.DsNumber)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("DS_NUMBER");

                entity.Property(e => e.DsPhone)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("DS_PHONE");

                entity.Property(e => e.DsZip)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DS_ZIP")
                    .IsFixedLength(true);

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
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ID_COUNTRY");

                entity.Property(e => e.DsCountry)
                    .HasMaxLength(200)
                    .HasColumnName("DS_COUNTRY");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.IdDistrict);

                entity.ToTable("DISTRICT");

                entity.Property(e => e.IdDistrict)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_DISTRICT");

                entity.Property(e => e.DsDistrict)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DS_DISTRICT");

                entity.Property(e => e.DtAtualization)
                    .HasPrecision(3)
                    .HasColumnName("DT_ATUALIZATION")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtCreation)
                    .HasPrecision(3)
                    .HasColumnName("DT_CREATION")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.HasKey(e => new { e.IdProducer, e.DsEmail });

                entity.ToTable("PRODUCER");

                entity.Property(e => e.IdProducer).HasColumnName("ID_PRODUCER");

                entity.Property(e => e.DsEmail)
                    .HasMaxLength(40)
                    .HasColumnName("DS_EMAIL");

                entity.Property(e => e.DsAddress)
                    .HasMaxLength(50)
                    .HasColumnName("DS_ADDRESS");

                entity.Property(e => e.DsComplement)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("DS_COMPLEMENT");

                entity.Property(e => e.DsDescription).HasColumnName("DS_DESCRIPTION");

                entity.Property(e => e.DsFantasyname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DS_FANTASYNAME");

                entity.Property(e => e.DsFederalInscription)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("DS_FEDERALINSCRIPTION");

                entity.Property(e => e.DsMunicipalInscription)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("DS_MUNICIPALINSCRIPTION");

                entity.Property(e => e.DsNumber)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("DS_NUMBER");

                entity.Property(e => e.DsPhone)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("DS_PHONE");

                entity.Property(e => e.DsProducer)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("DS_PRODUCER");

                entity.Property(e => e.DsStateInscription)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("DS_STATEINSCRIPTION");

                entity.Property(e => e.DsZip)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DS_ZIP")
                    .IsFixedLength(true);

                entity.Property(e => e.IdCity).HasColumnName("ID_CITY");

                entity.Property(e => e.IdDistrict).HasColumnName("ID_DISTRICT");

                entity.HasOne(d => d.DsEmailNavigation)
                    .WithMany(p => p.Producer)
                    .HasForeignKey(d => d.DsEmail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCER_USERHORTI");

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.Producer)
                    .HasForeignKey(d => d.IdCity)
                    .HasConstraintName("FK_PRODUCER_CITY");

                entity.HasOne(d => d.IdDistrictNavigation)
                    .WithMany(p => p.Producer)
                    .HasForeignKey(d => d.IdDistrict)
                    .HasConstraintName("FK_PRODUCER_DISTRICT");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.ToTable("PRODUCT");

                entity.Property(e => e.IdProduct)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_PRODUCT");

                entity.Property(e => e.BoStock)
                    .IsRequired()
                    .HasColumnName("BO_STOCK")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DsProduct)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DS_PRODUCT");

                entity.Property(e => e.DtAtualization)
                    .HasPrecision(3)
                    .HasColumnName("DT_ATUALIZATION")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtCreation)
                    .HasPrecision(3)
                    .HasColumnName("DT_CREATION")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtDiscount)
                    .HasColumnType("date")
                    .HasColumnName("DT_DISCOUNT");

                entity.Property(e => e.IdUnit).HasColumnName("ID_UNIT");

                entity.Property(e => e.NmPercentDiscount).HasColumnName("NM_PERCENTDISCOUNT");

                entity.Property(e => e.NmValue)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("NM_VALUE");

                entity.HasOne(d => d.IdUnitNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdUnit)
                    .HasConstraintName("FK_PRODUCT_UNITY");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => new { e.IdCountry, e.IdState });

                entity.ToTable("STATE");

                entity.Property(e => e.IdCountry)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ID_COUNTRY");

                entity.Property(e => e.IdState).HasColumnName("ID_STATE");

                entity.Property(e => e.DsState)
                    .HasMaxLength(200)
                    .HasColumnName("DS_STATE");

                entity.Property(e => e.DsUf)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DS_UF");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasKey(e => e.IdUnit);

                entity.ToTable("UNIT");

                entity.Property(e => e.IdUnit)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_UNIT");

                entity.Property(e => e.DsAbreviation)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("DS_ABREVIATION");

                entity.Property(e => e.DsUnit)
                    .HasMaxLength(50)
                    .HasColumnName("DS_UNIT");

                entity.Property(e => e.DtAtualization)
                    .HasPrecision(3)
                    .HasColumnName("DT_ATUALIZATION")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtCreation)
                    .HasPrecision(3)
                    .HasColumnName("DT_CREATION")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Userhorti>(entity =>
            {
                entity.HasKey(e => e.DsLogin);

                entity.ToTable("USERHORTI");

                entity.Property(e => e.DsLogin)
                    .HasMaxLength(40)
                    .HasColumnName("DS_LOGIN");

                entity.Property(e => e.BoActive)
                    .IsRequired()
                    .HasColumnName("BO_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DsPassword)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("DS_PASSWORD");

                entity.Property(e => e.DtAtualization)
                    .HasPrecision(3)
                    .HasColumnName("DT_ATUALIZATION")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtCreation)
                    .HasPrecision(3)
                    .HasColumnName("DT_CREATION")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
