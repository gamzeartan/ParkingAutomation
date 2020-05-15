using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlakaTanima.classlar
{
    class Kullanici
    {

        public int KullaniciID { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string KullaniciAdi { get; set; }

        [Column(TypeName = "varchar")]
        public string Sifre { get; set; }
    }
}
