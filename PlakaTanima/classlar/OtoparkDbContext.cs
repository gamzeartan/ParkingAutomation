using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PlakaTanima.classlar
{
    class OtoparkDbContext: DbContext
    {
        public DbSet<Marka> TBLMarka { get; set; }

        public DbSet<Seri> TBLSeri { get; set; }

        public DbSet<AracParkBilgileri> TBLAracParkBilgileri { get; set; }

        public DbSet<AracParkYerleri> TBLAracParkYerleri { get; set; }

        public DbSet<Satis> TBLSatis { get; set; }

        public DbSet<Musteri> TBLMusteri { get; set; }

        public DbSet<Kullanici> TBLKullanici { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
