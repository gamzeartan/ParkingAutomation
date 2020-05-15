using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakaTanima.classlar
{
    class AracParkBilgileri
    {
        public int ID { get; set; }


        public int MusteriId { get; set; }

        [Column(TypeName = "varchar")]
        public string AdiSoyadi { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Telefon { get; set; }

        public int MarkaID { get; set; }

        public int SeriID { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Plaka { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(70)]
        public string Yil { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(70)]
        public string Renk { get; set; }


        public int ParkyeriID { get; set; }


        [Column(TypeName = "varchar")]
        public string Aciklama { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime GirisTarihi { get; set; }

        public virtual AracParkYerleri AracParkYerleri { get; set; }

        public virtual Marka Marka { get; set; }

        public virtual Seri Seri { get; set; }

    }
}
