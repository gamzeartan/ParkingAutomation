using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakaTanima.classlar
{
    class AracParkYerleri
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(70)]
        public string ParkYerleri { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(70)]
        public string Durumu { get; set; }

        public virtual ICollection<AracParkBilgileri> AracParkBilgileri { get; set; }
    }
}
