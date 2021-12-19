using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class kargo
    {
        [Key]
        public int kargodetid { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(300)]
        public string kargodetail { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string kargono { get; set; }

        [Column(TypeName ="VarChar")]
        [StringLength(50)]
        public string kargorec { get; set; }

        public string customermail { get; set; }
        public virtual customer customer { get; set; }

        public string customerid { get; set; }
        public virtual customer customere { get; set; }

        public DateTime kargodate { get; set; }

        public bool available { get; set; }

        public ICollection<salemove> salemoves { get; set; }
    }
}