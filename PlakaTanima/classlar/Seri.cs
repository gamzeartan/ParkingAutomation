using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakaTanima.classlar
{
    class Seri

    {
        public int ID { get; set; }

        public int MarkaID { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(70)]
        public string seri { get; set; }
        public virtual Marka marka { get; set; }

        public virtual ICollection<AracParkBilgileri> AracParkBilgileri { get; set; }




    }
}
