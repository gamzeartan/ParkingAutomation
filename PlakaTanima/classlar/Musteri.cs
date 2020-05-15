using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakaTanima.classlar
{
    class Musteri
    {
       // [Column(TypeName = "varchar")]
        public int ID { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string  AdiSoyadi { get; set; }

        [Column(TypeName = "varchar")]
        public string Telefon { get; set; }

        [Column(TypeName = "varchar")]
        public string Email { get; set; }


        [Column(TypeName = "datetime2")]
        public DateTime Tarih { get; set; }
     



    }
}
